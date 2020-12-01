using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portal.Client.ViewModels
{
    public class GetVM
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Applicants { get; set; }
    }

    public class ReferanceJson
    {
        [JsonProperty("data")]
        public IList<GetVM> data { get; set; }
    }
    public class PositionJson
    {
        [JsonProperty("data")]
        public IList<GetVM> data { get; set; }
    }
    public class SkillJson
    {
        [JsonProperty("data")]
        public IList<GetVM> data { get; set; }
    }
}
