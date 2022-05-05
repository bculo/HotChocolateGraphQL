using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HotChocolateGraphQL.Models
{
    public class Platform
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string LicenseKey { get; set; }
        public virtual ICollection<Command> Commands { get; set; } = new HashSet<Command>();
    }
}
