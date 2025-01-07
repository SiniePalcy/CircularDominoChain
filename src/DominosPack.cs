using System.Collections;

public class DominosPack : IEnumerable<Domino>
{
    public List<Domino> Dominos { get; private set; } = new();

    public DominosPack()
    {
        var allSides = Enum.GetValues<DominoSide>();
        for (var i = 0; i < allSides.Length; i++)
        {
            for (int j = i; j < allSides.Length; j++)
            {
                Dominos.Add(new Domino((DominoSide)i, (DominoSide)j));
            }
        }
    }

    public List<Domino> TakeRandomDominos(int count)
    {
        if (count < 2)
        {
            throw new ArgumentException("You can take minimum 3 dominos");
        }

        if (count > Dominos.Count)
        {
            throw new ArgumentException("You can't take more than all dominos");
        }

        var result = new List<Domino>();

        var random = new Random();
        var selectedDominos = new HashSet<int>();

        for (int i = 0; i < count; i++)
        {
            int index;

            do
            {
                index = random.Next(Dominos.Count);
            } while (!selectedDominos.Add(index));

            result.Add(Dominos[index]);
        }

        return result;
    }

    public IEnumerator<Domino> GetEnumerator()
    {
        return Dominos.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}