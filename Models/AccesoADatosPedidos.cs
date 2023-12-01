using System.Text.Json;

namespace tl2_tp4_2023_MarceAbr.Models
{
    public class AccesoADatosPedidos
    {
        public List<Pedido> Obtener()
        {
            string pedidosJSON = File.ReadAllText("Pedidos.json");
            List<Pedido> listaPedidos = JsonSerializer.Deserialize<List<Pedido>>(pedidosJSON);
            return listaPedidos;
        }

        public bool Guardar(List<Pedido> pedidos)
        {
            string pedidosJson = JsonSerializer.Serialize(pedidos);
            File.WriteAllText("Pedidos.json", pedidosJson);

            if (pedidosJson != null)
            {
                return true;
            } else {
                return false;
            }
        }
    }
}