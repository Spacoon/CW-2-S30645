namespace apbd_02;

class Program
{
    static void Main(string[] args)
    {
        var liquidContainer = new LiquidContainer(100, 2.5, 1.5, 2.0, "B001", 500, true);
        var gasContainer = new GasContainer(200, 3.0, 2.0, 2.5, "N001", 1000, 5.0);
        var coolingContainer = new CoolingContainer(150, 2.8, 1.8, 2.2, "H001", 1200, Products.Fish, -2.0);

        liquidContainer.LoadCargo(200);
        gasContainer.LoadCargo(300);
        coolingContainer.LoadCargo(400);

        var containerShip = new ContainerShip(25, 10, 5);
        containerShip.AddContainer(liquidContainer);
        containerShip.AddContainer(gasContainer);

        var containers = new List<Container> { coolingContainer };
        containerShip.AddContainers(containers);

        containerShip.RemoveContainer(liquidContainer.SerialNumber);

        containerShip.UnloadContainer(gasContainer.SerialNumber);

        var newLiquidContainer = new LiquidContainer(120, 2.6, 1.6, 2.1, "D002", 500, false);
        containerShip.ReplaceContainer(coolingContainer.SerialNumber, newLiquidContainer);

        var secondContainerShip = new ContainerShip(20, 8, 4);

        containerShip.TransferContainer(secondContainerShip, newLiquidContainer.SerialNumber);

        newLiquidContainer.PrintContainerInfo();
        containerShip.PrintShipInfo();
        secondContainerShip.PrintShipInfo();
    }
}