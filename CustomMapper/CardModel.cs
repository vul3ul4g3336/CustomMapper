using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomMapper
{
    internal class CardModel
    {
        public List<numberModel> list { get; set; }
        public int id { get; set; }
        public string name { get; set; }

        public int cost { get; set; }

        public string Note { get; set; }

        public SampleModel sampleModel { get; set; }

        public CardType cardType { get; set; }

        public int[] array { get; set; }
    }
}
