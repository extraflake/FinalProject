using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Portal.Client.ViewModels
{
    public class FileVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string FileType { get; set; }
        [MaxLength]
        public byte[] DataFile { get; set; }
        public DateTime? CreatedOn { get; set; }

    }
}
