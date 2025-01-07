using System.Collections;

public class DominosPack : IReadOnlyList<Domino>
{
    public List<Domino> Dominos { get; private set; } = new();

    public int Count => Dominos.Count;

    public Domino this[int index] => Dominos[index];

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

    public int IndexOf(Domino item)
    {
        throw new NotImplementedException();
    }

    public void Insert(int index, Domino item)
    {
        throw new NotImplementedException();
    }

    public void RemoveAt(int index)
    {
        throw new NotImplementedException();
    }

    public void Add(Domino item)
    {
        throw new NotImplementedException();
    }

    public void Clear()
    {
        throw new NotImplementedException();
    }

    public bool Contains(Domino item)
    {
        throw new NotImplementedException();
    }

    public void CopyTo(Domino[] array, int arrayIndex)
    {
        throw new NotImplementedException();
    }

    public bool Remove(Domino item)
    {
        throw new NotImplementedException();
    }
}