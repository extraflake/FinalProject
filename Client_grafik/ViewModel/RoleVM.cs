using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Client_grafik.ViewModel
{
    public class RoleVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class jsRole
    {
        [JsonProperty("data")]
        public IList<RoleVM> data { get; set; }
    }
}
