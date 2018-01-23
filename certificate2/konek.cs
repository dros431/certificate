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
            con = new SqlConnection(@"Data Source=MYKHELBELLE-SDU;Initial Catalog=bywave;User ID=sa;Password=1234");
            con.Open();

            return con;
        }
    }
}
