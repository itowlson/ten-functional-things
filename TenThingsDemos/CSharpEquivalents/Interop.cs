using Microsoft.FSharp.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpEquivalents
{
    public static class Interop
    {
        public static void Test()
        {
            var pt = new Immutable.Point3D(0.1, 0.2, 0.3);
            Console.WriteLine(pt);
            Console.WriteLine(pt.X);
            Console.WriteLine(Immutable.extend(pt, 0.4, 0.5, 0.6));

            var expr = DiscriminatedUnions.ExprNode.NewVariableRef("myVariable");
            Console.WriteLine(expr);
            Console.WriteLine(((DiscriminatedUnions.ExprNode.VariableRef)expr).Item);

            var fnexpr = DiscriminatedUnions.ExprNode.NewFunctionApplication("increment", new FSharpList<DiscriminatedUnions.ExprNode>(expr, FSharpList<DiscriminatedUnions.ExprNode>.Empty));
            var fn = (DiscriminatedUnions.ExprNode.FunctionApplication)fnexpr;
            Console.WriteLine(fn.Name());
            Console.WriteLine(fn.Argument(0).As<DiscriminatedUnions.ExprNode.VariableRef>().Name());
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
