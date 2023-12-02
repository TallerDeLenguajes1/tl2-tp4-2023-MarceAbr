using Microsoft.AspNetCore.Mvc;
using tl2_tp4_2023_MarceAbr.Models;
namespace tl2_tp4_2023_MarceAbr;

[ApiController]
[Route("[controller]")]
public class CadeteriaController : ControllerBase
{
    private Cadeteria? cadeteria;
    private readonly ILogger<CadeteriaController > _logger;
    public CadeteriaController(ILogger<CadeteriaController> logger)
    {
        _logger = logger;
        AccesoADatosCadeteria accesoCadeteria = new AccesoADatosCadeteria();
        AccesoADatosCadetes accesoCadete = new AccesoADatosCadetes();
        AccesoADatosPedidos accesoPedido = new AccesoADatosPedidos();
        cadeteria = new Cadeteria(accesoCadeteria, accesoCadete, accesoPedido);
    }

    [HttpGet("GetCadeteria")]
    public ActionResult<string> GetNombreCadeteria()
    {
        return Ok(cadeteria.getNombreCadeteria());
    }

    [HttpGet("GetPedidos")]
    public ActionResult<List<Pedido>> GetPedidos()
    {
        List<Pedido> pedidos = cadeteria.getPedidos();
        return Ok(pedidos);
    }

    [HttpGet("GetCadetes")]
    public ActionResult<IEnumerable<Cadete>> GetCadetes()
    {
        var cadetes = cadeteria.getCadetes();
        return Ok(cadetes);
    }

    [HttpPost("AgregarPedido")]
    public ActionResult<Pedido> AgregarPedido(Pedido nuevoPedido, int idCadete)
    {
        bool valor = cadeteria.agregarPedido(nuevoPedido, idCadete);
        if (valor)
        {
            return Ok(nuevoPedido);
        } else {
            return BadRequest(nuevoPedido);
        }
    }

    [HttpPut("AsignarPedido")]
    public ActionResult<Pedido> asignarPedido(int idPedido, int idCadete)
    {
        Pedido pedido = cadeteria.buscarPedido(idPedido);
        cadeteria.asignarPedido(pedido, idCadete);
        return Ok(pedido);
    }

    [HttpPut("CambiarEstadoPedido")]
    public ActionResult<Pedido> CambiarEstadoPedido(int idPedido)
    {
        bool valor = cadeteria.cambiarEstadoPedido(idPedido);
        Pedido pedido = cadeteria.buscarPedido(idPedido);
        return Ok(pedido);
    }

    [HttpPut("CambiarCadetePedido")]
    public ActionResult<Pedido> CambiarCadeteAPedido(int idPedido, int idCadete)
    {
        Pedido pedido = cadeteria.buscarPedido(idPedido);
        cadeteria.asignarPedido(pedido, idCadete);
        return Ok(pedido);
    }

    [HttpGet("Buscar_Pedido")]
    public ActionResult<IEnumerable<Pedido>> GetPedido(int id)
    {
        Pedido pedido = cadeteria.buscarPedido(id);
        if (pedido != null){return Ok(pedido);} else {return NotFound();}
    }

    [HttpGet("Buscar_Cadete")]
    public ActionResult<IEnumerable<Cadete>> GetCadete(int id)
    {
        Cadete cadete = cadeteria.buscarCadete(id);
        if (cadete != null){return Ok(cadete);} else {return BadRequest();}
    }

    [HttpPost("AgregarCadete")]
    public ActionResult<Cadete> AddCadete(Cadete cadete)
    {
        bool valor = cadeteria.agregarCadete(cadete);
        if (valor){return Ok(cadete);} else{return BadRequest();}
    }

}