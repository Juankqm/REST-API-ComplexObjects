using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComplexObjects_REST_API.Models.ViewModels
{
    public class ContactoViewModel
    {
        public int ID_Contacto { get; set; }
        public string Nombre { get; set; }
        public string COrreoElectronico { get; set; }
        public List<NumeroTelefonoViewModel> Numeros { get; set; }

    }

    public class NumeroTelefonoViewModel
    {
        public int ID_NumeroTelefono { get; set; }
        public int Numero { get; set; }
    }
}
