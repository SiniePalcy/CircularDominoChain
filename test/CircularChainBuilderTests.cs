public class CircularChainBuilderTests
{
    [Test]
    public void IsCanBeCircular_Success()
    {
        var testCase = new[]
        {
            new Domino(DominoSide.Two, DominoSide.One),
            new Domino(DominoSide.Two, DominoSide.Three),
            new Domino(DominoSide.Three, DominoSide.One),
        };

        Assert.That(CircularChainBuilder.IsCanBeCircular(testCase), Is.True);
    }

    [Test]
    public void IsCanBeCircular_WithDoubledDominos_Failed()
    {
        var testCase = new[]
        {
            new Domino(DominoSide.Two, DominoSide.One),
            new Domino(DominoSide.Two, DominoSide.Four),
            new Domino(DominoSide.Four, DominoSide.One),
            new Domino(DominoSide.Three, DominoSide.Three),
        };

        Assert.That(CircularChainBuilder.IsCanBeCircular(testCase), Is.False);
    }
}