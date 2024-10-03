using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace catedra1.Src.Filters
{
    public class UserFilter
    {
        [RegularExpression(@"male|female|other|prefer not to say",
        ErrorMessage = "Gender must be 'male', 'female', 'other', or 'prefer not to say'.")]
        public string? Gender { get; set; } = string.Empty;
        [RegularExpression(@"asc|desc",
        ErrorMessage = "Sorting must be 'asc' for ascending order, or 'desc' for descending order")]
        public string? Sort {get; set; } = string.Empty;
    }
}