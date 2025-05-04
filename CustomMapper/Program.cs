
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CustomMapper
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var sampleModel = new SampleModel()
            {
                sample1 = "2",
                sample2 = "3",
            };
            CardModel card = new CardModel()
            {
                id = 2312321,
                name = "ben",
                cost = 9999,
                Note = "none",
                sampleModel = sampleModel,
                cardType = CardType.原始,
                list = new List<numberModel>()
                {
                     new numberModel(){ a = 1},
                     new numberModel(){a=2 },
                     new numberModel(){a=3 },
                },
                array = new int[3] { 99, 88, 77 },
                sets = new HashSet<SampleModel>()
                {
                      sampleModel
                }
            };

            //CardViewModel viewcard = new CardViewModel()
            //{
            //    id = 1,
            //    name = "ben",
            //    cost = 3,
            //    Note = "none"
            //};
            CardViewModel finalResult = Mapper.Map<CardModel, CardViewModel>(card);
            foreach (var x in finalResult.list)
            {
                Console.WriteLine(x.a);
            }
            Console.WriteLine(finalResult.id);
            Console.WriteLine(finalResult.name);
            Console.WriteLine(finalResult.cost);
            Console.WriteLine(finalResult.cardType);
            Console.WriteLine(finalResult.sampleModel.sample1);
            Console.WriteLine(finalResult.sampleModel.sample2);
            foreach (var x in finalResult.sets)
            {
                Console.WriteLine(x.sample1);
                Console.WriteLine(x.sample2);
            }


            //Array a = new int[5];
            //object obj = Array.CreateInstance(typeof(int), 123);
            //string elementTypeName = obj.GetType().GetElementType().Name;
            //Console.WriteLine(elementTypeName);


            // List<string> list = new List<string>(); => new T<T1,T2,T3>()
            //Console.WriteLine(typeof(List<int>).IsClass);
            //Console.WriteLine(typeof(List<int>).IsGenericType);

            //var typeArgs = typeof(List<int>).GenericTypeArguments; // 拿到我的TypeArguments 為 List<int> ; int 


            //Console.WriteLine(typeArgs);
            /* var listType = typeof(List<>).GetGenericTypeDefinition(); */// List<>
                                                                           //Console.WriteLine(listType.Name + "," + listType.FullName);
                                                                           //Console.WriteLine(typeof(List<int>).Name + "," + typeof(List<int>).FullName);

            //var newListType = listType.MakeGenericType(typeArgs); // List<int>
            //var obj = Activator.CreateInstance(newListType);
            //var objType = obj.GetType();
            //MethodInfo method = objType.GetMethods().FirstOrDefault(x => x.Name == "Add");
            //method.Invoke(obj, new object[] { 1 });
            //method.Invoke(obj, new object[] { 2 });
            //method.Invoke(obj, new object[] { 3 });
            //var methods = objType.GetMethods();
            //MethodInfo method1 = objType.GetMethods().FirstOrDefault(x => x.Name == "Find");
            //var target = (List<int>)obj;
            //int num = target.Find(x => x % 2 == 0);
            //Func<int, bool> first = First;
            //object func = first;
            //method1.Invoke(obj, new object[] { func });

            //var stringArgs = typeof(SampleModel<string>).GenericTypeArguments;
            //var type = typeof(SampleModel<>).GetGenericTypeDefinition(); // 空殼

            //var obj = Activator.CreateInstance(type.MakeGenericType(stringArgs));
            //var infos = obj.GetType().GetProperties();
            //var info = infos.Where(x => x.GetType() == typeof(string)).ToList();
            //foreach (var info2 in infos)
            //{
            //    info2.SetValue(obj, "a");
            //}

            //MethodInfo method2 = obj.GetType().GetMethod("TestGeneric");

            //var stringMethodType = method2.MakeGenericMethod(stringArgs);

            //stringMethodType.Invoke(obj, new object[] { "ahjf" });

            ////target.First();
            //foreach (var item in target)
            //{
            //    Console.WriteLine(item);
            //}
            //ints.Add(1);
            //ints.Add(2);
            //ints.Add(3);



            //object obj = card;
            //var info = obj.GetType().GetProperties();
            //var objArray = info.FirstOrDefault(x => x.Name == "array");
            //var array = objArray.GetValue(obj);
            //object o = array;

            //var y = array.GetType().GetProperties();
            //var property = y.FirstOrDefault(x => x.Name == "Length");
            //var ans = property.GetValue(o);
            //Console.WriteLine(ans.ToString());
            Console.ReadKey();
        }

    }
}
