using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TriangleCheck
{
    class Program
    {
        private static bool ValidationArgument(string argument)
        {
            int result;
            return Int32.TryParse(argument, out result);
        }

        static void Main(string[] args)
        {
            int check = 0;

            if (args.Length != 3)
            {
                check = 1;
            }

            else if (!ValidationArgument(args[0]) || !ValidationArgument(args[1]) || !ValidationArgument(args[2]))
            {
                check = 1;
            }

            if (check != 1)
            {
                ParseArgument checkArguments = ParseArgument.Parse(args);

                CheckTriangleOnThreeSides checkTriangleOnThreeSides = new CheckTriangleOnThreeSides(checkArguments);

                Console.WriteLine(checkTriangleOnThreeSides.TriangleCheck());
            }
            else
            {
                Console.WriteLine("Неизвестная ошибка");
            }
        }
    }
}
