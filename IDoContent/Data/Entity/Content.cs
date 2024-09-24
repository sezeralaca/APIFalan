using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;

namespace IDoContent.Data.Entity
{
    public class Content
    {
        [Key]
        public int Id { get; set; }
        public string ContentTitle { get; set; }
        public string ContentDescription { get; set; }
        public string ContentCategory { get; set; }
        public string MainContent { get; set; }
        public int ContentDate { get; set; }
    }
}
