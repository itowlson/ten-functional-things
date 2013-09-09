using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpEquivalents
{
    public static class Infix
    {
        public static string AddWord(this string s1, string s2)
        {
            return s1 + " " + s2;
        }

        public static void Greet()
        {
            var greeting = "hello".AddWord("world");
            Console.WriteLine(greeting);
        }
    }
}
