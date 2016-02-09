﻿using System;
using System.Collections.Generic;
using System.IO;

namespace RobotPintor {
    internal class Pintar {

        private string file;
        private char[,] matrizInicial;
        private char[,] matrizResultado;
        private List<Comando> resultCommands = new List<Comando>();

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
                    Console.WriteLine("Guardando: " + i + "," + j);
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
            //PrintMatriz(matrizInicial, this.ancho, this.alto);
            //Console.WriteLine("");
            Console.WriteLine("Pintando");

            for (int i = 0; i < alto; i++) {
                for (int j = 0; j < ancho; j++) {
                    //Console.WriteLine("Pensando: " + i + "," + j);
                    if (matrizInicial[i, j] == char.Parse("#")) {
                        //Console.WriteLine("Exito: #");
                        Pensar(new Punto(i,j));
                    }
                }
            }
            /*
            PintarCuadrado(new Punto(3, 3), 2);
            PintarLinea(new Punto(8, 2), new Punto(8, 6));
            PintarLinea(new Punto(8, 7), new Punto(10, 7));*/
            PrintMatriz(matrizInicial, this.ancho, this.alto);
            PrintMatriz(matrizResultado, this.ancho, this.alto);
            /*Console.WriteLine("");
            Console.WriteLine(resultCommands.Count);
            for (int i = 0; i < resultCommands.Count; i++) {
                Console.WriteLine(resultCommands[i]);
            }*/

            StreamWriter writer = new StreamWriter(@"..\..\..\" + file.Split(char.Parse("."))[0] + ".result");
            writer.WriteLine(resultCommands.Count);
            for (int i = 0; i < resultCommands.Count; i++) {
                writer.WriteLine(resultCommands[i]);
            }

        }

        private void Pensar(Punto origen) {
            Punto destino = origen;
            Result resultado = new Result(1, new Comando(origen, 0));

            int rHComp = 1;
            Punto destinoH = origen;
            Result rHoriz = new Result(rHComp, new Comando(origen, 0));

            while (origen.y + rHComp < ancho && matrizInicial[origen.x, origen.y + rHComp] == char.Parse("#") ) {
                //Console.WriteLine("Exito Contiguo: " + (origen.y + rHComp));
                destinoH = new Punto(origen.x, origen.y + rHComp);
                rHoriz = new Result(rHComp, new Comando(origen, destinoH));
                rHComp++;
            }
            // Comprobar horizontal
            int rVComp = 1;
            Punto destinoV = origen;
            Result rVert = new Result(rVComp, new Comando(origen, 0));

            while (origen.x + rVComp < alto && matrizInicial[origen.x + rVComp, origen.y] == char.Parse("#")) {
                //Console.WriteLine("Exito Vertical: " + (origen.x + rVComp));
                destinoV = new Punto(origen.x + rVComp, origen.y);
                rVert = new Result(rVComp, new Comando(origen, destinoV));
                rVComp++;
            }

            if (rHoriz.puntuacion >= rVert.puntuacion) {
                resultado = rHoriz;
                destino = destinoH;
            } else {
                resultado = rVert;
                destino = destinoV;
            }


            // Comprobar vertical
            resultCommands.Add(resultado.comando);
            PintarLinea(origen, destino);
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
                    for (int i = 0; i <= origen.y - destino.y; i++) {
                        matrizInicial[origen.x, origen.y + i] = char.Parse("♥");
                        matrizResultado[origen.x, origen.y + i] = char.Parse("#");
                    }
                } else {
                    for (int i = 0; i <= destino.y - origen.y; i++) {
                        matrizInicial[origen.x, destino.y - i] = char.Parse("♥");
                        matrizResultado[origen.x, destino.y - i] = char.Parse("#");
                    }
                }
                //Linea Horizontal
            } else if (origen.y == destino.y) {
                if (destino.x - origen.x < 0) {
                    for (int i = 0; i <= origen.x - destino.x; i++) {
                        matrizInicial[origen.x + i, origen.y] = char.Parse("♥");
                        matrizResultado[origen.x + i, origen.y] = char.Parse("#");
                    }
                } else {
                    for (int i = 0; i <= destino.x - origen.x; i++) {
                        matrizInicial[destino.x - i, origen.y] = char.Parse("♥");
                        matrizResultado[destino.x - i, origen.y] = char.Parse("#");
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