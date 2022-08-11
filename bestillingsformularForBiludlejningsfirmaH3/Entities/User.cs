using System;
using System.Collections.Generic;

namespace bestillingsformularForBiludlejningsfirmaH3.Entities
{
    public partial class User
    {
        public int UserId { get; set; }
        public string UserFullname { get; set; } = null!;
        public string UserEmail { get; set; } = null!;
        public string UserPassword { get; set; } = null!;
    }
}
