using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotPintor {
    class Program {
        static void Main(string[] args) {
            String file = "";
            if (args.Length == 0) {
                Console.WriteLine("File is required");
            } else {
                file = args[0];
                Console.WriteLine(file);
            }
            Pintar mural = new Pintar(file);
            mural.StartPaint();
            Console.Read();
        }
    }
}
