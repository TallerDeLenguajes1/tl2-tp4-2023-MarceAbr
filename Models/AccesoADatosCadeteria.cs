using System.Text.Json;

namespace tl2_tp4_2023_MarceAbr.Models
{
    public class AccesoADatosCadeteria
    {
        public Cadeteria Obtener()
        {   
            string? jsonString = File.ReadAllText("Cadeterias.json");
            Cadeteria cadeteria = JsonSerializer.Deserialize<Cadeteria>(jsonString);
            return cadeteria; 
        }
    }
}