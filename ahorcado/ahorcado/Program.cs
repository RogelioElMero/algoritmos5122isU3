using System.Linq;
using System.Collections.Generic;

using System;
using System.Threading;

namespace Main
{
    public class main
    {
        //array con palabras
        static string[] palabras = new string[]
           {
               //20 figuras
               "cuadrado", "trapecio", "estrella", "cubo", "circulo",
               "rombo", "triangulo" ,"rectangulo","hexagono","pentagrama",
               "trapecio","trapezoide","piramide","esfera","pentagono",
               "octagono","romboide","cilindro","cono","paralelogramo",
               

               //20 frutas
               "naranja","durazno","kiwi","fresa","manzana",
               "mandarina","aguacate","platano","pera","sandia",
               "piña","arandano","granada","mango","limon",
               "cerezas","aceitunas","mora","uva","guayaba",

               //20 animales
               "conejo","perro","gato","vaca","caballo",
               "serpiente","ardilla","raton","pajaro","cabra",
               "burro","toro","aguila","ballena","pulpo","loro",
               "panda","jirafa","canguro","koala","leon",

               //20 colores
               "amarillo","azul","blanco","verde","morado",
               "turquesa","magenta","cian","rosado","lila",
               "fucsia","purpura","violeta","marron","negro",
               "rosa","neon","rojo","oro","plata",

               //6 palabras largas 
               "parangaricutirimicuaro","esternocleidomastoideo","anticonstitucionalidad","electroencefalografia","otorrinolaringologico",
               "constitucionalizacion",

               //30 palabras de programacion
               "clase","lenguaje","estructura","objeto","herencia",
               "abstraccion","polimorfismo","c#","java","javascript",
               "compilador","diagrama","static","public","private",
               "constructor","variable","dato","comentario","concatenar",
               "software","biblioteca","paquete","driver","sentencia",
               "bucle","constante","funcion","debuggear","repositorio",
           };

