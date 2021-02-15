using System;
using System.Collections.Generic;

#nullable disable

namespace Model.Database
{
    public partial class Brand
    {
        public Brand()
        {
            BrandStores = new HashSet<BrandStore>();
        }

        public int Id { get; set; }
        public string Description { get; set; }
        public int? CompanyId { get; set; }

        public virtual Company Company { get; set; }
        public virtual ICollection<BrandStore> BrandStores { get; set; }
    }
}
