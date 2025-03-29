namespace apbd_02;

public enum Products
{
    Bananas,
    Chocolate,
    Fish,
    Meat,
    IceCream,
    FrozenPizza,
    Cheese,
    Sausages,
    Butter,
    Eggs
}

public static class ProductsTemperatures
{
    public static readonly Dictionary<Products, double> Temperatures = new Dictionary<Products, double>
    {
        {
            Products.Bananas, 13.3
        },
        {
            Products.Chocolate, 18.0
        },
        {
            Products.Fish, 2.0
        },
        {
            Products.Meat, -15.0
        },
        {
            Products.IceCream, -18.0
        },
        {
            Products.FrozenPizza, -30.0
        },
        {
            Products.Cheese, 7.2
        },
        {
            Products.Sausages, 5
        },
        {
            Products.Butter, 20.5
        },
        {
            Products.Eggs, 19.0
        }
    };
}