using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SACG_BLL
{
    public class Establecimiento
    {
        public Int64 DICOSE { get; set; }
        public Int64 RUT { get; set; }
        public Int64 BPS { get; set; }
        public String RazonSocial { get; set; }
        public Int64 Responsable { get; set; }
        public String Departamento { get; set; }
        public Int32 SeccionalPolicial { get; set; }
        public String Paraje { get; set; }
        public String Direccion { get; set; }
        public String Telefono { get; set; }
        public String Email { get; set; }
        public Int32 Superficie { get; set; }
        public Enum Estado { get; set; }

        public Establecimiento(Int64 DICOSE, Int64 RUT, Int64 BPS, String RazonSocial, Int64 Responsable,
            String Departamento, Int32 SeccionalPolicial, String Paraje, String Direccion, String Telefono,
            String Email, Int32 Superficie)
        {
            this.DICOSE = DICOSE;
            this.RUT = RUT;
            this.BPS = BPS;
            this.RazonSocial = RazonSocial;
            this.Responsable = Responsable;
            this.Departamento = Departamento;
            this.SeccionalPolicial = SeccionalPolicial;
            this.Paraje = Paraje;
            this.Direccion = Direccion;
            this.Telefono = Telefono;
            this.Email = Email;
            this.Superficie = Superficie;
        }
    }
}
