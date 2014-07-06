using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SACG_DAL;
using SACG_BLL;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace SACG_Mappers
{
    public class UsuarioMapper: AbstractBase
    {
        private Usuario usuario { get; set; }

        public UsuarioMapper(Usuario u)
            : base(FabricaObjetosConectados.Proveedores.SqlServer,
            ConfigurationManager.ConnectionStrings["conexionSACG"].ConnectionString)
        {
            usuario = u;
        }

        #region PERSISTENCIA

        public void Insertar()
        {

            List<IDataParameter> listaParametros = new List<IDataParameter>();

            IDataParameter pUser = CrearParametro("@Nick", usuario.User);
            IDataParameter pPass = CrearParametro("@Pass", usuario.Pass);
            IDataParameter pRol = CrearParametro("@Rol", usuario.Role);
            IDataParameter pEstado = CrearParametro("@Estado", "Activo");

            listaParametros.Add(pUser);
            listaParametros.Add(pPass);
            listaParametros.Add(pRol);
            listaParametros.Add(pEstado);

            EjecutarActualizacion(CommandType.StoredProcedure, "spAltaUsuario", listaParametros);
        }

        public void Eliminar()
        {
            List<IDataParameter> listaParametros = new List<IDataParameter>();
            IDataParameter pUser = this.CrearParametro("@DICOSE", usuario.User);
            listaParametros.Add(pUser);
            EjecutarActualizacion(CommandType.StoredProcedure, "spBajaUsuario", listaParametros);
        }

        public void Modificar()
        {
            List<IDataParameter> listaParametros = new List<IDataParameter>();

            IDataParameter pUser = CrearParametro("@Nick", usuario.User);
            IDataParameter pPass = CrearParametro("@Pass", usuario.Pass);

            listaParametros.Add(pUser);
            listaParametros.Add(pPass);

            EjecutarActualizacion(CommandType.StoredProcedure, "spModificarUsuario", listaParametros);
        }

        #endregion

        public void load(IDataRecord dr)
        {
            if (usuario != null)
            {
                usuario.User = dr.GetString(dr.GetOrdinal("Nick"));
                usuario.Pass = dr.GetString(dr.GetOrdinal("Pass"));
                usuario.Role = dr.GetString(dr.GetOrdinal("Rol"));
                usuario.Estado = dr.GetString(dr.GetOrdinal("Estado"));
            }
        }
    }
}
