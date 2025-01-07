var pack = new DominosPack();


Console.Write("How many dominos you'll select: ");
var selectedDominosCount = int.Parse(Console.ReadLine()!);

var takedDominos = pack.TakeRandomDominos(selectedDominosCount);
Console.WriteLine("You selected set: ");
takedDominos.OutputDominos();

if (!CircularChainBuilder.IsCanBeCircular(takedDominos))
{
    Console.WriteLine("Your set can't be circular chain");
    return;
}

var chain = CircularChainBuilder.BuildChain(takedDominos);
Console.WriteLine("Your circular chain:");
chain.OutputDominos();

