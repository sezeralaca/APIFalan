using System.ComponentModel.DataAnnotations;

namespace IDoContent.Data.Entity
{
    public class HotWheels
    {
        [Key]
        public int Id { get; set; }
        public string ContentTitle { get; set; }
        public string ContentDescription { get; set; }
        public string ContentCategory { get; set; }
        public string Content { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.Now;

    }
}
