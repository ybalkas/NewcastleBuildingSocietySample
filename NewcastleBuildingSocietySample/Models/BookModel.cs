using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewcastleBuildingSocietySample.Models
{
    internal class BookModel
    {
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string Phone{ get; set; }
        public string Email { get; set; }
        public string? CallTime { get; set; }
        public string? AdditinoalInfo { get; set; }
    }
}
