using MZBase.Domain;

namespace MicroStruct.Services.Dashboard.Domain.Model
{
    public class Widget:Model<Guid>
    {
        
        public string Name { get; set; }
        public bool Enabled { get; set; }
        public int DefaultHeight { get; set; }
    }
}
