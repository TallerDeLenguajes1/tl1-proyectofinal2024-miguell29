using ConsoleGame;

internal class Program
{
    private static async Task Main(string[] args)
    {
        var datos = new GameLoader();
        await datos.CargarPersonajes();
        var juego = new Game(datos.Personajes);
        juego.Play();
    }
}