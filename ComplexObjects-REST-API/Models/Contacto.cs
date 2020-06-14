using System;
using System.Collections.Generic;

namespace ComplexObjects_REST_API.Models
{
    public partial class Contacto
    {
        public Contacto()
        {
            NumeroTelefono = new HashSet<NumeroTelefono>();
        }

        public int IdContacto { get; set; }
        public string Nombre { get; set; }
        public string CorreoElectronico { get; set; }

        public virtual ICollection<NumeroTelefono> NumeroTelefono { get; set; }
    }
}
