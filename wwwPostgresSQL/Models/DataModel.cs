using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace wwwPostgresSQL.Models
{
    public class DataModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Address { get; set; }
        public decimal Salary { get; set; }
    }
}
