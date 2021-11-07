using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubwayProject
{
    public class UndergroundLine : Line
    {

        public UndergroundLine(string name, ConsoleColor color) : base(name, color)
        {

        }

        public override void PrintLine()
        {
            Console.ForegroundColor = Color;
            Console.Write("Underground line, ");
            base.PrintLine();
        }
    }
}
