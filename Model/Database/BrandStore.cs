using System;
using System.Collections.Generic;

#nullable disable

namespace Model.Database
{
    public partial class BrandStore
    {
        public int Id { get; set; }
        public int? Idbrand { get; set; }
        public int? IdStore { get; set; }

        public virtual Store IdStoreNavigation { get; set; }
        public virtual Brand IdbrandNavigation { get; set; }
    }
}
