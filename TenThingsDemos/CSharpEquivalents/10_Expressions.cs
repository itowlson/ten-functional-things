using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpEquivalents
{
    public static class Expressions
    {
        public static void IfStatementTest(int value)
        {
            int abs;

            if (value < 0)
            {
                abs = -value;
            }
            else
            {
                abs = value;
            }

            Console.WriteLine(abs);
        }

        public static void SwitchStatementTest(int value)
        {
            string trollText;

            switch (value)
            {
                case 0: trollText = "none"; break;
                case 1: trollText = "one"; break;
                case 2: trollText = "some"; break;
                case 3: trollText = "many"; break;
                default: trollText = "lots"; break;
            }

            Console.WriteLine(trollText);
        }

        public static void IfExpressionTest(int value)
        {
            int abs = value < 0 ? -value : value;
            Console.WriteLine(abs);
        }

        public static void ExceptionStatementTest()
        {
            string text;

            try
            {
                text = File.ReadAllText(@"c:\temp\test.txt");
            }
            catch (FileNotFoundException)
            {
                text = String.Empty;
            }

            Console.WriteLine("File contents: " + text);
        }

        public static void UsingStatementTest()
        {
            int lineCount;

            using (var stream = File.OpenRead(@"c:\temp\test.txt"))
            {
                using (var reader = new StreamReader(stream))
                {
                    lineCount = reader.ReadToEnd().Split('\n').Length;
                }
            }

            Console.WriteLine(lineCount);
        }

    }
}
