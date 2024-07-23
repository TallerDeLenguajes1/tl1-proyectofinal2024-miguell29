using ConsoleGame;

namespace GameComplements;

class Factory
{
    
    public static Personaje CreatePersonaje()
    {
        var num = new Random();
       
        //lista de nombres
        string[] nameList = {"Gandalf", "Legolas", "Aragorn",};
        var name = nameList[num.Next(nameList.Length)];
        //lista de apodos
        string[] nickList = {"El mago", "El elfo", "El caballero"};
        var title = nickList[num.Next(nickList.Length)];

        var id = num.Next(1,120).ToString();
        var blurb = "Descripcion del Personaje";
        var info = new Info()
        {
            Attack = num.Next(1,10),
            Defense = num.Next(1,10),
            Magic = num.Next(1,10),
            Difficulty = num.Next(1,10)
        };
        var image = new Image()
        {
            Full = "...",
            Sprite = "...",
            Group = "champion",
            X = 48,
            Y = 0,
            W = 48,
            H = 48
        };
        var tags = new List<string>{"1", "2", "3"};
        var partype = "partype";
        var stats = new Stats()
        {
             Hp = num.NextDouble()*100,
             HpPerLevel= num.NextDouble()*100,
             Mp = num.NextDouble()*100,
             MpPerLevel = num.NextDouble()*100,
             MoveSpeed = num.NextDouble()*100,
             Armor = num.NextDouble()*100,
             ArmorPerLevel = num.NextDouble()*100,
             SpellBlock = num.NextDouble()*100,
             SpellBlockPerLevel = num.NextDouble()*100,
             AttackRange = num.NextDouble()*100,
             HpRegen = num.NextDouble()*100,
             HpRegenPerLevel = num.NextDouble()*100,
             MpRegen = num.NextDouble()*100,
             MpRegenPerLevel = num.NextDouble()*100,
             Crit = num.NextDouble()*100,
             CritPerLevel = num.NextDouble()*100,
             AttackSpeedOffset = num.NextDouble()*100,
             AttackSpeedPerLevel = num.NextDouble()*100
        };

        var personaje = new Personaje(id,name,title,blurb,info,image,tags,partype,stats);
        return personaje;  
    }
}