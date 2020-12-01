using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamOnline.Client.ViewModel
{
    public class SegmentVM
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Duration { get; set; }
        public int QuestionQuantity { get; set; }
        public bool IsSegmentActive { get; set; }
    }
    public class SegmentJson
    {
        [JsonProperty("data")]
        public IList<SegmentVM> data { get; set; }
    }
}
