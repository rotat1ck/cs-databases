namespace ef_core {
    internal class Program {
        static void Main(string[] args) {
            using ApplicationDbContext db = new ApplicationDbContext();

            User ivan = new User() { Name = "Ivan", Age = 20 };
            User anna = new User() { Name = "Anna", Age = 21 };

            db.Users.Add(ivan);
            db.Users.Add(anna);
            db.SaveChanges();
            Console.WriteLine("Объекты успешно сохранены");

            var users = db.Users.ToList();

            foreach (var user in users) {
                Console.WriteLine($"{user.Id}. {user.Name} - {user.Age}");
            }
        }
    }
}
