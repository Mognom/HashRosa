using System;
using System.IO;

namespace RobotPintor {
    internal class Pintar {

        private string file;
        private char[,] matrizInicial;

        public Pintar(string file) {
            this.file = file;
            this.inicializarComponentes();
        }

        private void inicializarComponentes() {
            StreamReader toPaint = new StreamReader(file);

            string dimension = toPaint.ReadLine();
            string[] dimensionSplit = dimension.Split(new char[0], StringSplitOptions.RemoveEmptyEntries);

            int alto, ancho;
            alto = int.Parse(dimensionSplit[0]);
            ancho = int.Parse(dimensionSplit[1]);

            Console.WriteLine("alto: " + alto + ", ancho: " + ancho);
            matrizInicial = new char[alto, ancho];
            for (int i = 0; i < alto; i++) {
                string tempLine = toPaint.ReadLine();
                for (int j = 0; j < ancho; j++) {
                    matrizInicial[i, j] = tempLine[j];
                }
            }
            /*
            for (int i = 0; i < alto; i++) {
                Console.WriteLine("");
                for (int j = 0; j < ancho; j++) {
                    Console.Write(matrizInicial[i, j]);
                }
            }*/
        }

        public void StartPaint() {
            Console.WriteLine("Pintando");

        }

        private void PintarCuadrado(Punto centro, int radio) {

        }

        private void PintarLinea(Punto origen, Punto destino) {
            if (origen.x == destino.x) {
                //Linea Horizontal
            } else if (origen.y == destino.y) {
                //Linea Vertical
            } else {
                Console.WriteLine("Unspected Value");
            }
        }
    }
}