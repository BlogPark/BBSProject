using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BBSProject.DataModel.Model;
using System.Data;
using System.Data.SqlClient;
using Dapper;

namespace BBSProject.SQLCommDAL
{
    public class Class1
    {

        private readonly string sqlconnectstr = @"Data Source=localhost;Initial Catalog=BBSProData;User ID=sa;password=!@#123qwe;pooling=false;";

        public  SqlConnection GetOpenConnection(bool mars = false)
        {
            var cs = sqlconnectstr;
            if (mars)
            {
                SqlConnectionStringBuilder scsb = new SqlConnectionStringBuilder(cs);
                scsb.MultipleActiveResultSets = true;
                cs = scsb.ConnectionString;
            }
            var connection = new SqlConnection(cs);
            connection.Open();
            return connection;
        }
        
        public IEnumerable<AdvertInfo> GetAllAvertInfo()
        {
            using (IDbConnection conn = new SqlConnection(sqlconnectstr))
            {
                conn.Open();

                string sqltxt = @"SELECT  ID ,
        AdvertPositionID ,
        AdvertTip ,
        AdvertFileName ,
        AdvertFilePath ,
        AdvertClickCount
FROM    BBSProData.dbo.bbs_AdvertInfo";
                var co = conn.QueryAsync<AdvertInfo>(sqltxt).Result;
                return co;
            }
        }
    }
}
