using Elsa.Activities.Primitives;
using Elsa.Activities.Signaling.Services;
using Elsa.Models;
using Elsa.Persistence.Specifications;
using Elsa.Persistence;
using Elsa.Services.Models;
using Elsa.Services.Workflows;
using Elsa.Services.WorkflowStorage;
using Elsa.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MicroStruct.Services.WorkflowApi.Controllers.Base;
using System.Dynamic;
using MicroStruct.Services.WorkflowApi.Config;
using MicroStruct.Services.WorkflowApi.Data;
using MicroStruct.Services.WorkflowApi.Controllers.Dtos;
using MicroStruct.Services.WorkflowApi.Models;

namespace MicroStruct.Services.WorkflowApi.Controllers
{
 

    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class LoanAcceptanceFlowController : WorkflowBaseApiController
    {
        private readonly IWorkflowRegistry _workflowRegistry;
        private readonly WorkflowStarter _wfStarter;
        private readonly IWorkflowInstanceStore _instanceStore;
        private readonly IDbContextFactory<LoanContext> _dbContextFactoryFactory;
        private readonly IWorkflowTriggerInterruptor _wfTriggerInterruptor;
        private readonly IWorkflowLaunchpad _wfLaunchpad;
        private readonly ISignaler _signaler;
        private readonly IWorkflowStorageService _workflowStorageService;
        private readonly IOptions<FlowConfig> _facilityFlowConfig;

        public LoanAcceptanceFlowController(IWorkflowRegistry workflowRegistry,
            WorkflowStarter wfStarter,
            IWorkflowInstanceStore instanceStore,
            IDbContextFactory<LoanContext> dbContextFactoryFactory,
            IWorkflowTriggerInterruptor wfTriggerInterruptor,
            IWorkflowLaunchpad wfLaunchpad,
            ISignaler signaler,
            IWorkflowStorageService workflowStorageService,
            IOptions<FlowConfig> facilityFlowConfig)
        {
            _workflowRegistry = workflowRegistry;
            _wfStarter = wfStarter;
            _instanceStore = instanceStore;
            _dbContextFactoryFactory = dbContextFactoryFactory;
            _wfTriggerInterruptor = wfTriggerInterruptor;
            _wfLaunchpad = wfLaunchpad;
            _signaler = signaler;
            _workflowStorageService = workflowStorageService;
            _facilityFlowConfig = facilityFlowConfig;
        }

        [Authorize(Roles = "Admin,Customer")]
        [HttpPost("PostAndStartFacilityWF")]
        public async Task<IActionResult> PostAndStartFacilityWF(LoanRequestLocalDto facilityRequest)
        {
            if (!User.IsInRole("Admin"))
            {
                if (UserName != facilityRequest.CreatedBy)
                {
                    return Unauthorized("Not from same company");
                }
            }
            var contextDB = _dbContextFactoryFactory.CreateDbContext();
            LoanRequestLocal? req = await contextDB.LoanRequestLocals.FirstOrDefaultAsync(uu => uu.Id == facilityRequest.SUID);
            bool isNew = false;
            if (req == null)
            {
                isNew = true;
                req = new LoanRequestLocal();
                req.Id = facilityRequest.SUID;
                req.CreatedBy = UserName;
                req.CreationTime = DateTime.Now;
                req.CompanyNationalID = facilityRequest.CompanyNationalID;
                contextDB.LoanRequestLocals.Add(req);
            }
            req.DepartmentSUID = facilityRequest.DepartmentSUID;
            req.DirectDepartmentExpertUserName = facilityRequest.DirectDepartmentExpertUserName;
            req.ProgramTypeID = facilityRequest.ProgramTypeID;
            req.LastMidificationTime = DateTime.Now;
            req.LastModifiedBy = UserName;
            req.WorkflowStartDate = DateTime.Now;
            try
            {
                contextDB.SaveChanges();
            }
            catch (Exception ex)
            {
                throw;
            }
            if (!string.IsNullOrWhiteSpace(req.WorkflowInstanceId))
            {
                return BadRequest("The facility request workflow has been already started");
            }
            string defaultFlowName = _facilityFlowConfig.Value.DefaultAcceptanceFlowName;
            //var runWorkflowResult = await _workflowRegistry.ListAsync(CancellationToken.None);
            //var bluePrint = runWorkflowResult.FirstOrDefault(uu => uu.Name == "SimpleFlow" && uu.IsLatest);
            var bluePrint = await _workflowRegistry.FindByNameAsync(defaultFlowName, VersionOptions.Latest);
            if (bluePrint == null)
            {
                return BadRequest("Workflow defenition not found");
            }
            RunWorkflowResult workflowInstance = await _wfStarter.StartWorkflowAsync(bluePrint, null, null, null, facilityRequest.SUID.ToString());
            req.WorkflowInstanceId = workflowInstance.WorkflowInstance.Id;
            try
            {
                contextDB.SaveChanges();
            }
            catch (Exception ex)
            {
                throw;
            }
            return Ok(workflowInstance.WorkflowInstance.Id);
        }

        [HttpPost]
        [HttpGet]
        [Authorize(Roles = "Admin")]
        [Route("ResetFacilityRequestWF")]
        public async Task<IActionResult> ResetFacilityRequestWF(Guid facilityRequestSUID)
        {
            var contextDB = _dbContextFactoryFactory.CreateDbContext();
            try
            {
                LoanRequestLocal req = await contextDB.Set<LoanRequestLocal>().AsQueryable().FirstOrDefaultAsync(uu => uu.Id == facilityRequestSUID);

                if (req == null)
                {
                    return NotFound("Facility not found");
                }
                if (string.IsNullOrWhiteSpace(req.WorkflowInstanceId))
                {
                    return BadRequest("The facility has no workflow");
                }

                var wfInstanceDef = await _instanceStore.FindAsync(new EntityIdSpecification<WorkflowInstance>(req.WorkflowInstanceId));
                if (wfInstanceDef == null)
                {
                    return Problem("The facility workflow instance is set but not found");
                }
                await _instanceStore.DeleteAsync(wfInstanceDef);

                req.WorkflowInstanceId = null;
                req.Approved = false;
                req.WorkflowStartDate = null;
                req.CurrentStepFormalName = null;
                req.CurrentActivityId = null;
                req.InThisStateFrom = null;
                req.LastMidificationTime = DateTime.Now;
                req.LastModifiedBy = UserName;

                await contextDB.SaveChangesAsync();
                return Ok("Workflow reseted succsessfully for facility with id:" + facilityRequestSUID);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        //[HttpGet]
        //[Route("GetLoanCurrentStateAvailableSignals")]
        //public async Task<IActionResult> GetLoanCurrentStateAvailableSignals(Guid loanRequestID)
        //{
        //    var contextDB = _dbContextFactoryFactory.CreateDbContext();
        //    LoanRequestLocal req = await contextDB.Set<LoanRequestLocal>().AsQueryable().FirstOrDefaultAsync(uu => uu.Id == loanRequestID);
        //    if (req == null)
        //    {
        //        return NotFound("Loan not found");
        //    }
        //    if (string.IsNullOrWhiteSpace(req.WorkflowInstanceId))
        //    {
        //        return BadRequest("The loan workflow has not been started");
        //    }

        //    var wfInstanceDef = await _instanceStore.FindAsync(new EntityIdSpecification<WorkflowInstance>(req.WorkflowInstanceId));
        //    var currentActivityID = wfInstanceDef.BlockingActivities.FirstOrDefault().ActivityId;
        //    var commaSepActions = wfInstanceDef.ActivityData[currentActivityID]["Actions"];
        //    return Ok(commaSepActions);
        //}

        [HttpGet("GetFacilityRequestCurrentStateDetails")]
        public async Task<IActionResult> GetFacilityRequestCurrentStateDetails(Guid facilityRequestSUID)
        {
            var contextDB = _dbContextFactoryFactory.CreateDbContext();
            LoanRequestLocal req = await contextDB.Set<LoanRequestLocal>().AsQueryable().FirstOrDefaultAsync(uu => uu.Id == facilityRequestSUID);
            if (req == null)
            {
                return NotFound("Facility request not found");
            }
            if (string.IsNullOrWhiteSpace(req.WorkflowInstanceId))
            {
                return BadRequest("The facility request workflow has not been started");
            }

            var wfInstanceDef = await _instanceStore.FindAsync(new EntityIdSpecification<WorkflowInstance>(req.WorkflowInstanceId));
            if (wfInstanceDef.FinishedAt == null)
            {
                var currentActivityID = wfInstanceDef.BlockingActivities.FirstOrDefault().ActivityId;
                var currentState = wfInstanceDef.ActivityData[currentActivityID];

                var currentStatePermissions = contextDB.Set<LoanRequestPermission>().AsQueryable().Where(uu => uu.LoanRequestLocalID == facilityRequestSUID)
                    .Select(uu => new { uu.RoleLocalID, RoleName = uu.RoleLocal.Name, uu.StateActionID, StateActionName = uu.StateAction.Name }).ToList();

                req = await contextDB.Set<LoanRequestLocal>().AsQueryable().FirstOrDefaultAsync(uu => uu.Id == facilityRequestSUID);
                var bluePrint = await _workflowRegistry.FindAsync(wfInstanceDef.DefinitionId, VersionOptions.Latest);
                var currentActivity = bluePrint.Activities.FirstOrDefault(uu => uu.Id == currentActivityID);
                dynamic rtn = new ExpandoObject();
                rtn.availableActions = currentState.ContainsKey("Actions") ? currentState["Actions"] : "";
                rtn.currentActivityPermissions = currentStatePermissions;
                rtn.finishedAt = null;
                rtn.CurrentActivityId = currentActivityID;
                rtn.CurrentActivityName = currentActivity.Name;
                rtn.currentActivityFormalName = currentState.ContainsKey("FormalName") ? currentState["FormalName"] : "";
                rtn.currentActivityDescription = currentActivity.Description;
                rtn.facilityRequestTotalState = req.FacilityRequestTotalState;

                return Ok(rtn);
            }
            else
            {
                dynamic rtn = new ExpandoObject();
                rtn.availableActions = null;
                rtn.CurrentActivityId = null;
                rtn.CurrentActivityName = null;
                rtn.currentActivityFormalName = null;
                rtn.currentActivityDescription = null;
                rtn.currentActivityPermissions = null;
                rtn.finishedAt = wfInstanceDef.FinishedAt;
                rtn.facilityRequestTotalState = "";
                return Ok(rtn);
            }
        }

        [HttpPost("SendSignalToInstance")]
        public async Task<IActionResult> SendSignalToInstance(LoanRequestWorkflowCommandDto facilityRequestWorkflowCommand)
        {
            var contextDB = _dbContextFactoryFactory.CreateDbContext();
            LoanRequestLocal req = await contextDB.Set<LoanRequestLocal>().AsQueryable().FirstOrDefaultAsync(uu => uu.Id == facilityRequestWorkflowCommand.FacilityRequest.SUID);
            if (req == null)
            {
                return NotFound("Facility request not found");
            }
            if (string.IsNullOrWhiteSpace(req.WorkflowInstanceId))
            {
                return BadRequest("The facility request workflow has not been started");
            }
            #region check permission
            var ss = LoweredUserRoleNames.FirstOrDefault();
            if (ss == null)
            {
                return BadRequest("User Role not found");
            }
            var userRole = await contextDB.RoleLocals.FirstOrDefaultAsync(uu => uu.Name.ToLower() == ss);
            if (userRole == null)
            {
                return BadRequest("User Role not defined in db");
            }
            var stateAction = await contextDB.StateActions.FirstOrDefaultAsync(uu => uu.Name.ToLower() == facilityRequestWorkflowCommand.UserAction.ToLower());
            if (stateAction == null)
            {
                return BadRequest("State action not defined in db");
            }
            var roleStateAction = await contextDB.LoanRequestPermissions
                .FirstOrDefaultAsync(uu => uu.LoanRequestLocalID == req.Id &&
                                       uu.StateActionID == stateAction.Id &&
                                       uu.RoleLocalID == userRole.Id);
            if (roleStateAction == null)
            {
                return BadRequest("User has not permission to do this action in this step");
            }
            #endregion
            req.DepartmentSUID = facilityRequestWorkflowCommand.FacilityRequest.DepartmentSUID;
            req.DirectDepartmentExpertUserName = facilityRequestWorkflowCommand.FacilityRequest.DirectDepartmentExpertUserName;
            req.ProgramTypeID = facilityRequestWorkflowCommand.FacilityRequest.ProgramTypeID;

            await contextDB.SaveChangesAsync();

            var wfInstanceDef = await _instanceStore.FindAsync(new EntityIdSpecification<WorkflowInstance>(req.WorkflowInstanceId));
            var currentActivityId = wfInstanceDef.BlockingActivities.FirstOrDefault().ActivityId;
            var currentState = wfInstanceDef.ActivityData[currentActivityId];
            List<string?> availableActions = currentState.ContainsKey("Actions") ? (List<string?>)currentState["Actions"] : null;
            if (availableActions == null)
            {
                return Problem("No action defined for current step");
            }
            if (!availableActions.Contains(facilityRequestWorkflowCommand.UserAction))
            {
                return Problem("Action is not available");
            }
            await _workflowStorageService.UpdateInputAsync(wfInstanceDef, new WorkflowInput(facilityRequestWorkflowCommand.UserAction), default);
            var runres = await _wfTriggerInterruptor.InterruptActivityAsync(wfInstanceDef, currentActivityId, default);
            var wfInstanceDefAfter = await _instanceStore.FindAsync(new EntityIdSpecification<WorkflowInstance>(req.WorkflowInstanceId));
            if (wfInstanceDefAfter.FinishedAt == null)
            {
                var currentActivityIdAfter = wfInstanceDef.BlockingActivities.FirstOrDefault().ActivityId;
                var currentStateAfter = wfInstanceDef.ActivityData[currentActivityId];
            }
            else
            {
                req.CurrentStepDescription = "فرآیند بررسی این تسهیلات نهایی شده است";
                req.CurrentStepFormalName = "آرشیو";
                req.WorkflowFinishTime = DateTime.Now;

              
                await contextDB.SaveChangesAsync();
            }
            return Ok(runres.Executed);

        }

    }
}
