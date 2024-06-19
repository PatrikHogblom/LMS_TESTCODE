using System.Diagnostics;

namespace LMSLexicon.API.Models.Entities
{
    public class Module
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        // Foreign key
        public int CourseID { get; set; }

        // Navigation property for activities
        public Course Course { get; set; }
        public ICollection<Activity> Activities { get; set; } = new List<Activity>();
        public ICollection<Document> Documents { get; set; } = new List<Document>();

    }
}
