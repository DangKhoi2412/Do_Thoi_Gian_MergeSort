using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp27
{
    internal class DoThoiGian
    {
        class program
        {
            static void Main()
            {
                Console.InputEncoding = Encoding.Unicode;
                Console.OutputEncoding = Encoding.Unicode;
                Console.WriteLine("Đang đo thời gian thuật toán Merge Sort...");
                tinh.tinhthoigiantb("Dễ nhất (mảng đã sắp xếp)", taomang.denhat);
                tinh.tinhthoigiantb("Trung bình (mảng ngẫu nhiên)", taomang.trungbinh);
                tinh.tinhthoigiantb("Khó nhất (mảng sắp xếp ngược)", taomang.khonhat);
                Console.ReadKey();
            }
        }
        class taomang
        {
            static public int[] denhat(int size)
            {
                Random rand = new Random();
                int[] arr = new int[size];
                for (int i = 0; i < size; i++)
                    arr[i] = rand.Next(1, size + 1);
                Array.Sort(arr);
                return arr;
            }
            static public int[] trungbinh(int size)
            {
                Random rand = new Random();
                int[] arr = new int[size];
                for (int i = 0; i < size; i++)
                    arr[i] = rand.Next(1, size + 1);
                return arr;
            }

            static public int[] khonhat(int size)
            {
                Random rand = new Random();
                int[] arr = new int[size];
                for (int i = 0; i < size; i++)
                    arr[i] = rand.Next(1, size + 1);
                Array.Sort(arr);
                Array.Reverse(arr);
                return arr;
            }
        }
        class tinh
        {
            static public void tinhthoigiantb(string casename, Func<int, int[]> taomang)
            {
                Timing tg = new Timing();
                TimeSpan tongtg = new TimeSpan(0);

                for (int i = 0; i < 1000; i++)
                {
                    int[] arr = taomang(10000);

                    GC.Collect();
                    GC.WaitForPendingFinalizers();

                    tg.startTime();
                    Program.mergeSort(arr, 0, arr.Length - 1);
                    tg.StopTime();

                    tongtg += tg.Result();
                }

                Console.WriteLine($"{casename}: Trung bình {tongtg.TotalMilliseconds / 1000} ms");
            }
        }

    }
}
