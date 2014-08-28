using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace LogicAnalyser
{
    public static class Loader
    {
        public static Type[] GetTestibleTypes(Assembly[] assemblies)
        {
            List<Type> typeList = new List<Type>();

            foreach(Assembly assembly in assemblies)
            {
                typeList.AddRange(GetTestibleTypes(assembly));
            }

            return typeList.ToArray();
        }

        public static Type[] GetTestibleTypes(Assembly assembly)
        {
            return assembly.GetTypes()
                            .Where(t2 => t2.GetCustomAttributes(true)
                                .OfType<Attributes.UnderTest>()
                                .Any())
                            .ToArray();
        }

        public static List<Object> InstantiateArray(Type[] types)
        {
            return types.Select(t => Activator.CreateInstance(t)).ToList();
        }

        public static List<SystemContainer> FindTestObjects()
        {
            var toTest = GetTestibleTypes(AppDomain.CurrentDomain.GetAssemblies());

            List<Object> instances = InstantiateArray(toTest);

            return instances.Where(i => i is IAnalysable)
                .Select(i => new SystemContainer((IAnalysable)i))
                .ToList();


            //foreach (var inf in toTest)
            //{
            //    System.Reflection.FieldInfo[] fi = inf.GetFields(System.Reflection.BindingFlags.NonPublic
            //                                                        | System.Reflection.BindingFlags.Public
            //                                                        | System.Reflection.BindingFlags.Static
            //                                                        | System.Reflection.BindingFlags.Instance)
            //                                            .Where(f => f.GetCustomAttributes(true).OfType<LogicAnalyser.Attributes.Input>().Any())
            //                                            .ToArray();

            //}
            
            //return 
        }
    }
}
