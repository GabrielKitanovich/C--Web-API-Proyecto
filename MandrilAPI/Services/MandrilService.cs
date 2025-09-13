using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MandrilAPI.Helpers;
using MandrilAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace MandrilAPI.Services;

public class MandrilService
{
    public List<Mandril> Mandriles { get; set; }

    public static MandrilService Instance { get; } = new MandrilService();

    public MandrilService()
    {
        Mandriles = new List<Mandril>()
        {
            new() {
                Id = 1,
                Nombre = "Perez",
                Apellido = "Pereira",
                Habilidades =
                [
                    new() { Id = 1,
                            Nombre = "Salto Mortal",
                            Potencia = Habilidad.EPotencia.Extremo
                    },
                    new() { Id = 2,
                            Nombre = "Vision Nocturna",
                            Potencia = Habilidad.EPotencia.Suave
                    }
                ]
            },
            new() {
                Id = 2,
                Nombre = "Mandril2",
                Apellido = "Apellido2",
                Habilidades =
                [
                    new() { Id = 3,
                            Nombre = "Habilidad3",
                            Potencia = Habilidad.EPotencia.Intenso
                    },
                    new() { Id = 4,
                            Nombre = "Habilidad4",
                            Potencia = Habilidad.EPotencia.RePotente
                    }
                ]
            },
            new() {
                Id = 3,
                Nombre = "Mandril3",
                Apellido = "Apellido3",
                Habilidades =
                [
                    new() { Id = 5,
                            Nombre = "Habilidad5",
                            Potencia = Habilidad.EPotencia.Extremo
                    },
                    new() { Id = 6,
                            Nombre = "Habilidad6",
                            Potencia = Habilidad.EPotencia.Suave
                    }
                ]
            }
        };
    }

    public ActionResult? MandrilExists(int mandrilId, out Mandril? mandril)
    {
        mandril = Mandriles.FirstOrDefault(m => m.Id == mandrilId);
        if (mandril == null)
            return new NotFoundObjectResult(Messages.Mandril.NotFound);
        return null;
    }
}
