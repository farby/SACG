using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.Data.Odbc;

namespace SACG_DAL
{
   public class FabricaObjetosConectados
    {
       public enum Proveedores { SqlServer,Odbc,OleDb}
       public IDbConnection getConexionProveedor(Proveedores prov)
       {
           switch (prov)
           {
               case Proveedores.SqlServer: { return new SqlConnection(); } 
               case Proveedores.Odbc: {return new OdbcConnection(); }
               case Proveedores.OleDb: {return new OleDbConnection();}
               default: return null;
           }
       }
       public IDbCommand getComandoProveedor(Proveedores prov)
       {
           switch (prov)
           {
               case Proveedores.SqlServer: { return new SqlCommand(); }
               case Proveedores.Odbc: { return new OdbcCommand();  }
               case Proveedores.OleDb: { return new OleDbCommand(); }
               default: return null;
           }
       }
       public IDataParameter getParametroProveedor(Proveedores prov)
       {
           switch (prov)
           {
               case Proveedores.SqlServer: { return new SqlParameter(); }
               case Proveedores.Odbc: { return new OdbcParameter(); }
               case Proveedores.OleDb: { return new OleDbParameter(); }
               default: return null;
           }
       }
    }
}
