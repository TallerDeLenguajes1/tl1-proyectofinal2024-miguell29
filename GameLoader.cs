//* Esta clase se encarga de preparar todo antes de que el juego inicie

using GameComplements;

namespace ConsoleGame;

class GameLoader
{
    private List<Personaje> personajes = new List<Personaje>();
    public GameLoader(){
        if (GameFile.Existe("personajes.json"))
        {
            personajes = GameFile.LeerPersonajes("Personajes.json");
        }else
        {
            for (int i = 0; i < 10; i++)
            {
                personajes.Add(Factory.CreatePersonaje());
            }
            GameFile.GuardarPersonajes(personajes);
        }
    }

    public List<Personaje> Personajes { get => personajes; }
}