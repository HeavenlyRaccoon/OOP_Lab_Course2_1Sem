using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.IO;

namespace lab_12
{
    static class Reflector
    {
        private static string path = "out.txt";
        private static StreamWriter writer = null;

        private static void FileOpen() => writer = new StreamWriter(path, true);
        private static void FileClose() => writer.Close();

        static public void GetAssemblyName(Type cl)
        {
            FileOpen();
            writer.WriteLine(cl.AssemblyQualifiedName);
            FileClose();
        }

        static public void GetPublicCtor(Type cl)
        {
            FileOpen();
            ConstructorInfo[] constructors = cl.GetConstructors();
            Console.WriteLine("Конструкторы: ");
            foreach(ConstructorInfo info in constructors)
            {
                writer.Write(cl.Name + " (");
                ParameterInfo[] parameters = info.GetParameters();
                for (int i = 0; i < parameters.Length; i++)
                {
                    writer.Write(parameters[i].ParameterType.Name + " " + parameters[i].Name);
                    if (i + 1 < parameters.Length) writer.Write(", ");
                }
                writer.WriteLine(")");
            }
            FileClose();
        }

        static public IEnumerable<string> getPublicMethod(Type cl)
        {
            MethodInfo[] methods = cl.GetMethods();
            var MethodsName = methods.Select(t => t.Name);
            return MethodsName;
        }

        static public IEnumerable<string> getProp(Type cl)
        {
            FieldInfo[] fields = cl.GetFields(BindingFlags.NonPublic|BindingFlags.Public|BindingFlags.DeclaredOnly | BindingFlags.Instance);
            PropertyInfo[] properties = cl.GetProperties(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.DeclaredOnly | BindingFlags.Instance);
            IEnumerable<string> field = fields.Select(t => t.Name);
            IEnumerable<string> prop = properties.Select(t => t.Name);
            var result = field.Concat(prop);
            return result;
        }

        static public IEnumerable<string> getI(Type cl)
        {
            Type[] types = cl.GetInterfaces();
            IEnumerable<string> result = types.Select(t => t.Name);
            return result;
        }

        static public void getMethodsByType(Type cl)
        {
            FileOpen();
            string type;
            Console.WriteLine("Введите тип параметра");
            Console.WriteLine(typeof(int).Name+" "+typeof(string).Name);
            type = Console.ReadLine();
            Console.WriteLine("Методы с параметрами этого типа: ");
            MethodInfo[] methods = cl.GetMethods();
            bool check = false;
            foreach(MethodInfo method in methods)
            {
                ParameterInfo[] parameters = method.GetParameters();
                foreach(ParameterInfo parameter in parameters)
                {
                    if (parameter.ParameterType.Name == type)
                    {
                        check = true;
                    }
                }
                if (check)
                {
                    Console.WriteLine(method.Name);
                    check = false;
                }
            }
            FileClose();
        }

        public static void GetClassInvoke(string className, string methodName, string infile)
        {


            Console.WriteLine($"Calling {methodName}");

            Type classData = Type.GetType(className);

            var method = classData.GetMethod(methodName);
            if (method == null)
            {
                Console.WriteLine("Invalid method");
                return;
            }

            StreamReader reader = new StreamReader(infile);

            object obj = Activator.CreateInstance(classData);

            string parm;

            while ((parm = reader.ReadLine()) != null)
            {
                if (method.GetParameters().Length != 0)
                {
                    method.Invoke(obj, parm.Split('|'));
                }
                else
                {
                    method.Invoke(obj, new object[] { });
                }
            }
        }

        public static object CreateType(string className)
        {
            return Activator.CreateInstance(Type.GetType(className));
        }
    }
}
