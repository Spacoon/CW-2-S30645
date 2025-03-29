namespace apbd_02;

public class GasContainer : Container, IhazardNotifier
{
    public double Pressure { get; private set; }
    
    public GasContainer(double payloadWeight, 
        double height,
        double weight,
        double depth,
        string serialNumber,
        double maxWeight,
        double pressure)
    {
        PayloadWeight = payloadWeight;
        Height = height;
        Weight = weight;
        Depth = depth;
        SerialNumber = serialNumber;
        MaxWeight = maxWeight;
        
        SerialNumber = MakeSerialNumber("G");
        Pressure = pressure;
        MaxWeight = 1000; 
    }

    public void NotifyHazard(string containerNumber)
    {
        Console.WriteLine($"HAZARD ALERT: Container {containerNumber} is being loaded unsafely!");
    }
 
    // load cargo niepotrzebne, bo sie nic nie zmienia
    public override void UnloadCargo()
    {
        PayloadWeight *= 0.5;
    }
    
    public override void PrintContainerInfo()
    {
        base.PrintContainerInfo();
        Console.WriteLine($"Pressure: {Pressure} bar");
    }
    
}