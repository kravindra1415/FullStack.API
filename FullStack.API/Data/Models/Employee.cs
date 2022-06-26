using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace FullStack.API.Data.Models
{
    public class Employee
    {
        public Guid Id { get; set; }

        [Unicode(false)]
        [StringLength(50)]
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public long Phone { get; set; }
        public long Salary { get; set; }

        [Unicode(false)]
        [StringLength(50)]
        public string Department { get; set; }=null!;

    }
}
