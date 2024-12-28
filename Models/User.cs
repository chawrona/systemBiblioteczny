using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace systemBiblioteczny.Models
{
    public class User : IdentityUser
    {
        [Column(TypeName = "nvarchar(50)")]
        [StringLength(50)]
        public string Login { get; set; }

    }
}
