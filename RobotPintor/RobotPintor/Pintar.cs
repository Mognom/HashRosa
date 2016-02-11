using System;
using System.IO;

/*
Lanzar dos threads para recorrer matriz en vertical y horizontal
Algoritmo, cuando #, calculas linea vertical y horizontal, a partir de ellas buscar cuadrados, de los cuadrados
obtenidos quedarse mayor puntuaje = numero de asteriscos.
Los cuadrados, calcularlos con vacios y estos restarselos a la puntuacion.

*/

namespace RobotPintor {
    internal class Pintar {

        private string file;
        private char[,] matrizInicial;
        private char[,] matrizResultado;
        private int ancho;
        private int alto;

        public Pintar(string file) {
            this.file = file;
            this.inicializarComponentes();
        }

        private void inicializarComponentes() {
            StreamReader toPaint = new StreamReader(file);

            string dimension = toPaint.ReadLine();
            string[] dimensionSplit = dimension.Split(new char[0], StringSplitOptions.RemoveEmptyEntries);

            this.alto = int.Parse(dimensionSplit[0]);
            this.ancho = int.Parse(dimensionSplit[1]);

            Console.WriteLine("alto: " + alto + ", ancho: " + ancho);
            matrizInicial = new char[alto, ancho];
            matrizResultado = new char[alto, ancho];
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
            PintarCuadrado(new Punto(3, 3), 2);
            PintarLinea(new Punto(8, 2), new Punto(8, 6));
            PintarLinea(new Punto(8, 7), new Punto(10, 7));
            PrintMatriz(matrizResultado, this.ancho, this.alto);
        }

        private void PintarCuadrado(Punto centro, int radio) {
            matrizResultado[centro.x, centro.y] = char.Parse("#");
            if (radio > 0) {
                for (int i = -radio; i < radio + 1; i++) {
                    for (int j = -radio; j < radio + 1; j++) {
                        matrizResultado[centro.x + i, centro.y + j] = char.Parse("#");
                    }
                }
            }
        }

        private void PintarLinea(Punto origen, Punto destino) {
            if (origen.x == destino.x) {
                if (destino.y - origen.y < 0) {
                    for (int i = 0; i < origen.y - destino.y; i++) {
                        matrizResultado[origen.x, origen.y + i] = char.Parse("#");
                    }
                } else {
                    for (int i = 0; i < destino.y - origen.y; i++) {
                        matrizResultado[origen.x, destino.y + i] = char.Parse("#");
                    }
                }
                //Linea Horizontal
            } else if (origen.y == destino.y) {
                if (destino.x - origen.x < 0) {
                    for (int i = 0; i < origen.x - destino.x; i++) {
                        matrizResultado[origen.x + i, origen.y] = char.Parse("#");
                    }
                } else {
                    for (int i = 0; i < destino.x - origen.x; i++) {
                        matrizResultado[destino.x + i, origen.y] = char.Parse("#");
                    }
                }
                //Linea Vertical
            } else {
                Console.WriteLine("Unspected Value");
            }
        }

        private void PrintMatriz(char[,] matriz, int ancho, int alto) {
            for (int i = 0; i < alto; i++) {
                Console.WriteLine("");
                for (int j = 0; j < ancho; j++) {
                    Console.Write(matriz[i, j]);
                }
            }

        }
    }
}