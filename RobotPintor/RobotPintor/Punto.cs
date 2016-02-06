using System;

namespace RobotPintor {
    public class Punto {

        public int x
        {
            get;
            private set;
        }

        public int y {
            get;
            private set;
        }

        public Punto() {
            Console.WriteLine("Es necesario especificar el punto");
        }

        public Punto(int x, int y) {
            this.x = x;
            this.y = y;
        }
    }
}