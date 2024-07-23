using GameComplements;

namespace ConsoleGame;


class Game
{
    private List<Personaje> personajes;
    private Personaje player;
    private Personaje enemy;

    public List<Personaje> Personajes { get => personajes; set => personajes = value; }
    public Personaje Player { get => player; set => player = value; }
    public Personaje Enemy { get => enemy; set => enemy = value; }

    public Game(List<Personaje> personajes )
    {
        Personajes = personajes;
    }

    public void Play()
    {
        var random = new Random();
        while (personajes.Count != 0)
        {
            //selecciono un personaje al azar
            Thread.Sleep(500);
            Console.Clear();
            var num = random.Next(personajes.Count);
            if (Player == null)
            {
                Player = personajes[num];
                personajes.Remove(player);
                continue;
            }else
            {
                enemy = personajes[num];
                personajes.Remove(enemy);
                //*comienza la pelea
                Figth(Player,enemy);
                if (player.Stats.Hp > 0)
                {
                    //TODO restaurar salud y mejorar nivel
                }else
                {
                    player = enemy;
                    //TODO restaurar salud y mejorar nivel
                }
                continue;
            }
        }
        PresentarGanadorJuego();
        GameFile.GuardarGanador(Player);
    }
    private void Figth(Personaje player1, Personaje player2)
    {
        Console.WriteLine($"Inicio de la pelea entre {player1.Name} y {player2.Name}");
        while (player1.Stats.Hp > 0 && player2.Stats.Hp > 0)
        {
            //TODO menú de acciones
            Thread.Sleep(500); 
            player1.Atacar(player2);
            if (player2.Stats.Hp > 0)
            {
                Thread.Sleep(500);
                player2.Atacar(player1);
            }
        }
        if (player1.Stats.Hp > 0)
        {
            PresentarGanadorPelea(player1);
        }else
        {
            PresentarGanadorPelea(player2);
        }
        Console.ReadKey();
    }
    private void PresentarGanadorJuego()
    {
        Console.WriteLine($"******** El ganador  del juego es: {Player.Title.ToUpper()} {Player.Name.ToUpper()} ********");
        Console.WriteLine("FELICITACIONES");
    }
    private void PresentarGanadorPelea(Personaje ganador)
    {
        Console.WriteLine($"******** El ganador  de la pelea es: {ganador.Title.ToUpper()} {ganador.Name.ToUpper()} ********");    
    }
}