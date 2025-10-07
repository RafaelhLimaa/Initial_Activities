namespace Initial_Activities
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //StudentAverageCalculation calculation = new();
            //calculation.Calculation();

            ShowMenu showMenu = new();
            showMenu.ShowMenuItems();
            showMenu.StartOrder();
        }
    }
}
