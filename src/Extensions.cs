using System.Runtime.CompilerServices;

public static class Extensions
{
    public static void OutputDominos(this IEnumerable<Domino> dominos)
    {
        foreach (var domino in dominos)
        {
            Console.WriteLine(domino.ToString());
        }

        Console.WriteLine();
    }
}
