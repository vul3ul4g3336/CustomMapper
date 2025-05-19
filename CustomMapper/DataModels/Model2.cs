using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomMapper.DataModels
{
    internal class Model2
    {
        public string Id { get; set; }

        public HashSet<SampleModel> sets { get; set; }
        public int card { get; set; }
        public SampleModel sampleModel2 { get; set; }
        public SampleModel sampleModel { get; set; }

        public bool IsEnabled { get; set; }
    }
}
