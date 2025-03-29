namespace apbd_02;

public class LiquidContainer : Container, IhazardNotifier
{
    public bool IsDangerous { get; private set; }

    public LiquidContainer(double payloadWeight, 
        double height,
        double weight,
        double depth,
        string serialNumber,
        double maxWeight,
        bool isDangerous)
    {
        PayloadWeight = payloadWeight;
        Height = height;
        Weight = weight;
        Depth = depth;
        SerialNumber = serialNumber;
        MaxWeight = maxWeight;
        
        
        SerialNumber = MakeSerialNumber("L");
        IsDangerous = isDangerous;
        MaxWeight = 500; 
    }
    public void NotifyHazard(string containerNumber)
    {
        Console.WriteLine($"Kontener {containerNumber} jest przeciazaony!");
    }

    public override void LoadCargo(double cargoWeight)
    {
        double maxLoadPercentage;
        if (IsDangerous)
        {
            maxLoadPercentage = 0.5;
        }
        else
        {
            maxLoadPercentage = 0.9;
        }
        
        double allowedWeight = MaxWeight * maxLoadPercentage;

        if (cargoWeight > allowedWeight)
        {
            NotifyHazard(SerialNumber);
        }
        base.LoadCargo(cargoWeight);
    }

    public override void PrintContainerInfo()
    {
        base.PrintContainerInfo();
        Console.WriteLine($"Is Dangerous: {IsDangerous}");
    }
}