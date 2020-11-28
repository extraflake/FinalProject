using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Portal.Client.ViewModels
{
    public class ApplicantVM
    {
        public int Id { get; set; }
        public IEnumerable<int> SkillId { get; set; }
        public int FileId { get; set; }
        public int PositionId { get; set; }
        public string PositionName { get; set; }
        public int ReferenceId { get; set; }
        public string ReferenceName { get; set; }

        public int EmployeeId { get; set; }

        // Application
        public string FileName { get; set; }
        public string FileType { get; set; }
        [MaxLength]
        public byte[] DataFile { get; set; }
        public DateTime? CreatedOn { get; set; }

        // User Data
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime BirthDate { get; set; }
        public string Gender { get; set; }
        public string Religion { get; set; }
        public string University { get; set; }
        public string Department { get; set; }
        public string Degree { get; set; }
        public string GraduationYear { get; set; }
        public string GPA { get; set; }
    }


    public class ApplicantJson
    {
        [JsonProperty("data")]
        public IList<ApplicantVM> data { get; set; }
    }
}
