using Microsoft.AspNetCore.Mvc;
using tl2_tp4_2023_MarceAbr.Models;
namespace tl2_tp4_2023_MarceAbr;

[ApiController]
[Route("[controller]")]
public class CadeteriaController : ControllerBase
{
    private readonly ILogger<CadeteriaController > _logger;
    Cadeteria cadeteria;
    public CadeteriaController(ILogger<CadeteriaController> logger)
    {
        _logger = logger;
        cadeteria = Cadeteria.getInstancia();
    }

    [HttpGet("GetCadeteria")]
    public ActionResult<string> GetNombreCadeteria()
    {
        return cadeteria.Nombre;
    }

    [HttpGet("GetPedidos")]
    public ActionResult<List<Pedido>> GetPedidos()
    {
        List<Pedido> pedidos = cadeteria.getPedidos();
        return Ok(pedidos);
    }

    [HttpGet("GetCadetes")]
    public ActionResult<List<Cadete>> GetCadetes()
    {
        List<Cadete> cadetes = cadeteria.getCadetes();
        return Ok(cadetes);
    }

    [HttpPost("AgregarPedido")]
    public ActionResult<string> AgregarPedido(int numPed, string obs, float precio, string cliente, string direc,string tel, string refencia)
    {
        return Ok(cadeteria.agregarPedido(numPed, obs, precio, cliente, direc, tel, refencia));
    }

    [HttpPut("CambiarEstado")]
    public ActionResult CambiarEstadoPedido(int idPedido,int newEstado)
    {
         return Ok(cadeteria.cambiarEstadoPedido(idPedido,newEstado));
    }

    [HttpPut("AsignarPedido")]
    public ActionResult<string> AsignarPedido(int idPedido,int idCadete)
    {
        if (cadeteria.ListaDeCadetes!=null)
        {
            return Ok(cadeteria.asignarPedido(idCadete,idPedido));
        } else {
            return NotFound("No existen cadetes cargados");
        }
    }

}