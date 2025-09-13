using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MandrilAPI.Helpers;
using MandrilAPI.Models;
using MandrilAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace MandrilAPI.Controllers;

[ApiController]
[Route("api/mandril/[controller]/{mandrilId}")]
public class HabilidadController : ControllerBase
{
    [HttpGet]
    public ActionResult<IEnumerable<Habilidad>> GetAll(int mandrilId)
    {
        ActionResult? error = MandrilService.Instance.MandrilExists(mandrilId, out var mandril);
        if (error != null)
            return error;
        ActionResult? habilidadError = HabilidadService.Instance.HabilidadesExists(mandril!, out var habilidades);
        if (habilidadError != null)
            return habilidadError;
        return Ok(habilidades);
    }
    [HttpGet("{habilidadId}")]
    public ActionResult<Habilidad> GetById(int mandrilId, int habilidadId)
    {
        ActionResult? mandrilError = MandrilService.Instance.MandrilExists(mandrilId, out var mandril);
        if (mandrilError != null)
            return mandrilError;
        ActionResult? habilidadError = HabilidadService.Instance.HabilidadExists(mandril!, habilidadId, out var habilidad);
        if (habilidadError != null)
            return habilidadError;
        return Ok(habilidad);
    }

    [HttpPost]
    public ActionResult<Habilidad> Create(int mandrilId, HabilidadDTO habilidadDTO)
    {
        ActionResult? mandrilError = MandrilService.Instance.MandrilExists(mandrilId, out var mandril);
        if (mandrilError != null)
            return mandrilError;
        var habilidadExists = mandril!.Habilidades.FirstOrDefault(h => h.Nombre == habilidadDTO.Nombre);
        if (habilidadExists != null)
            return Conflict(Messages.Habilidad.AlreadyExists);

        var maxId = mandril.Habilidades.Max(h => h.Id);
        var habilidadNueva = new Habilidad()
        {
            Id = maxId + 1,
            Nombre = habilidadDTO.Nombre,
            Potencia = habilidadDTO.Potencia
        };
        mandril.Habilidades.Add(habilidadNueva);
        return CreatedAtAction(nameof(GetById), new { mandrilId, habilidadId = habilidadNueva.Id }, habilidadNueva);

    }

    [HttpPut("{habilidadId}")]
    public ActionResult<Habilidad> Put(int mandrilId, int habilidadId, HabilidadDTO habilidadDTO)
    {
        ActionResult? mandrilError = MandrilService.Instance.MandrilExists(mandrilId, out var mandril);
        if (mandrilError != null)
            return mandrilError;

        ActionResult? habilidadError = HabilidadService.Instance.HabilidadExists(mandril!, habilidadId, out var habilidad);
        if (habilidadError != null)
            return habilidadError;

        var habilidadNameExists = mandril!.Habilidades
            .FirstOrDefault(h => h.Nombre == habilidadDTO.Nombre && h.Id != habilidadId);

        if (habilidadNameExists != null)
            return Conflict(Messages.Habilidad.AlreadyExists);

        habilidad!.Nombre = habilidadDTO.Nombre;
        habilidad.Potencia = habilidadDTO.Potencia;
        return NoContent();
    }


    [HttpDelete("{habilidadId}")]
    public ActionResult<Habilidad> Delete(int mandrilId, int habilidadId)
    {
        ActionResult? mandrilError = MandrilService.Instance.MandrilExists(mandrilId, out var mandril);
        if (mandrilError != null)
            return mandrilError;

        ActionResult? habilidadError = HabilidadService.Instance.HabilidadExists(mandril!, habilidadId, out var habilidad);
        if (habilidadError != null)
            return habilidadError;

        mandril!.Habilidades.Remove(habilidad!);
        return NoContent();
    }
}