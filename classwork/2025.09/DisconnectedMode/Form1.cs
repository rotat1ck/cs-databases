using System.Data;
using Microsoft.Data.SqlClient;

namespace DisconnectedMode
{
    public partial class Form1 : Form {
        string cs = @"Data Source=ROTATICK;Initial Catalog=test;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False";

        private SqlDataReader reader;
        private DataTable table;
        private SqlConnection conn;
        private SqlCommand cmd; 

        public Form1() {
            InitializeComponent();
            conn = new SqlConnection();

            conn.ConnectionString = cs;

        }
        DataSet ds = new DataSet();
        DataTable dt1 = ds.Tables[0];
        string ln = dt1.Rows[0][1].ToString();
        private void ExecButton_Click(object sender, EventArgs e) {
            
        }
    }
}
