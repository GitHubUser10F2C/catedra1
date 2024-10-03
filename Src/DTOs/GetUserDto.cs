using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace catedra1.Src.DTOs
{
    public class GetUserDto
    {
        public int Id { get; set; }
        public string Rut { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Gender { get; set; } = string.Empty;
        public string Birthday { get; set; } = string.Empty;
    }
}