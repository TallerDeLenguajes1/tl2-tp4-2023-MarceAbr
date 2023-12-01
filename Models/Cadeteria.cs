namespace tl2_tp4_2023_MarceAbr.Models
{
    public class Cadeteria
    {
        private string? nombre;
        private string? telefono;
        private List<Pedido>? listaPedidosCadeteria; 
        private List<Cadete>? listaDeCadetes;
        private AccesoADatosCadetes? accesoCadetes;
        private AccesoADatosPedidos? accesoPedidos;


        public Cadeteria(AccesoADatosCadeteria accesoCad, AccesoADatosCadetes accesoCadete, AccesoADatosPedidos accesoPedido)
        {
            Cadeteria cad = accesoCad.Obtener();
            this.nombre = cad.nombre;
            this.telefono = cad.telefono;
            accesoCadetes = accesoCadete;
            accesoPedidos = accesoPedido;
            listaDeCadetes = accesoCadetes.Obtener();
            listaPedidosCadeteria = accesoPedidos.Obtener();
        }
        public Cadeteria()
        {
            
        }
        
        public Cadeteria(string nomb, string tel){
            this.nombre = nomb;
            this.telefono = tel;
            listaDeCadetes = new List<Cadete>();
            listaPedidosCadeteria = new List<Pedido>();
        }

        public string Nombre { get => nombre; set => nombre = value;}
        public string Telefono { get => telefono; set => telefono = value;}

        public string getNombreCadeteria()
        {
            return this.nombre;
        }

        public List<Pedido> getPedidos()
        {
            return this.listaPedidosCadeteria;
        }

        public Cadete cargarCadete(Cadete cadete)
        {
            this.listaDeCadetes.Add(cadete);
            return cadete;
        }

        public List<Cadete> getCadetes()
        {
            return this.listaDeCadetes;
        }

        public bool agregarPedido(Pedido pedido, int idCadete)
        {
            pedido = asignarPedido(pedido, idCadete);
            listaPedidosCadeteria.Add(pedido);
            pedido.Nro = listaPedidosCadeteria.Count();

            if (accesoPedidos.Guardar(listaPedidosCadeteria))
            {
                return true;
            } else {
                return false;
            }
        }

        public Pedido asignarPedido(Pedido pedAsignar, int idCadete)
        {
            Cadete? cadete = listaDeCadetes.FirstOrDefault(c => c.ID == idCadete);
            pedAsignar.Cadete = cadete;
            accesoPedidos.Guardar(listaPedidosCadeteria);

            return pedAsignar;
        }

        public Pedido buscarPedido(int id)
        {
            Pedido pedido = listaPedidosCadeteria.Find(p => p.Nro == id);
            return pedido;
        }

        public bool cambiarEstadoPedido(int id)
        {
            Pedido pedido = listaPedidosCadeteria.FirstOrDefault(p => p.Nro == id);
            bool valor = pedido.cambiarEstado();
            accesoPedidos.Guardar(listaPedidosCadeteria);

            if (valor)
            {
                return true;
            } else {
                return false;
            }
        } 

    }
}