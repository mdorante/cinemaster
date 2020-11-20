using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Cinemaster.Lib;

namespace Cinemaster
{
    class Program
    {
        public static void MostrarMensaje(string mensaje, ConsoleColor color)
        {
            Console.Clear();
            Console.ForegroundColor = color;
            Console.WriteLine(mensaje);
            Console.ResetColor();

            Console.WriteLine("\nPresione Enter para volver.");
            Console.ReadLine();
        }

        public static bool ValidarOpcion(int valorMin, int valorMax, int opcion, string mensaje)
        {
            if (opcion < valorMin || opcion > valorMax)
            {
                MostrarMensaje(mensaje, ConsoleColor.Red);
                return false;
            }
            else
            {
                return true;
            }
        }

        public static void MostrarTextoConPadding(int cantRef, string texto)
        {
            int mult = 0;
            int cantRest = 0;

            if (texto == "ENTRADA")
            {
                mult = 2;
                cantRest = 7;
            }

            if (texto == "PANTALLA")
            {
                mult = 5;
                cantRest = 8;
            }

            int cantCharEntrada = (mult * cantRef) - cantRest;
            int mitadEntrada = cantCharEntrada / 2;
            int lPad = mitadEntrada;
            int rPad = mitadEntrada;

            if (cantCharEntrada % 2 != 0)
                rPad += 1;

            for (int i = 0; i < lPad; i++)
            {
                Console.Write("=");
            }
            Console.Write(texto);
            for (int i = 0; i < rPad; i++)
            {
                Console.Write("=");
            }
            Console.WriteLine();
        }

