using System.Diagnostics;
using System.Reflection;

namespace LMSLexicon.API.Models.Entities
{
    public class Document
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime UploadTime { get; set; }

        // Foreign keys
        public string UserID { get; set; }  // Foreign key to User
        public int CourseID { get; set; }  // Foreign key to Course (optional, depending on your design)
        public int ModuleID { get; set; }  // Foreign key to Module (optional, depending on your design)
        public int ActivityID { get; set; }  // Foreign key to Activity (optional, depending on your design)

        // Navigation property
        public User User { get; set; }
        public Module Module { get; set; }
        public Activity Activity { get; set; }
        public Course Course { get; set; }
    }
}
