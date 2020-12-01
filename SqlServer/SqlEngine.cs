using Contracts;
using System.Data;
using System.Data.SqlClient;

namespace SqlServer
{
    public class SqlEngine : IStorageEngine
    {
        private readonly string m_connectionString;
        public SqlEngine(string connectionString)
        {
            m_connectionString = connectionString;
        }

        public DataTable GetCumulativeViews(CumulativeViewsParameters searchParameters)
        {
            var result = new DataTable();
            using (var conn = new SqlConnection(m_connectionString))
            {
                var sqlComm = new SqlCommand("GetCumulativeViews", conn);
                sqlComm.Parameters.AddWithValue("@StartTime", searchParameters.StartTime);
                sqlComm.Parameters.AddWithValue("@DueTime", searchParameters.DueTime);
                sqlComm.CommandType = CommandType.StoredProcedure;

                var da = new SqlDataAdapter();
                da.SelectCommand = sqlComm;

                da.Fill(result);
                return result;
            }
        }
    }
 }
