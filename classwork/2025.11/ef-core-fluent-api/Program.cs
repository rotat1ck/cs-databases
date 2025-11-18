namespace ef_core_fluent_api {
    internal class Program {
        static void Main(string[] args) {
            using (AppDbContext db = new AppDbContext()) {
                var users = db.Users.ToList();
                foreach (var user in users) {
                    Console.WriteLine(user.Name);
                }
            }
        }
    }
}
