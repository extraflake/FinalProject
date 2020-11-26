using System;

namespace Portal.Client.Controllers
{
    internal class Files
    {
        public Files()
        {
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string FileType { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}