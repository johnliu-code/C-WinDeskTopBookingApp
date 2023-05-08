using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration; 

namespace Booking_Test.Repositories
{
    public abstract class RepositoryBase
    {
        private readonly string _connectionString;
        public RepositoryBase()
        {
            //_connectionString = "Server=(localdb)\\MSSQLLocalDB;Database=MotelBookingMSDb;Integrated Security=true";
            _connectionString = ConfigurationManager.ConnectionStrings["Booking_Test.Properties.Settings.MotelBookingMSDbConnectionString"].ConnectionString;
        }
        protected SqlConnection GetConnection()
        {
            return new SqlConnection(_connectionString);
        }
    }
}
