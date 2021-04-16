using System;
using System.Collections.Generic;

#nullable disable

namespace ClimaWeb.Models
{
    public partial class Ciudades
    {
        public int IdCiudad { get; set; }
        public int IdPais { get; set; }
        public string Descripcion { get; set; }

        public virtual Paises IdPaisNavigation { get; set; }
    }
}
