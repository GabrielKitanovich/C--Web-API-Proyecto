using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
}