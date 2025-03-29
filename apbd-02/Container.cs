namespace apbd_02;

public abstract class Container
{
    private static int _counter = 0;
    public double PayloadWeight { get; protected set; } // w kg
    public double Height { get; protected set; }
    public double Weight { get; protected set; } // w kg
    public double Depth { get; protected set; }
    
    public string SerialNumber { get; protected set; }
    
    public double MaxWeight { get; protected set; }  // w kg
    

    public virtual void UnloadCargo()
    {
        PayloadWeight = 0;
    }
    
    public string MakeSerialNumber(string type)
    {
        return $"KON-{type}-{++_counter}";
    }
    
    public virtual void LoadCargo(double cargoWeight)
    {
        if (cargoWeight > MaxWeight)
        {
            throw new OverfillException("Kontener przeciazaony");
        }
        Weight += cargoWeight;
    }

    public class OverfillException : Exception
    {
        public OverfillException(string exceptionMessage) : base( exceptionMessage) {}
    }
    
    public virtual void PrintContainerInfo()
    {
        Console.WriteLine("Container Information".ToUpper());
        Console.WriteLine($"Serial Number: {SerialNumber}");
        Console.WriteLine($"Container Weight: {Weight} kg");
        Console.WriteLine($"Current Cargo Weight: {PayloadWeight} kg");
        Console.WriteLine($"Max Capacity: {MaxWeight} kg");
        Console.WriteLine($"Height: {Height} m");
        Console.WriteLine($"Depth: {Depth} m");
        Console.WriteLine($"Payload Weight: {PayloadWeight} kg");
        Console.WriteLine($"Max Weight: {MaxWeight} kg");
        Console.WriteLine();
    }
    
}