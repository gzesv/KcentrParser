namespace KcentrParser.Models;

public class Apple
{
    public Apple(string name, string link, string price)
    {
        Name = name;
        Link = link;
        Price = price;
    }

    public string Name { get; }
    public string Link { get; }
    public string Price { get; }
}