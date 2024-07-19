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
        Thread.Sleep(2000); 
        Console.Clear();
        var juego = new Game(carga.Personajes);
        juego.Play();
        Console.ReadKey();
    }
}