namespace tl2_tp4_2023_MarceAbr.Models
{
    public class Pedido
    {
        private int nro;
        private string obs;
        private string estado;
        private float precio;
        private Cliente cliente;
        private Cadete cadete;

        public int Nro { get => nro; set => nro = value;}
        public string Obs { get => obs; set => obs = value;}
        public Cliente Cliente { get => cliente; set => cliente = value;}
        public string Estado { get => estado; set => estado = value;}
        public Cadete Cadete { get => cadete; set => cadete = value;}
        public float Precio { get => precio; set => precio = value;}

        public Pedido(int nro, string obs, float precio, string nombCliente, string direccion, string tel, string refe){
            cliente = new Cliente(nombCliente, direccion, tel, refe);
            this.nro = nro;
            this.obs = obs;
            this.precio = precio;
            this.estado = "Pendiente";
        }
    }
}