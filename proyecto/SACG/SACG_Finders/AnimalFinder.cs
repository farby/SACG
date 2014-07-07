using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SACG_DAL;
using SACG_BLL;
using SACG_Mappers;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace SACG_Finders
{
    public class AnimalFinder  : AbstractBase
    {
        public AnimalFinder()
            : base(FabricaObjetosConectados.Proveedores.SqlServer,
                ConfigurationManager.ConnectionStrings["conexionSACG"].ConnectionString)
        {

        }


        //Buscar Animales de un Establecimiento
        public List<Animal> buscarAnimales(Int64 dicose)
        {
            List<Animal> animales =null;
            List<IDataParameter> listaParametros = new List<IDataParameter>();
            IDataParameter pDICOSE = CrearParametro("@DICOSE", dicose);
            listaParametros.Add(pDICOSE);
            IDataReader dr = EjecutarReader(CommandType.Text, "Select * from Animales where DICOSE = @DICOSE and AñoMuerte = 0", listaParametros);

            if (dr != null)
            {
                animales = new List<Animal>();
                while (dr.Read())
                {
                    Animal obj = new Animal();
                    AnimalMapper mapper = new AnimalMapper(obj);
                    mapper.load(dr);
                    animales.Add(obj);
                }
                dr.Close();
            }
            return animales;  
        }
    
    }
}
