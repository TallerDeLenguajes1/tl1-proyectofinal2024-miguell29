using System.Security;
using GameComplements;

namespace ConsoleGame;

record Game(List<string> Tags)
{
    private List<Personaje> personajes;
    private Personaje player;
    private Personaje enemy;

    public List<Personaje> Personajes { get => personajes; set => personajes = value; }
    public Personaje Player { get => player; set => player = value; }
    public Personaje Enemy { get => enemy; set => enemy = value; }

    public Game(List<Personaje> personajes) : this(new List<string>())
    {
        Personajes = personajes;

        //*Se crea una lista con los tags de cada champion, que sirve para seleccionar un personaje

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
        Inicio.Start();
        var salir = false;
        while (!salir)
        {
            var opcionesMenuPrincipal = new List<string>{" ","Jugar","Historial","Salir"};
            int opcion = Menu.Show(opcionesMenuPrincipal,Console.WindowWidth/2,10);
            
            switch (opcion)
            {
                case 1:
                    
                break;
                case 2:
                    Historial.Show(GameFile.LeerGanadores("HistorialGanadores.json"));
                break;

                case 3:
                    salir = true;
                    Console.SetCursorPosition(Console.WindowWidth/2,20);
                    Console.WriteLine("Saliendo...");
                    Thread.Sleep(2000);
                break;

                default:

                break;  
            }
        }
        
        
        var random = new Random();
        Console.Clear();
        while (personajes.Count != 0)
        {
            var num = random.Next(personajes.Count);
            if (Player == null)
            {
                player = SeleccionarPersonaje();
                personajes.Remove(player);
                continue;
            }
            else
            {
                enemy = personajes[num];
                personajes.Remove(enemy);
                //*comienza la pelea
                Figth(Player, enemy);
                if (player.Salud > 0)
                {
                    //TODO restaurar salud y mejorar nivel
                    LevelUp(player);
                }
                else
                {
                    GameOver(player);
                    break;
                    //player = enemy;
                    //TODO restaurar salud y mejorar nivel
                }
                //!Despues de cada ronda se eliminan la mitad de los personajes de la lista
                for (int i = 0; i < personajes.Count / 2; i++)
                {
                    personajes.RemoveAt(random.Next(personajes.Count));
                }
                Console.Clear();
                Console.WriteLine($"Cantidad de enemigos restantes: {personajes.Count}");
                continue;
            }
        }
        if (player.Salud > 0)
        {
            PresentarGanadorJuego();
            GameFile.GuardarGanador(Player);
        }
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
        while (player1.Salud > 0 && player2.Salud > 0)
        {
            //TODO menú de acciones
            Thread.Sleep(500);
            player1.Atacar(player2);
            if (player2.Salud > 0)
            {
                Thread.Sleep(500);
                player2.Atacar(player1);
            }
        }
        if (player1.Salud > 0)
        {
            PresentarGanadorPelea(player1);
        }
        else
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
    public void GameOver(Personaje player)
    {
        Console.Clear();
        Console.SetCursorPosition(20, 10);
        Console.WriteLine($"******** El juego ha terminado ********");
        Console.WriteLine($"******** {player.Title.ToUpper()} {player.Name.ToUpper()} ha perdido ********");
    }
    public void LevelUp(Personaje player)
    {
        Console.WriteLine(player.Name + " Subio de nivel");
        Console.WriteLine("Curando Heridas...");
        Console.WriteLine("Ataque Mejorado...");
        Console.WriteLine("Defensa Mejorada...");
        Console.WriteLine("Velocidad Mejorada...");
        player.Nivel++;
        //*La salud del personaje no debe superar la salud max
        player.Salud = Math.Min(player.Salud + player.Stats.Hp * 0.3, player.Stats.Hp);
        player.Stats.AttackDamage += player.Nivel * player.Stats.AttackDamagePerLevel;
        Console.ReadKey();
    }
}