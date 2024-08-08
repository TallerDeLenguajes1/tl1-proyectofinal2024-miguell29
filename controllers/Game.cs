using GameComplements;

namespace ConsoleGame;

public class Game
{
    private List<Personaje> personajes = new List<Personaje>();
    private List<Personaje> personajesEnJuego;

    private Personaje player;
    private Personaje enemy;
    private List<string> tags = new List<string>();
    public List<Personaje> Personajes { get => personajes; set => personajes = value; }
    public Personaje Player { get => player; set => player = value; }
    public Personaje Enemy { get => enemy; set => enemy = value; }
    public List<string> Tags { get => tags; set => tags = value; }

    public Game(List<Personaje> Listapersonajes)
    {
        personajes = Listapersonajes;

        //*Se crea una lista con los tags de cada champion, que sirve para seleccionar un personaje

        foreach (var item in Listapersonajes)
        {
            foreach (var tag in item.Tags)
            {
                if (!Tags.Contains(tag.ToUpper().Trim()))
                {
                    Tags.Add(tag.ToUpper().Trim());
                }
            }
        }
        Tags.Sort();
    }

    public void Play()
    {
        Animacion.Inicio();
        var salir = false;
        while (!salir)
        {
            var opcionesMenuPrincipal = new List<string>{" ","Nuevo Juego","Historial","Salir"};
            int opcion = Menu.Show(opcionesMenuPrincipal,Console.WindowWidth/2,10);
            
            switch (opcion)
            {
                case 1:
                    NuevoJuego();
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
            }
        }
    }

    private void NuevoJuego()
    {
        Console.Clear();

        personajesEnJuego = new List<Personaje>(personajes); // copia la lista y no pasa por referncia
        player = null;
        enemy = null;
        var random = new Random();
        while (personajesEnJuego.Count != 0)
        {
            var num = random.Next(personajesEnJuego.Count);
            if (player == null)
            {
                player = SeleccionarPersonaje();
                if (player != null)
                {
                    personajesEnJuego.Remove(player);
                    RestaurarStats(player);
                    continue;                    
                }else
                {
                    break;
                }
            }
            else
            {
                enemy = personajesEnJuego[num];
                personajesEnJuego.Remove(enemy);
                RestaurarStats(enemy);

                //*comienza la pelea
                Figth(Player, enemy);
                if (player.Salud > 0)
                {
                    //* restaurar salud y mejorar nivel
                    LevelUp(player);
                }
                else
                {
                    Console.Clear();
                    Animacion.GameOver();
                    break;
                }
                //!Despues de cada ronda se eliminan la mitad de los personajes de la lista
                for (int i = 0; i < personajesEnJuego.Count / 2; i++)
                {
                    personajesEnJuego.RemoveAt(random.Next(personajesEnJuego.Count));
                }
                Console.Clear();
                Console.WriteLine($"Cantidad de enemigos restantes: {personajesEnJuego.Count}");
                continue;
            }
        }
        if (player != null)
        {
            if (player.Salud > 0)
            {
                PresentarGanadorJuego();
                GameFile.GuardarGanador(Player);
            }
        }
    }

    private Personaje SeleccionarPersonaje()
    {
        Console.WriteLine("-------->    Seleccion de personajes");
        Console.WriteLine("Elija el tipo:");

        Personaje personajeSeleccionado = null;
        if (Tags[0] != " ") Tags.Insert(0," ");
        var selected = false;

        while (!selected)
        {
            var indiceTag = Menu.Show(Tags,2,5);
            if (indiceTag == -1) {
                Console.Clear();
                break;
            }
            var listaPersonajePorTag = new List<string>();
            foreach (var personaje in personajesEnJuego)
            {
                foreach (var tag in personaje.Tags)
                {
                    if (tag.ToUpper().Trim() == Tags[indiceTag])
                    {
                        listaPersonajePorTag.Add(personaje.Name);
                        break;
                    }
                }
            }
            listaPersonajePorTag.Insert(0," ");
            var indicePersonaje = Menu.Show(listaPersonajePorTag,22,5);
            if (indicePersonaje != -1)
            {
                foreach (var item in personajesEnJuego)
                {
                    if (item.Name == listaPersonajePorTag[indicePersonaje])
                    {
                        personajeSeleccionado = item;
                        selected = true;
                        Console.Clear();
                        break;
                    }
                }                
            }else
            {
                personajeSeleccionado = null;
            }
        }        
        return personajeSeleccionado;
    }
    private void Figth(Personaje player1, Personaje player2)
    {
        Animacion.Versus(player1,player2);
        double danio;//daño

        while (player1.Salud > 0 && player2.Salud > 0)
        {
            //TODO menú de acciones
            Thread.Sleep(500);
            danio = Atacar(player1,player2);
            Animacion.Atacar(player1,player2,1,danio);

            if (player2.Salud > 0)
            {
                Thread.Sleep(500);
                danio = Atacar(player2,player1);
                Animacion.Atacar(player2,player1,-1,danio);
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
        Thread.Sleep(2000);
        Console.Clear();
        Animacion.Victory();
    }
    private void PresentarGanadorPelea(Personaje ganador)
    {
        Console.WriteLine($"******** El ganador  de la pelea es: {ganador.Title.ToUpper()} {ganador.Name.ToUpper()} ********");
        Console.ReadKey();
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
        player.Ataque += player.Nivel * player.Stats.AttackDamagePerLevel;
        Console.ReadKey();
    }
    public void RestaurarStats(Personaje player)
    {
        player.Salud = player.Stats.Hp;
        player.Ataque = player.Stats.AttackDamage;
        player.Nivel = 1;

    }
    double Atacar(Personaje player,Personaje enemy)
    {
        var ataque = player.Ataque;
       
        var efectividadDeAtaqueMin = Math.Min((player.Nivel-1)*10, 100);
        var efectividadDeAtaque = new Random().Next(efectividadDeAtaqueMin, 101) / 100.0;
        var efectividadDeDeefensaMin = Math.Min((enemy.Nivel-1)*10, 100);
        var efectividadDeDefensa = new Random().Next(efectividadDeDeefensaMin, 101) / 200.0;;
       
        var defensa = enemy.Stats.Armor + (enemy.Stats.MoveSpeed * 0.1);// defensa = armadura + velocidad * 0.1
        var danio = (ataque * efectividadDeAtaque) - (defensa * efectividadDeDefensa);

        // Asegurarse de que el daño no sea negativo
        danio = Math.Max(danio, 0);
        enemy.Salud -= danio;
        return danio;
    }
}