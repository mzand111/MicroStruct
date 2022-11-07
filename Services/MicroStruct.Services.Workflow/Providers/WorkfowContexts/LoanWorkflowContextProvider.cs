using Elsa.Models;
using Elsa.Persistence;
using Elsa.Persistence.Specifications;
using Elsa.Services;
using Elsa.Services.Models;
using MicroStruct.Services.WorkflowApi.Data;
using MicroStruct.Services.WorkflowApi.Models;
using Microsoft.EntityFrameworkCore;

namespace MicroStruct.Services.WorkflowApi.Providers.WorkfowContexts
{
    public class LoanWorkflowContextProvider : WorkflowContextRefresher<LoanRequestLocal>
    {
        private readonly IDbContextFactory<LoanContext> _facilityContextFactory;
        private readonly IWorkflowInstanceStore _instanceStore;
        private readonly IWorkflowRegistry _registry;

        public LoanWorkflowContextProvider(IDbContextFactory<LoanContext> facilityContextFactoryFactory
            , IWorkflowInstanceStore istanceStore
            , IWorkflowRegistry registry)
        {
            _facilityContextFactory = facilityContextFactoryFactory;
            this._instanceStore = istanceStore;
            _registry = registry;
        }

        /// <summary>
        /// Loads a BlogPost entity from the database.
        /// </summary>
        public override async ValueTask<LoanRequestLocal?> LoadAsync(LoadWorkflowContext context, CancellationToken cancellationToken = default)
        {
            Guid facilityRequestId;
            if (Guid.TryParse(context.ContextId, out facilityRequestId))
            {
                await using var dbContext = _facilityContextFactory.CreateDbContext();

                return await dbContext.LoanRequestLocals.AsQueryable().FirstOrDefaultAsync(x => x.Id == facilityRequestId, cancellationToken);
            }
            return null;
        }

        /// <summary>
        /// Updates a FacilityRequestLocal entity in the database.
        /// If there's no actual workflow context, we will get it from the input. This works because we know we have a workflow that starts with an HTTP Endpoint activity that receives BlogPost models.
        /// This is a design choice for this particular demo. In real world scenarios, you might not even need this since your workflows may be dealing with existing entities, or have (other) workflows that handle initial entity creation.
        /// The key take away is: you can do whatever you want with these workflow context providers :) 
        /// </summary>
        public override async ValueTask<string?> SaveAsync(SaveWorkflowContext<LoanRequestLocal> context, CancellationToken cancellationToken = default)
        {
            var facilityRequestLocal = context.Context;
            await using var dbContext = _facilityContextFactory.CreateDbContext();
            var dbSet = dbContext.LoanRequestLocals;

            if (!string.IsNullOrEmpty(context.ContextId))
            {
                Guid facilityRequestLocalID = Guid.Parse(context.ContextId);
                var loanRequestLocal = await dbSet.AsQueryable().Where(x => x.Id == facilityRequestLocalID).FirstAsync(cancellationToken);
                if (facilityRequestLocal == null)
                {
                    facilityRequestLocal = loanRequestLocal;
                }
                WorkflowInstance? wfInstanceDef = null;
                wfInstanceDef = await _instanceStore.FindAsync(new CorrelationIdSpecification<WorkflowInstance>(context.WorkflowExecutionContext.CorrelationId));
                var reg = await _registry.FindByDefinitionVersionIdAsync(wfInstanceDef.DefinitionVersionId);
                string? currentActivityID = null;
                if (reg.Name == "FaciliyRequestAcceptance")
                {
                    if (loanRequestLocal.WorkflowInstanceId == null)
                    {

                        facilityRequestLocal.WorkflowStartDate = DateTime.Now;
                        facilityRequestLocal.WorkflowInstanceId = wfInstanceDef?.Id;
                        facilityRequestLocal.WorkflowFinishTime = wfInstanceDef.FinishedAt?.ToDateTimeUtc();


                        loanRequestLocal.WorkflowStartDate = DateTime.Now;
                        loanRequestLocal.WorkflowInstanceId = wfInstanceDef?.Id;
                        loanRequestLocal.WorkflowFinishTime = wfInstanceDef.FinishedAt?.ToDateTimeUtc();

                    }
                }
                else
                {


                    if (facilityRequestLocal.Financial_WorkflowInstanceId == null)
                    {
                        facilityRequestLocal.Financial_WorkflowStartDate = DateTime.Now;
                        facilityRequestLocal.Financial_WorkflowInstanceId = wfInstanceDef?.Id;
                        facilityRequestLocal.Financial_WorkflowFinishTime = wfInstanceDef.FinishedAt?.ToDateTimeUtc();

                        loanRequestLocal.Financial_WorkflowStartDate = DateTime.Now;
                        loanRequestLocal.Financial_WorkflowInstanceId = wfInstanceDef?.Id;
                        loanRequestLocal.Financial_WorkflowFinishTime = wfInstanceDef.FinishedAt?.ToDateTimeUtc();

                    }
                }


                dbContext.Entry(loanRequestLocal).CurrentValues.SetValues(facilityRequestLocal);

                context.WorkflowExecutionContext.WorkflowContext = loanRequestLocal;
                context.WorkflowExecutionContext.ContextId = loanRequestLocal.Id.ToString();


            }

            await dbContext.SaveChangesAsync(cancellationToken);
            return facilityRequestLocal?.Id.ToString();
        }
    }
}
