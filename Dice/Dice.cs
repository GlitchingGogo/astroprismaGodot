using Godot;

public enum Dice
{
    D4,
    D6,
    D8,
    D10,
    D12,
    D20,
}

public static partial class Extensions
{
    public static int Roll(this Dice dice, int amount = 1)
    {
        Vector2I range = dice.GetRange();
        int total = 0;

        for (int i = 0; i < amount; i++)
        {
            total += GD.RandRange(range.X, range.Y);
        }
        
        return total;
    }

    public static Vector2I GetRange(this Dice dice)
    {
        switch (dice)
        {
            case Dice.D4: return new Vector2I(1, 4);
            case Dice.D6: return new Vector2I(1, 6);
            case Dice.D8: return new Vector2I(1, 8);
            case Dice.D10: return new Vector2I(1, 10);
            case Dice.D12: return new Vector2I(1, 12);
            case Dice.D20: return new Vector2I(1, 20);
        }

        return Vector2I.One;
    }
}