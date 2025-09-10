namespace SqlConnection;

using Microsoft.Data.SqlClient;
class Program {
    static string path = @"Data Source=ROTATICK;Initial Catalog=test;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False";
    static string selStr = "select * from Authors";
    static void Main(string[] args) {
        //Console.WriteLine("Hello, World!");
        //string insStr = @"insert into Authors(FirstName, LastName) values ('Ivan', 'Ivanov')";

        //using (SqlConnection conn = new(path)) {
        //    conn.Open();
        //    SqlCommand cmd = new(insStr, conn);
        //    cmd.ExecuteNonQuery();

        //}
        ReadData();
    }

    public static void ReadData() {
        SqlDataReader? reader = null;
        using (SqlConnection conn = new(path)) {
            conn.Open();
            SqlCommand cmd = new("select * from Authors; select * from Books", conn);
            reader = cmd.ExecuteReader();

            do {
                int line = 0;
                while (reader.Read()) {
                    if (line == 0) {
                        for (int i = 0; i < reader.FieldCount; i++) {
                            Console.Write(reader.GetName(i).ToString() + "\t");
                        }
                        Console.WriteLine();
                    }
                    line++;
                    Console.WriteLine(reader[0] + "\t" + reader[1] + "\t" + reader[2]);
                }
                Console.WriteLine("Total records: " + line);
            } while (reader.NextResult());

            reader.Close();
        }
    }
}

