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
        }

        private static string Name(this DiscriminatedUnions.ExprNode.VariableRef variableRef)
        {
            return variableRef.Item;
        }
    }
}
