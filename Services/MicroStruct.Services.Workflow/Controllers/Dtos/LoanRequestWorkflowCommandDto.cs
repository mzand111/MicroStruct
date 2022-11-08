namespace MicroStruct.Services.WorkflowApi.Controllers.Dtos
{
    public class LoanRequestWorkflowCommandDto
    {
        public LoanRequestLocalDto FacilityRequest { get; set; }
        public string UserAction { get; set; }
        public string? ActionDescription { get; set; }
    }
}
