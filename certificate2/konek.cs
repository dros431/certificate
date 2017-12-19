using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Sql;
using System.Data.SqlClient;

namespace certificate2
{  
   
    class konek
    {
        SqlConnection con;

        public SqlConnection getcon()
        {
            con = new SqlConnection(@"Data Source=MENDROS\SQLEXPRESS;Initial Catalog=bywave;Integrated Security=True");
            con.Open();

            return con;
        }
    }
}
