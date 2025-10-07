using System.Configuration;
using System.Data;
using Microsoft.Data.SqlClient;

namespace DisconnectedMode
{
    public partial class Form1 : Form {
        string cs = null;
        private SqlConnection conn = null;
        SqlDataAdapter da = null;
        DataSet set = null;
        SqlCommandBuilder cmd = null;

        public Form1() {
            InitializeComponent();
            conn = new SqlConnection();

            cs = ConfigurationManager.ConnectionStrings["MyConnString"].ConnectionString;
            conn.ConnectionString = cs;
        }

        private void FillButton_Click(object sender, EventArgs e) {
            //using (SqlConnection conn = new SqlConnection(cs)) {
                try {
                    set = new DataSet();

                    string sql = InputBox.Text;
                    da = new SqlDataAdapter(sql, conn);
                    DataGrid.DataSource = null;
                    cmd = new SqlCommandBuilder(da);

                    da.Fill(set, "Books");
                    DataGrid.DataSource = set.Tables["Books"];
                } catch {
                
                } 
            // }
        }

        private void ExecButton_Click(object sender, EventArgs e) {
            da.Update(set, "Books");
        }
    }
}
