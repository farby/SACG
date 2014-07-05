using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Configuration;


namespace SACG_DAL
{
    public abstract class AbstractBase
    {
        protected FabricaObjetosConectados.Proveedores proveedor;
        string cadenaConexion;


        public AbstractBase(FabricaObjetosConectados.Proveedores prov,
            string cadenaConn)
        {
            this.proveedor = prov;
            this.cadenaConexion = cadenaConn;
        }

        protected IDbConnection Conectar()
        {

            cn = new FabricaObjetosConectados().getConexionProveedor(this.proveedor);
            cn.ConnectionString = cadenaConexion;

            return cn;
        }

        protected void Abrir(IDbConnection cn)
        {
            try
            {
                if (cn != null && cn.State != ConnectionState.Open)
                {
                    cn.Open();
                } 
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.Assert(false, "Error al abrir la conexion:" + e.Message);
            }
        }

        protected void Cerrar(IDbConnection cn)
        {
            try
            {
                if (cn != null && cn.State != ConnectionState.Closed)
                {
                    cn.Close();
                    cn.Dispose();
                }
            }
            catch (Exception e)
            {

                System.Diagnostics.Debug.Assert(false,
                    "Error al cerrar la conexion:" + e.Message);
            }
        }

        #region Manejo de transacciones

        //Variables utilizadas para compartir la conexión y la transacción entre distintos métodos
        //evita el pasaje de parámetros
        private static IDbConnection cn;
        private static IDbTransaction trn;

        //Iniciar una nueva transacción. Se debe invocar inmediatamente antes de la ejecución del primer comando de la serie
        //que deba ejecutarse transaccionalmente 

        public void IniciarTransaccion()
        {
            if (trn != null) //ya había una transacción en trámite, no hay que iniciarla.
                return;

            try
            {
                // instanciar la conexión
                cn = Conectar();
                Abrir(cn);
                // iniciar la transacción, se utiliza el nivel de aislamiento Read Commited - por defecto para SQL Server
                // no permite lecturas sucias, pero sí non-repeatable y phantom reads
                trn = cn.BeginTransaction();
            }
            catch (Exception exc)
            {
                Cerrar(cn);
                System.Diagnostics.Debug.WriteLine(exc.Message);
                throw;
            }
        }
        /// <summary>
        /// Hace el commit de la transacción - actualiza los cambios en la BD.
        /// </summary>
        public void CommitTransaccion()
        {
            if (trn == null)
                return;

            try
            {
                // Commit transaction
                trn.Commit();
            }
            catch (Exception exc)
            {
                // rollback transaction
                RollbackTransaccion();
                System.Diagnostics.Debug.WriteLine(exc.Message);
                throw;
            }
            finally
            {
                Cerrar(cn);
                trn = null;

            }
        }

        /// <summary>
        /// Hace el rollback de una transacción anulando los cambios pendientes.
        /// </summary>
        public void RollbackTransaccion()
        {
            if (trn == null)
                return;

            try
            {
                trn.Rollback();
            }
            catch (Exception Exc)
            {
                System.Diagnostics.Debug.WriteLine(Exc.Message);
            }
            finally
            {
                Cerrar(cn);
                trn = null;
            }
        }
        #endregion



        protected IDbCommand PrepararComando(CommandType tipo, string cadenaComando)
        {
            FabricaObjetosConectados fab = new FabricaObjetosConectados();
            IDbCommand cmd = fab.getComandoProveedor(this.proveedor);
            cmd.CommandText = cadenaComando;
            cmd.CommandType = tipo;
            if (cn == null) cn = Conectar();
            cmd.Connection = cn;


            return cmd;
        }


