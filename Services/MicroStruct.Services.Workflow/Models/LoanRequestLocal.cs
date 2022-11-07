using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;

namespace MicroStruct.Services.WorkflowApi.Models
{
    public class LoanRequestLocal
    {
        [Key]
        public Guid Id { get; set; }
        [DefaultValue("-")]
        public string CompanyNationalID { get; set; }
        [DefaultValue(0)]
        public int ProgramTypeID { get; set; }
        public string? WorkflowInstanceId { get; set; }
        public Guid? DepartmentSUID { get; set; }
        public string? DirectDepartmentExpertUserName { get; set; }
        public DateTime? WorkflowStartDate { get; set; }
        public string? CurrentStep { get; set; }
        public string? CurrentStepFormalName { get; set; }
        public string? CurrentStepDescription { get; set; }
        public string? CurrentActivityId { get; set; }
        public DateTime? WorkflowFinishTime { get; set; }
        public bool Approved { get; set; } = false;
        public DateTime? InThisStateFrom { get; set; }
        public string? FacilityRequestTotalState { get; set; }
        public string CreatedBy { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime CreationTime { get; set; }
        public DateTime LastMidificationTime { get; set; }

        public string? Financial_WorkflowInstanceId { get; set; }
        public DateTime? Financial_WorkflowStartDate { get; set; }
        public string? Financial_CurrentActivityId { get; set; }
        public DateTime? Financial_InThisStateFrom { get; set; }
        public string? Financial_CurrentStep { get; set; }
        public string? Financial_CurrentStepFormalName { get; set; }
        public string? Financial_CurrentStepDescription { get; set; }
        public string? Financial_FacilityRequestTotalState { get; set; }
        public DateTime? Financial_WorkflowFinishTime { get; set; }
        public byte ProgramTypeKindID { get; set; }
        public double? RequestedAmount { get; set; }
        public double? AcceptedAmount { get; set; }
        public double? AcceptedRate { get; set; }
      

    }
}
