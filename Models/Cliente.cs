namespace tl2_tp4_2023_MarceAbr.Models
{
    public class Cliente
    {
        private string nombre;
        private string direccion;
        private string telefono;
        private string datosReferenciaDireccion;
        

        public string Nombre { get => nombre; set => nombre = value; }
        public string Direccion { get => direccion; set => direccion = value; }
        public string Telefono { get => telefono; set => telefono = value; }
        public string DatosReferenciaDireccion { get => datosReferenciaDireccion; set => datosReferenciaDireccion = value;}

        public Cliente(string nomb, string direc, string tel, string refen)
        {
            this.nombre = nomb;
            this.direccion = direc;
            this.telefono = tel;
            this.datosReferenciaDireccion = refen;
        }
    }
}