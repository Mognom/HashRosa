namespace RobotPintor {
    public class Result {

        public int puntuacion;
        public Comando comando;

        public Result() {
            this.puntuacion = 0;
            this.comando = null;
        }

        public Result(int puntuacion, Comando comando) {
            this.puntuacion = puntuacion;
            this.comando = comando;
        }
    }
}