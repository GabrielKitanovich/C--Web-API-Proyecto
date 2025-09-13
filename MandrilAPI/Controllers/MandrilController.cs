using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MandrilAPI.Models;
using MandrilAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace MandrilAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MandrilController : ControllerBase
{
    // ...
    [HttpGet]
    public ActionResult<IEnumerable<Mandril>> GetAll()
    {
        return Ok(MandrilService.Instance.Mandriles);
    }
///asd
    [HttpGet("{mandrilId}")]
    public ActionResult<Mandril> GetById(int mandrilId)
    {
    ActionResult? error = MandrilService.Instance.MandrilExists(mandrilId, out var mandril);
        if (error != null)
            return error;
        return Ok(mandril!);
    }

    [HttpPost]
    public ActionResult<Mandril> Create(MandrilDTO mandrilDTO)
    {
        var maxId = MandrilService.Instance.Mandriles.Max(m => m.Id);
        var newMandril = new Mandril()
        {
            Id = maxId + 1,
            Nombre = mandrilDTO.Nombre,
            Apellido = mandrilDTO.Apellido
        };

        MandrilService.Instance.Mandriles.Add(newMandril);
        return CreatedAtAction(nameof(GetById),
                                new { mandrilid = newMandril.Id },
                                newMandril
                                );
    }

    [HttpPut("{mandrilId}")]
    public ActionResult<Mandril> Put(int mandrilId, MandrilDTO mandrilDTO)
    {
    ActionResult? error = MandrilService.Instance.MandrilExists(mandrilId, out var mandril);
        if (error != null)
            return error;
        mandril!.Nombre = mandrilDTO.Nombre;
        mandril!.Apellido = mandrilDTO.Apellido;
        return NoContent();
    }

    [HttpDelete("{mandrilId}")]
    public ActionResult<Mandril> Delete(int mandrilId)
    {
    ActionResult? error = MandrilService.Instance.MandrilExists(mandrilId, out var mandril);
        if (error != null)
            return error;
        MandrilService.Instance.Mandriles.Remove(mandril!);
        return NoContent();
    }
}
