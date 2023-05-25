using Microsoft.AspNetCore.Mvc;
using webapi.Models;
using webapi.Services;

namespace  webapi.Controllers;

[Route("api/[controller]")]

public class CategoriaController : ControllerBase
{
    ICategoriaService catetegoriaService;
    public CategoriaController(ICategoriaService service)
    {
        catetegoriaService = service;
    }

    [HttpGet]
    public IActionResult Get()
    {
        catetegoriaService.Get();
        return Ok(catetegoriaService.Get());
    }
    

    [HttpPost]
    public IActionResult Post([FromBody] Categoria categoria)
    {
        catetegoriaService.Save(categoria);
        return Ok();
    }

    [HttpPut("{id}")]
    public IActionResult Put(Guid id, [FromBody] Categoria categoria)
    {
        catetegoriaService.Update(id, categoria);
        return Ok();
    }
    
    [HttpDelete("{id}")]

    public IActionResult Delete(Guid id)
    {
        catetegoriaService.Delete(id);
        return Ok();
    }

}
