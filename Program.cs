using ConsoleGame;

internal class Program
{
    private static async Task Main(string[] args)
    {
        var datos = new GameLoader();
        await datos.CargarPersonajes();
        Thread.Sleep(2000); 
        var juego = new Game(datos.Personajes);
        juego.Play();
        Console.ReadKey();
    }
}