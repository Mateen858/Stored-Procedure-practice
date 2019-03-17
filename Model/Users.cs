using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Model
{
  public  class Users
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage ="Name is required")]
        [StringLength(4, ErrorMessage ="minimum 4 characters are required")]
        public string Name { get; set; }
        public string Age { get; set; }
        public bool IsEmployed { get; set; }
        public DateTime DateOfBirth { get; set; }

    }
}
