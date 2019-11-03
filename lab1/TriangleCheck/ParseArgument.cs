using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TriangleCheck
{
    public class ParseArgument : INumberProvider
    {
        public int A { get; }
        public int B { get; }
        public int C { get; }
        public ParseArgument(int a, int b, int c)
        {
            A = a;
            B = b;
            C = c;
        }

        public static ParseArgument Parse(string[] args)
        {
            int first = int.Parse(args[0]);
            int second = int.Parse(args[1]);
            int third = int.Parse(args[2]);

            return new ParseArgument(first, second, third);
        }

        public static bool ValidationArgument(string argument)
        {
            int result;
            return Int32.TryParse(argument, out result);
        }
    }
}
