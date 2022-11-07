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
        DisplayName = "مرحله بررسی تایید درخواست",
        Category = "مرحله تایید کاربری بر اساس دسترسی",
        Description = "این نوع از وضعیت بر اساس ارسال رخدادها بوسیله کاربر نظیر تایید، رد یا بازگشت ایجاد میشود",
        Outcomes = new string[0]
    )]
    public class PermissionAwareUserTask : UserTask
    {
        private readonly LoanContext _businessContext;

        [ActivityInput(Hint = "عنوان رسمی مرحله در چرخه تایید", Label = "عنوان رسمی")]
        public string FormalName { get; set; }
        [ActivityInput(Hint = "دسترسی نقشها در این مرحله", Label = "دسترسی نقشها", UIHint = "role-permission-editor", Category = "دسترسیها")]
        public string Permissions { get; set; }

        [ActivityInput(Hint = "وضعیت کلی تایید آیتم در این مرحله از چرخه",
            Label = "وضعیت تایید",
            UIHint = ActivityInputUIHints.Dropdown,
            OptionsProvider = typeof(WorkflowAcceptanceStatusOptionsProvider),
           DefaultValue = "processing"
           )]
        [DefaultValue("processing")]
        public string AcceptanceStatusInThisState { get; set; }
        //[ActivityInput(Hint = "تنظیمات رخدادهای این مرحله", Label = "تنظیمات رخدادها",UIHint = "actions-settings-editor"))]
        //public string ActionSettings { get; set; }

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
