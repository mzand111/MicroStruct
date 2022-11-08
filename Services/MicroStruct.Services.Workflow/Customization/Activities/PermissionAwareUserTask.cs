using Elsa.Activities.UserTask.Activities;
using Elsa.ActivityResults;
using Elsa.Attributes;
using Elsa.Design;
using Elsa.Metadata;
using Elsa.Serialization;
using Elsa.Services.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using MicroStruct.Services.WorkflowApi.Data;
using MicroStruct.Services.WorkflowApi.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.ComponentModel;
using System.Reflection;

namespace MicroStruct.Services.WorkflowApi.Customization.Activities
{
    [Trigger(
        DisplayName = "Request Checking Step",
        Category = "Permission-Centric User Interaction Check Steps",
        Description = "With this kind of user task you can allow a user to accept/reject/turn back of the context object and also set other permissions due to the user roles",
        Outcomes = new string[0]
    )]
    public class PermissionAwareUserTask : UserTask
    {
        private readonly LoanContext _businessContext;

        [ActivityInput(Hint = "This name appears to the business context's reports", Label = "Formal Name")]
        public string FormalName { get; set; }
        [ActivityInput(Hint = "Role permissions in this step", Label = "Role Permissions", UIHint = "role-permission-editor", Category = "Permissions")]
        public string Permissions { get; set; }

        [ActivityInput(Hint = "The flow total acceptance state in this step",
            Label = "Acceptance State",
            UIHint = ActivityInputUIHints.Dropdown,
            OptionsProvider = typeof(WorkflowAcceptanceStatusOptionsProvider),
           DefaultValue = "processing"
           )]
        [DefaultValue("processing")]
        public string AcceptanceStatusInThisState { get; set; }
      
        public PermissionAwareUserTask(IContentSerializer serializer, IDbContextFactory<LoanContext> dbContextFactory) : base(serializer)
        {
            this._businessContext = dbContextFactory.CreateDbContext();
        }
        protected override bool OnCanExecute(ActivityExecutionContext context)
        {
            //var ff = _businessContext.LoanRequestPermissions.Count();            
            dynamic mz = JsonConvert.DeserializeObject(Permissions);

            return base.OnCanExecute(context);
        }
        protected override IActivityExecutionResult OnExecute(ActivityExecutionContext context)
        {
            Guid facilityRequestId;
            if (Guid.TryParse(context.ContextId, out facilityRequestId))
            {
                var previousPermissions = _businessContext.LoanRequestPermissions.AsQueryable().Where(x => x.LoanRequestLocalID == facilityRequestId).ToList();
                foreach (var item in previousPermissions)
                {
                    _businessContext.LoanRequestPermissions.Remove(item);
                }
                _businessContext.SaveChanges();
                Dictionary<string, List<string>> data = new Dictionary<string, List<string>>();
                JObject mz = JsonConvert.DeserializeObject<JObject>(Permissions);
                var g = Dyn2Dict(JsonConvert.DeserializeObject(Permissions));
                var roles = _businessContext.RoleLocals.ToList();
                var stateActions = _businessContext.StateActions.ToList();
                foreach (var role in roles)
                {
                    if (g.ContainsKey(role.Name))
                    {
                        var permittedActions = g[role.Name];
                        foreach (var action in permittedActions)
                        {
                            if (string.IsNullOrWhiteSpace(action)) continue;
                            LoanRequestPermission lrp = new LoanRequestPermission();
                            lrp.RoleLocalID = role.Id;
                            lrp.StateActionID = stateActions.FirstOrDefault(uu => uu.Name == action).Id;
                            lrp.LoanRequestLocalID = facilityRequestId;
                            _businessContext.LoanRequestPermissions.Add(lrp);
                        }
                    }
                }
                var facilityRequest = _businessContext.LoanRequestLocals.FirstOrDefault(x => x.Id == facilityRequestId);

                facilityRequest.CurrentActivityId = this.Id;
                facilityRequest.InThisStateFrom = DateTime.Now;

                facilityRequest.CurrentStep = this.Name;
                facilityRequest.CurrentStepFormalName = this.FormalName;
                facilityRequest.CurrentStepDescription = this.Description;
                facilityRequest.FacilityRequestTotalState = this.AcceptanceStatusInThisState;
               

                _businessContext.Entry(facilityRequest).State = EntityState.Modified;
                _businessContext.SaveChanges();
            }
            return base.OnExecute(context);
        }

        public Dictionary<string, List<string>> Dyn2Dict(dynamic dynObj)
        {
            var dictionary = new Dictionary<string, List<string>>();
            foreach (PropertyDescriptor propertyDescriptor in TypeDescriptor.GetProperties(dynObj))
            {
                List<string> obj = propertyDescriptor.GetValue(dynObj).ToObject<List<string>>();
                dictionary.Add(propertyDescriptor.Name, obj);
            }
            return dictionary;
        }
    }

    public class WorkflowAcceptanceStatusOptionsProvider : IActivityPropertyOptionsProvider
    {
        public object GetOptions(PropertyInfo property)
        {            
            return new List<SelectListItem>()
            {
               
               new SelectListItem(  "In Proccessing Flow","processing"),
               new SelectListItem( "Accepted","accepted"),
               new SelectListItem( "Rejected","rejected"),
            };
        }
    }
}
