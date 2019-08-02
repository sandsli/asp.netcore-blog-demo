using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            FastReflection.Program.Maintest();

            //Foo.Test();
            //People.Test();
            Console.Read();
        }

        //private static void MyGet(Foo foo, System.Reflection.PropertyInfo p)
        //{

        //   // var result = p.GetValue(foo);

        //}

        //private static void MyGet2(Foo foo, System.Reflection.PropertyInfo p)
        //{
        //    //var target = Expression.Parameter(typeof(Foo));
        //    //var getPropertyValue = Expression.Property(target, "Name");
        //    //var getfunc = Expression.Lambda<Func<Foo, string>>(getPropertyValue, target).Compile();
        //    //var result = getfunc(foo);
        //}
    }
}
