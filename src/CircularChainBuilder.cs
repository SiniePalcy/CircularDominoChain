public static class CircularChainBuilder
{
    public static HashSet<Domino> BuildChain(IReadOnlyList<Domino> dominosSet)
    {
        var result = new HashSet<Domino>();
        result.Add(dominosSet[0]);

        while(result.Count < dominosSet.Count)
        {
            var current = result.Last();
            if (!current.IsDoubled)
            {
                var dominosToConnect = dominosSet.Where(
                    domino => !result.Contains(domino) && domino.CanBeConnected(current));
                Domino? doubledDomino = dominosToConnect
                    .Select(x => (Domino?) x)
                    .FirstOrDefault(x => x.Value.IsDoubled);

                var dominoToConnect = doubledDomino.HasValue ? doubledDomino.Value : dominosToConnect.First();

                AddDominoToChain(current, dominoToConnect);
            }
            else
            {
                var dominoToConnect = dominosSet.First(
                   domino => !result.Contains(domino) && domino.CanBeConnected(current));
                AddDominoToChain(current, dominoToConnect);
            }
        }

        return result;

        void AddDominoToChain(Domino current, Domino connect)
        {
            if (current.SideB == connect.SideA)
            {
                result.Add(connect);
            }
            else if (current.SideB == connect.SideB)
            {
                result.Add(connect.Reverse);
            }
            else if (current.SideA == connect.SideA)
            {
                result.Remove(current);
                result.Add(current.Reverse);
                result.Add(connect);
            }
            else if (current.SideA == connect.SideB)
            {
                result.Remove(current);
                result.Add(current.Reverse);
                result.Add(connect.Reverse);
            }
        }
    }

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

            if (values[side] == 2 && dominosSet.Any(x => x.SideA == side && x.IsDoubled))
            {
                return false;
            }
        }

        return true;
    }

}
