


namespace BKStudentMVC
{
    using BKStudentMVC.Models;
    using StudentLib.Services;
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Data;
    using System.Data.SqlClient;
    using System.Data.SqlServerCe;
    using System.Diagnostics;
    using System.IO;
    using System.Linq;

    public class ValidationRuleConfig
    {
        public static readonly string ConnectionString = ConfigurationManager.ConnectionStrings["RuleModelDBContext"].ConnectionString;
        protected static bool CreateDatabase(string dbName, string dbFileName)
        {
            try
            {
                using (var connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();
                    var cmd = connection.CreateCommand();

                    DetachDatabase(dbName);

                    cmd.CommandText = $"CREATE DATABASE @dbName ON (NAME = @dbName, FILENAME = @dbFileName)";
                    var dbNameParam = new SqlParameter("@dbName", SqlDbType.Char);
                    dbNameParam.Value = dbName;

                    var dbFileNameParam = new SqlParameter("@dbFileName", SqlDbType.Char);
                    dbFileNameParam.Value = dbFileName;

                    cmd.Parameters.Add(dbNameParam);
                    cmd.Parameters.Add(dbFileNameParam);
                    cmd.ExecuteNonQuery();
                }
                if (File.Exists(dbFileName))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                throw;
            }
        }
        protected static bool DetachDatabase(string dbName)
        {
            try
            {
                using (var conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();
                    var cmd = conn.CreateCommand();
                    cmd.CommandText = "exec_sp_detach @dbName";
                    var nameParam = new SqlParameter("@dbName", SqlDbType.Char);
                    nameParam.Value = dbName;
                    cmd.Parameters.Add(nameParam);
                    cmd.ExecuteNonQuery();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
        public static void Start()
        {
            Debug.WriteLine(ConnectionString);
            //var conn = new SqlConnection(ConnectionString);
            //conn.Open();
            //conn.Close();

            IEnumerable<Type> ruleTypes = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(x => x.GetTypes())
                .Where(x => typeof(IValidationRule).IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract);

            //RuleDBContext ruleDB = new RuleDBContext(connectionString);
            RuleDBContext ruleDB = new RuleDBContext();
            foreach (var type in ruleTypes)
            {
                var rule = Activator.CreateInstance(type) as IValidationRule;
                RuleModel ruleModel = new RuleModel(rule);
                //Console.WriteLine(ruleModel);
                Debug.WriteLine(ruleModel);
                //var cmd = conn.CreateCommand();
                //cmd.CommandText = 

                //if (ruleDB.Rules.Find(ruleModel) == null)
                //{
                //    ruleDB.Rules.Add(ruleModel);
                //}
            }

        }
        public static void End()
        {

        }
    }
}