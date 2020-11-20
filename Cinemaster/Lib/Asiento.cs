using System;
namespace Cinemaster.Lib
{
    public class Asiento
    {
        public int Fila;
        public int Columna;
        public bool EsVip;

        public Asiento(int Row, int Column)
        {
            this.Fila = Row;
            this.Columna = Column;
            this.EsVip = false;
        }
    }
}
