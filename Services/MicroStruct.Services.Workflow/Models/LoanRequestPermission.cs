
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MicroStruct.Services.WorkflowApi.Models
{
    public class LoanRequestPermission
    {
       
        public Guid LoanRequestLocalID { get; set; }
        public Guid RoleLocalID { get; set; }
        public int StateActionID { get; set; }

        [ForeignKey(nameof(LoanRequestLocalID))]
        public LoanRequestLocal LoanRequestLocal { get; set; }
        [ForeignKey(nameof(RoleLocalID))]
        public RoleLocal RoleLocal { get; set; }
        [ForeignKey(nameof(StateActionID))]
        public StateAction StateAction { get; set; }

    }
}
