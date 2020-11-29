using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Client_grafik.ViewModel
{
    public class UniversityVM
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }

    public class JsonUniv
    {
        [JsonProperty("data")]
        public IList<UniversityVM> data { get; set; }
    }
}
