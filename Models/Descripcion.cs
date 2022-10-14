using System;
using System.Collections.Generic;

#nullable disable

namespace AARCOAPI.Models
{
    public partial class Descripcion
    {
        public int Id { get; set; }
        public string Descripcion1 { get; set; }
        public string DescripcionId { get; set; }
        public int IdModelo { get; set; }

        public virtual Modelo IdModeloNavigation { get; set; }
    }
}
