using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace linq_hw2_1A2B
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string yn;
            do
            {
                int[] computerans = new int[0];
                Random rnd = new Random();

                // 4個不重複亂數
                for (int i = 0; i < 4; i++)
                {
                    bool emp;
                    var x = 0;
                    do
                    {
                        x = rnd.Next(0, 10);
                        emp = computerans.Contains(x);
                    } while (emp);

                    computerans = computerans.Append(x).ToArray();
                }
                foreach (int x in computerans)
                {
                    Console.Write(x);
                }

                Console.WriteLine("\n歡迎來到 1A2B 猜數字的遊戲～");
                Console.WriteLine("===========================");

                int a = 0, b = 0;
                do // 沒有猜對一直重複
                {
                    //輸入數字
                    a = 0; b = 0;
                    Console.Write("請輸入 4 個數字： ");
                    string str = Console.ReadLine();
                    int[] player = new int[0];
                    foreach (var item in str)
                    {
                        player = player.Append(Convert.ToInt32(item) - '0').ToArray();
                    }


                    //判斷幾A幾B
                    int[] ints = new int[0];

                    ints = computerans.Intersect(player).ToArray();

                    foreach (var item in ints)
                    {
                        Console.WriteLine(item);
                        int indexcm = Array.IndexOf(computerans, item);
                        int indexpy = Array.IndexOf(player, item);
                        if (indexcm == indexpy)
                        {
                            a++;
                        }
                        else if (indexcm != indexpy && indexcm >= 0) { b++; }

                    }

                    Console.WriteLine($"{a}A {b}B");
                } while (a < 4);

                Console.WriteLine("恭喜你！猜對了！！");

                Console.WriteLine("你要繼續玩嗎？(y/n): ");
                yn = Console.ReadLine();
            } while (yn == "y");
           

        }
    }
}
