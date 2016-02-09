namespace RobotPintor {
    public class Result {

        public int puntuacion {
            get;
            private set;
        }
        public Comando comando {
            get;
            private set;
        }

        public Result() {
            puntuacion = 0;
            comando = null;
        }

        public Result(int puntuacion, Comando comando) {
            this.puntuacion = puntuacion;
            this.comando = comando;
        }
    }
}