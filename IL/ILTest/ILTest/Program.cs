using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace ILTest
{
    class Program
    {
        static void Main(string[] args)
        {
            //var a = 1;
            //var b = 2;
            //var c = a + b;

            //var type = EmitClass.Create();

            //Console.WriteLine(type.Name);
            DemoAssemblyBuilder.Sample();
            Console.Read();
        }


     
    }
}
