using System;
using System.Collections.Generic;

#nullable disable

namespace Model.Database
{
    public partial class Company
    {
        public Company()
        {
            Brands = new HashSet<Brand>();
        }

        public int Id { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Brand> Brands { get; set; }
    }
}
