﻿using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace GameBox.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public virtual ICollection<Article> Articles { get; set; }
    }
}
