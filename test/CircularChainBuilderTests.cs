public class CircularChainBuilderTests
{
    [Test]
    public void IsCanBeCircular_Succeeded()
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

    [Test]
    public void IsCanBeCircular_WithDoubledDominos_Succeeded()
    {
        var testCase = new[]
        {
            new Domino(DominoSide.One, DominoSide.Three),
            new Domino(DominoSide.One, DominoSide.Six),
            new Domino(DominoSide.Four, DominoSide.Six),
            new Domino(DominoSide.Three, DominoSide.Four),
            new Domino(DominoSide.Four, DominoSide.Four),
        };

        Assert.That(CircularChainBuilder.IsCanBeCircular(testCase), Is.True);
    }

    [Test]
    public void BuildChain_Succeeded()
    {
        var testCase = new[]
        {
            new Domino(DominoSide.Two, DominoSide.One),
            new Domino(DominoSide.Two, DominoSide.Four),
            new Domino(DominoSide.One, DominoSide.Four),
        };

        var builtChain = new[]
{
            new Domino(DominoSide.One, DominoSide.Two),
            new Domino(DominoSide.Two, DominoSide.Four),
            new Domino(DominoSide.Four, DominoSide.One),
        };

        var actualBuiltChain = CircularChainBuilder.BuildChain(testCase);

        Assert.That(actualBuiltChain, Is.EqualTo(builtChain));
    }

    [Test]
    public void BuildChain_WithDoubles_Succeeded()
    {
        var testCase = new[]
        {
            new Domino(DominoSide.Two, DominoSide.One),
            new Domino(DominoSide.Four, DominoSide.One),
            new Domino(DominoSide.One, DominoSide.One),
            new Domino(DominoSide.Two, DominoSide.Four),
        };

        var builtChain = new[]
{
            new Domino(DominoSide.Two, DominoSide.One),
            new Domino(DominoSide.One, DominoSide.One),
            new Domino(DominoSide.One, DominoSide.Four),
            new Domino(DominoSide.Four, DominoSide.Two),
        };

        var actualBuiltChain = CircularChainBuilder.BuildChain(testCase);

        Assert.That(actualBuiltChain, Is.EqualTo(builtChain));
    }
}