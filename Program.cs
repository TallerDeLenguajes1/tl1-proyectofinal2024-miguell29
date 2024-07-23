using ConsoleGame;

internal class Program
{
    private static async Task Main(string[] args)
    {
        var datos = new GameLoader();
        await datos.CargarPersonajes();
        foreach (var personaje in datos.Personajes)
        {
            personaje.MostrarDatos();
        }
        Thread.Sleep(2000); 
        Console.Clear();
        var juego = new Game(datos.Personajes);
        juego.Play();
        Console.ReadKey();
    }
}