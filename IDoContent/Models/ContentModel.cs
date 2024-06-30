using Microsoft.VisualBasic;

namespace IDoContent.Models
{
    public class ContentModel
    {
        public int Id { get; set; }
        public string ContentTitle { get; set; }
        public string ContentDescription { get; set; }
        public string ContentCategory { get; set; }
        public string Content { get; set; }
        public int ContentDate { get; set; }
    }
}
