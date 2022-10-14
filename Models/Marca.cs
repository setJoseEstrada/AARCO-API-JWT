using System;
using System.Collections.Generic;

#nullable disable

namespace AARCOAPI.Models
{
    public partial class Marca
    {
        public Marca()
        {
            Submarcas = new HashSet<Submarca>();
        }

        public int Id { get; set; }
        public string Marca1 { get; set; }

        public virtual ICollection<Submarca> Submarcas { get; set; }
    }
}
