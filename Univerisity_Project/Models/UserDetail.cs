using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Univerisity_Project.Models
{
    public class UserDetail
    {
        [Key]
        [ForeignKey("User")]
        public int UserId { get; set; }
        public string UserName { get; set; }
        public User User { get; set; }
    }
}