using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using static System.Console;

namespace lab9
{
    public class Student<T>
    {
        public string Name { get; set; }

        public Student(string name)
        {
            Name = name;
        }

        public Student()
        {
            Name = "Diana";
        }

        public static List<T> genericlist = new List<T>();
        public static SortedSet<T> sortedset = new SortedSet<T>();

        public static void WhenChange(object sender, NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    Student<T> newStudent = e.NewItems[0] as Student<T>;
                    WriteLine("Added new object: {0}", newStudent.Name);
                    break;
                case NotifyCollectionChangedAction.Remove:
                    Student<T> oldStudent = e.OldItems[0] as Student<T>;
                    WriteLine("Deleted object: {0}", oldStudent.Name);
                    break;
                case NotifyCollectionChangedAction.Replace:
                    Student<T> replacedStudent = e.OldItems[0] as Student<T>;
                    Student<T> replacingStudent = e.NewItems[0] as Student<T>;
                    WriteLine("Object {0} is replaced by object {1}", replacedStudent.Name, replacingStudent.Name);
                    break;
            }
        }
    }
}
