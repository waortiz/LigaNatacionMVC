using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Entidades
{
    public class Deportista
    {
        public string PrimerNombre { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoNombre { get; set; }
        public string SegundoApellido { get; set; }
        public string NumeroDocumento { get; set; }
        public TipoDocumento TipoDocumento { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public Sexo Sexo { get; set; }
        public long Id { get; set; }
    }
}