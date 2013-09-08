using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpEquivalents
{
    public sealed class Point3D
    {
        private readonly double _x;
        private readonly double _y;
        private readonly double _z;

        public Point3D(double x, double y, double z)
        {
            _x = x;
            _y = y;
            _z = z;
        }

        public double X
        {
            get { return _x; }
        }

        public double Y
        {
            get { return _y; }
        }

        public double Z
        {
            get { return _z; }
        }

        public override bool Equals(object obj)
        {
            Point3D other = obj as Point3D;

            if (other == null)
            {
                return false;
            }

            return other._x == _x && other._y == _y && other._z == _z;
        }

        public override int GetHashCode()
        {
            return _x.GetHashCode()
                + 19 * _y.GetHashCode()
                    + 359 * _z.GetHashCode();
        }
    }
}
