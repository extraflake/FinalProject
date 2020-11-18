using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portal.ViewModel
{
    public class ApplicantVM
    {
        public int Id { get; set; }
        public IEnumerable<int> SkillId { get; set; }
        public string DocPath { get; set; }
        public int PositionId { get; set; }
        public int ReferenceId { get; set; }

    }
}
