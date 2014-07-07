using SACG_BLL;
using SACG_DAL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SACG_Mappers
{
    public class AnimalMapper: AbstractBase
    {
        private Animal animal { get; set; }

        public AnimalMapper(Animal a)
            : base(FabricaObjetosConectados.Proveedores.SqlServer,
                ConfigurationManager.ConnectionStrings["conexionSACG"].ConnectionString)
        {
            animal = a;
        }


        #region PERSISTENCIA

        public void Insertar()
        {

            List<IDataParameter> listaParametros = new List<IDataParameter>();

            IDataParameter pDICOSE = CrearParametro("@DICOSE", animal.DICOSE);
            IDataParameter pSexo = CrearParametro("@SEXO", animal.Sexo);
            IDataParameter pAno = CrearParametro("@ANO", animal.AnoNacimiento);
            IDataParameter pEstacion = CrearParametro("@ESTACION", animal.EstacionNacimiento);
            IDataParameter pRaza = CrearParametro("@RAZA", animal.RazaCruza);

            listaParametros.Add(pDICOSE);
            listaParametros.Add(pSexo);
            listaParametros.Add(pAno);
            listaParametros.Add(pEstacion);
            listaParametros.Add(pRaza);

            try
            {
                if (animal.RFID == 0)
                {
                    EjecutarActualizacion(CommandType.StoredProcedure, "spAltaAnimal", listaParametros);
                }
                else
                {
                    IDataParameter pRfid = CrearParametro("@RFID", animal.RFID);
                    listaParametros.Add(pRfid);
                    EjecutarActualizacion(CommandType.StoredProcedure, "spAltaAnimalRFID", listaParametros);
                }
                
            }
            catch (Exception)
            {
                
                throw;
            }
            
        }

        #endregion



        public void load(IDataRecord dr)
        {
            if (animal != null)
            {
                animal.RFID = dr.GetInt64(dr.GetOrdinal("RFID"));
                animal.DICOSE = dr.GetInt64(dr.GetOrdinal("DICOSE"));
                animal.Sexo = Convert.ToChar(dr.GetString(dr.GetOrdinal("Sexo")));
                animal.AnoNacimiento = dr.GetInt32(dr.GetOrdinal("AñoNacimiento"));
                animal.AnoMuerte = dr.GetInt32(dr.GetOrdinal("AñoMuerte"));
                
                animal.EstacionNacimiento = Convert.ToChar(dr.GetString(dr.GetOrdinal("EstacionNacimiento")));
                animal.RazaCruza = dr.GetString(dr.GetOrdinal("RazaCruza"));
                animal.ID = dr.GetInt32(dr.GetOrdinal("ID"));
            }
        }


    }
}
