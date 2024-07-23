using ConsoleGame;
using Newtonsoft.Json;

class API
{
    public static async Task<List<Personaje>> GetPersonjes()
    {
        using (HttpClient client = new HttpClient())
        {
            string url = "https://ddragon.leagueoflegends.com/cdn/3.6.14/data/es_ES/champion.json";
            var response = await client.GetStringAsync(url);
            var championData = JsonConvert.DeserializeObject<PersonajeData>(response);
            foreach (var item in championData.Data.Values)
            {
                Console.WriteLine(item.Title);
            }
            Console.WriteLine(championData.Data.Count);
            return championData.Data.Values.ToList();
        }
    }
}