using System;

namespace part2
{
    class Program
    {
        static void Main(string[] args)
        {
            bool[,] arr = new bool[12+1, 31+1];
            int choice = 0;

            for (int i = 0; i < 12+1; i++)
            {
                for (int j = 0; j < 31+1; j++)
                {
                    arr[i, j] = false;
                }
            }

            while (choice != 4)
            {
                Console.WriteLine("Enter a number between 1 and 4 (according to the instructions on the exercise page)");
                choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:                         // new order
                        Console.Write("Enter the start date of the accommodation:\nDay = ");
                        int day = int.Parse(Console.ReadLine());
                        Console.Write("Month = ");
                        int month = int.Parse(Console.ReadLine());

                        Console.WriteLine("Enter the number of days");
                        Console.Write("Length = ");
                        int length = int.Parse(Console.ReadLine());

                        bool isOk = true;           // is it ok to order in the date.
                        int tempDay = day, TempMonth = month;
                        for (int i = 0; i < length-2 && isOk; i++)
                        {
                            tempDay++;                   // not chack the first day

                            if (tempDay > 31)
                            {
                                tempDay = 1;
                                TempMonth++;
                            }
                            if (TempMonth > 12)         // error!
                            {
                                Console.WriteLine("Error: Date cannot exceed next year");
                                isOk = false;
                                break;
                            }

                            if (arr[TempMonth, tempDay] == true)
                                isOk = false;
                        }

                        if (isOk)
                        {
                            Console.WriteLine("The request allowed");
                            for (int i = 0; i < length; i++)
                            {
                                arr[month, day++] = true;

                                if (day > 31)
                                {
                                    day = 1;
                                    month++;
                                }
                            }
                        }
                        else
                            Console.WriteLine("The request denied");
                        break;
                    case 2:             //print
                        bool isStart = false;
                        int prevI, prevJ;
                        for (int i = 1; i < 12+1; i++)
                        {
                            for (int j = 1; j < 31+1; j++)
                            {
                                if (arr[i,j] == true)
                                {
                                    if (!isStart)
                                    {
                                        isStart = true;
                                        Console.WriteLine("Start Date: {0 }/{1 }", j ,i);
                                    }
                                }
                                if (arr[i, j] == false)
                                {
                                    if (isStart)
                                    {
                                        if(j == 1)
                                        {
                                            prevI = 31;
                                            prevJ = j - 1;
                                        }
                                        else
                                        {
                                            prevI = i;
                                            prevJ = j-1;
                                        }
                                        isStart = false;
                                        Console.WriteLine("End Date: {0}/{1}" , prevJ, prevI);
                                    }
                                }
                            }
                        }
                        break;
                    case 3:
                        int sum = 0;
                        for (int i = 1; i < 12 + 1; i++)
                        {
                            for (int j = 1; j < 31 + 1; j++)
                            {
                                if (arr[i,j])
                                {
                                    sum++;
                                }
                            }
                        }
                            Console.WriteLine("sum: {0}\npercentage: {1}%" , sum , (int)(((double)sum/(31*12))*100));

                        break;
                    default:
                        break;
                }
            }
        }
    }
}
