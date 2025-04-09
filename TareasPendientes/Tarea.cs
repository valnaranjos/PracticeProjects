using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TareasPendientes
{
    public class Tarea
    {
        public int Id { get; }
        public string? Descripcion { get; set; }
        public string Estado { get; set; }

        public Tarea(string descripcion)
        {
            Id = GeneradorId.ObtenerNuevoID();
            Descripcion = descripcion;
            Estado = "Pendiente";
        }

    } 
}
