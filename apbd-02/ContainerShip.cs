namespace apbd_02;

public class ContainerShip
{
    public List<Container> Containers { get; private set; }  = new List<Container>();
    public double MaxSpeed { get; private set; }
    public int MaxContainerCount { get; private set; }
    public double MaxTotalWeight { get; private set; } // w tonach
    private double _currentWeight = 0.0;

    
    public ContainerShip(double maxSpeed, int maxContainerCount, double maxTotalWeight)
    {
        MaxSpeed = maxSpeed;
        MaxContainerCount = maxContainerCount;
        MaxTotalWeight = maxTotalWeight;
    }

    public void AddContainer(Container container)
    {
        if (Containers.Count >= MaxContainerCount)
        {
            throw new Exception("Osiągnięto limit liczby kontenerów.");
        }
        Containers.Add(container);
        if (_currentWeight + container.Weight > MaxTotalWeight * 1000)
        {
            throw new Exception("Osiągnięto limit wagi.");
        }
        _currentWeight += container.Weight;
    }
    
    public void AddContainers(List<Container> containers)
    {
        foreach (var container in containers)
        {
            AddContainer(container);
        }
    }
    
    public void RemoveContainer(string serialNumber)
    {
        var container = Containers.FirstOrDefault(c => c.SerialNumber == serialNumber);
        if (container != null)
        {
            Containers.Remove(container);
            _currentWeight -= container.Weight;
        }
        else
        {
            throw new Exception("Nie znaleziono kontenera o podanym numerze seryjnym.");
        }
    }
    public void UnloadContainer(string serialNumber)
    {
        var container = Containers.FirstOrDefault(c => c.SerialNumber == serialNumber);
        if (container != null)
        {
            container.UnloadCargo();
            _currentWeight -= container.PayloadWeight;
        }
        else
        {
            throw new Exception("Nie znaleziono kontenera o podanym numerze seryjnym.");
        }
    }
    
    public void ReplaceContainer(string serialNumber, Container newContainer)
    {
        var container = Containers.FirstOrDefault(c => c.SerialNumber == serialNumber);
        if (container != null)
        {
            Containers.Remove(container);
            AddContainer(newContainer);
        }
        else
        {
            throw new Exception("Nie znaleziono kontenera o podanym numerze seryjnym.");
        }
    }
    public void TransferContainer(ContainerShip targetShip, string serialNumber)
    {
        var container = Containers.FirstOrDefault(c => c.SerialNumber == serialNumber);
        if (container != null)
        {
            RemoveContainer(serialNumber);
            targetShip.AddContainer(container);
        }
        else
        {
            throw new Exception("Nie znaleziono kontenera o podanym numerze seryjnym.");
        }
    }
    
    public void PrintShipInfo()
    {
        Console.WriteLine("Container Ship Information".ToUpper());
        Console.WriteLine($"Max Speed: {MaxSpeed} knots");
        Console.WriteLine($"Max Container Count: {MaxContainerCount}");
        Console.WriteLine($"Max Total Weight: {MaxTotalWeight} tons");
        Console.WriteLine($"Current Weight: {_currentWeight}");
        Console.WriteLine($"Number of Containers: {Containers.Count}");
        Console.WriteLine("Containers Info:");
        
        foreach (var container in Containers)
        {
            container.PrintContainerInfo();
            Console.WriteLine("--------------------");
        }
    }
}