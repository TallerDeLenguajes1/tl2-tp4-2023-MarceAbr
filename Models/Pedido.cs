namespace tl2_tp4_2023_MarceAbr.Models
{
    public enum Estado
    {
        Pendiente,
        Entregado,
        Cancelado
    }
    public class Pedido
    {
        private int nro;
        private string? obs;
        private Estado estado;
        private Cliente? cliente;
        private Cadete? cadete;

        public Pedido(){}

        public Pedido(int nro, string obs, Cliente cliente){
            this.nro = nro;
            this.obs = obs;
            this.cliente = cliente;
            estado = Estado.Pendiente;
            Cadete = new Cadete();
        }

        public int Nro { get => nro; set => nro = value;}
        public string? Obs { get => obs; set => obs = value;}
        public Estado Estado { get => estado; set => estado = value;}
        public Cadete? Cadete { get => cadete; set => cadete = value;}

        public void agregarCliente(Cliente cliente)
        {
            this.cliente = cliente;
        }

        public void eliminarCliente()
        {
            this.cliente = null;
        }

        public string getDireccion()
        {
            return cliente.Direccion;
        }

        public string getDatos()
        {
            return cliente.DatosReferenciaDireccion;
        }

        public bool cambiarEstado()
        {
            if (estado == Estado.Pendiente)
            {   
                estado = Estado.Entregado;
                return true;
            } else {
                return false;
            }
        }

        public void cancelarPedido()
        {
            estado = Estado.Cancelado;
        }

    }
}