using Microsoft.Data.SqlClient;

namespace DbConnection;

 class Program {
    static void Main(string[] args) {
        string path = @"Data Source=ROTATICK;Initial Catalog=test;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=True;";
        using(SqlConnection sql = new SqlConnection(path)) {
            sql.Open();
            Console.WriteLine("Введите имя: ");
            string name = Console.ReadLine().Trim();

            SqlCommand cmd = new();
            cmd.CommandText = $"insert into users(name) values ('{name}')";
            cmd.Connection = sql;

            cmd.ExecuteNonQuery();
            // cmd.ExecuteReader(); // SELECT
            // cmd.ExecuteScalar(); // MIN

            cmd.CommandText = "select * from users";
            SqlDataReader reader = cmd.ExecuteReader();

            // Strongly typed
            if (reader.HasRows) {
                string firstName = reader.GetName(0);
                Console.WriteLine($"Первая запись: {name}");
            }
                    
            // Object type
            while (reader.Read()) {
                object id = reader.GetValue(0);
                Console.WriteLine($"Запись: {id}");
            }
            
        }
    }
}
