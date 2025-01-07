public enum DominoSide
{
    Blank = 0,
    One,
    Two,
    Three,
    Four,
    Five,
    Six
}

public readonly struct Domino : IEquatable<Domino>
{
    public DominoSide SideA { get; }
    public DominoSide SideB { get; }

    public Domino(DominoSide sideA, DominoSide sideB)
    {
        SideA = sideA;
        SideB = sideB;
    }

    public bool Equals(Domino other)
    {
        return (SideA == other.SideA && SideB == other.SideB) ||
               (SideA == other.SideB && SideB == other.SideA);
    }

    public override bool Equals(object? obj)
    {
        return obj is Domino other && Equals(other);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine((int)SideA + (int)SideB, Math.Min((int)SideA, (int)SideB));
    }

    public override string ToString()
    {
        return $"[{SideA}|{SideB}]";
    }
}
