using API.Dtos;
using API.Helpers.Errors;
using API.Services;
using AutoMapper;
using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;
[ApiVersion("1.0")]
[ApiVersion("1.1")]
[Authorize]

public class InsumoPrendaController: BaseApiController
{
    private readonly IUnitOfWork unitofwork;
    private readonly IMapper mapper;

    public InsumoPrendaController( IUnitOfWork unitofwork, IMapper mapper)
    {
        this.unitofwork = unitofwork;
        this.mapper = mapper;
    }
    [HttpGet]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<InsumoPrendaDto>>> Get()
    {
        var entidad = await unitofwork.InsumoPrendas.GetAllAsync();
        return mapper.Map<List<InsumoPrendaDto>>(entidad);
    }
    
    [HttpGet]
    [MapToApiVersion("1.1")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Pager<InsumoPrendaDto>>> GetPagination([FromQuery] Params paisParams)
    {
        var entidad = await unitofwork.InsumoPrendas.GetAllAsync(paisParams.PageIndex, paisParams.PageSize, paisParams.Search);
        var listEntidad = mapper.Map<List<InsumoPrendaDto>>(entidad.registros);
        return new Pager<InsumoPrendaDto>(listEntidad, entidad.totalRegistros, paisParams.PageIndex, paisParams.PageSize, paisParams.Search);
    }

    
    [HttpGet("consulta5/{id}")]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<object>> InsumosYCostoProduccion(string id)
    {
        var entidad = await unitofwork.InsumoPrendas.InsumosYCostoProduccion(id);
        var dto = mapper.Map<IEnumerable<object>>(entidad);
        return Ok(dto);
    }
    
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]

    public async Task<ActionResult<InsumoPrendaDto>> Put(int id, [FromBody] InsumoPrendaDto entidadDto)
    {
        if (entidadDto == null)
        {
            return NotFound();
        }
        var entidad = this.mapper.Map<InsumoPrenda>(entidadDto);
        unitofwork.InsumoPrendas.Update(entidad);
        await unitofwork.SaveAsync();
        return entidadDto;
    }
    
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]

    public async Task<ActionResult<InsumoPrendaDto>> Get(int id)
    {
        var entidad = await unitofwork.InsumoPrendas.GetByIdAsync(id);
        if (entidad == null)
        {
            return NotFound();
        }
        return this.mapper.Map<InsumoPrendaDto>(entidad);
    }


    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        var entidad = await unitofwork.InsumoPrendas.GetByIdAsync(id);
        if (entidad == null)
        {
            return NotFound();
        }
        unitofwork.InsumoPrendas.Remove(entidad);
        await unitofwork.SaveAsync();
        return NoContent();
    }

}