        static void Main(string[] args)
        {

            string palabra, Frase, opcion = "", nombre = "";
            int vidas, time = 200,inicio=0,final=0,grupo;
            Boolean finish = false;
            char p = ' ';
            char[] letras;
            char[] jugador;

            //consulta su nombre 
          
            Console.WriteLine("ingrese su nombre: ");
            nombre = Console.ReadLine();
            //tiempo muerto
            for (int i = 0; i < 4; i++)
            {

                Thread.Sleep(time);

                Console.Write(".");

            }

            Console.Clear();
            
            opcion = "YES";
            //inicio del juego
            do
            {
                //vidas y una variable bool que limiita si se hace una vez o otra vez
                vidas = 10;
                finish = false;
                
                if (opcion=="YES")
                {
                    Console.Write("ingrese el numero del grupo de palabras" +
                        " \n\t1.- Figuras" +
                        "\n\t2.- Frutas" +
                        "\n\t3.- Animales" +
                        "\n\t4.- Colores" +
                        "\n\t5.- palabras largas" +
                        "\n\t6.- programacion\n\t ->");
                    grupo = int.Parse(Console.ReadLine());
                    switch (grupo)
                    {
                        case 1:
                            inicio = 0;
                            final = 20;
                            break;
                        case 2:
                            inicio = 21;
                            final = 40;
                            break;
                        case 3:
                            inicio = 41;
                            final = 60;
                            break;
                        case 4:
                            inicio = 61;
                            final = 80;
                            break;
                        case 5:
                            inicio = 81;
                            final = 86;
                            break;
                        case 6:
                            inicio = 87;
                            final = 116;
                            break;
                    }
                }

               
                
                palabra = palabras[NumAleatorio(inicio,final)];
                letras = palabra.ToCharArray();


                jugador = iniciarArrayJ(palabra.Length);
                // indica la longitud de la palabra 
                Console.WriteLine("le toco una palabra de {0} de longitud", palabra.Length);

                //tiempo muerto 
                for (int i = 0; i < 5; i++)
                {

                    Thread.Sleep(time);

                    Console.Write(".");

                }

                //bucle que se repitira condicionando varias veces para imprimir
                //los muñecos y muestrara las letras que se agregar corrdctamente
                while (vidas > 0 && !finish)
                {
                    Console.Clear();

                    mostrarahor(vidas);

                    for (int i = 0; i < palabra.Length; i++)
                    {
                        Console.Write("{0} ", jugador[i]);
                    }

                    p = ' ';
                    Console.Write("\n\ningrese una letra o 1 para escribir toda palabra   \n >");
                    p = char.Parse(Console.ReadLine().Substring(0, 1));

                    //si el usuario sabe la respuesta pulsara 1
                    if (p == '1')
                    {

                        Console.Write("\ningrese la palabra \n >");
                        Frase = Console.ReadLine();

                        //si la palabra ingresada es correcta se finaliza el juego
                        if (Frase == palabra)
                        {
                            Console.Clear();
                            mostrarahor(vidas);
                            for (int i = 0; i < palabra.Length; i++)
                            {

                                Console.Write("{0} ", jugador[i]);

                            }
                            Console.WriteLine("\n\n\t\tfin del juego, FELICIDADES ->{0}<- la palabra es -> {1}\n\n", nombre, palabra);
                            finish = true;
                            //si ingresa una palabra mal se resta un minuto
                        }
                        else
                        {

                            vidas--;

                        }

                    }
                    else
                    {
                        //verifica si la letra esta en la palabra que previamente le toco 
                        if (existeEnPala(p, letras))
                        {
                            jugador = llenarArrayJ(letras, jugador, p);

                            if (sonIguales(letras, jugador))
                            {
                                Console.Clear();
                                mostrarahor(vidas);
                                for (int i = 0; i < palabra.Length; i++)
                                {

                                    Console.Write("{0} ", jugador[i]);

                                }
                                Console.WriteLine("\n\n\t\tfin del juego, FELICIDADES ->{0}<- la palabra es -> {1}\n\n", nombre, palabra);
                                finish = true;
                            }





                        }
                        //si la letra que ingreso erronea sele resta una vida
                        else
                        {
                            vidas--;
                            //si elcontador de vidas da cero el juego termina 
                            if (vidas == 0)
                            {
                                Console.Clear();
                                mostrarahor(vidas);
                                Console.WriteLine("\n\n\t\t GAME OVER \tla palabra era -> {0} <- \n", palabra);
                                finish = true;

                            }
                        }
                    }



                }
                //este es para volver a repetir todo el juego 
                Console.Write("\nvolver a intentarlo? escriba <yes>, \nescojer otro grupo de palabras escriba <YES>\no ingrese cualquier boton para finalizar\n\t->");
                opcion = Console.ReadLine();

            } while (opcion == "YES" || opcion == "yes");


        }
        /*
        ->nada
        <-int
       funcion que me devuelve un numero aleatorio
        */
        public static int NumAleatorio(int inicio,int final)
        {

            int randomNumber = new Random().Next(inicio, final+1);

            return randomNumber;
        }
        /*
        ->int
        <-char[]
        
        ingresa un numero o la longitud dd la palabra con la cual rrellena un array
        y este lo rellena con guiones bajos para mostrarlos despues
        */
        public static char[] iniciarArrayJ(int T)
        {
            char[] array = new char[T];

            for (int i = 0; i < T; i++)
            {
                array[i] = '_';
            }

            return array;
        }

