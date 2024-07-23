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
    public List<string> Tags { get; set; }

    public Game(List<Personaje> personajes )
    {
        Personajes = personajes;

        //*Se crea una lista con los tags de cada champion, que sirve para seleccionar un personaje
        Tags = new List<string>();
        foreach (var item in personajes)
        {
            foreach (var tag in item.Tags)
            {
                if (!Tags.Contains(tag))
                {
                    Tags.Add(tag);
                }
            }
        }
        Tags.Sort();
    }

    public void Play()
    {
        var random = new Random();
        Console.Clear();
        while (personajes.Count != 0)
        {
            //selecciono un personaje al azar
            Thread.Sleep(500);
            var num = random.Next(personajes.Count);
            if (Player == null)
            {
                player = SeleccionarPersonaje();
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
                //!Despues de cada ronda se eliminan la mitad de los personajes de la lista
                for (int i = 0; i < personajes.Count/2; i++)
                {
                    personajes.RemoveAt(random.Next(personajes.Count));
                }
                Console.Clear();
                Console.WriteLine($"Cantidad de enemigos restantes: {personajes.Count}");
                continue;
            }
        }
        PresentarGanadorJuego();
        GameFile.GuardarGanador(Player);
    }
    private Personaje SeleccionarPersonaje()
    {
        Console.WriteLine("-------->    Seleccion de personajes");
        Console.WriteLine("Elija el tipo:");
        var indiceTag = 1;
        foreach (var tag in Tags)
        {
            Console.WriteLine($"{indiceTag++} - {tag}");
        }
        indiceTag = int.Parse(Console.ReadLine());
        var indicePersonaje = 1;
        var listaPersonajePorTag = new List<Personaje>();
        foreach (var personaje in personajes)
        {
            foreach (var tag in personaje.Tags)
            {
                if (tag == Tags[indiceTag - 1])
                {
                    Console.WriteLine($"{indicePersonaje++} - {personaje.Name}");
                    listaPersonajePorTag.Add(personaje);
                    break;
                }
            }
        }
        indicePersonaje = int.Parse(Console.ReadLine()) - 1;
        return listaPersonajePorTag[indicePersonaje];

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