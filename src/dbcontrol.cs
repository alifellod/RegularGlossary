using System.Configuration;
using System.Data.OleDb;
using System.Data;

namespace RegularGlossary
{
    public class Dbcontrol
    {
        protected OleDbConnection Connection;
        protected string ConnectionString;
        public Dbcontrol()
        {
            ConnectionString = ConfigurationManager.AppSettings["ConnectionString"];
            Connection = new OleDbConnection(ConnectionString);
        }

        public Dbcontrol(string connstring)
        {
            ConnectionString = connstring;
            Connection = new OleDbConnection(ConnectionString);
        }
        /// <summary>
        /// 根据存储过程名称和参数生成对应的OleDb命令对象
        /// </summary>
        /// <param name="storedProcName">存储过程名</param>
        /// <param name="parameters">存储过程参数</param>
        /// <returns></returns>
        private OleDbCommand BuilderQueryCommandStorPro(string storedProcName, OleDbParameter[] parameters)
        {
            OleDbCommand command;
            if (storedProcName.IndexOf('@') >= 0)
            {
                command = new OleDbCommand(storedProcName, Connection);
                command.CommandType = CommandType.Text;
            }
            else
            {
                command = new OleDbCommand(storedProcName, Connection);
                command.CommandType = CommandType.StoredProcedure;
            }

            if (parameters != null)
            {
                foreach (OleDbParameter p in parameters)
                {
                    command.Parameters.Add(p);
                }
            }
            return command;
        }
        private OleDbCommand BuilderQueryCommandText(string strEx, OleDbParameter[] parameters)
        {
            OleDbCommand command = new OleDbCommand(strEx, Connection);
            command.CommandType = CommandType.Text;
            if (parameters != null)
            {
                foreach (OleDbParameter p in parameters)
                {
                    command.Parameters.Add(p);
                }
            }
            return command;
        }
        /// <summary>
        /// 返回执行操作成功的数目
        /// </summary>
        /// <param name="storedProcName">存储过程名</param>
        /// <param name="parameters">参数组</param>
        /// <returns></returns>
        public int ReExNum(string storedProcName, OleDbParameter[] parameters)
        {
            int effect = 0;
            if (Connection.State == ConnectionState.Closed)
            {
                Connection.Open();
            }
            OleDbTransaction trans = Connection.BeginTransaction();
            try
            {
                OleDbCommand cmd = BuilderQueryCommandStorPro(storedProcName, parameters);
                cmd.Transaction = trans;
                effect = cmd.ExecuteNonQuery();
                trans.Commit();
                return effect;
            }
            catch
            {

                trans.Rollback();
                Connection.Close();
                return effect;
            }
            finally
            {
                Connection.Close();
            }
        }
        public int ReExNum(string strOleDb)
        {
            int effect = 0;
            if (Connection.State == ConnectionState.Closed)
            {
                Connection.Open();
            }
            OleDbTransaction trans = Connection.BeginTransaction();
            try
            {
                OleDbCommand cmd = new OleDbCommand(strOleDb, Connection);
                cmd.Transaction = trans;
                effect = cmd.ExecuteNonQuery();
                trans.Commit();
                return effect;
            }
            catch
            {

                trans.Rollback();
                Connection.Close();
                return effect;
            }
            finally
            {
                Connection.Close();
            }
        }
        /// <summary>
        /// 返回dateSet
        /// </summary>
        /// <param name="procName"></param>
        /// <param name="parameters"></param>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public DataSet ReSelectdt(string procName, OleDbParameter[] parameters, string tableName)
        {
            try
            {

                DataSet ds = new DataSet();
                if (Connection.State == ConnectionState.Closed)
                {
                    Connection.Open();
                }
                OleDbDataAdapter myDa = new OleDbDataAdapter();
                myDa.SelectCommand = BuilderQueryCommandStorPro(procName, parameters);
                myDa.Fill(ds, tableName);
                return ds;
            }
            catch
            {
                return null;
            }
            finally
            {
                Connection.Close();
            }
        }
        /// <summary>		
        /// 执行OleDb语句返回OleDbDataReader
        /// </summary>
        /// <param name="strOleDb">OleDb语句</param>
        /// <returns>OleDbDataReader</returns>
        public OleDbDataReader ReSelectdr(string strOleDb)
        {
            if (Connection.State == ConnectionState.Closed)
            {
                Connection.Open();
            }
            try
            {
                OleDbCommand cmd = new OleDbCommand(strOleDb, Connection);
                return cmd.ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch
            {
                Connection.Close();
                return null;
            }
        }
        public OleDbCommand ReOleCmd(string strOleDb)
        {
            if (Connection.State == ConnectionState.Closed)
            {
                Connection.Open();
            }
            try
            {
                OleDbCommand cmd = new OleDbCommand(strOleDb, Connection);
                return cmd;
            }
            catch
            {
                Connection.Close();
                return null;
            }
        }
        /// <summary>
        /// 返回结果的存储过程
        /// </summary>
        /// <param name="storedProcName">任何OleDb语句</param>
        /// <param name="parameters">参数值</param>
        /// <returns></returns>
        public OleDbDataReader ReSelectdr(string storedProcName, OleDbParameter[] parameters)
        {
            try
            {
                OleDbDataReader reader;
                OleDbCommand cmd = BuilderQueryCommandStorPro(storedProcName, parameters);
                if (Connection.State == ConnectionState.Closed)
                {
                    Connection.Open();
                }
                reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                return reader;
            }
            catch
            {
                return null;
            }
        }
        public DataTable ReSelectdtb(string storedProcName, OleDbParameter[] parameters)
        {
            try
            {

                DataTable dt = new DataTable();
                if (Connection.State == ConnectionState.Closed)
                {
                    Connection.Open();
                }
                OleDbDataAdapter myDa = new OleDbDataAdapter();
                myDa.SelectCommand = BuilderQueryCommandStorPro(storedProcName, parameters);
                myDa.Fill(dt);

                return dt;
            }
            catch
            {
                return null;
            }
            finally
            {
                Connection.Close();
            }
        }
        /// <summary>
        /// 执行OleDb语句返回DataTable
        /// </summary>
        public DataTable ReSelectdtb(string strOleDb)
        {
            try
            {

                DataTable dt = new DataTable();
                if (Connection.State == ConnectionState.Closed)
                {
                    Connection.Open();
                }
                OleDbDataAdapter myDa = new OleDbDataAdapter();
                //myDa.SelectCommand.Parameters.Add("@UserName", OleDbDbType.NVarChar, 60).Value = userName;

                myDa.SelectCommand = new OleDbCommand(strOleDb, Connection);
                myDa.Fill(dt);

                return dt;
            }
            catch
            {
                return null;
            }
            finally
            {
                Connection.Close();
            }
        }
        /// <summary>
        /// 通過存儲過程及自定義參數組查詢返回OleDbDataAdapter對象
        /// </summary>
        public OleDbDataAdapter ReSelectdat(string storedProcName, OleDbParameter[] parameters)
        {
            if (Connection.State == ConnectionState.Closed)
            {
                Connection.Open();
            }
            try
            {
                OleDbCommand cmd = BuilderQueryCommandStorPro(storedProcName, parameters);
                OleDbDataAdapter oleDbdat1 = new OleDbDataAdapter(cmd);
                return oleDbdat1;
            }
            catch
            {
                Connection.Close();
                return null;
            }
        }
        /// <summary>
        /// 执行OleDb语句返回影响行数
        /// </summary>
        /// <param name="strOleDb">OleDb插入,更新,刪除等语句</param>
        public void ExOleDb(string strOleDb)
        {
            if (Connection.State == ConnectionState.Closed)
            {
                Connection.Open();
            }
            OleDbTransaction trans = Connection.BeginTransaction();
            try
            {
                OleDbCommand cmd = new OleDbCommand(strOleDb, Connection);
                cmd.Transaction = trans;
                cmd.ExecuteNonQuery();
                trans.Commit();
            }
            catch
            {

                trans.Rollback();
                Connection.Close();
            }
            finally
            {
                Connection.Close();
            }
        }
        public void ExOleDb(string storedProcName, OleDbParameter[] parameters)
        {
            if (Connection.State == ConnectionState.Closed)
            {
                Connection.Open();
            }
            OleDbTransaction trans = Connection.BeginTransaction();
            try
            {
                OleDbCommand cmd = BuilderQueryCommandStorPro(storedProcName, parameters);
                cmd.Transaction = trans;
                cmd.ExecuteNonQuery();
                trans.Commit();
            }
            catch
            {

                trans.Rollback();
                Connection.Close();
            }
            finally
            {
                Connection.Close();
            }
        }


        /// <summary>
        ///	 執行OleDb查詢語句,返回記錄條數
        /// </summary>
        /// <param name="strOleDb">Select語句</param>
        /// <returns>返回查詢到之記錄條數</returns>
        public int ReSelectNum(string strOleDb)
        {
            int effect = 0;
            if (Connection.State == ConnectionState.Closed)
            {
                Connection.Open();
            }
            try
            {
                OleDbCommand cmd = new OleDbCommand(strOleDb, Connection);
                OleDbDataReader dr = cmd.ExecuteReader();
                if (dr != null && dr.Read())
                {
                    effect = int.Parse(dr.GetValue(0).ToString());
                }
                return effect;
            }
            catch
            {
                Connection.Close();
                effect = 0;
                return effect;

            }
            finally
            {
                Connection.Close();
            }
        }
        public int ReSelectNum(string storedProcName, OleDbParameter[] parameters)
        {
            int effect = 0;
            if (Connection.State == ConnectionState.Closed)
            {
                Connection.Open();
            }
            try
            {
                OleDbCommand cmd = BuilderQueryCommandStorPro(storedProcName, parameters);
                OleDbDataReader dr = cmd.ExecuteReader();
                if (dr != null && dr.Read())
                {
                    effect = int.Parse(dr.GetValue(0).ToString());
                }
                return effect;
            }
            catch
            {
                Connection.Close();
                effect = 0;
                return effect;

            }
            finally
            {
                Connection.Close();
            }
        }
    }

}
