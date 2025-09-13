using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static MandrilAPI.Models.Habilidad;

namespace MandrilAPI.Models
{
    public class HabilidadDTO
    {
        public string Nombre { get; set; } = string.Empty;

        public EPotencia Potencia { get; set; }

    }
}