        protected IDbCommand PrepararComando(CommandType tipo, string cadenaComando, List<IDataParameter> listaParametros)
        {

            IDbCommand cmd = this.PrepararComando(tipo, cadenaComando);
            if (listaParametros != null)
                foreach (IDataParameter param in listaParametros)
                    cmd.Parameters.Add(param);
            return cmd;
        }
        protected int EjecutarActualizacion(CommandType tipo, string cadenaComando)
        {
            int afectadas = -1;
            IDbCommand cmd = null;
            try
            {

                cmd = this.PrepararComando(tipo, cadenaComando);
                Abrir(cmd.Connection);
                cmd.Transaction = trn;
                afectadas = cmd.ExecuteNonQuery();


                return afectadas;

            }
            catch (Exception e)
            {

                System.Diagnostics.Debug.Assert(false, "Error al actualizar:" + e.Message);
                return -1;
            }
            finally
            {
                if (cmd.Transaction == null)
                    Cerrar(cmd.Connection);
            }

        }
        public int EjecutarActualizacion(CommandType tipo, string cadenaComando,
            List<IDataParameter> listaParams)
        {
            int afectadas = -1;
            IDbCommand cmd = null;
            try
            {

                cmd = this.PrepararComando(tipo, cadenaComando, listaParams);

                Abrir(cmd.Connection);
                cmd.Transaction = trn;
                afectadas = cmd.ExecuteNonQuery();

                return afectadas;
            }
            catch (Exception e)
            {

                System.Diagnostics.Debug.Assert(false, "Error al actualizar:" + e.Message);
                return -1;
            }
            finally
            {
                if (cmd.Transaction == null)
                    Cerrar(cmd.Connection);
            }
        }


        public Object EjecutarConsultaEscalar(CommandType tipo, string cadenaComando)
        {
            Object valorEscalar = null;
            IDbCommand cmd = null;
            try
            {

                cmd = this.PrepararComando(tipo, cadenaComando);

                Abrir(cmd.Connection);
                cmd.Transaction = trn;
                valorEscalar = cmd.ExecuteScalar();


                return valorEscalar;

            }
            catch (Exception e)
            {

                System.Diagnostics.Debug.Assert(false, "Error al actualizar:" + e.Message);
                return -1;
            }
            finally
            {
                if (cmd.Transaction == null)
                    Cerrar(cmd.Connection);
            }

        }
        public Object EjecutarConsultaEscalar(CommandType tipo, string cadenaComando,
                                List<IDataParameter> listaParams)
        {
            Object valorEscalar = null;
            IDbCommand cmd = null;
            try
            {
                cmd = this.PrepararComando(tipo, cadenaComando, listaParams);

                Abrir(cmd.Connection);
                cmd.Transaction = trn;

                valorEscalar = cmd.ExecuteScalar();


                return valorEscalar;

            }
            catch (Exception e)
            {

                System.Diagnostics.Debug.Assert(false, "Error al actualizar:" + e.Message);
                return -1;
            }
            finally
            {
                if (cmd.Transaction == null)
                    Cerrar(cmd.Connection);
            }

        }
        public IDataReader EjecutarReader(CommandType tipo, string cadenaComando, List<IDataParameter> listaParams)
        {
            IDataReader miReader = null;
            IDbCommand cmd = null;
            try
            {
                cmd = this.PrepararComando(tipo, cadenaComando, listaParams);
                Abrir(cmd.Connection);
                miReader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                //aquí no se puede cerrar la conexión, pues el reader es conectado


                return miReader;

            }
            catch (Exception e)
            {

                System.Diagnostics.Debug.Assert(false, "Error al actualizar:" + e.Message);
                Cerrar(cmd.Connection);
                return null;
            }
        }
        public IDataReader EjecutarReader(CommandType tipo, string cadenaComando)
        {
            IDataReader miReader = null;
            IDbCommand cmd = null;
            try
            {
                cmd = this.PrepararComando(tipo, cadenaComando);
                Abrir(cmd.Connection);
                miReader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                //aquí no se puede cerrar la conexión, pues el reader es conectado

                return miReader;

            }
            catch (Exception e)
            {

                System.Diagnostics.Debug.Assert(false, "Error al actualizar:" + e.Message);
                Cerrar(cmd.Connection);
                return null;
            }


        }
        public IDataParameter CrearParametro(string nombreParametro, object valorParametro)
        {
            IDataParameter param = new FabricaObjetosConectados().getParametroProveedor(this.proveedor);
            param.ParameterName = nombreParametro;
            param.Value = (valorParametro == null) ? DBNull.Value : valorParametro;

            return param;
        }

    }
}
