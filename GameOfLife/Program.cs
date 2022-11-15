namespace GameOfLife
{
    internal class Program
    {
        static void Main()
        {
            var field = InitializeFieldWithUser();

            int millisecondsTimeout = InitializeMillisecondsTimeOut();

            PrintTimer();

            while (true)
            {
                PrintField(field);
                field.GoToNextGeneration();
                Thread.Sleep(millisecondsTimeout);
                Console.Clear();
            }
            // ReSharper disable once FunctionNeverReturns
        }

        private static int InitializeMillisecondsTimeOut()
        {
            Console.WriteLine("Enter the refresh time in milliseconds: ");
            return Convert.ToInt32(Console.ReadLine());
        }

        private static void PrintField(Field field)
        {
            for (int i = 0; i < field.LengthOfField; i++)
            {
                for (int j = 0; j < field.HeightOfField; j++)
                {
                    Console.Write(field.Cells[i, j]);
                }
                Console.WriteLine();
            }
        }

        private static Field InitializeFieldWithUser()
        {
            Console.WriteLine("Hello Survivor, welcome to the game of life :)" + Environment.NewLine + "Form of dead cells: ." +
                              Environment.NewLine + "Form of alive cells: *" + Environment.NewLine + Environment.NewLine);
            
            Console.WriteLine("Enter the size of your field " + Environment.NewLine + "length: ");
            var length = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("height: ");
            var height = Convert.ToInt32(Console.ReadLine());

            var field = new Field(length, height);

            Console.WriteLine();

            Console.WriteLine("Enter the indexes from your alive cells! enter s to start!" + Environment.NewLine +
                              "Attention if you enter a cell double it will switch to a dead cell" + Environment.NewLine +
                              "Press g for a demo :)");

            while (true)
            {
                Console.WriteLine();


                Console.WriteLine("index x: ");
                var indexHeight = Console.ReadLine();

                if (string.Equals(indexHeight, "s", StringComparison.Ordinal))
                    break;

                if (string.Equals(indexHeight, "g", StringComparison.Ordinal))
                {
                    field = new Field(20, 20);
                    field.SwitchLiveState(5, 5);
                    field.SwitchLiveState(5, 6);
                    field.SwitchLiveState(6, 4);
                    field.SwitchLiveState(7, 4);
                    field.SwitchLiveState(6, 7);
                    field.SwitchLiveState(7, 7);
                    field.SwitchLiveState(8, 7);
                    field.SwitchLiveState(8, 6);
                    field.SwitchLiveState(8, 5);

                    field.SwitchLiveState(9, 13);
                    field.SwitchLiveState(9, 14);
                    field.SwitchLiveState(10, 13);
                    field.SwitchLiveState(10, 12);
                    field.SwitchLiveState(11, 14);

                    field.SwitchLiveState(13, 9);
                    field.SwitchLiveState(14, 9);
                    field.SwitchLiveState(14, 8);
                    field.SwitchLiveState(15, 8);
                    field.SwitchLiveState(15, 10);
                    break;
                }

                Console.WriteLine();

                Console.WriteLine("index y: ");
                var indexLength = Console.ReadLine();

                if (string.Equals(indexHeight, "s", StringComparison.Ordinal))
                    break;

                field.SwitchLiveState(Convert.ToInt32(indexLength), Convert.ToInt32(indexHeight));

                Console.WriteLine();

                Console.WriteLine("---- next cell -----");
            }

            Console.Clear();

            return field;
        }

        private static void PrintTimer()
        {
            Thread.Sleep(1000);
            Console.WriteLine(3);
            Console.Clear();

            Thread.Sleep(1000);
            Console.WriteLine(2);
            Console.Clear();

            Thread.Sleep(1000);
            Console.WriteLine(1);
            Console.Clear();
        }


        public void SwitchRandomStates(int numberOfSwitches)
        {
            
        }
    }
}