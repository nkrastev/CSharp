namespace NeedForSpeed
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var raceMotorCycle = new RaceMotorcycle(7, 100);
            raceMotorCycle.Drive(10);

            System.Console.WriteLine(raceMotorCycle.FuelConsumption());
            //System.Console.WriteLine(raceMotorCycle.Fuel()); its 80, its working correct

            var familyCar = new FamilyCar(1, 100);
            familyCar.Drive(10);

            System.Console.WriteLine(familyCar.FuelConsumption());
            
        }
    }
}
