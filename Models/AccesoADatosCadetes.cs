using System.Reflection.Metadata;
using System.Text.Json;

namespace tl2_tp4_2023_MarceAbr.Models
{
    public class AccesoADatosCadetes
    {   
        public List<Cadete> Obtener()
        { 
            string cadeteJSON = File.ReadAllText("Cadetes.json");
            List<Cadete>? listaCad = JsonSerializer.Deserialize<List<Cadete>>(cadeteJSON);
            return listaCad;
        }
    }
}