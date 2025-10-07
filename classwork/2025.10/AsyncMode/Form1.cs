using System.Configuration;
using System.Data;
using System.Data.Common;
using Microsoft.Data.SqlClient;

namespace AsyncMode
{
    public partial class Form1 : Form {
        DbConnection? conn = null;
        DbProviderFactory? fact = null;
        string connectionString = "";
        public Form1() {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e) {
            conn.ConnectionString = connectionString;
            await conn.OpenAsync();

            DbCommand cmd = conn.CreateCommand();
            cmd.CommandText = "WAITFOR DELAY '00:00:05'";
            cmd.CommandText += textBox1.Text.ToString();
            DataTable dt = new DataTable();

            using (DbDataReader dr = await cmd.ExecuteReaderAsync()) {
                int line = 0;

                do {
                    while (await dr.ReadAsync()) {
                        if (line == 0) {
                            for (int i = 0; i < dr.FieldCount; ++i) {
                                dt.Columns.Add(dr.GetName(i));
                            }
                            line++;
                        }

                        DataRow row = dt.NewRow();
                        for (int i = 0; i < dr.FieldCount; ++i) {
                            row[i] = await dr.GetFieldValueAsync<Object>(i);
                        }

                        dt.Rows.Add(row);
                    }
                } while (await dr.NextResultAsync());

                dataGridView1.DataSource = null;
                dataGridView1.DataSource = dt;
            }

            await conn.CloseAsync();
        }

        private void Form1_Load(object sender, EventArgs e) {
            //DbProviderFactories.RegisterFactory("Microsoft.Data.SqlClient", SqlClientFactory.Instance);
            //fact = DbProviderFactories.GetFactory("Microsoft.Data.SqlClient");
            conn = new SqlConnection();
            connectionString = GetConnectionStringByProvider("Microsoft.Data.SqlClient");
            if (connectionString == null) {
                MessageBox.Show("В конфиге нет строки подключения");
            }
        }

        static string GetConnectionStringByProvider(string providerName) {
            string returnValue = null;
            ConnectionStringSettingsCollection settings = ConfigurationManager.ConnectionStrings;

            if (settings != null) {
                foreach (ConnectionStringSettings cs in settings) {
                    if (cs.ProviderName == providerName) {
                        returnValue = cs.ConnectionString;
                        break;
                    }
                }
            }

            return returnValue;
        }

        private void textBox1_TextChanged(object sender, EventArgs e) {
            if (textBox1.Text.Length > 0) {
                button1.Enabled = true;
            } else {
                button1.Enabled = false;
            }
        }
    }
}
