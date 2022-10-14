using System;
using System.Collections.Generic;

#nullable disable

namespace AARCOAPI.Models
{
    public partial class Modelo
    {
        public Modelo()
        {
            Descripcions = new HashSet<Descripcion>();
        }

        public int Id { get; set; }
        public short Modelo1 { get; set; }
        public int IdSubMarca { get; set; }

        public virtual Submarca IdSubMarcaNavigation { get; set; }
        public virtual ICollection<Descripcion> Descripcions { get; set; }
    }
}
