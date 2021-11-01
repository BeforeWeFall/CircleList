using System;
using System.Collections.Generic;

namespace ClosedList
{
    class Program
    {
        static void Main(string[] args)
        {
            CircleClosedList<string> s = new CircleClosedList<string>();
            s.Add("b");
            s.Add("c");

            s.Add("d");
            s.Clear();
            //s.Clear();
            // u = s[0];
            // u1 = s[1];

            var t = s.Contains("c");
        }

        static private void DoSomething(object sender, string e)
        {
            Console.WriteLine("qq");
        }
    }
}
