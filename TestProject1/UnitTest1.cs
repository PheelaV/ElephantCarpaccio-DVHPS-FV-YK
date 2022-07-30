using ClassLibrary1;

namespace TestProject1;

public class UnitTest1
{
    [Fact]
    public void ShouldGetTotal()
    {
        var invoicer = new Invoicer();

        var o = invoicer.GetTotal(0, 0, string.Empty);
        
        Assert.Equal(0, o.total);
    }
    
    [Fact]
    public void ShouldGetTotalDiscounted()
    {
        var invoicer = new Invoicer();

        var o = invoicer.GetTotal(1000, 10, string.Empty);
        
        Assert.Equal((decimal)9000, o.total);
    }
    
        
    [Fact]
    public void ShouldGetTotalTaxed()
    {
        var invoicer = new Invoicer();

        var o = invoicer.GetTotal(1000, 10, "al");
        
        Assert.Equal((decimal)9360, o.total);
    }
    
    [Fact]
    public void ShouldErrorOnInvalidItemCount()
    {
        var invoicer = new Invoicer();

        Assert.Throws<Exception>(() => invoicer.GetTotal(-1, 10, "al"));
    }
    
    [Fact]
    public void ShouldErrorOnInvalidStateCode()
    {
        var invoicer = new Invoicer();

        Assert.Throws<Exception>(() => invoicer.GetTotal(-1, 10, "al"));
    }
}