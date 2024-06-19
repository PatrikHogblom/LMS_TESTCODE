using Microsoft.AspNetCore.Identity;
using System.Reflection.Metadata;

namespace LMSLexicon.API.Models.Entities
{
    public class User : IdentityUser
    {

        //public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName => $"{FirstName} {LastName}";
        //public string Email { get; set; }
        public UserRole Role { get; set; }
        //public string Password { get; set; }


        // Navigation property to Course
        public int CourseID { get; set; }
        public Course Course { get; set; }

        // Navigation property to Documents
        public ICollection<Document> Documents { get; set; } = new List<Document>();
    }

    public enum UserRole
    {
        Admin,
        Teacher,
        Student
    }
}
