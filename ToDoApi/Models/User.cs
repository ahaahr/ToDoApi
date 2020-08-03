using System.ComponentModel.DataAnnotations;

namespace ToDoApi.Models
{
    public class User
    {
        [Required]
        public string ID { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }

        public string Token { get; set; }
    }
}
