using System;
namespace Cinemaster.Lib
{
    public class Sala
    {
        public int Numero;
        public Asiento[,] Asientos;

        public Sala(int Number, int Rows, int Columns)
        {
            this.Numero = Number;
            this.Asientos = new Asiento[Rows, Columns];

            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    this.Asientos[i, j] = new Asiento(i, j);

                    if (i == Rows - 1)
                        this.Asientos[i, j].EsVip = true;
                }
            }
        }
    }
}
