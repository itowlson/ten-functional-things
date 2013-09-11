using Microsoft.FSharp.Collections;
using Microsoft.FSharp.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpEquivalents
{
    public static class Interop
    {
        // FSharpx (https://github.com/fsharp/fsharpx) has
        // helpers for Option, Unit, List, functions and more

        public static void Test()
        {
            // Records => classes
            var pt = new Immutable.Point3D(0.1, 0.2, 0.3);  // constructor
            Console.WriteLine(pt);
            Console.WriteLine(pt.X);  // member access

            // Module functions => static methods
            var extended = Immutable.extend(pt, 0.4, 0.5, 0.6);
            Console.WriteLine(extended);

            // Discriminated unions => base + subclasses
            var expr = DiscriminatedUnions.ExprNode.NewVariableRef("myVariable");
            Console.WriteLine(expr);
            Console.WriteLine(((DiscriminatedUnions.ExprNode.VariableRef)expr).Item);

            // DUs can cross the boundary -- but they can be verbose!
            // Consider putting helper functions on the F# side
            var fnexpr = DiscriminatedUnions.ExprNode.NewFunctionApplication("increment", BuildFSharpList(expr));
            var fn = (DiscriminatedUnions.ExprNode.FunctionApplication)fnexpr;
            Console.WriteLine(fn.Name());
            Console.WriteLine(fn.Argument(0).As<DiscriminatedUnions.ExprNode.VariableRef>().Name());

            // Can't use C# delegates for F# function arguments - see
            // FSharpx for helpers.
            //FSharpOption<string> bob = FSharpOption<string>.Some("bob");
            //Option.applyOrDefault(bob, s => "hello " + s, () => "bye");
        }

        // Dealing with F# lists in C# can be fiddly - give yourself
        // helper functions (either in C# or in F#)
        private static FSharpList<T> BuildFSharpList<T>(params T[] values)
        {
            var list = FSharpList<T>.Empty;
            for (int i = values.Length - 1; i >= 0; --i)
            {
                list = new FSharpList<T>(values[i], FSharpList<T>.Empty);
            }
            return list;
        }

        private static string Name(this DiscriminatedUnions.ExprNode.VariableRef variableRef)
        {
            return variableRef.Item;
        }

        private static string Name(this DiscriminatedUnions.ExprNode.FunctionApplication fn)
        {
            return fn.Item1;
        }

        private static IEnumerable<DiscriminatedUnions.ExprNode> Arguments(this DiscriminatedUnions.ExprNode.FunctionApplication fn)
        {
            return fn.Item2;
        }

        private static DiscriminatedUnions.ExprNode Argument(this DiscriminatedUnions.ExprNode.FunctionApplication fn, int index)
        {
            return fn.Item2.ElementAt(index);
        }

        private static T As<T>(this DiscriminatedUnions.ExprNode expr)
            where T : DiscriminatedUnions.ExprNode
        {
            return expr as T;
        }
    }
}
