using MicroStruct.Services.Dashboard.Domain.Model;
using System.ComponentModel.DataAnnotations.Schema;

namespace MicroStruct.Services.Dashboard.Data.Entities
{
    [Table("Widget")]
    public class WidgetEntity:Widget
    {
        public WidgetEntity()
        {

        }
        public ICollection<WidgetAccessEntity> WidgetAccessEntities { get; set; }
    }
}
