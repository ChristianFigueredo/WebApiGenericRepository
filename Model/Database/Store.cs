using System;
using System.Collections.Generic;

#nullable disable

namespace Model.Database
{
    public partial class Store
    {
        public Store()
        {
            BrandStores = new HashSet<BrandStore>();
            Employees = new HashSet<Employee>();
        }

        public int Id { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }

        public virtual ICollection<BrandStore> BrandStores { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
    }
}
