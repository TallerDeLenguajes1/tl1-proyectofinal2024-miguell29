using System.Net;
using System.Text.Json;
using ConsoleGame;

namespace GameComplements;

public static class GameFile
{
    //*Campo que almacena el path de la carpeta donde se guardaran los archivos
    //se crea un campo para evitar la repeticion de codigo
    // y prop para cambiarlo en un solo lugar en caso de ser necesario
    private static string carpeta = Path.Combine(Directory.GetCurrentDirectory(),"Files"); 
    public static string Carpeta { get; set; }
    
    public static void GuardarPersonajes(List<Personaje> lista)
    {
        var DataJson = JsonSerializer.Serialize(lista);
        var fileName = "Personajes.json";
        //var carpeta = Path.Combine(Directory.GetCurrentDirectory(),"Files"); //* Crea el path de la carpeta FILES que contiene los archivos generados
        if (!Directory.Exists(carpeta))
        {
            Directory.CreateDirectory(carpeta);
        }
        File.WriteAllText(Path.Combine(carpeta,fileName),DataJson);
    }
    public static List<Personaje> LeerPersonajes(string fileName)
    {
       // var carpeta = Path.Combine(Directory.GetCurrentDirectory(),"Files");
        var dataJson = File.ReadAllText(Path.Combine(carpeta,fileName));
        List<Personaje> personajes = JsonSerializer.Deserialize<List<Personaje>>(dataJson);
        return personajes;
    }
    public static void GuardarGanador(Personaje ganador)
    {
        var datajson = JsonSerializer.Serialize(ganador);
        var datos = new List<string>
        {
            datajson
        };
        var fileName = "HistorialGanadores.json";
       // var carpeta = Path.Combine(Directory.GetCurrentDirectory(),"Files");
        if (!Directory.Exists(carpeta)){
            Directory.CreateDirectory(carpeta);
        }
        File.AppendAllLines(Path.Combine(carpeta,fileName),datos);
    }
    public static List<Personaje> LeerGanadores(string fileName)
    {
        //var carpeta = Path.Combine(Directory.GetCurrentDirectory(),"Files");
        var listaGanadoresJson = File.ReadAllLines(Path.Combine(carpeta,fileName));//lista de strings con los ganadores en formato json
        var listaGanadores = new List<Personaje>();
        foreach (var ganadorJson in listaGanadoresJson)
        {
            var ganador = JsonSerializer.Deserialize<Personaje>(ganadorJson);
            listaGanadores.Add(ganador);
        }
        return listaGanadores;
    }
    public static bool Existe(string fileName)
    {
        //var carpeta = Path.Combine(Directory.GetCurrentDirectory(),"Files");
        if (!Directory.Exists(carpeta))
        {
            Directory.CreateDirectory(carpeta);
        }
        return File.Exists(Path.Combine(carpeta,fileName));
        /*
        *File.Exists devuelve true si el autor de la llamada tiene los permisos necesarios y 
        *path contiene el nombre de un archivo existente ; de lo contrario, false. 
        *Este método también devuelve false si path es null, 
        una ruta de acceso no válida 
        *o una cadena de longitud cero.
        Si el autor de la llamada no tiene permisos suficientes para leer el archivo especificado,
        no se produce ninguna excepción y el método devuelve false independientemente de la existencia de path.
        
        referencia: https://learn.microsoft.com/es-es/dotnet/api/system.io.file.exists?view=net-8.0
        */
    }
}