using Entidades;
using Repositorio;
using System.Collections.Generic;
using System.Data;

namespace Negocio
{
    public class DeportistaNegocio
    {
        IRepositorioDeportista repositorio;
        public DeportistaNegocio()
        {
            repositorio = new RepositorioDeportistaMock();
        }

        public void IngresarDeportista(Deportista deportista)
        {
            repositorio.IngresarDeportista(deportista);
        }

        public List<Deportista> ObtenerDeportistas(string numeroDocumento, string primerNombre, string segundoNombre, string primerApellido, string segundoApellido)
        {
            return repositorio.ObtenerDeportistas(numeroDocumento, primerNombre, segundoNombre, primerApellido, segundoApellido);
        }

        public DataTable ObtenerDeportistas()
        {
            return repositorio.ObtenerDeportistas();
        }
    }
}

