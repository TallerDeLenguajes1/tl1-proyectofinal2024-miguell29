using System.Text.Json;
using ConsoleGame;

namespace GameComplements;

public static class GameFile
{
    public static void GuardarPersonajes(List<Personaje> lista)
    {
        var DataJson = JsonSerializer.Serialize(lista);
        var fileName = "Personajes.json";
        var carpeta = Path.Combine(Directory.GetCurrentDirectory(),"Files"); //* Crea el path de la carpeta FILES que contiene los archivos generados
        if (!Directory.Exists(carpeta))
        {
            Directory.CreateDirectory(carpeta);
        }
        File.WriteAllText(Path.Combine(carpeta,fileName),DataJson);
    }
    public static List<Personaje> LeerPersonajes(string fileName)
    {
        var carpeta = Path.Combine(Directory.GetCurrentDirectory(),"Files");
        var dataJson = File.ReadAllText(Path.Combine(carpeta,fileName));
        List<Personaje> personajes = JsonSerializer.Deserialize<List<Personaje>>(dataJson);
        return personajes;
    }
    public static bool Existe(string fileName)
    {
        var carpeta = Path.Combine(Directory.GetCurrentDirectory(),"Files");
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