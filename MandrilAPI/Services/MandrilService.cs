using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MandrilAPI.Models;

namespace MandrilAPI.Services;

public class MandrilService
{
    public List<Mandril> Mandriles { get; set; }

    public MandrilService()
    {
        Mandriles = new List<Mandril>()
        {
            new() {
                Id = 1,
                Nombre = "Perez",
                Apellido = "Pereira",
                Habilidades = new List<Habilidad>()
                {
                    new() { Id = 1,
                            Nombre = "Salto Mortal",
                            Potencia = Habilidad.EPotencia.Extremo
                    },
                    new() { Id = 2,
                            Nombre = "Vision Nocturna",
                            Potencia = Habilidad.EPotencia.Suave
                    }
                }
            },
            new() {
                Id = 2,
                Nombre = "Mandril2",
                Apellido = "Apellido2",
                Habilidades = new List<Habilidad>()
                {
                    new() { Id = 3,
                            Nombre = "Habilidad3",
                            Potencia = Habilidad.EPotencia.Intenso
                    },
                    new() { Id = 4,
                            Nombre = "Habilidad4",
                            Potencia = Habilidad.EPotencia.RePotente
                    }
                }
            },
            new() {
                Id = 3,
                Nombre = "Mandril3",
                Apellido = "Apellido3",
                Habilidades = new List<Habilidad>()
                {
                    new() { Id = 5,
                            Nombre = "Habilidad5",
                            Potencia = Habilidad.EPotencia.Extremo
                    },
                    new() { Id = 6,
                            Nombre = "Habilidad6",
                            Potencia = Habilidad.EPotencia.Suave
                    }
                }
            }
        };

    }
}
