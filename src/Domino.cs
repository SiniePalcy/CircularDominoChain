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

    public bool IsDoubled => SideA == SideB;

    public Domino Reverse => new Domino(SideB, SideA);

    public bool CanBeConnected(Domino other) =>
        SideB == other.SideA ||
        SideB == other.SideB || 
        SideA == other.SideA ||
        SideA == other.SideB;

    public bool Equals(Domino other) => 
        (SideA == other.SideA && SideB == other.SideB) ||
        (SideA == other.SideB && SideB == other.SideA);

    public override bool Equals(object? obj) => obj is Domino other && Equals(other);

    public override int GetHashCode() => 
        HashCode.Combine((int)SideA + (int)SideB, Math.Min((int)SideA, (int)SideB));

    public override string ToString() => $"[{SideA}|{SideB}]";

    public static bool TryParse(string enteredDomino, out Domino? domino)
    {
        var parts = enteredDomino.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        try
        {
            if (parts.Length != 2 ||
                !int.TryParse(parts[0], out int sideA) ||
                !int.TryParse(parts[1], out int sideB) ||
                !Enum.IsDefined(typeof(DominoSide), sideA) ||
                !Enum.IsDefined(typeof(DominoSide), sideB))
            {
                throw new ArgumentException("Wrong data to parse");
            }

            domino = new Domino((DominoSide)sideA, (DominoSide)sideB);
            return true;
        }
        catch
        {
            domino = null;
            return false;
        }
    }
}
