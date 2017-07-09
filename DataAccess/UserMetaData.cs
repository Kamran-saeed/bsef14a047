using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    [MetadataType(typeof(UserMetaData))]
    public partial class User
    {

    }
    public class UserMetaData
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "The Login field is required")]
        public string Login { get; set; }
        [Required(ErrorMessage = "The Password Field is required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
