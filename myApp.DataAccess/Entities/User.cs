using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myApp.DataAccess.Entities
{
    [Table("user")]
    public class User
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Account { get; set; }
        public string Passsword { get; set; }
        public int Role { get; set; }
        public bool IsActive { get; set; }
    }
}
