using System;
using System.Collections.Generic;

namespace Cinemaster.Lib
{
    public class Cine
    {
        public string Nombre;
        public List<Pelicula> Peliculas = new List<Pelicula>();
        public List<Sala> Salas = new List<Sala>();
        public List<Funcion> Funciones = new List<Funcion>();
        public List<Entrada> Entradas = new List<Entrada>();
        public float PrecioEntrada;
        public float PrecioEntradaVip;

        public Cine(string Nombre, float precio, float precioVip)
        {
            this.Nombre = Nombre;
            this.PrecioEntrada = precio;
            this.PrecioEntradaVip = precioVip;
        }

        public List<Funcion> BuscarFuncion(Pelicula pelicula)
        {
            if (pelicula == null)
                throw new ArgumentNullException("El argumento pelicula no puede ser nulo.");

            int cantFunciones = this.Funciones.Count;

            List<Funcion> FuncionesDisponibles = new List<Funcion>();

            for (int i = 0; i < cantFunciones; i++)
            {
                if (this.Funciones[i].Pelicula == pelicula && this.Funciones[i].ContarAsientosLibres() > 0)
                    FuncionesDisponibles.Add(this.Funciones[i]);
            }

            return FuncionesDisponibles;
        }

        public Pelicula SeleccionarPelicula()
        {
            int opcion = -1;
            bool opcionValida = false;
            bool esNumerico = false;
            int cantPeliculas = this.Peliculas.Count;

            while (!opcionValida || !esNumerico)
            {
                Console.Clear();
                Console.WriteLine($"Bienvenido a cine {this.Nombre}");
                Console.WriteLine("Que pelicula quieres ver?");
                for (int i = 0; i < cantPeliculas; i++)
                {
                    Console.WriteLine($"{i} - {this.Peliculas[i].Titulo} ({this.Peliculas[i].TituloOriginal})");
                }

                Console.Write("Su eleccion: ");
                esNumerico = int.TryParse(Console.ReadLine(), out opcion);

                string mensajeError = $"Opcion invalida\nDebes elegir una opcion entre el 0 y el {cantPeliculas - 1}.";

                if (esNumerico)
                    opcionValida = Program.ValidarOpcion(0, cantPeliculas, opcion, mensajeError);
                else
                    Program.MostrarMensaje(mensajeError, ConsoleColor.Red);
            }

            return this.Peliculas[opcion];
        }

        public Funcion SeleccionarFuncion(Pelicula pelicula)
        {
            int opcion = -1;
            bool opcionValida = false;
            bool esNumerico = false;

            List<Funcion> FuncionesDisponibles = BuscarFuncion(pelicula);

            int cantFuncionesDisp = FuncionesDisponibles.Count;

            while (!opcionValida || !esNumerico)
            {
                Console.Clear();
                Console.WriteLine($"Titulo: {pelicula.Titulo}");
                Console.WriteLine($"Titulo Original: {pelicula.TituloOriginal}");
                Console.WriteLine($"Duracion: {pelicula.Duracion.Hours} horas {pelicula.Duracion.Minutes} minutos");
                Console.WriteLine($"Director: {pelicula.Director.Nombre} {pelicula.Director.Apellido}");
                Console.WriteLine("Reparto:");

                foreach (KeyValuePair<Persona, string> item in pelicula.Reparto)
                {
                    Console.WriteLine($"*{item.Key.Nombre} {item.Key.Apellido} como {item.Value}");
                }

                Console.WriteLine($"Sinopsis: {pelicula.Sinopsis}");

                Console.WriteLine("\nFunciones:");
                for (int i = 0; i <= cantFuncionesDisp; i++)
                {
                    if (i == cantFuncionesDisp)
                    {
                        Console.WriteLine($"{i} - Cancelar");
                        break;
                    }

                    Console.WriteLine($"{i} - {FuncionesDisponibles[i].FechaYHora.ToString("dd/MM/yyyy HH:mm")}");
                }

                Console.Write("Su eleccion: ");
                esNumerico = int.TryParse(Console.ReadLine(), out opcion);

                string mensajeError = $"Opcion invalida\nDebes elegir una opcion entre el 0 y el {cantFuncionesDisp}.";

                if (esNumerico)
                    opcionValida = Program.ValidarOpcion(0, cantFuncionesDisp, opcion, mensajeError);
                else
                    Program.MostrarMensaje(mensajeError, ConsoleColor.Red);
            }

            if (opcion == cantFuncionesDisp)
                return null;

            return FuncionesDisponibles[opcion];
        }

    }
}
