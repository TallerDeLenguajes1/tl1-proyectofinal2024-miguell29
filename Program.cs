using ConsoleGame;

internal class Program
{
    private static void Main(string[] args)
    {
        var carga = new GameLoader();
        foreach (var personaje in carga.Personajes)
        {
            personaje.MostrarDatos();
        }
        Console.ReadKey();
    }
}