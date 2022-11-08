namespace MicroStruct.Services.WorkflowApi.Controllers.Dtos
{
    public class LoanRequestLocalDto
    {
        public Guid SUID { get; set; }
        public string CompanyNationalID { get; set; }
        public int ProgramTypeID { get; set; }
        public string? WorkflowInstanceId { get; set; }
        public Guid? DepartmentSUID { get; set; }
        public string? DirectDepartmentExpertUserName { get; set; }
        public DateTime? WorkflowStartDate { get; set; }
        public string? CurrentStep { get; set; }
        public string? CurrentStepFormalName { get; set; }
        public string? CurrentActivityId { get; set; }
        public DateTime? WorkflowFinishTime { get; set; }
        public bool Approved { get; set; } = false;
        public DateTime? InThisStateFrom { get; set; }
        public byte ProgramTypeKindID { get; set; }
        public double? RequestedAmount { get; set; }
        public double? AcceptedAmount { get; set; }
        public double? AcceptedRate { get; set; }
        public string CreatedBy { get; set; }

    }
}
