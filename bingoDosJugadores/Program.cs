using System;

namespace bingoDosJugadores
{
    class Program
    {
        static void Main(string[] args)
        {
            string[,] cartonJugador1 = new string[4, 6];
            string[,] cartonJugador2 = new string[4, 6];
            string nombreUno = "";
            string nombreDos = "";
            int aciertosJugador1 = 0;
            int aciertosJugador2 = 0;
            bool ganador = false;
            
            int contadorTiros = 1;
            string[] ary_bolillas = new string[99];
            int tirosFaltantes = 99;

            Console.WriteLine("Bienvenidos al Bingo!!!");
            Console.WriteLine("\nJugador 1 ingresa tu nombre: ");
            nombreUno = Console.ReadLine();
            Console.WriteLine("\nJugador 2 ingresa tu nombre: ");
            nombreDos = Console.ReadLine();

            Console.Clear();
            cartonJugador1 = generarCarton(cartonJugador1);
            cartonJugador2 = generarCarton(cartonJugador2);

            imprimirCartones(nombreUno, nombreDos, cartonJugador1, cartonJugador2, aciertosJugador1, aciertosJugador2);
            Console.WriteLine("\n¡Que comience el juego. Tiren la primer bolilla!");
            Console.ReadKey(); 


            while (!ganador)
            {
                Console.Clear();

                // No me funciona al llamarlo en una función (Puede ser problemas con los contadores
                //sacarBolillas(contadorTiros, tirosFaltantes, ary_bolillas);

                Random rnd = new Random();
                int num_random = rnd.Next(1, 100);
                if(num_random < 10) ary_bolillas[contadorTiros] = "0" + num_random.ToString();
                else ary_bolillas[contadorTiros] = num_random.ToString();

                contadorTiros = contadorTiros + 1;
                tirosFaltantes = tirosFaltantes - 1;

                imprimirCartones(nombreUno, nombreDos, cartonJugador1, cartonJugador2, aciertosJugador1, aciertosJugador2);

                Console.WriteLine("\nPresione enter para tirar una bolilla");
                for (int i = 0; i < ary_bolillas.Length; i++) Console.Write(ary_bolillas[i] + " ");

                tacharNumero(cartonJugador1,ary_bolillas,nombreUno, aciertosJugador1);
                tacharNumero(cartonJugador2,ary_bolillas, nombreDos, aciertosJugador2);
                aciertosJugador1 =  contarAciertos(cartonJugador1, aciertosJugador1);
                aciertosJugador2 =  contarAciertos(cartonJugador2, aciertosJugador2);

                ganador = validarGanador(aciertosJugador1, nombreUno, ganador);
                ganador = validarGanador(aciertosJugador2, nombreDos, ganador);

                Console.ReadKey();
            }

            Console.ReadKey();
        }


     
        static string[,] generarCarton(string[,] cartonJugador)
        {
            Random rnd = new Random();

            int num_random = rnd.Next(1, 100);

            for(int i = 0; i < 4; i++)
            {
                for(int j = 0; j < 6; j++)
                {
                    num_random = rnd.Next(1, 100);
                    if (num_random < 10) cartonJugador[i, j] = "0" + num_random.ToString();
                    else cartonJugador[i, j] = num_random.ToString();
                }
            }

            cartonJugador = ordenarCarton(cartonJugador);
            return cartonJugador;
        }
        static string[,] ordenarCarton(string[,] cartonJugador)
        {
            string[] cartonUnidimensional = new string[24];
            int contador = 0;

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    cartonUnidimensional[contador] = cartonJugador[i, j];
                    contador++;
                }
            }
            Array.Sort(cartonUnidimensional);

