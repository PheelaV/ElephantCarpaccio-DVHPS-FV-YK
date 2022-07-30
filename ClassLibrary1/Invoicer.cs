namespace ClassLibrary1;

public class Invoicer
{
    
    public Output GetTotal(int noItem, decimal itemPrice, string stateCode)
    {
        if (noItem < 0) throw new Exception("negative items");
        
        if (string.IsNullOrEmpty(stateCode) || string.IsNullOrWhiteSpace(stateCode)) 
            throw new Exception("invalid state code");
        
        var total = noItem * itemPrice;

        var discount = total switch
        {
            < 1000 => 0,
            < 5000 => 3,
            < 7000 => 5,
            < 10_000 => 7,
            < 50_000 => 10,
            >= 50_000 => 15
        };
        
        var myDiscount = (1 - discount / (decimal) 100);

        var tax = stateCode.ToUpper() switch
        {
            "UT" => 6.85,
            "NV" => 8,
            "TX" => 6.25,
            "AL" => 4,
            "CA" => 8.25,
            "" => 0,
            _ => throw new Exception("invalid state code")
        };

        var discountedTotal = total * myDiscount;
        var taxTotal = discountedTotal * (decimal)(tax / 100);
        var taxedDiscountedTotal = discountedTotal + taxTotal;
        return new(noItem, itemPrice, stateCode, taxedDiscountedTotal);
    }
}

public record Output(int noItem, decimal itemPrice, string stateCode, decimal total);