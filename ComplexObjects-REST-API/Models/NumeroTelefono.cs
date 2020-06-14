using System;
using System.Collections.Generic;

namespace ComplexObjects_REST_API.Models
{
    public partial class NumeroTelefono
    {
        public int IdNumeroTelefono { get; set; }
        public int IdContacto { get; set; }
        public int Numero { get; set; }

        public virtual Contacto IdContactoNavigation { get; set; }
    }
}
