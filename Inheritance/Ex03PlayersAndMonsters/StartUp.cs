namespace PlayersAndMonsters
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var bladeKnight = new BladeKnight("test", 3);
            System.Console.WriteLine(bladeKnight.ToString());
        }
    }
}