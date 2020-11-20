using System;
namespace Cinemaster.Lib
{
    public class Entrada
    {
        public Funcion Funcion;
        public Asiento Asiento;
        public float Precio;
        public DateTime FechaEmision;

        public Entrada(Funcion func, Asiento seat, Cine cine)
        {
            this.Funcion = func;
            this.Asiento = seat;
            this.FechaEmision = DateTime.Now;

            if (this.Asiento.EsVip)
                this.Precio = cine.PrecioEntradaVip;
            else
                this.Precio = cine.PrecioEntrada;

            if (this.Funcion.FechaYHora.DayOfWeek == DayOfWeek.Wednesday || this.Funcion.FechaYHora.DayOfWeek == DayOfWeek.Thursday)
            {
                this.Precio /= 2;
            }
        }

        public void MostrarEntrada()
        {
            string funcStr = $"Funcion: {this.Funcion.Pelicula.Titulo} {this.Funcion.FechaYHora.ToString("dd/MM/yyyy HH:mm")}"; ;

            Console.Clear();
            Program.MostrarTextoConPadding(funcStr.Length, "ENTRADA");

            Console.WriteLine(funcStr);
            Console.WriteLine($"Asiento: Fila {this.Asiento.Fila}, Columna {this.Asiento.Columna}");
            Console.WriteLine($"Precio: ${this.Precio}");
            Console.WriteLine($"Fecha de emision: {this.FechaEmision.ToString("dd/MM/yyyy HH:mm")}");

            Console.WriteLine("\nPresione Enter para volver al menu principal.");
            Console.ReadLine();
        }
    }
}
