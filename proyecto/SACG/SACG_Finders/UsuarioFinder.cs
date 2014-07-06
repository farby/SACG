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
    public class UsuarioFinder: AbstractBase
    {
        public UsuarioFinder()
            : base(FabricaObjetosConectados.Proveedores.SqlServer,
            ConfigurationManager.ConnectionStrings["conexionSACG"].ConnectionString)
        {
  
        }
    
        public Usuario Login(String user, String pass)
        {
            List<IDataParameter> listaParametros = new List<IDataParameter>();
            IDataParameter pUser = CrearParametro("@Nick", user);
            IDataParameter pPass = CrearParametro("@Pass", pass);
            listaParametros.Add(pUser);
            listaParametros.Add(pPass);
            IDataReader dr = EjecutarReader(CommandType.Text,
                "Select Nick, Rol from Usuarios where Nick = @Nick and Pass = @Pass and Estado = 'Activo'",
                listaParametros
            );
            if (dr != null)
            {
                if (dr.Read())
                {
                    Usuario u = new Usuario();
                    UsuarioMapper m = new UsuarioMapper(u);
                    m.load(dr);
                    dr.Close();
                    return u;
                }
            }  
            return null;        
        }
    }
}
