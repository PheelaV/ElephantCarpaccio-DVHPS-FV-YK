// See https://aka.ms/new-console-template for more information

using ClassLibrary1;

Console.WriteLine("Hello, World!");

while (true)
{
    var invoicer = new Invoicer();

    Console.WriteLine("items?");
    var itemsInput = Console.ReadLine();
    if (string.IsNullOrEmpty(itemsInput) || string.IsNullOrWhiteSpace(itemsInput))
    {
        Console.WriteLine("invalid items input");
        continue;
    }
    int items;
    try
    {
        items = int.Parse(itemsInput);
    }
    catch (Exception e)
    {
        Console.WriteLine("invalid items input");
        continue;
    }
    Console.WriteLine("price per item?");
    var priceInput = Console.ReadLine();
    if (string.IsNullOrEmpty(priceInput) || string.IsNullOrWhiteSpace(priceInput))
    {
        Console.WriteLine("invalid price per item input");
    continue;
    }

    decimal price;
    try
    {
        price = decimal.Parse(priceInput);
    }
    catch (Exception e)
    {
        Console.WriteLine("invalid price per item input");
        continue;
    }
    Console.WriteLine("state code?");
    var stateCode = Console.ReadLine();
    
    if (string.IsNullOrEmpty(stateCode) || string.IsNullOrWhiteSpace(stateCode))
    {
        Console.WriteLine("invalid state input");
        continue;
        

    }    var output = invoicer.GetTotal(items, price, stateCode);

    Console.WriteLine($"total: {output.total}");
    Console.WriteLine("Please enter your credit card details:");
    _ = Console.ReadLine();
    Console.WriteLine("you mug");
}