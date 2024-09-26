using System.ComponentModel.DataAnnotations;

namespace IDoContent.Data.Entity
{
    public class HotWheels
    {
        [Key]
        public int HWId { get; set; }
        public string HWBrand { get; set; }
        public string HWModel { get; set; }
        public string HWSeries { get; set; }
        public string HWColor { get; set; }
        public string HWDescription { get; set; }
        public string HWBoxCondition { get; set; }
        public DateTime HWDateAdded { get; set; } = DateTime.Now;
    }

}

