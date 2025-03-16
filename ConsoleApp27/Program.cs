using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp27
{
    internal class Program
    {
        public static void merge(int[] a, int l, int m, int r)
        {
            int n1 = m - l + 1, n2 = r - m;
            int[] x = new int[n1];
            int[] y = new int[n2];

            Array.Copy(a, l, x, 0, n1);
            Array.Copy(a, m + 1, y, 0, n2);

            int i = 0, j = 0;

            while (i < n1 && j < n2)
            {
                if (x[i] <= y[j])
                {
                    a[l] = x[i]; l++; i++;
                }
                else
                {
                    a[l] = y[j]; l++; j++;
                }
            }
            while (i < n1)
            {
                a[l] = x[i]; l++; i++;

            }
            while (j < n2)
            {
                a[l] = y[j]; l++; j++;
            }
        }
        public static void mergeSort(int[] a, int l, int r)
        {
            if (l < r)
            {
                int m = (l + r) / 2;
                mergeSort(a, l, m);
                mergeSort(a, m + 1, r);
                merge(a, l, m, r);
            }
        }
        static void Main(string[] args)
        {
            Random random = new Random();
            int n = Convert.ToInt32(Console.ReadLine());
            int[] a = new int[n];

            for (int i = 0; i < n; i++)
            {
                a[i] = random.Next(1, 100);
            }
            mergeSort(a, 0, n - 1);

            foreach (int x in a)
            {
                Console.Write(x + " ");
            }
        }
            //Timing time = new Timing();
            //TimeSpan tongtg = new TimeSpan(0);
            //for (int i = 0; i < 1000; i++)
            //{
            //    int[] a = new int[n];
            //    for (int j = 0; j < n; j++)
            //    {
            //        a[j] = random.Next(1, 1000);
            //    }
            //    //Array.Sort(a);
            //    //Array.Reverse(a);
            //    time.startTime();
            //    mergeSort(a, 0, n - 1);
            //    time.StopTime();

            //    tongtg += time.Result();
            //}
            //Console.WriteLine(tongtg.TotalMilliseconds / 1000);
        

    }
}
