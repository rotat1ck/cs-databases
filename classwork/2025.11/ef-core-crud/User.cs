namespace ef_core_crud {
    public class User {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int Age { get; set; }

        public override string ToString() {
            return $"{Id}: {Name} - {Age}";
        }
    }
}
