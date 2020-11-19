using Portal.Bases;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Portal.Models
{
    [Table("TB_M_Files")]
    public class File : IEntity
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string FileType { get; set; }
        [MaxLength]
        public byte[] DataFile { get; set; }
        public DateTime? CreatedOn { get; set; }

        public Applicant Applicant { get; set; }
    }
}
