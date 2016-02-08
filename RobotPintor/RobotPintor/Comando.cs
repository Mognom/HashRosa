
namespace RobotPintor {
    public class Comando {
        public string tipo;
        public string origen;
        public string destino;
        public string radio;

        public Comando(Punto origen) {
            this.tipo = "ERASE_CELL";
            this.origen = origen.x + " " + origen.y;
        }

        public Comando(Punto origen, int radio) {
            this.tipo = "PAINT_SQUARE";
            this.origen = origen.x + " " + origen.y;
            this.radio = radio.ToString();
        }

        public Comando(Punto origen, Punto destino) {
            this.tipo = "PAINT_LINE";
            this.origen = origen.x + " " + origen.y;
            this.destino = destino.x + " " + destino.y;
        }

        public override string ToString() {
            string toReturn = "";
            switch (tipo) {
                case "ERASE_CELL":
                    toReturn = this.tipo + " " + this.origen;
                    break;
                case "PAINT_SQUARE":
                    toReturn = this.tipo + " " + origen + " " + radio;
                    break;
                case "PAINT_LINE":
                    toReturn = this.tipo + " " + origen + " " + destino;
                    break;
                default:
                    toReturn = "Invalid Command";
                    break;
            }
            return toReturn;
        }
    }
}