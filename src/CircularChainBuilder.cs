using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public static class CircularChainBuilder
{
    public static bool IsCanBeCircular(IEnumerable<Domino> dominosSet)
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

            if (values[side] == 2 && dominosSet.Any(x => x.SideA == side && x.SideB == side))
            {
                return false;
            }
        }

        return true;
    }

}
