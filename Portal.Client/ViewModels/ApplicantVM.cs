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

        // Application
        public string FileName { get; set; }
        public string FileType { get; set; }
        [MaxLength]
        public byte[] DataFile { get; set; }
        public DateTime? CreatedOn { get; set; }
    }
}
