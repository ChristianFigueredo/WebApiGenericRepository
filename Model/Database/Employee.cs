using System;
using System.Collections.Generic;

#nullable disable

namespace Model.Database
{
    public partial class Employee
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Documento { get; set; }
        public int? IdStore { get; set; }

        public virtual Store IdStoreNavigation { get; set; }
    }
}
