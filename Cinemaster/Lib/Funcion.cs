using System;
using System.Collections.Generic;

namespace Cinemaster.Lib
{
    public class Funcion
    {
        public Pelicula Pelicula;
        public Sala Sala;
        public DateTime FechaYHora;
        public Dictionary<Asiento, EstadoAsiento> EstadoDeAsientos = new Dictionary<Asiento, EstadoAsiento>();

        public Funcion(Pelicula Pelicula, Sala Sala, DateTime FechaYHora)
        {
            this.Pelicula = Pelicula;
            this.Sala = Sala;
            this.FechaYHora = FechaYHora;

            int filasAsientos = this.Sala.Asientos.GetLength(0);
            int columnasAsientos = this.Sala.Asientos.GetLength(1);

            for (int i = 0; i < filasAsientos; i++)
            {
                for (int j = 0; j < columnasAsientos; j++)
                {
                    EstadoDeAsientos.Add(this.Sala.Asientos[i, j], EstadoAsiento.Libre);
                }
            }
        }

        public bool IntentarOcuparAsiento(Asiento asiento)
        {
            if (asiento == null)
                throw new ArgumentNullException("El asiento no puede ser nulo.");

            if (!BuscarAsiento(asiento))
                throw new ArgumentException("El asiento no corresponde a la sala de esta funcion.");
            else
            {
                if (this.EstadoDeAsientos[asiento] == EstadoAsiento.Ocupado)
                    return false;
                else
                {
                    this.EstadoDeAsientos[asiento] = EstadoAsiento.Ocupado;
                    return true;
                }
            }
        }

        private bool BuscarAsiento(Asiento asiento)
        {
            int filasAsientos = this.Sala.Asientos.GetLength(0);
            int columnasAsientos = this.Sala.Asientos.GetLength(1);

            for (int i = 0; i < filasAsientos; i++)
            {
                for (int j = 0; j < columnasAsientos; j++)
                {
                    if (asiento == this.Sala.Asientos[i, j])
                        return true;
                }
            }

            return false;
        }

        public int ContarAsientosLibres()
        {
            int cant = 0;

            foreach (KeyValuePair<Asiento, EstadoAsiento> element in this.EstadoDeAsientos)
            {
                if (element.Value == EstadoAsiento.Libre)
                    cant += 1;
            }

            return cant;
        }

        public Asiento SeleccionarAsiento(Cine cine)
        {
            int fila = -2;
            int col = -2;
            bool esNumerico1 = false;
            bool esNumerico2 = false;
            bool asientoSeleccionado = false;

            bool filaValida = false;
            bool colValida = false;

            int maxFilas = this.Sala.Asientos.GetLength(0);
            int maxCols = this.Sala.Asientos.GetLength(1);

            while (!filaValida || !colValida || !asientoSeleccionado)
            {
                Console.Clear();

                Console.WriteLine($"Pelicula: {this.Pelicula.Titulo}");
                Console.WriteLine($"Funcion: {this.FechaYHora.ToString("dd/MM/yyyy HH:mm")}");

                this.MostrarAsientos();

                float precioEntrada = cine.PrecioEntrada;
                float precioEntradaVip = cine.PrecioEntradaVip;

                string libre = $"[ ] = Libre ${precioEntrada}";
                string vip = $"[ V ] = VIP Libre ${precioEntradaVip}";

                if (this.FechaYHora.DayOfWeek == DayOfWeek.Wednesday || this.FechaYHora.DayOfWeek == DayOfWeek.Thursday)
                {
                    precioEntrada = cine.PrecioEntrada / 2;
                    precioEntradaVip = cine.PrecioEntradaVip / 2;

                    libre = $"[ ] = Libre ${precioEntrada} (precio promo)";
                    vip = $"[ V ] = VIP Libre ${precioEntradaVip} (precio promo)";
                }

                Console.WriteLine("Referencias: ");
                Console.WriteLine(libre);
                Console.WriteLine(vip);
                Console.WriteLine($"[ O ] = Ocupado");

                string mensajeError = $"Opcion invalida\nDebe elegir una opcion entre el -1 y el {maxFilas - 1}.";

                Console.Write("Ingrese Fila (-1 para cancelar): ");
                esNumerico1 = int.TryParse(Console.ReadLine(), out fila);

                if (esNumerico1)
                {
                    if (fila == -1)
                        return null;

                    filaValida = Program.ValidarOpcion(-1, maxFilas, fila, mensajeError);

                    if (!filaValida)
                        continue;
                }

                Console.Write("Ingrese Columna (-1 para cancelar): ");
                esNumerico2 = int.TryParse(Console.ReadLine(), out col);

                if (esNumerico2)
                {
                    if (col == -1)
                        return null;

                    mensajeError = $"Opcion invalida\nDebe elegir una opcion entre el -1 y el {maxCols - 1}.";
                    colValida = Program.ValidarOpcion(-1, maxCols, col, mensajeError);

                    if (!colValida)
                        continue;
                }

                if (filaValida && colValida)
                {
                    if (!IntentarOcuparAsiento(this.Sala.Asientos[fila, col]))
                    {
                        Program.MostrarMensaje("El asiento ya esta ocupado.", ConsoleColor.Red);
                        continue;
                    }
                    else
                        asientoSeleccionado = true;
                }
                else
                    Program.MostrarMensaje("Datos invalidos.", ConsoleColor.Red);
            }

            return this.Sala.Asientos[fila, col];
        }


        private void MostrarAsientos()
        {
            int fils = this.Sala.Asientos.GetLength(0);
            int cols = this.Sala.Asientos.GetLength(1);

            Console.Write("   ");
            Program.MostrarTextoConPadding(cols, "PANTALLA");

            Console.Write("   ");
            for (int c = 0; c < cols; c++)
            {
                Console.Write($" {c:00}  ");
            }


            Console.WriteLine();
            for (int f = 0; f < fils; f++)
            {
                Console.Write($"{f:00} ");
                for (int c = 0; c < cols; c++)
                {
                    char seat;

                    if (this.EstadoDeAsientos[this.Sala.Asientos[f, c]] == EstadoAsiento.Libre)
                    {
                        if (this.Sala.Asientos[f, c].EsVip)
                            seat = 'V';
                        else
                            seat = ' ';
                    }
                    else
                        seat = 'O';

                    Console.Write($"[ {seat} ]");
                }
                Console.WriteLine();
            }
        }
    }
}
