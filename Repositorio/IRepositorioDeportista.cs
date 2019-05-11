using Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Repositorio
{
    public interface IRepositorioDeportista
    {
        void IngresarDeportista(Deportista deportista);

        List<Deportista> ObtenerDeportistas(string numeroDocumento, string primerNombre, string segundoNombre, string primerApellido, string segundoApellido);
        DataTable ObtenerDeportistas();
    }
}

