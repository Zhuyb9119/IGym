using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using IGym.IRepository.Model;

namespace IGym.EFRepository.Model
{
    public class User : IUser
    {
        [Key]
        public int Id { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string UserName { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string Password { get; set; }

        public DateTime DateTime { get; set; }
    }
}
