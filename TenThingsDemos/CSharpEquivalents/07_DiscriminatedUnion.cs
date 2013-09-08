using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpEquivalents
{
    public abstract class ExprNode
    {
        public abstract int Eval(Func<string, int> environment);
    }

    public class NumericLiteral : ExprNode
    {
        private readonly int _value;

        public NumericLiteral(int value)
        {
            _value = value;
        }

        public override int Eval(Func<string, int> environment)
        {
            return _value;
        }
    }

    public class VariableRef : ExprNode
    {
        private readonly string _name;

        public VariableRef(string name)
        {
            _name = name;
        }

        public override int Eval(Func<string, int> environment)
        {
            return environment(_name);
        }
    }

    public class FunctionApplication : ExprNode
    {
        private readonly string _func;
        private readonly IList<ExprNode> _args;

        public FunctionApplication(string func, IList<ExprNode> args)
        {
            _func = func;
            _args = args;
        }

        public override int Eval(Func<string, int> environment)
        {
            var argvals = _args.Select(a => a.Eval(environment)).ToList();
            return Functions[_func](argvals);
        }

        private static readonly Dictionary<string, Func<List<int>, int>> Functions =
            new Dictionary<string, Func<List<int>, int>>
            {
                { "factorial", args => Enumerable.Range(1, args[0]).Aggregate((x, y) => x * y) },
            };

        public IList<ExprNode> Arguments
        {
            get { return _args; }
        }
    }

    public class InfixApplication : ExprNode
    {
        private readonly string _op;
        private readonly ExprNode _left;
        private readonly ExprNode _right;

        public InfixApplication(string op, ExprNode left, ExprNode right)
        {
            _op = op;
            _left = left;
            _right = right;
        }

        public override int Eval(Func<string, int> environment)
        {
            var larg = _left.Eval(environment);
            var rarg = _right.Eval(environment);
            return Operators[_op](larg, rarg);
        }

        private static readonly Dictionary<string, Func<int, int, int>> Operators =
            new Dictionary<string, Func<int, int, int>>
            {
                { "+", (x, y) => x + y },
            };

        public ExprNode Left
        {
            get { return _left; }
        }

        public ExprNode Right
        {
            get { return _right; }
        }
    }
}
