var pack = new DominosPack();


Console.Write("How many dominos you'll select: ");
var selectedDominosCount = int.Parse(Console.ReadLine());

var takedDominos = pack.TakeRandomDominos(selectedDominosCount);
Console.WriteLine("You selected set: ");
takedDominos.OutputDominos();

if (!IsCanBeCircular(takedDominos))
{
    Console.WriteLine("Your set can't be circular chain");
    return;
}


static bool IsCanBeCircular(IEnumerable<Domino> dominosSet)
{
    var values = new Dictionary<DominoSide, int>();
    foreach (var domino in dominosSet)
    {
        if (!values.ContainsKey(domino.SideA))
        {
            values.Add(domino.SideA, 0);
        }

        if (!values.ContainsKey(domino.SideB))
        {
            values.Add(domino.SideB, 0);
        }

        values[domino.SideA]++;
        values[domino.SideB]++;
    }

    foreach (var side in values.Keys)
    {
        if (values[side] % 2 != 0)
        {
            return false;
        }
    }

    return true;
}