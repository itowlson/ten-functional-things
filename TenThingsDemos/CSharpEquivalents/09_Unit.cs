using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpEquivalents
{
    public static class Unit
    {
        public static void Void_ItsNotAType()
        {
            int i = 17;

            Func<double> getSqrt = () => Sqrt(i);  // () -> double
            var sqrt = WithExceptionLogging(getSqrt);

            Action writeSqrt = () => Console.WriteLine(Sqrt(i));  // () -> ?
            WithExceptionLogging(writeSqrt);
        }

        private static T WithExceptionLogging<T>(Func<T> action)
        {
            try
            {
                return action();
            }
            catch (Exception ex)
            {
                Log(ex);
                throw;
            }
        }

        private static void WithExceptionLogging(Action action)  // can't absorb as Func<void>
        {
            try
            {
                action();
            }
            catch (Exception ex)
            {
                Log(ex);
                throw;
            }
        }

        private static void Log(Exception ex)
        {
            // placeholder
        }

        private static double Sqrt(double d)
        {
            if (d < 0)
            {
                throw new ArgumentException("d");
            }
            return Math.Sqrt(d);
        }
    }
}
