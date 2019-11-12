using System;

namespace part1
{
    class Program
    {
        static void Main(string[] args)
        {
            Random r = new Random(DateTime.Now.Millisecond);

            int[] A = new int[20], B = new int[20], C = new int[20];

            for (int i = 0; i < 20; i++)
            {
                A[i] = r.Next(18, 122 + 1);
                B[i] = r.Next(18, 122 + 1);
                C[i] = Math.Abs(A[i] - B[i]);
                Console.Write("{0,4}" , A[i]);
            }

            Console.WriteLine();

            for (int i = 0; i < 20; i++)
            {
                Console.Write("{0,4}", B[i]);
            }

            Console.WriteLine();

            for (int i = 0; i < 20; i++)
            {
                Console.Write("{0,4}", C[i]);
            }

            Console.WriteLine();
        }
    }
}
