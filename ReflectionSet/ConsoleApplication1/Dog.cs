
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace ConsoleApplication1
{


    public class People
    {
        public String Name { get; set; }

        public static void TestExpression(People people)
        {
            PropertyInfo propertyInfo = people.GetType().GetProperty("Name"); 
            

            ParameterExpression param = Expression.Parameter(typeof(People), "param");
            Expression GetPropertyValueExp = Expression.Lambda(Expression.Property(param, "Name"), param);
            Expression<Func<People, String>> GetPropertyValueLambda = (Expression<Func<People, String>>)GetPropertyValueExp;// (dog)=>dog.Name;
            ParameterExpression paramo = Expression.Parameter(typeof(People), "param");
            ParameterExpression parami = Expression.Parameter(typeof(String), "newvalue");
            MethodCallExpression MethodCallSetterOfProperty = Expression.Call(paramo, propertyInfo.GetSetMethod(), parami);
            Expression SetPropertyValueExp = Expression.Lambda(MethodCallSetterOfProperty, paramo, parami);
            Expression<Action<People, String>> SetPropertyValueLambda = (Expression<Action<People, String>>)SetPropertyValueExp;//(dog,newvalue)=>dog.Name=newvalue;

            //创建了属性Name的Get方法表达式和Set方法表达式,当然只是最简单的
            Func<People, String> Getter = GetPropertyValueLambda.Compile();
            Action<People, String> Setter = SetPropertyValueLambda.Compile();

            Setter.Invoke(people, "sl");
            var name = Getter.Invoke(people);
        }

        public static void TestRef(People people)
        {
            PropertyInfo propertyInfo = people.GetType().GetProperty("Name");
            propertyInfo.SetValue(people, "sl");
            var name = propertyInfo.GetValue(people);
        }

        public static void Test()
        {
            var st2 = new Stopwatch();
            st2.Start();
            for (int i = 0; i < 1000; i++)
            {
                People people = new People();
                TestRef(people);
            }
            st2.Stop();
            Console.WriteLine("ref " + st2.ElapsedMilliseconds);


            var st = new Stopwatch();
            st.Start();
            for (int i = 0; i < 1000; i++)
            {
                People people = new People();
                TestExpression(people);
            }
            st.Stop();
            Console.WriteLine("exp " + st.ElapsedMilliseconds);


            Console.ReadKey();
        }
    }



}
