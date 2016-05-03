using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace LogicAnalyser
{
    public static class Loader
    {
        public static Type[] GetTestibleTypes(Assembly[] assemblies)
        {
            var typeList = new List<Type>();

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

        public static Object Instantiate(Type type)
        {
            return Activator.CreateInstance(type);
        }

        public static List<Object> InstantiateArray(IEnumerable<Type> types)
        {
            return types.Select(Instantiate).ToList();
        }

        public static List<SystemContainer> WrapObjects(IEnumerable<Type> types)
        {
            return types.Select(i => new SystemContainer(i)).ToList();
        }

        public static Type[] GetTestibleTypes()
        {
            return GetTestibleTypes(AppDomain.CurrentDomain.GetAssemblies());
        }

        public static List<SystemContainer> FindTestObjects()
        {
            var toTest = GetTestibleTypes();

            return WrapObjects(toTest);
        }

        public static FieldInfo[] GetFields<T>(Type type)
        {
            //return (FieldInfo[])GetMembers<T>(type.GetFields);

            return type.GetFields(BindingFlags.NonPublic
                                | BindingFlags.Public
                                | BindingFlags.Static
                                | BindingFlags.Instance)
                    .Where(f => GetAttributes<T>(f).Any())
                    .ToArray();
        }

        public static IEnumerable<T> GetAttributes<T>(MemberInfo field)
        {
            return field.GetCustomAttributes(true).OfType<T>();
        }

        public static MethodInfo[] GetMethods<T>(Type type)
        {
            //return (MethodInfo[])GetMembers<T>(type.GetMethods);

            return type.GetMethods(BindingFlags.NonPublic
                                | BindingFlags.Public
                                | BindingFlags.Static
                                | BindingFlags.Instance)
                        .Where(m => GetAttributes<T>(m).Any())
                        .ToArray();
        }

        //public static MemberInfo[] GetMembers<T>(Func<BindingFlags, IEnumerable<MemberInfo>> action)
        //{
        //    return action(BindingFlags.NonPublic
        //                        | BindingFlags.Public
        //                        | BindingFlags.Static
        //                        | BindingFlags.Instance)
        //                .Where(m => GetAttributes<T>(m).Any())
        //                .ToArray();
        //}
    }
}
