namespace tl2_tp4_2023_MarceAbr.Models
{
    public class Cadeteria
    {
        private string nombre;
        private string telefono;
        private List<Pedido> listaPedidosCadeteria = new List<Pedido>(); 
        private List<Cadete> listaDeCadetes;

        public string Nombre { get => nombre; set => nombre = value;}
        public string Telefono { get => telefono; set => telefono = value;}
        public List<Cadete> ListaDeCadetes { get => listaDeCadetes; set => listaDeCadetes = value;}
        public List<Pedido> ListaPedidosCadeteria { get => listaPedidosCadeteria; set => listaPedidosCadeteria = value;}


        //Singleton
        private static Cadeteria? instancia;

        public static Cadeteria getInstancia()
        {   
            if (instancia == null)
            {
                AccesoADatos datos = new AccesoADatos();
                string? direc = "Cadetes";
                datos = new AccesoCSV();
                datos.cargarCadetes(direc);
                instancia = new Cadeteria("Bajonazo", "3863548752", datos.ListaCadetes);
            }
            return instancia;
        }

        public Cadeteria(string nomb, string tel, List<Cadete> listCadete){
            this.nombre = nomb;
            this.telefono = tel;
            this.listaDeCadetes = listCadete;
        }

        public List<Pedido> getPedidos()
        {
            return this.listaPedidosCadeteria;
        }

        public List<Cadete> getCadetes()
        {
            return this.listaDeCadetes;
        }

        public List<Pedido> agregarPedido(int num, string obs, float precio, string cliente, string direc, string tel, string refencia)
        {
            Pedido ped = new Pedido(num, obs, precio, cliente, direc, tel, refencia);
            listaPedidosCadeteria.Add(ped);
            return listaPedidosCadeteria;
        }

        public bool asignarPedido(int numPedido, int idCadete)
        {
            Cadete? cadete = listaDeCadetes.Find(cad => cad.Id == idCadete);
            Pedido? pedido = listaPedidosCadeteria.Find(ped => ped.Nro == numPedido);

            pedido.Cadete = cadete;

            if (pedido.Cadete != null)
            {
                return true;
            } else {
                return false;
            }
        }

        public bool cambiarEstadoPedido(int numero, int opcion)
        {
            bool valor = false;
            foreach (var pedido in listaPedidosCadeteria)
            {
                if (pedido.Nro == numero)
                {
                    switch(opcion){
                        case 1:
                        pedido.Estado="Entregado";
                        break;
                        case 2:
                        pedido.Estado="Cancelado";
                        break;
                    }
                    valor=true;
                }
            }
            return(valor);
        } 

    }
}