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

        public bool Guardar(List<Cadete> cadetes)
        {
            string? cadeteJson = JsonSerializer.Serialize(cadetes);
            File.WriteAllText("Cadetes.json", cadeteJson);

            if (cadeteJson != null)
            {
                return true;
            } else {
                return false;
            }
        }
    }
}