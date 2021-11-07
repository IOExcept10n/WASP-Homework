using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubwayProject
{
    public class MCCLine : Line
    {
        public MCCLine(string name, ConsoleColor color) : base(name, color)
        {

        }

        public override void PrintLine()
        {
            Console.ForegroundColor = Color;
            Console.Write("MCC line, ");
            base.PrintLine();
        }
    }
}
