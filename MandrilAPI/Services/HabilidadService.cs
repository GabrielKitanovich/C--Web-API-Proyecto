using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MandrilAPI.Helpers;
using MandrilAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace MandrilAPI.Services;

public class HabilidadService
{
    public static HabilidadService Instance { get; } = new HabilidadService();


    public ActionResult? HabilidadExists(Mandril mandril, int habilidadId, out Habilidad? habilidad)
    {
        habilidad = mandril.Habilidades.FirstOrDefault(h => h.Id == habilidadId);
        if (habilidad == null)
            return new NotFoundObjectResult(Messages.Habilidad.NotFound);
        return null;
    }
    public ActionResult? HabilidadesExists(Mandril mandril, out List<Habilidad>? habilidades)
    {
        habilidades = mandril.Habilidades;
        if (habilidades == null || habilidades.Count == 0)
            return new NotFoundObjectResult(Messages.Habilidad.NotFound);
        return null;
    }

}
