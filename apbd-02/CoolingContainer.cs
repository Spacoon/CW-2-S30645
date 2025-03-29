namespace apbd_02;

public class CoolingContainer : Container
{
    public Products ProductType { get; private set; }
    public double Temperature { get; private set; }
    
    public CoolingContainer(double payloadWeight, 
        double height,
        double weight,
        double depth,
        string serialNumber,
        double maxWeight,
        Products product,
        double requiredTemperature)
    {
        PayloadWeight = payloadWeight;
        Height = height;
        Weight = weight;
        Depth = depth;
        SerialNumber = serialNumber;
        MaxWeight = maxWeight;
        
        SerialNumber = MakeSerialNumber("C");
        ProductType = product;
        Temperature = requiredTemperature;
        MaxWeight = 1200;

        if (ProductsTemperatures.Temperatures[product] < requiredTemperature)
        {
            throw new Exception($"nie mozna wstawic {product} ze wzgledu na mniejsza wymagana temperature");
        }
    }
    
}


