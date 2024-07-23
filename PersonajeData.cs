using ConsoleGame;

public class PersonajeData
{
    public Dictionary<string, Personaje> Data { get; set; }
}
public class Info
{
    public int Attack { get; set; }
    public int Defense { get; set; }
    public int Magic { get; set; }
    public int Difficulty { get; set; }
}

public class Image
{
    public string Full { get; set; }
    public string Sprite { get; set; }
    public string Group { get; set; }
    public int X { get; set; }
    public int Y { get; set; }
    public int W { get; set; }
    public int H { get; set; }
}

public class Stats
{
    public double Hp { get; set; }
    public double HpPerLevel { get; set; }
    public double Mp { get; set; }
    public double MpPerLevel { get; set; }
    public double MoveSpeed { get; set; }
    public double Armor { get; set; }
    public double ArmorPerLevel { get; set; }
    public double SpellBlock { get; set; }
    public double SpellBlockPerLevel { get; set; }
    public double AttackRange { get; set; }
    public double HpRegen { get; set; }
    public double HpRegenPerLevel { get; set; }
    public double MpRegen { get; set; }
    public double MpRegenPerLevel { get; set; }
    public double Crit { get; set; }
    public double CritPerLevel { get; set; }
    public double AttackDamage { get; set; }
    public double AttackDamagePerLevel { get; set; }
    public double AttackSpeedOffset { get; set; }
    public double AttackSpeedPerLevel { get; set; }
}