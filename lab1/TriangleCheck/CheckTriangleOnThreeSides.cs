using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TriangleCheck
{
    public class CheckTriangleOnThreeSides
    {
        private readonly INumberProvider _numberProvider;

        public CheckTriangleOnThreeSides(INumberProvider numberProvider)
        {
            _numberProvider = numberProvider;
        }

        public string TriangleCheck()
        {
            if (CheckNotTriangle())
            {
                return "Не треугольник";
            }

            if (CheckEquilateralTriangle())
            {
                return "Равносторонний треугольник";
            }

            if (CheckIsoscelesTriangle())
            {
                return "Равнобедренный треугольник";
            }

            return "Обычный треугольник";
        }

        private bool CheckNotTriangle()
        {
            if (_numberProvider.A == 0 && _numberProvider.B == 0 && _numberProvider.C == 0)
            {
                return true;
            }
            else if (_numberProvider.A + _numberProvider.B <= _numberProvider.C)
            {
                return true;
            }
            else if (_numberProvider.A + _numberProvider.C <= _numberProvider.B)
            {
                return true;
            }
            else if (_numberProvider.B + _numberProvider.C <= _numberProvider.A)
            {
                return true;
            }

            return false;
        }

        private bool CheckEquilateralTriangle()
        {
            if ((_numberProvider.A == _numberProvider.B) && (_numberProvider.A == _numberProvider.C) && (_numberProvider.B == _numberProvider.C))
            {
                return true;
            }
            return false;
        }

        private bool CheckIsoscelesTriangle()
        {
            if ((_numberProvider.A == _numberProvider.B) || (_numberProvider.A == _numberProvider.C) || (_numberProvider.B == _numberProvider.C))
            {
                return true;
            }
            return false;
        }
    }
}
