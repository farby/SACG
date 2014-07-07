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
        public List<Int32> todos()
        {
            IDataReader dr = EjecutarReader(CommandType.Text,
                "select ID from Animales where AñoMuerte = 0");
            List<Int32> listaActivos;

            if (dr != null)
            {
                listaActivos = new List<Int32>();
                while (dr.Read())
                {
                    listaActivos.Add(dr.GetInt32(dr.GetOrdinal("ID")));
                }
                dr.Close();
                return listaActivos;
            }
            return null;
        }

        //Buscar Animales de un Establecimiento
        public List<Animal> buscarAnimales(Int64 dicose)
        {
            List<Animal> animales = null;
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

        //Buscar Animales de un Establecimiento
        public List<Animal> buscarAnimales(Int64 dicose, String sexo)
        {
            List<Animal> animales = null;
            List<IDataParameter> listaParametros = new List<IDataParameter>();
            IDataParameter pDICOSE = CrearParametro("@DICOSE", dicose);
            IDataParameter pSexo = CrearParametro("@SEXO", sexo);
            listaParametros.Add(pDICOSE);
            listaParametros.Add(pSexo);
            IDataReader dr = EjecutarReader(CommandType.Text,
                "select * from Animales where DICOSE = @DICOSE and SEXO = @SEXO and AñoMuerte = 0",
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
                "select * from Animales where AñoMuerte = 0 and ID not in" +
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
            List<IDataParameter> listaParametros = new List<IDataParameter>();
            IDataParameter pID = CrearParametro("@ID", ID);
            listaParametros.Add(pID);
            IDataReader dr = EjecutarReader(CommandType.Text,
                "select ('Fecha: ' + CAST(Fecha as varchar(25)) + ' Peso: ' + Observaciones) " +
                "as Pesaje from Eventos where Tipo like 'Pesaje' and Animal = @ID",
                listaParametros);
            List<String> list;

            if (dr != null)
            {
                list = new List<String>();
                while (dr.Read())
                {
                    list.Add(dr.GetString(dr.GetOrdinal("Pesaje")).ToString());
                }
                dr.Close();
                if (list.Count == 0)
                {
                    return null;
                }
                return list;
            }
            return null;
        }
    
    }
}
