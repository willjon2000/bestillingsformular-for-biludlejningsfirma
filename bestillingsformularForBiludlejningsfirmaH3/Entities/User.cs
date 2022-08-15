using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace bestillingsformularForBiludlejningsfirmaH3.Entities
{
    public partial class User
    {
        public int UserId { get; set; }
        [Required]
        [StringLength(255)]
        public string UserFullname { get; set; } = null!;
        [Required]
        [StringLength(255)]
        [EmailAddress]
        public string UserEmail { get; set; } = null!;
        [Required, StringLength(255, ErrorMessage = "Password must be between 8 and 256", MinimumLength = 8), DataType(DataType.Password)]
        [RegularExpression(@"^(?=.*[A-ZÆØÅ])(?=.*[a-zæøå])(?=.*\d)(?=.*\W).{8,40}",
        ErrorMessage = "Password must contain atleast 1 number, 1 upper and lowercase letter and 1 special character")]
        public string UserPassword { get; set; } = null!;
    }
}
