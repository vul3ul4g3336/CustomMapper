using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomMapper.DataModels
{
    internal class Model1
    {
        public int Id { get; set; }
        public List<SampleModel> sets { get; set; }

        public CardType cardType { get; set; }

        public SampleModel sampleModel1 { get; set; }
        public SampleModel sampleModel { get; set; }

        public bool IsEnabled {  get; set; }
    }
}
