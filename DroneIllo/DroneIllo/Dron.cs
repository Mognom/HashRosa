using System.Collections.Generic;

namespace DroneIllo {
    public class Dron {
        public int capacidad;
        public int carga;

        public Punto posicionActual;
        public Dictionary<Producto, int> tipoCarga;
    }
}