using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace tl2_tp4_2023_MarceAbr.Models
{
    public class AccesoADatos
    {
        private List<Cadete>? listaCadetes;
        public List<Cadete>? ListaCadetes{get; set;}

        public virtual void cargarCadetes(string datos)
        {
            Console.WriteLine("Base");
        }
    }

    public class AccesoCSV: AccesoADatos{
        public override void cargarCadetes(string datos){
            List<Cadete> cadetes = new List<Cadete>();
            var cargaCadetes = File.ReadAllLines(datos + ".csv").Select(line => line.Split(',')).
            Select(parts => new Cadete(int.Parse(parts[0]), parts[1], parts[2], parts[3]));
            cadetes.AddRange(cargaCadetes);
            ListaCadetes = cadetes;
        }
    }

    public class AccedoJSON : AccesoADatos{
        public override void cargarCadetes(string datos)
        {
            List<Cadete> cadetes = new List<Cadete>();
            if (File.Exists(datos))
            {
                string? datosJSON = File.ReadAllText(datos);
                List<Cadete>? listaCadete = JsonSerializer.Deserialize<List<Cadete>>(datosJSON);
            } else {
                Console.WriteLine("Error");
            }
        }
    }
}