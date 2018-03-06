using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Methode
{
    public class CAD
    {
        private string scnx;
        private string rq_sql;
        private System.Data.SqlClient.SqlDataAdapter da;
        private System.Data.SqlClient.SqlConnection cnx;
        private System.Data.SqlClient.SqlCommand cmd;
        private System.Data.DataSet ds;

        public CAD()
        {
            this.scnx = @"Data Source=ENBICOMPU\SQLEXPRESS;Initial Catalog=TPSOA;Integrated Security=True";
            this.rq_sql = "NC";
            this.cnx = new System.Data.SqlClient.SqlConnection();
            this.cmd.CommandType = System.Data.CommandType.Text;

            this.da = new System.Data.SqlClient.SqlDataAdapter();
            this.da.SelectCommand = this.cmd;

        }

        public System.Data.DataSet getRows(string rowsName, string rq_sql)
        {
            this.ds = new System.Data.DataSet();
            this.cmd.CommandText = this.rq_sql;
            this.da.Fill(this.ds, rowsName);
            return this.ds;
        }
    }
}
