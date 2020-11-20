using System;
using System.Collections.Generic;

namespace Cinemaster.Lib
{
    public class Pelicula
    {
        public string Titulo;
        public string TituloOriginal;
        public Persona Director;
        public Dictionary<Persona, string> Reparto = new Dictionary<Persona, string>();
        public TimeSpan Duracion;
        public string Sinopsis;

        public Pelicula(string Title, string EnglishTitle, Persona Director, Dictionary<Persona, string> Cast, TimeSpan Duration, string Synopsis)
        {
            this.Titulo = Title;
            this.TituloOriginal = EnglishTitle;
            this.Director = Director;
            this.Reparto = Cast;
            this.Duracion = Duration;
            this.Sinopsis = Synopsis;
        }
    }
}
