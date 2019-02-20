using System;
using static System.Console;
using System.IO;
using System.Reflection;

namespace lab11
{
    public class Reflector<T>
    {
        public void ShowAll(T obj)
        {
            Type myType = obj.GetType();

            using (StreamWriter sw = new StreamWriter("note.txt", false))
            {
                foreach (MemberInfo mi in myType.GetMembers())
                {
                    sw.WriteLine(mi.DeclaringType + " " + mi.MemberType + " " + mi.Name);
                }
                sw.WriteLine();
            }
        }

        public void GetPublicMethods(T obj)
        {
            Type myType = obj.GetType();

            using (StreamWriter sw = new StreamWriter("note.txt", true))
            {
                sw.WriteLine("_______________Public methods of class_______________");

                foreach (MemberInfo mi in myType.GetMethods())
                {
                    sw.WriteLine(mi.Name);
                }

                sw.WriteLine();
            }
        }

        public void GetPropField(T obj)
        {
            Type myType = obj.GetType();

            using (StreamWriter sw = new StreamWriter("note.txt", true))
            {
                sw.WriteLine("_______________Info about properties and fields_______________");
                sw.WriteLine("Properties:");

                foreach (PropertyInfo mi in myType.GetProperties())
                {
                    sw.WriteLine(mi.Name + " " + mi.PropertyType);
                }

                sw.WriteLine();

                sw.WriteLine("Fields:");

                foreach (FieldInfo mi in myType.GetFields())
                {
                    sw.WriteLine(mi.Name + " " + mi.FieldType);
                }

                sw.WriteLine();
            }
        }

        public void GetInterfaces(T obj)
        {
            Type myType = obj.GetType();

            using (StreamWriter sw = new StreamWriter("note.txt", true))
            {
                sw.WriteLine("_______________Info about implemented interfaces_______________");

                foreach (MemberInfo mi in myType.GetInterfaces())
                {
                    sw.WriteLine(mi.Name);
                }

                sw.WriteLine();
            }
        }

        public void GetUserMethods(T obj)
        {
            WriteLine("Enter name of method to find: ");
            var nameOfMethod = ReadLine();

            Type myType = obj.GetType();

            MethodInfo methodInfo = myType.GetMethod(nameOfMethod);
            ParameterInfo[] myParameter = methodInfo.GetParameters();

            using (StreamWriter sw = new StreamWriter("note.txt", true))
            {
                sw.WriteLine("_______________Info about user methods_______________");

                for (int i = 0; i < myParameter.Length; i++)
                {
                    sw.WriteLine(myParameter[i]);
                }

                sw.WriteLine();
            }
        }

        public void CallAnyMethod(T obj, string mth)
        {
            FileStream file2 = new FileStream("args.txt", FileMode.Open);
            StreamReader reader = new StreamReader(file2);
            object[] arr = { reader.ReadLine() };
            Type t = typeof(T);
            MethodInfo metod = t.GetMethod(mth);
            object mval = metod.Invoke(obj, arr);
            WriteLine(mval);
        }
    }
}
