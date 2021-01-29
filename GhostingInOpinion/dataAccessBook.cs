using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace GhostingInOpinion
{
    public class dataAccessBook
    {
        public List<BookSetGet> GetBook(string bookname)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.Cnnval("Database")))
            {
                var output = connection.Query<BookSetGet>($"select * from BookTB where Bookname = '{bookname}'").ToList();
                return output;
            }
        }
    }
}