            contador = 0;
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    cartonJugador[i, j] = cartonUnidimensional[contador];
                    contador++;
                }
            }
            return cartonJugador;
        }
        static void imprimirCartones(string nombreUno, string nombreDos, string[,] cartonJugador1, string[,] cartonJugador2, int aciertosJugador1, int aciertosJugador2 )
        {
            
            Console.WriteLine("Jugador 1: " + nombreUno + "\t\t\t\t\t\tJugador 2: " + nombreDos);
            
            Console.WriteLine("Aciertos: " + aciertosJugador1 + "\t\t\t\t\t\t\tAciertos: " + aciertosJugador2);


            Console.WriteLine("\n-------------------------------------------               -------------------------------------------");
            Console.WriteLine("|  {0}  |  {1}  |  {2}  |  {3}  |  {4}  |  {5}  |               |  {6}  |  {7}  |  {8}  |  {9}  |  {10}  |  {11}  | ",
                cartonJugador1[0, 0],
                cartonJugador1[0, 1],
                cartonJugador1[0, 2],
                cartonJugador1[0, 3],
                cartonJugador1[0, 4],
                cartonJugador1[0, 5],

                cartonJugador2[0, 0],
                cartonJugador2[0, 1],
                cartonJugador2[0, 2],
                cartonJugador2[0, 3],
                cartonJugador2[0, 4],
                cartonJugador2[0, 5]
                );
            Console.WriteLine("-------------------------------------------               -------------------------------------------");
            Console.WriteLine("|  {0}  |  {1}  |  {2}  |  {3}  |  {4}  |  {5}  |               |  {6}  |  {7}  |  {8}  |  {9}  |  {10}  |  {11}  | ",
               cartonJugador1[1, 0],
               cartonJugador1[1, 1],
               cartonJugador1[1, 2],
               cartonJugador1[1, 3],
               cartonJugador1[1, 4],
               cartonJugador1[1, 5],

                cartonJugador2[1, 0],
                cartonJugador2[1, 1],
                cartonJugador2[1, 2],
                cartonJugador2[1, 3],
                cartonJugador2[1, 4],
                cartonJugador2[1, 5]
               );
            Console.WriteLine("-------------------------------------------               -------------------------------------------");
            Console.WriteLine("|  {0}  |  {1}  |  {2}  |  {3}  |  {4}  |  {5}  |               |  {6}  |  {7}  |  {8}  |  {9}  |  {10}  |  {11}  | ",
               cartonJugador1[2, 0],
               cartonJugador1[2, 1],
               cartonJugador1[2, 2],
               cartonJugador1[2, 3],
               cartonJugador1[2, 4],
               cartonJugador1[2, 5],

               cartonJugador2[2, 0],
               cartonJugador2[2, 1],
               cartonJugador2[2, 2],
               cartonJugador2[2, 3],
               cartonJugador2[2, 4],
               cartonJugador2[2, 5]
               );
            Console.WriteLine("-------------------------------------------               -------------------------------------------");
            Console.WriteLine("|  {0}  |  {1}  |  {2}  |  {3}  |  {4}  |  {5}  |               |  {6}  |  {7}  |  {8}  |  {9}  |  {10}  |  {11}  | ",
               cartonJugador1[3, 0],
               cartonJugador1[3, 1],
               cartonJugador1[3, 2],
               cartonJugador1[3, 3],
               cartonJugador1[3, 4],
               cartonJugador1[3, 5],

               cartonJugador2[3, 0],
               cartonJugador2[3, 1],
               cartonJugador2[3, 2],
               cartonJugador2[3, 3],
               cartonJugador2[3, 4],
               cartonJugador2[3, 5]
               );
            Console.WriteLine("-------------------------------------------               -------------------------------------------\n");
        }
        //static void sacarBolillas(int contadorTiros, int tirosFaltantes, string[] ary_bolillas)
        //{

        //    Random rnd = new Random();
        //    int num_random = rnd.Next(1, 100);

        //    ary_bolillas[contadorTiros] = num_random.ToString();
        //    contadorTiros = contadorTiros + 1;
        //    tirosFaltantes = tirosFaltantes - 1;

        //    Console.WriteLine("\nPresione enter para tirar una bolilla");
        //    Console.WriteLine("La longitud del array es de: " + ary_bolillas.Length);
        //    for (int i = 0; i < ary_bolillas.Length; i++)
        //    {
        //        Console.Write(ary_bolillas[i] + " ");
        //    }
        //}
        static string[,] tacharNumero(string[,]cartonJugador, string[]ary_bolillas, string nombreJugador, int aciertosJugador)
        {
            int contador = 0;
            while(contador < ary_bolillas.Length)
            {
                for (int i = 0; i < 4; i++)
                {
                    for (int j = 0; j < 6; j++)
                    {
                        if (cartonJugador[i, j] == ary_bolillas[contador])
                        {
                            cartonJugador[i, j] = "X ";
                            Console.WriteLine("\n\n\t" + nombreJugador + " tachaste el número " + ary_bolillas[contador]);
                            aciertosJugador++;
                        }
                    }
                }

                contador++;
            }

            return cartonJugador;
        }
        static int contarAciertos(string[,]cartonJugador , int aciertosJugador)
        {
            int aciertos = 0;
            for(int i = 0; i < 4; i++)
            {
                for(int j = 0; j < 6; j++)
                {
                    if(cartonJugador[i,j] == "X ")
                    {
                        aciertos = aciertos + 1;
                    }
                }

            }
            return aciertos; 
        }
        static bool validarGanador(int aciertosJugador, string nombreJugador, bool ganador)
        {
            if (aciertosJugador == 24)
            {
                ganador = true;
                Console.WriteLine("\n¡¡¡Felicitaciones " + nombreJugador + " has ganado!!!");
            } else ganador = false; 

            return ganador;
        }

   

    }
}

