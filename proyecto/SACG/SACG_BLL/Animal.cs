using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SACG_BLL
{
    public class Animal
    {
        public Int32 ID{get; set;}

        public Int64 RFID { get; set; }

        public Int64 DICOSE { get; set; }

        public Char Sexo { get; set; }

        public Int32 AnoNacimiento { get; set; }

        public Int32 AnoMuerte { get; set; }

        public Char EstacionNacimiento { get; set; }

        public String RazaCruza { get; set; }

        public Evento Evento { get; set; }
    }
}