        public static void CargarDataCine(Cine cine)
        {
            Sala sala1 = new Sala(1, 17, 28);
            Sala sala2 = new Sala(2, 28, 39);
            Sala sala3 = new Sala(3, 24, 24);
            Sala sala4 = new Sala(4, 18, 25);
            Sala sala5 = new Sala(5, 24, 17);
            Sala sala6 = new Sala(6, 25, 30);

            cine.Salas.Add(sala1);
            cine.Salas.Add(sala2);
            cine.Salas.Add(sala3);
            cine.Salas.Add(sala4);
            cine.Salas.Add(sala5);
            cine.Salas.Add(sala6);

            Dictionary<Persona, string> beautyCast = new Dictionary<Persona, string>();
            beautyCast.Add(new Persona("Paige", "O'Hara"), "Belle (voice)");
            beautyCast.Add(new Persona("Robby", "Benson"), "Beast (voice)");
            beautyCast.Add(new Persona("Richard", "White"), "Gaston (voice)");
            beautyCast.Add(new Persona("Jerry", "Orbach"), "Lumiere (voice)");
            beautyCast.Add(new Persona("David", "Ogden"), "Cogsworth (voice)");
            beautyCast.Add(new Persona("Angela", "Lansbury"), "Mrs. Potts (voice)");

            string beautySynopsis = "An enchantress disguised as an old beggar woman offers a rose to a cruel and selfish prince in exchange for shelter from a storm." +
                "\nWhen he refuses, she reveals her identity. As punishment for the prince's lack of compassion, the enchantress transforms him into a beast and his servants into household objects." +
                "\nShe casts a spell on the rose and warns the prince that the spell will only be broken if he learns to love another," +
                " and be loved in return, before the last petal falls, or he will remain a beast forever.";

            Dictionary<Persona, string> lionCast = new Dictionary<Persona, string>();
            lionCast.Add(new Persona("Matthew", "Broderick"), "Simba (voice)");
            lionCast.Add(new Persona("James", "Jones"), "Mufasa (voice)");
            lionCast.Add(new Persona("Jeremy", "Irons"), "Scar (voice)");
            lionCast.Add(new Persona("Moira", "Kelly"), "Nala (voice)");
            lionCast.Add(new Persona("Nathan", "Lane"), "Timon (voice)");
            lionCast.Add(new Persona("Ernie", "Sabella"), "Pumbaa (voice)");

            string lionSynopsis = "In the Pride Lands of Africa, a pride of lions rule over the animal kingdom from Pride Rock." +
                "\nKing Mufasa's and Queen Sarabi's newborn son, Simba, is presented to the gathering animals by Rafiki the mandrill," +
                " the kingdom's shaman and advisor.";

            Dictionary<Persona, string> aladdinCast = new Dictionary<Persona, string>();
            aladdinCast.Add(new Persona("Will", "Smith"), "Genie");
            aladdinCast.Add(new Persona("Mena", "Massoud"), "Aladdin");
            aladdinCast.Add(new Persona("Naomi", "Scott"), "Princess Jasmine");
            aladdinCast.Add(new Persona("Marwan", "Kenzaro"), "Jafar");

            string aladdinSynopsis = "Aladdin, a street urchin in the Arabian city of Agrabah, and his monkey Abu meet Princess Jasmine," +
                " who has snuck away from her sheltered life in the palace. " +
                "\nJasmine wishes to succeed her father as Sultan, but is instead expected to marry one of her royal suitors," +
                " including the charming yet dimwitted Prince Anders. " +
                "\nJafar, the grand vizier, schemes to overthrow the Sultan and seeks a magic lamp hidden in the Cave of Wonders," +
                " but only \"the diamond in the rough\" can enter the cave.";

            Pelicula laBellaYLaBestia = new Pelicula("La Bella y la Bestia", "Beaty and the Beast", new Persona("Gary", "Trousdale"), beautyCast, new TimeSpan(1, 24, 0), beautySynopsis);
            Pelicula elReyLeon = new Pelicula("El Rey Leon", "The Lion King", new Persona("Roger", "Allers"), lionCast, new TimeSpan(1, 28, 0), lionSynopsis);
            Pelicula aladdin = new Pelicula("Aladdin (2019)", "Aladdin (2019)", new Persona("Guy", "Ritchie"), aladdinCast, new TimeSpan(2, 8, 0), aladdinSynopsis);

            cine.Peliculas.Add(laBellaYLaBestia);
            cine.Peliculas.Add(elReyLeon);
            cine.Peliculas.Add(aladdin);

            cine.Funciones.Add(new Funcion(laBellaYLaBestia, sala1, new DateTime(2020, 12, 18, 11, 30, 0)));
            cine.Funciones.Add(new Funcion(laBellaYLaBestia, sala2, new DateTime(2020, 12, 18, 15, 0, 0)));
            cine.Funciones.Add(new Funcion(laBellaYLaBestia, sala3, new DateTime(2020, 12, 18, 18, 15, 0)));

            cine.Funciones.Add(new Funcion(laBellaYLaBestia, sala4, new DateTime(2020, 12, 19, 10, 30, 0)));
            cine.Funciones.Add(new Funcion(laBellaYLaBestia, sala5, new DateTime(2020, 12, 19, 16, 45, 0)));
            cine.Funciones.Add(new Funcion(laBellaYLaBestia, sala6, new DateTime(2020, 12, 19, 20, 30, 0)));

            cine.Funciones.Add(new Funcion(laBellaYLaBestia, sala1, new DateTime(2020, 12, 20, 12, 30, 0)));
            cine.Funciones.Add(new Funcion(laBellaYLaBestia, sala2, new DateTime(2020, 12, 20, 15, 30, 0)));
            cine.Funciones.Add(new Funcion(laBellaYLaBestia, sala3, new DateTime(2020, 12, 20, 18, 30, 0)));

            cine.Funciones.Add(new Funcion(laBellaYLaBestia, sala4, new DateTime(2020, 12, 21, 12, 30, 0)));
            cine.Funciones.Add(new Funcion(laBellaYLaBestia, sala5, new DateTime(2020, 12, 21, 16, 30, 0)));
            cine.Funciones.Add(new Funcion(laBellaYLaBestia, sala6, new DateTime(2020, 12, 21, 19, 30, 0)));

            cine.Funciones.Add(new Funcion(laBellaYLaBestia, sala1, new DateTime(2020, 12, 23, 9, 30, 0)));
            cine.Funciones.Add(new Funcion(laBellaYLaBestia, sala2, new DateTime(2020, 12, 23, 12, 30, 0)));
            cine.Funciones.Add(new Funcion(laBellaYLaBestia, sala3, new DateTime(2020, 12, 23, 15, 30, 0)));

            cine.Funciones.Add(new Funcion(elReyLeon, sala1, new DateTime(2020, 12, 18, 11, 30, 0)));
            cine.Funciones.Add(new Funcion(elReyLeon, sala2, new DateTime(2020, 12, 18, 15, 0, 0)));
            cine.Funciones.Add(new Funcion(elReyLeon, sala3, new DateTime(2020, 12, 18, 18, 15, 0)));

            cine.Funciones.Add(new Funcion(elReyLeon, sala4, new DateTime(2020, 12, 19, 10, 30, 0)));
            cine.Funciones.Add(new Funcion(elReyLeon, sala5, new DateTime(2020, 12, 19, 16, 45, 0)));
            cine.Funciones.Add(new Funcion(elReyLeon, sala6, new DateTime(2020, 12, 19, 20, 30, 0)));

            cine.Funciones.Add(new Funcion(elReyLeon, sala1, new DateTime(2020, 12, 20, 12, 30, 0)));
            cine.Funciones.Add(new Funcion(elReyLeon, sala2, new DateTime(2020, 12, 20, 15, 30, 0)));
            cine.Funciones.Add(new Funcion(elReyLeon, sala3, new DateTime(2020, 12, 20, 18, 30, 0)));

            cine.Funciones.Add(new Funcion(elReyLeon, sala4, new DateTime(2020, 12, 21, 12, 30, 0)));
            cine.Funciones.Add(new Funcion(elReyLeon, sala5, new DateTime(2020, 12, 21, 16, 30, 0)));
            cine.Funciones.Add(new Funcion(elReyLeon, sala6, new DateTime(2020, 12, 21, 19, 30, 0)));

            cine.Funciones.Add(new Funcion(elReyLeon, sala1, new DateTime(2020, 12, 23, 9, 30, 0)));
            cine.Funciones.Add(new Funcion(elReyLeon, sala2, new DateTime(2020, 12, 23, 12, 30, 0)));
            cine.Funciones.Add(new Funcion(elReyLeon, sala3, new DateTime(2020, 12, 23, 15, 30, 0)));

            cine.Funciones.Add(new Funcion(aladdin, sala1, new DateTime(2020, 12, 18, 11, 30, 0)));
            cine.Funciones.Add(new Funcion(aladdin, sala1, new DateTime(2020, 12, 18, 15, 0, 0)));
            cine.Funciones.Add(new Funcion(aladdin, sala1, new DateTime(2020, 12, 18, 18, 15, 0)));

            cine.Funciones.Add(new Funcion(aladdin, sala1, new DateTime(2020, 12, 19, 10, 30, 0)));
            cine.Funciones.Add(new Funcion(aladdin, sala1, new DateTime(2020, 12, 19, 16, 45, 0)));
            cine.Funciones.Add(new Funcion(aladdin, sala1, new DateTime(2020, 12, 19, 20, 30, 0)));

            cine.Funciones.Add(new Funcion(aladdin, sala1, new DateTime(2020, 12, 20, 12, 30, 0)));
            cine.Funciones.Add(new Funcion(aladdin, sala1, new DateTime(2020, 12, 20, 15, 30, 0)));
            cine.Funciones.Add(new Funcion(aladdin, sala1, new DateTime(2020, 12, 20, 18, 30, 0)));

            cine.Funciones.Add(new Funcion(aladdin, sala1, new DateTime(2020, 12, 21, 12, 30, 0)));
            cine.Funciones.Add(new Funcion(aladdin, sala1, new DateTime(2020, 12, 21, 16, 30, 0)));
            cine.Funciones.Add(new Funcion(aladdin, sala1, new DateTime(2020, 12, 21, 19, 30, 0)));

            cine.Funciones.Add(new Funcion(aladdin, sala1, new DateTime(2020, 12, 23, 9, 30, 0)));
            cine.Funciones.Add(new Funcion(aladdin, sala1, new DateTime(2020, 12, 23, 12, 30, 0)));
            cine.Funciones.Add(new Funcion(aladdin, sala1, new DateTime(2020, 12, 23, 15, 30, 0)));
        }

        static void Main(string[] args)
        {
            Cine multiplex = new Cine("Multiplex", 150f, 200f);
            CargarDataCine(multiplex);

            while (true)
            {
                Pelicula movie = multiplex.SeleccionarPelicula();
                if (movie == null)
                    continue;

                Funcion funcion = multiplex.SeleccionarFuncion(movie);
                if (funcion == null)
                    continue;

                Asiento asiento = funcion.SeleccionarAsiento(multiplex);
                if (asiento == null)
                    continue;

                Entrada entrada = new Entrada(funcion, asiento, multiplex);

                entrada.MostrarEntrada();
            }
        }
    }
}
