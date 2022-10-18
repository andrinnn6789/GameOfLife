namespace GameOfLife
{
    internal class Program
    {
        static void Main()
        {
            Console.WriteLine("Hello World!");
        }

        public void SwitchRandomStates(int numberOfSwitches)
        {
            var rand = new Random();

            for (int i = 0; i < numberOfSwitches; i++)
            {
                //SwitchLiveState(rand.Next(0, _lenghtOfField), rand.Next(0, _heightOfField));
            }
        }
    }
}