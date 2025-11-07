namespace ef_core_crud {
    internal class Program {
        static void Main(string[] args) {
            using (AppDbContext db = new AppDbContext()) {
                User ivan = new User {
                    Name = "Ivan",
                    Age = 20
                };
                User anna = new User {
                    Name = "Anna",
                    Age = 21
                };

                db.Users.Add(ivan);
                db.Users.Add(anna);
                db.SaveChanges();
            }

            using (AppDbContext db = new AppDbContext()) {
                var users = db.Users.ToList();
                Console.WriteLine($"List after added:\n{string.Join("\n", users)}");
            }

            using (AppDbContext db = new AppDbContext()) {
                var first = db.Users.FirstOrDefault();
                if (first != null) {
                    first.Name = "Gleb";
                    first.Age = 20000;

                    db.Users.Update(first);
                    db.SaveChanges();

                    var users = db.Users.ToList();
                    Console.WriteLine($"List after update:\n{string.Join("\n", users)}");
                }
            }

            using (AppDbContext db = new AppDbContext()) {
                var last = db.Users.FirstOrDefault();
                if (last != null) {
                    db.Users.Remove(last);
                    db.SaveChanges();

                    var users = db.Users.ToList();
                    Console.WriteLine($"List after removal:\n{string.Join("\n", users)}");
                }
            }
        }
    }
}
