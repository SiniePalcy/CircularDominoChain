var pack = new DominosPack();

Console.Write("How many dominos you'll select: ");
var selectedDominosCount = int.Parse(Console.ReadLine()!);

Console.Write("Do you want to get random dominos? (y/n): ");
var answer = Console.ReadLine();

var takedDominos = answer == "y" || answer == "Y"
    ? pack.TakeRandomDominos(selectedDominosCount) 
    : EnterDominosManually(selectedDominosCount, pack.Count);

Console.WriteLine("Your selected set: ");
takedDominos.OutputDominos();

if (!CircularChainBuilder.IsCanBeCircular(takedDominos))
{
    Console.WriteLine("Your set can't be circular chain");
    return;
}

var chain = CircularChainBuilder.BuildChain(takedDominos);
Console.WriteLine("Your circular chain:");
chain.OutputDominos();


static List<Domino> EnterDominosManually(int dominosCount, int maxDominos)
{
    if (dominosCount < 2)
    {
        throw new ArgumentException("You can take minimum 3 dominos");
    }

    if (dominosCount > maxDominos)
    {
        throw new ArgumentException("You can't take more than all dominos");
    }

    var result = new List<Domino>(dominosCount);
    for (int i = 0; i < dominosCount; i++)
    {
        string enteredDominoString = string.Empty;
        Domino? domino = null;
        do
        {
            Console.Write($"Please enter the {i + 1} domino separated by spaces (for example 6 0): ");
            enteredDominoString = Console.ReadLine();
            if (!Domino.TryParse(enteredDominoString, out domino))
            {
                Console.WriteLine("Wrong entered data, please, try again");
            }
        } while (domino is null);

        result.Add(domino.Value);
    }

    return result;
}