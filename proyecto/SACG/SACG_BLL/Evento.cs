using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SACG_BLL
{
    public class Evento
    {
        public Int32 ID { get; set; }

        public String Tipo { get; set; }

        public String Nombre { get; set; }

        public DateTime Fecha { get; set; }

        public String Observaciones { get; set; }

        public Int64 idAnimal { get; set; }

        public Int64 DicoseOrg { get; set; }

        public Int64 DicoseDest { get; set; }
    }
}
