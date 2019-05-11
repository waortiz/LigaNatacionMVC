using Entidades;
using System.Linq;
using System.Collections.Generic;
using System;
using System.Data;

namespace Repositorio
{
    public class RepositorioDeportistaMock : IRepositorioDeportista
    {
        public static List<Deportista> deportistas = new List<Deportista>();

        public void EliminarDeportista(long idDeportista)
        {
            var deportista = deportistas.FirstOrDefault(d=>d.Id == idDeportista);
            if(deportista != null)
            {
                deportistas.Remove(deportista);
            }
        }

        public void IngresarDeportista(Deportista deportista)
        {
            deportista.Id = new Random().Next(1, 1000000000);
            deportistas.Add(deportista);
        }

        public List<Deportista> ObtenerDeportistas(string numeroDocumento, string primerNombre, string segundoNombre, string primerApellido, string segundoApellido)
        {
            return deportistas.Where(p => (numeroDocumento == "" || p.NumeroDocumento == numeroDocumento) &&
            (primerNombre == "" || p.PrimerNombre.Contains(primerNombre)) &&
            (segundoNombre == "" || p.SegundoNombre.Contains(segundoNombre)) &&
            (primerApellido == "" || p.PrimerApellido.Contains(primerApellido)) &&
            (segundoApellido == "" || p.SegundoApellido.Contains(segundoApellido))
            ).ToList();
        }

        public DataTable ObtenerDeportistas()
        {
            List<Deportista> listado = new List<Deportista>();
            var table = new DataTable();

            table.Columns.Add("PrimerNombre", typeof(string));
            table.Columns.Add("SegundoNombre", typeof(string));
            table.Columns.Add("PrimerApellido", typeof(string));
            table.Columns.Add("SegundoApellido", typeof(string));
            table.Columns.Add("NumeroDocumento", typeof(string));
            table.Columns.Add("FechaNacimiento", typeof(DateTime));

            foreach (var deportista in deportistas)
            {
                var row = table.NewRow();

                row["PrimerNombre"] = deportista.PrimerNombre;
                row["SegundoNombre"] = deportista.SegundoNombre;
                row["PrimerApellido"] = deportista.PrimerApellido;
                row["SegundoApellido"] = deportista.SegundoApellido;
                row["NumeroDocumento"] = deportista.SegundoApellido;
                row["FechaNacimiento"] = deportista.FechaNacimiento;

                table.Rows.Add(row);
            }

            return table;
        }
    }
}
