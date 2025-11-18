using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace ef_core_fluent_api {
    [Index("Phonenumber")]
    internal class User {
        //[Key]
        //[Column("user_id")]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public int Age { get; set; }
        public string? Phonenumber { get; set; }

        //public Company? Company { get; set; }
    }

    public class Company {
        public int Id { get; set; }
        public string? Name { get; set; }
    }

    public class Country {
        public int Id { get; set; }
        public string? Name { get; set; }
    }
}
