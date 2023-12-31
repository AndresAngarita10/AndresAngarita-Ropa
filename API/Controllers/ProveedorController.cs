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

public class ProveedorController: BaseApiController
{
    private readonly IUnitOfWork unitofwork;
    private readonly IMapper mapper;

    public ProveedorController( IUnitOfWork unitofwork, IMapper mapper)
    {
        this.unitofwork = unitofwork;
        this.mapper = mapper;
    }
    [HttpGet]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<ProveedorDto>>> Get()
    {
        var entidad = await unitofwork.Proveedores.GetAllAsync();
        return mapper.Map<List<ProveedorDto>>(entidad);
    }
    
    [HttpGet]
    [MapToApiVersion("1.1")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Pager<ProveedorDto>>> GetPagination([FromQuery] Params paisParams)
    {
        var entidad = await unitofwork.Proveedores.GetAllAsync(paisParams.PageIndex, paisParams.PageSize, paisParams.Search);
        var listEntidad = mapper.Map<List<ProveedorDto>>(entidad.registros);
        return new Pager<ProveedorDto>(listEntidad, entidad.totalRegistros, paisParams.PageIndex, paisParams.PageSize, paisParams.Search);
    }

    
    [HttpGet("consulta1")]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<ProveedorDto>> ProvPerNatural()
    {
        var entidad = await unitofwork.Proveedores.ProvPerNatural();
        var dto = mapper.Map<IEnumerable<ProveedorDto>>(entidad);
        return Ok(dto);
    }
    
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]

    public async Task<ActionResult<ProveedorDto>> Put(int id, [FromBody] ProveedorDto entidadDto)
    {
        if (entidadDto == null)
        {
            return NotFound();
        }
        var entidad = this.mapper.Map<Proveedor>(entidadDto);
        unitofwork.Proveedores.Update(entidad);
        await unitofwork.SaveAsync();
        return entidadDto;
    }
    
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]

    public async Task<ActionResult<ProveedorDto>> Get(int id)
    {
        var entidad = await unitofwork.Proveedores.GetByIdAsync(id);
        if (entidad == null)
        {
            return NotFound();
        }
        return this.mapper.Map<ProveedorDto>(entidad);
    }


    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        var entidad = await unitofwork.Proveedores.GetByIdAsync(id);
        if (entidad == null)
        {
            return NotFound();
        }
        unitofwork.Proveedores.Remove(entidad);
        await unitofwork.SaveAsync();
        return NoContent();
    }

}
