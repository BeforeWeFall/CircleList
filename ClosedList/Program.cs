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
            s.HeadReached += DoSomething;
            var u = s[0];
            var u1 = s[1];
            //s[1] = "b";
            //var u2 = s[1];
            var u3 = s[2];

            s.MoveNext();
            s.MoveNext();
            s.MoveNext();
            s.MoveNext();
            s.MoveNext();
            s.MoveNext();
            s.MoveNext();
            s.MoveNext();
            //s.Clear();
            // u = s[0];
            // u1 = s[1];

            string[] arr = new string[7];
            s.CopyTo(arr, 1);
        }

        static private void DoSomething(object sender, string e)
        {
            Console.WriteLine("qq");
        }
    }
}
