using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;

namespace ConsoleApplication1
{

    public class Bar
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class Foo
    {
        public Bar Bar { get; set; }

        public static void SetReflection(Foo foo, Bar bar)
        {
            var property = foo.GetType().GetProperty("Bar");
            property.SetValue(foo, bar);
        }

        public static Action<Foo, Bar> SetExpression()
        {
            var property = typeof(Foo).GetProperty("Bar");
            var target = Expression.Parameter(typeof(Foo));
            ParameterExpression propertyValue = Expression.Parameter(typeof(Bar));
            //var setPropertyValue = Expression.Call(target, property.GetSetMethod(), propertyValue);
            BinaryExpression setPropertyValue = Expression.Assign(Expression.Property(target, property), propertyValue);
            var setAction = Expression.Lambda<Action<Foo, Bar>>(setPropertyValue, target, propertyValue).Compile();
            return setAction;
        }

        public static Action<Foo, Bar> SetEmit()
        {
            var property = typeof(Foo).GetProperty("Bar");
            DynamicMethod method = new DynamicMethod("SetValue", null, new Type[] { typeof(Foo), typeof(Bar) });
            ILGenerator ilGenerator = method.GetILGenerator();
            ilGenerator.Emit(OpCodes.Ldarg_0);
            ilGenerator.Emit(OpCodes.Ldarg_1);
            ilGenerator.EmitCall(OpCodes.Callvirt, property.GetSetMethod(), null);
            ilGenerator.Emit(OpCodes.Ret);
            method.DefineParameter(1, ParameterAttributes.In, "obj");
            method.DefineParameter(2, ParameterAttributes.In, "value");
            var setAction2 = (Action<Foo, Bar>)method.CreateDelegate(typeof(Action<Foo, Bar>));
            return setAction2;
        }

        public static void Test()
        {
            var act1 = Foo.SetExpression();
            var act2 = Foo.SetEmit();

            var st = new Stopwatch();
            st.Start();

            for (int i = 0; i < 1000000; i++)
            {
                var foo = new Foo { };
                var bar = new Bar { Id = 1, Name = "name" };
                Foo.SetReflection(foo, bar);
            }

            Console.WriteLine("Reflection " + st.ElapsedMilliseconds);

            st.Restart();
            for (int i = 0; i < 1000000; i++)
            {
                var foo = new Foo { };
                var bar = new Bar { Id = 1, Name = "name" };
                act1(foo, bar);
            }

            Console.WriteLine("Expression " + st.ElapsedMilliseconds);

            st.Restart();
            for (int i = 0; i < 1000000; i++)
            {
                var foo = new Foo { };
                var bar = new Bar { Id = 1, Name = "name" };
                act2(foo, bar);
            }

            Console.WriteLine("Emit " + st.ElapsedMilliseconds);
        }
    }
}
