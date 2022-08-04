namespace FlyingStars
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.SetWindowSize(100, 20);
            int count;
            Console.Write("Enter number of stars from 0 to 100: ");
            string countValue = Console.ReadLine();
            count = Convert.ToInt32(countValue);

            int[,] arr = new int[count, 3]; //array describes each star(y,x,speed)
            int[,] board = new int[20, 100];//fixed board
            Random rnd = new Random();
            for (int i = 0; i < count; i++)
            {
                arr[i, 0] = rnd.Next(0, 19);
                arr[i, 1] = rnd.Next(0, 99);
                arr[i, 2] = rnd.Next(1, 3); //speed can be from 1 to 3
                board[arr[i, 0], arr[i, 1]] += 1;
            }

            while (true)
            {
                Console.Clear();
                PrintArr(board, 20, 100);
                System.Threading.Thread.Sleep(200);
                Console.Clear();
                for (int i = 0; i < count; i++)
                {
                    board[arr[i, 0], arr[i, 1]] -= 1;
                    arr[i, 1] += arr[i, 2];
                    arr[i, 1] %= 100;
                    board[arr[i, 0], arr[i, 1]] += 1;

                }
            }

        }
        public static void PrintArr(int[,] arr, int height, int width)
        {
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                    if (arr[i, j] == 0)
                        Console.Write(' ');
                    else
                    {
                        Console.Write('*');
                    }
                Console.Write("\n");
            }
                


        }
    }
}

