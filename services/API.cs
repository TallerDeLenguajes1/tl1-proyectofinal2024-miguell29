using ConsoleGame;
using Newtonsoft.Json;

class API
{
    public static async Task<List<Personaje>> GetPersonajes()
    {
        try
        {
            using (HttpClient client = new HttpClient())
            {
                string url = "https://ddragon.leagueoflegends.com/cdn/3.6.14/data/es_ES/champion.json";
                var response = await client.GetStringAsync(url);
                var championData = JsonConvert.DeserializeObject<PersonajeData>(response);
                return championData.Data.Values.ToList();
            }
        }
        catch (System.Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
            Console.ReadKey(true);
            return null;
        }
    }
}