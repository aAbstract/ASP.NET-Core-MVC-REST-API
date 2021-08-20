using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace commander.DataLayer
{
    public class SqlServerDataAccess : IDataAccess
    {
        // class constants
        private const string SERVER_ADDR = "192.168.108.128";
        private const string SERVER_PORT = "1433";
        private const string DATABASE_NAME = "CommanderApi";
        private const string USER_NAME = "SA";
        private const string USER_PASSWORD = "p@55word";
        private string SqlServerCs = "";
        private string[] CommandKeys = { "CommandId", "HowTo", "Line", "Platfrom" };

        // class private methods
        private void ObjKeyMap(string[] Keys, Dictionary<string, string> Obj, SqlDataReader Reader)
        {
            foreach (string Key in Keys)
            {
                Obj[Key] = Reader.GetValue(Key).ToString();
            }
        }
        public SqlServerDataAccess()
        {
            this.SqlServerCs = $"Server={SERVER_ADDR},{SERVER_PORT};Initial Catalog={DATABASE_NAME};User ID={USER_NAME};Password={USER_PASSWORD}";
        }
        // IDataAccess interface implementation
        public Task<List<Dictionary<string, string>>> GetAllCommands()
        {
            return Task.Run(() =>
            {
                using (SqlConnection DbObj = new SqlConnection(this.SqlServerCs))
                {
                    using (SqlCommand cmd = new SqlCommand("GetAllCommands", DbObj))
                    {
                        List<Dictionary<string, string>> Commands = new List<Dictionary<string, string>>();
                        cmd.CommandType = CommandType.StoredProcedure;
                        DbObj.Open();
                        using (SqlDataReader Reader = cmd.ExecuteReader())
                        {
                            if (Reader != null)
                            {
                                while (Reader.Read())
                                {
                                    Dictionary<string, string> Row = new Dictionary<string, string>();
                                    this.ObjKeyMap(this.CommandKeys, Row, Reader);
                                    Commands.Add(Row);
                                }
                            }
                        }
                        DbObj.Close();
                        return Commands;
                    }
                }
            });
        }

        public Task<Dictionary<string, string>> GetCommandById(int Id)
        {
            return Task.Run(() =>
            {
                using (SqlConnection DbObj = new SqlConnection(this.SqlServerCs))
                {
                    using (SqlCommand cmd = new SqlCommand("GetCommandById", DbObj))
                    {
                        Dictionary<string, string> Command = new Dictionary<string, string>();
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Id", SqlDbType.Int).Value = Id;
                        DbObj.Open();
                        using (SqlDataReader Reader = cmd.ExecuteReader())
                        {
                            if (Reader != null)
                            {
                                Reader.Read();
                                this.ObjKeyMap(this.CommandKeys, Command, Reader);
                            }
                        }
                        DbObj.Close();
                        return Command;
                    }
                }
            });
        }

        public Task<int> CreateCommand(Dictionary<string, string> CommandToAdd)
        {
            return Task.Run(() =>
            {
                using (SqlConnection DbObj = new SqlConnection(this.SqlServerCs))
                {
                    using (SqlCommand cmd = new SqlCommand("AddCommand", DbObj))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@HowTo", SqlDbType.VarChar).Value = CommandToAdd["HowTo"];
                        cmd.Parameters.AddWithValue("@Line", SqlDbType.VarChar).Value = CommandToAdd["Line"];
                        cmd.Parameters.AddWithValue("@Platfrom", SqlDbType.VarChar).Value = CommandToAdd["Platfrom"];
                        DbObj.Open();
                        int Res = -1;
                        using (SqlDataReader Reader = cmd.ExecuteReader())
                        {
                            if (Reader != null)
                            {
                                Reader.Read();
                                Res = System.Convert.ToInt32(Reader.GetValue("NewId"));
                            }
                        }
                        DbObj.Close();
                        return Res;
                    }
                }
            });
        }
    }
}