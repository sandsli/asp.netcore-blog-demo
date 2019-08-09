using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection.Emit;
using System.Reflection;

namespace ILTest
{
    public class EmitClass
    {
        const string AssemblyName = "DynamicAssembly";
        const string AssemblyFileName = "DynamicAssembly.dll";
        const string ModuleName = "DynamicModule";

        public static Type Create()
        {
            AssemblyBuilder _assemblyBuilder = AppDomain.CurrentDomain.DefineDynamicAssembly(new AssemblyName(AssemblyName),
                AssemblyBuilderAccess.RunAndSave, System.AppDomain.CurrentDomain.BaseDirectory);
            var _moduleBuilder = _assemblyBuilder.DefineDynamicModule(ModuleName, AssemblyFileName);

            var _typeBuilder = _moduleBuilder.DefineType("MyDynamicType", TypeAttributes.Public | TypeAttributes.Sealed);

            ConstructorBuilder constructorBuilder = _typeBuilder.DefineConstructor(MethodAttributes.Public,
              CallingConventions.HasThis, null);


            ILGenerator generator = constructorBuilder.GetILGenerator();
            ConstructorInfo defaultConstructorInfo = typeof(EmitClass).GetConstructor(Type.EmptyTypes);

            //generator.DefineLabel();
            generator.DeclareLocal(typeof(int));

            generator.Emit(OpCodes.Ldarg_0);
            generator.Emit(OpCodes.Ldarg_1);
            generator.Emit(OpCodes.Stfld,1);
            //generator.Emit(OpCodes.Ldarg_0);
            //generator.Emit(OpCodes.Ldarg_0);
            //generator.Emit(OpCodes.Newobj, defaultConstructorInfo);
            generator.Emit(OpCodes.Ret);//结束


            var type = _typeBuilder.CreateType();
            _assemblyBuilder.Save(AssemblyFileName);
            return type;
        }
    }
}
