using System;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Stealer
{
    public class Spy
    {
        public string StealFieldInfo(string _class, params string[] fields)
        {
            StringBuilder result = new StringBuilder();

            Type type = Type.GetType("Stealer." + _class);

            var _fields = type.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);

            object instance = Activator.CreateInstance(type, new object[] { });

            foreach (var field in _fields.Where(v => fields.Contains(v.Name)))
            {
                result.AppendLine($"{field.Name} = {field.GetValue(instance).ToString()}");
            }

            return result.ToString();
        }

        public string AnalyzeAcessModifiers(string classStr)
        {
            StringBuilder result = new StringBuilder();

            Type type = Type.GetType("Stealer." + classStr);

            var _fields = type.GetFields(BindingFlags.Public | BindingFlags.Instance);

            var publicMethods = type.GetMethods(BindingFlags.Public | BindingFlags.Instance);

            var privateMethods = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance);

            object instance = Activator.CreateInstance(type, new object[] { });

            foreach (var field in _fields)
            {
                result.AppendLine($"{field.Name} mist be private!");
            }

            foreach (var method in privateMethods)
            {
                if (method.Name.StartsWith("get"))
                {
                    result.AppendLine(method.Name + " have to be public!");
                }
            }

            foreach (var method in publicMethods)
            {
                if (method.Name.StartsWith("set"))
                {
                    result.AppendLine(method.Name + " have to be private!");
                }
            }

            return result.ToString();
        }

        public string RevealPrivateMethods(string className)
        {
            StringBuilder result = new StringBuilder();

            result.AppendLine($"All Private Methods of Class: {className}");

            Type type = Type.GetType("Stealer." + className);

            var privateMethods = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance);

            object instance = Activator.CreateInstance(type, new object[] { });

            result.AppendLine($"Base Class: {type.BaseType.Name}");

            foreach (var method in privateMethods)
            {
                result.AppendLine(method.Name);
            }

            return result.ToString().Trim();
        }

        public string CollectGettersAndSetters(string className)
        {
            StringBuilder result = new StringBuilder();

            Type type = Type.GetType("Stealer." + className);

            var methods = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public | BindingFlags.Static);

            object instance = Activator.CreateInstance(type, new object[] { });

            foreach (var method in methods.Where(m => m.Name.StartsWith("get")))
            {
                result.AppendLine($"{method.Name} will return {method.ReturnType}");
            }

            foreach (var method in methods.Where(m => m.Name.StartsWith("set")))
            {
                result.AppendLine($"{method.Name} will set field of {method.GetParameters().First().ParameterType}");
            }

            return result.ToString().Trim();
        }
    }
}
