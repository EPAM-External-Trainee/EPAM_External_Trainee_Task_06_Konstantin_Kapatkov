using System;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DAL.DB.DBDeployment
{
    /// <summary>Class describes functionality for database deployment</summary>
    public static class DatabaseDeployment
    {
        /// <summary>SQL scripts files location</summary>
        private const string _sqlScriptsLocation = @"..\..\..\..\DAL\DB\SQLScripts";

        /// <summary>SQL scripts file extension</summary>
        private const string _sqlScriptsExtension = "*.sql";

        /// <summary>Regex for correct spliting scripts contains 'GO'</summary>
        private static readonly Regex _regex = new Regex(@"^\s*GO\s*$", RegexOptions.Multiline | RegexOptions.IgnoreCase);

        /// <summary>Expanding database</summary>
        /// <param name="serverConnectionString">SQL Server connection string</param>
        /// <remarks>SQL Server connection string must have 'master' as initial catalog</remarks>
        /// <returns>Operation result</returns>
        public static async Task<bool> TryExpandTheDatabaseAsync(string serverConnectionString = @"Data Source=KONSTANTINPC\SQLEXPRESS; Initial Catalog=master; Integrated Security=true;")
        {
            try
            {
                using var connection = new SqlConnection(serverConnectionString);
                await connection.OpenAsync().ConfigureAwait(false);

                foreach (var fileName in Directory.GetFiles(_sqlScriptsLocation, _sqlScriptsExtension).Select(Path.GetFileName).ToArray())
                {
                    foreach (string command in _regex.Split(File.ReadAllText(Path.Combine(_sqlScriptsLocation, fileName))).Where(command => command.Trim() != ""))
                    {
                        using var sqlCommand = new SqlCommand(command, connection);
                        await sqlCommand.ExecuteNonQueryAsync().ConfigureAwait(false);
                    }
                }

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}