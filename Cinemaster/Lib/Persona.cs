using System;
namespace Cinemaster.Lib
{
    public class Persona
    {
        public string Nombre;
        public string Apellido;

        public Persona(string Name, string LastName)
        {
            this.Nombre = Name;
            this.Apellido = LastName;
        }
    }
}