        /*
        ->int[] x2
        <-boolean
        verifica si los 2 arrsh son iguales a su totalidad y devjelve true si es cierto
        */
        public static Boolean sonIguales(char[] array1, char[] array2)
        {
            Boolean[] array = new Boolean[array1.Length];
            Boolean valor = false;
            int X = 0;

            for (int i = 0; i < array1.Length; i++)
            {
                if (array1[i] == array2[i])
                {
                    array[i] = true;

                }
                else
                {
                    array[i] = false;
                }
            }

            for (int i = 0; i < array1.Length; i++)
            {
                if (!array[i])
                {
                    X++;
                }
            }

            if (X == 0)
            {
                valor = true;
            }

            return valor;
        }
        /*
        ->int[] x2 y 1 char
        <-char[]
         ingresa un array1 y sale un array2 que posee las letras p que se encuentran en array1
         */
        public static char[] llenarArrayJ(char[] letras, char[] jugador, char p)
        {
            char[] array = new char[letras.Length];

            for (int i = 0; i < letras.Length; i++)
            {
                array[i] = jugador[i];
            }

            for (int i = 0; i < letras.Length; i++)
            {
                if (letras[i] == p)
                {
                    array[i] = p;
                }
            }


            return array;
        }
        /*
        ->char y char[]
        <-boolean
        devuelve verdadero si se encuentra p en el areay y devuelve un verdadero si es cierto
        */
        public static Boolean existeEnPala(char p, char[] letras)
        {
            Boolean valor = false;
            for (int i = 0; i < letras.Length; i++)
            {
                if (letras[i] == p)
                {
                    valor = true;

                }
            }

            return valor;
        }
        /*
        ->int
        <-nada
        evalua cuantas vidas tiene y muestra el muñeco en consola.
        */
        public static void mostrarahor(int vidas)
        {
            switch (vidas)
            {
                case 0:
                    ahorcado11();
                    break;
                case 1:
                    ahorcado10();
                    break;
                case 2:
                    ahorcado9();
                    break;
                case 3:
                    ahorcado8();
                    break;
                case 4:
                    ahorcado7();
                    break;
                case 5:
                    ahorcado6();
                    break;
                case 6:
                    ahorcado5();
                    break;
                case 7:
                    ahorcado4();
                    break;
                case 8:
                    ahorcado3();
                    break;
                case 9:
                    ahorcado2();
                    break;
                case 10:
                    ahorcado1();
                    break;
            }

        }
        //boceto para 10 vidas
        public static void ahorcado1()
        {
            Console.WriteLine("|");
            Console.WriteLine("|");
            Console.WriteLine("|");
            Console.WriteLine("|");
            Console.WriteLine("|");
            Console.WriteLine("|");
            Console.WriteLine("|");
            Console.WriteLine("|");
            Console.WriteLine("|");
            Console.WriteLine("|");
            Console.WriteLine("|");
            Console.WriteLine("|");
            Console.WriteLine("|");
            Console.WriteLine("|");
            Console.WriteLine("|");
            Console.WriteLine("|");
            Console.WriteLine("|");
            Console.WriteLine("|");
            Console.WriteLine("|");
            Console.WriteLine("|");
            Console.WriteLine("|");
            Console.WriteLine("|");
            Console.WriteLine("-----------------");
        }
        //boceto para 9 vidas
        public static void ahorcado2()
        {
            Console.WriteLine("|-----------");
            Console.WriteLine("|");
            Console.WriteLine("|");
            Console.WriteLine("|");
            Console.WriteLine("|");
            Console.WriteLine("|");
            Console.WriteLine("|");
            Console.WriteLine("|");
            Console.WriteLine("|");
            Console.WriteLine("|");
            Console.WriteLine("|");
            Console.WriteLine("|");
            Console.WriteLine("|");
            Console.WriteLine("|");
            Console.WriteLine("|");
            Console.WriteLine("|");
            Console.WriteLine("|");
            Console.WriteLine("|");
            Console.WriteLine("|");
            Console.WriteLine("|");
            Console.WriteLine("|");
            Console.WriteLine("|");
            Console.WriteLine("-----------------");

        }
        //boceto para 8 vidas
        public static void ahorcado3()
        {
            Console.WriteLine("|-----------");
            Console.WriteLine("|  /");
            Console.WriteLine("| /");
            Console.WriteLine("|/");
            Console.WriteLine("|");
            Console.WriteLine("|");
            Console.WriteLine("|");
            Console.WriteLine("|");
            Console.WriteLine("|");
            Console.WriteLine("|");
            Console.WriteLine("|");
            Console.WriteLine("|");
            Console.WriteLine("|");
            Console.WriteLine("|");
            Console.WriteLine("|");
            Console.WriteLine("|");
            Console.WriteLine("|");
            Console.WriteLine("|");
            Console.WriteLine("|");
            Console.WriteLine("|");
            Console.WriteLine("|");
            Console.WriteLine("|");
            Console.WriteLine("-----------------");

        }
        //boceto para 7 vidas
        public static void ahorcado4()
        {
            Console.WriteLine("|-----------");
            Console.WriteLine("|  /       |");
            Console.WriteLine("| /        |");
            Console.WriteLine("|/         |");
            Console.WriteLine("|");
            Console.WriteLine("|");
            Console.WriteLine("|");
            Console.WriteLine("|");
            Console.WriteLine("|");
            Console.WriteLine("|");
            Console.WriteLine("|");
            Console.WriteLine("|");
            Console.WriteLine("|");
            Console.WriteLine("|");
            Console.WriteLine("|");
            Console.WriteLine("|");
            Console.WriteLine("|");
            Console.WriteLine("|");
            Console.WriteLine("|");
            Console.WriteLine("|");
            Console.WriteLine("|");
            Console.WriteLine("|");
            Console.WriteLine("-----------------");

        }
        //boceto para 6 vidas 
        public static void ahorcado5()
        {
            Console.WriteLine("|-----------");
            Console.WriteLine("|  /       |");
            Console.WriteLine("| /        |");
            Console.WriteLine("|/         |");
            Console.WriteLine("|         ***");
            Console.WriteLine("|        *   *");
            Console.WriteLine("|       *     *");
            Console.WriteLine("|       *     *");
            Console.WriteLine("|       *     *");
            Console.WriteLine("|        *   *");
            Console.WriteLine("|         ***");
            Console.WriteLine("|");
            Console.WriteLine("|");
            Console.WriteLine("|");
            Console.WriteLine("|");
            Console.WriteLine("|");
            Console.WriteLine("|");
            Console.WriteLine("|");
            Console.WriteLine("|");
            Console.WriteLine("|");
            Console.WriteLine("|");
            Console.WriteLine("|");
            Console.WriteLine("-----------------");
        }
        //boceto para 5 vidas
        public static void ahorcado6()
        {
            Console.WriteLine("|-----------");
            Console.WriteLine("|  /       |");
            Console.WriteLine("| /        |");
            Console.WriteLine("|/         |");
            Console.WriteLine("|         ***");
            Console.WriteLine("|        *   *");
            Console.WriteLine("|       *     *");
            Console.WriteLine("|       *     *");
            Console.WriteLine("|       *     *");
            Console.WriteLine("|        *   *");
            Console.WriteLine("|         ***");
            Console.WriteLine("|          *");
            Console.WriteLine("|          *");
            Console.WriteLine("|          *");
            Console.WriteLine("|          *");
            Console.WriteLine("|          *");
            Console.WriteLine("|          *");
            Console.WriteLine("|          *");
            Console.WriteLine("|");
            Console.WriteLine("|");
            Console.WriteLine("|");
            Console.WriteLine("|");
            Console.WriteLine("-----------------");
        }
        //boceto para 4 vidas
        public static void ahorcado7()
        {
            Console.WriteLine("|-----------");
            Console.WriteLine("|  /       |");
            Console.WriteLine("| /        |");
            Console.WriteLine("|/         |");
            Console.WriteLine("|         ***");
            Console.WriteLine("|        *   *");
            Console.WriteLine("|       *     *");
            Console.WriteLine("|       *     *");
            Console.WriteLine("|       *     *");
            Console.WriteLine("|        *   *");
            Console.WriteLine("|         ***");
            Console.WriteLine("|          *");
            Console.WriteLine("|        ***");
            Console.WriteLine("|        * *");
            Console.WriteLine("|        * *");
            Console.WriteLine("|        * *");
            Console.WriteLine("|          *");
            Console.WriteLine("|          *");
            Console.WriteLine("|");
            Console.WriteLine("|");
            Console.WriteLine("|");
            Console.WriteLine("|");
            Console.WriteLine("-----------------");



        }
        //boceto para 3 vidas 
        public static void ahorcado8()
        {
            Console.WriteLine("|-----------");
            Console.WriteLine("|  /       |");
            Console.WriteLine("| /        |");
            Console.WriteLine("|/         |");
            Console.WriteLine("|         ***");
            Console.WriteLine("|        *   *");
            Console.WriteLine("|       *     *");
            Console.WriteLine("|       *     *");
            Console.WriteLine("|       *     *");
            Console.WriteLine("|        *   *");
            Console.WriteLine("|         ***");
            Console.WriteLine("|          *");
            Console.WriteLine("|        *****");
            Console.WriteLine("|        * * *");
            Console.WriteLine("|        * * *");
            Console.WriteLine("|        * * *");
            Console.WriteLine("|          *");
            Console.WriteLine("|          *");
            Console.WriteLine("|");
            Console.WriteLine("|");
            Console.WriteLine("|");
            Console.WriteLine("|");
            Console.WriteLine("-----------------");



        }
        // boceto para 2 vidas 
        public static void ahorcado9()
        {
            Console.WriteLine("|-----------");
            Console.WriteLine("|  /       |");
            Console.WriteLine("| /        |");
            Console.WriteLine("|/         |");
            Console.WriteLine("|         ***");
            Console.WriteLine("|        *   *");
            Console.WriteLine("|       *     *");
            Console.WriteLine("|       *     *");
            Console.WriteLine("|       *     *");
            Console.WriteLine("|        *   *");
            Console.WriteLine("|         ***");
            Console.WriteLine("|          *");
            Console.WriteLine("|        *****");
            Console.WriteLine("|        * * *");
            Console.WriteLine("|        * * *");
            Console.WriteLine("|        * * *");
            Console.WriteLine("|          *");
            Console.WriteLine("|          *");
            Console.WriteLine("|         *");
            Console.WriteLine("|        *");
            Console.WriteLine("|       *");
            Console.WriteLine("|");
            Console.WriteLine("-----------------");



        }
        //boceto para 1 vida 
        public static void ahorcado10()
        {
            Console.WriteLine("|-----------");
            Console.WriteLine("|  /       |");
            Console.WriteLine("| /        |");
            Console.WriteLine("|/         |");
            Console.WriteLine("|         ***");
            Console.WriteLine("|        *   *");
            Console.WriteLine("|       *     *");
            Console.WriteLine("|       *     *");
            Console.WriteLine("|       *     *");
            Console.WriteLine("|        *   *");
            Console.WriteLine("|         ***");
            Console.WriteLine("|          *");
            Console.WriteLine("|        *****");
            Console.WriteLine("|        * * *");
            Console.WriteLine("|        * * *");
            Console.WriteLine("|        * * *");
            Console.WriteLine("|          *");
            Console.WriteLine("|          *");
            Console.WriteLine("|         * *");
            Console.WriteLine("|        *   *");
            Console.WriteLine("|       *     *");
            Console.WriteLine("|");
            Console.WriteLine("-----------------");



        }
        //boceto para 0 vidas
        public static void ahorcado11()
        {
            Console.WriteLine("|-----------");
            Console.WriteLine("|  /       |");
            Console.WriteLine("| /        |");
            Console.WriteLine("|/         |");
            Console.WriteLine("|         ***");
            Console.WriteLine("|        *X X*");
            Console.WriteLine("|       *     *");
            Console.WriteLine("|       *     *");
            Console.WriteLine("|       *  x  *");
            Console.WriteLine("|        *   *");
            Console.WriteLine("|         ***");
            Console.WriteLine("|          *");
            Console.WriteLine("|        *****");
            Console.WriteLine("|        * * *");
            Console.WriteLine("|        * * *");
            Console.WriteLine("|        * * *");
            Console.WriteLine("|          *");
            Console.WriteLine("|          *");
            Console.WriteLine("|         * *");
            Console.WriteLine("|        *   *");
            Console.WriteLine("|       *     *");
            Console.WriteLine("|");
            Console.WriteLine("-----------------");

        }



    }
}
