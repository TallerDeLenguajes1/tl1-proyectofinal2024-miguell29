//* Esta clase se encarga de preparar todo antes de que el juego inicie
using GameComplements;

namespace ConsoleGame;

class GameLoader
{
    private List<Personaje> personajes = new List<Personaje>();
    public List<Personaje> Personajes { get => personajes;}
    public  async Task CargarPersonajes()
    { //*Metodo que prepara la lista de personajes que se  usara en el juego
        
        if (GameFile.Existe("Personajes.json"))
        {
            personajes = GameFile.LeerPersonajes("Personajes.json");
        }else
        {   
            //*Usando la clase Factory
            //for (int i = 0; i < 10; i++)
            //{
            //    personajes.Add(Factory.CreatePersonaje());
            //}
            
            //*Usando la clase API
            personajes = await API.GetPersonajes();
            GameFile.GuardarPersonajes(personajes);
        }
    }

}