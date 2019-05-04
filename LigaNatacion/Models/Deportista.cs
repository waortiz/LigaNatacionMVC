using System;

namespace LigaNatacion.Models
{
    public class Deportista
    {
        public long Id { get; set; }
        public string PrimerNombre { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoNombre { get; set; }
        public string SegundoApellido { get; set; }
        public string NumeroDocumento { get; set; }
        public string TipoDocumento { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public string Genero { get; set; }
    }
}