using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomMapper
{
    public class SampleModel
    {
        public string sample1 { get; set; }
        public string sample2 { get; set; }

        public void TestGeneric<T2>(T2 data)
        {
            Console.WriteLine(sample1 + ":" + sample2 + ":" + data.ToString());
        }
    }
}
