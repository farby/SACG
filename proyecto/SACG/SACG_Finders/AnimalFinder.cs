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
            IDataReader dr = EjecutarReader(CommandType.Text,
                "select * from Animales where DICOSE = @DICOSE and AñoMuerte = 0",
                listaParametros);

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

        public List<Animal> reporteSinPesar(DateTime fecha)
        {
            List<Animal> animales = null;
            List<IDataParameter> listaParametros = new List<IDataParameter>();
            IDataParameter pFecha = CrearParametro("@Fecha", fecha);
            listaParametros.Add(pFecha);
            //DEVUELVO ANIMALES VIVOS SIN PESAR DESDE LA FECHA PASADA
            IDataReader dr = EjecutarReader(CommandType.Text,
                "select * from Animales where AñoMuerte is null and ID not in" +
                "(select ID from Eventos where Tipo like 'Pesaje' and Fecha > @Fecha)",
                listaParametros);
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

        public List<String> pesajes(Int32 ID)
        {
            List<String> animales = null;
            List<IDataParameter> listaParametros = new List<IDataParameter>();
            IDataParameter pID = CrearParametro("@ID", ID);
            listaParametros.Add(pID);
            //DEVUELVO STRING CON CADA PESAJE PARA EL ANIMAL SELECCIONADO
            IDataReader dr = EjecutarReader(CommandType.Text,
                "select ('Fecha: ' + CAST(Fecha as varchar(25)) + ' Peso: ' + Observaciones)" +
                "as Pesaje from Eventos where Tipo like 'Pesaje' and ID = @ID",
                listaParametros);
            if (dr != null)
            {
                while (dr.Read())
                {
                    animales.Add(dr.Read().ToString());
                }
                dr.Close();
            }
            return animales;
        }
    
    }
}
