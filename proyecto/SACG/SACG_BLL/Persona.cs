using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SACG_BLL
{
    public class Persona
    {
        public Int64 Documento { get; set; }
        public String Nombre { get; set; }
        public String Apellido { get; set; }
        public String Telefono { get; set; }

        public Persona(Int64 documento, String nombre, String apellido, String telefono)
        {
            this.Documento = documento;
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Telefono = telefono;
        }
    }
}
