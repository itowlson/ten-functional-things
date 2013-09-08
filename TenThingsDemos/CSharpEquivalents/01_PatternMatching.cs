using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpEquivalents
{
    public class PatternMatching
    {
        public static int EvalOp(string opname, int lval, int rval)
        {
            Func<int, int, int> op;

            switch (opname)
            {
                case "+": op = (x, y) => x + y; break;
                case "-": op = (x, y) => x - y; break;
                case "*": op = (x, y) => x * y; break;
                case "/": op = (x, y) => x / y; break;
                default: throw new ArgumentException("unknown operation");
            }

            return op(lval, rval);
        }

        public static int Depth(ExprNode expr)
        {
            if (expr is NumericLiteral)
            {
                return 1;
            }
            if (expr is VariableRef)
            {
                return 1;
            }
            if (expr is FunctionApplication)
            {
                return 1 + ((FunctionApplication)expr).Arguments.Max(e => Depth(e));
            }

            Debug.Assert(expr is InfixApplication);  // brittle: what if someone later adds a new subtype of expression?

            var infixAppl = (InfixApplication)expr;
            return 1 + Math.Max(Depth(infixAppl.Left), Depth(infixAppl.Right));
        }
    }
}
