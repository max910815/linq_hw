using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace linq_hw
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var open = File.ReadLines(@"C:\Users\a0966\source\repos\linq_hw\product.csv")
                        .Skip(1)
                        .Select(x => x.Split(',')); 
            
            
            var totalall = open.Where(x => x[3] != null).ToList().Select(x => x[3]);

            int sum1 = 0;
            foreach(var item in totalall)
            {
                sum1 = sum1 + int.Parse(item);
            }
            Console.WriteLine($"計算所有商品的總價格 {sum1} 元");

            Console.WriteLine($"計算所有商品的平均價格 {sum1 / totalall.Count()}");

            var manyall = open.Where(x => x[2] != null).ToList().Select(x => x[2]);

            int summany = 0;
            foreach(var item in manyall)
            {
                summany = summany + int.Parse(item);
            }

            Console.WriteLine($"計算商品的總數量 {summany}");

            Console.WriteLine($"計算商品的平均數量 {summany / manyall.Count()}");

            Console.WriteLine($"找出哪一項商品最貴 {totalall.Max()}");

            Console.WriteLine($"找出哪一項商品最貴 {totalall.Min()}");

            var much3c = open.Where(x => x[4] == "3C").Select(x => x[3]);
            int sum3c = 0;
            foreach(var item in much3c)
            {
                sum3c= sum3c + int.Parse(item);
            }

            Console.WriteLine($"算產品類別為 3C 的商品總價 {sum3c}");

            var muchdrink = open.Where(x => x[4] == "飲料").Select(x => x[3]);
            var mucheat = open.Where(x => x[4] == "食品").Select(x => x[3]);

            int sumdrinkeat = 0;

            foreach(var item in mucheat)
            {
                sumdrinkeat+= int.Parse(item);
            }
            foreach(var item in muchdrink)
            {
                sumdrinkeat+= int.Parse(item);
            }

            Console.WriteLine($"計算產品類別為飲料及食品的商品總價 {sumdrinkeat}");

            var manycommditymore100 = open.Where(x => x[4] == "食品").Where(x => int.Parse(x[2]) > 100).Select(x => x[0]);

            Console.Write($"找出所有商品類別為食品，而且商品數量大於 100 的商品 ");

            foreach(var item in manycommditymore100) { Console.Write($" {item},"); }
            Console.WriteLine();

            var muchcommditymore1000 = open.Where(x=> int.Parse(x[3]) > 1000).Select(x => x[0]);

            Console.Write($"找出各個商品類別底下有哪些商品的價格是大於 1000 的商品 ");

            foreach (var item in muchcommditymore1000){  Console.Write($" {item},"); }
            Console.WriteLine();

            var averagecommdity = open.Where(x => int.Parse(x[3]) > 1000).Sum(x => Convert.ToInt64(x[3]) );

            Console.WriteLine($"呈上題，請計算該類別底下所有商品的均價格 {averagecommdity / muchcommditymore1000.Count()}");

            var sortbigtosmall = open.OrderByDescending(x => int.Parse(x[3])).Select(x => int.Parse(x[3]));

            Console.Write($"依照商品價格由高到低排序 ");

            foreach(var item in sortbigtosmall){    Console.Write($" {item},"); }
            Console.WriteLine();

            var sortsmalltobig = open.OrderBy(x => int.Parse(x[2])).Select(x => int.Parse(x[2]));

            Console.Write($"依照商品數量由低到高排序 ");

            foreach(var item in sortsmalltobig) { Console.Write($"{item},"); }
            Console.WriteLine();


            Console.WriteLine($"找出各商品類別底下，最貴的商品  ");

            
            
            var moreexpensive3c = open.Where(x => x[4] == "3C").Select(x => x[3]);
            var moreexpensivedrink = open.Where(x => x[4] == "飲料").Select(x => x[3]);
            var moreexpensiveeat = open.Where(x => x[4] == "食品").Select(x => x[3]);

            Console.WriteLine($"  3C {moreexpensive3c.Max()}");
            Console.WriteLine($"  飲料 {moreexpensivedrink.Max()}");
            Console.WriteLine($"  食品 {moreexpensiveeat.Max()}");

            Console.WriteLine($"找出各商品類別底下，最便宜的商品  ");

            Console.WriteLine($"  3C {moreexpensive3c.Min()}");
            Console.WriteLine($"  飲料 {moreexpensivedrink.Min()}");
            Console.WriteLine($"  食品 {moreexpensiveeat.Min()}");


            var morethan10000commdity = open.Where(x => int.Parse(x[3]) > 10000).Select(x => x[1]);

            Console.Write("找出價格小於等於 10000 的商品 ");

            foreach (var item in morethan10000commdity) { Console.Write(item.ToString() + ", "); }
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine($"製作一頁 4 筆總共 5 頁的分頁選擇器 ");
            

            

            var paging = File.ReadLines(@"C:\Users\a0966\source\repos\linq_hw\product.csv").Skip(1);

            //每页条数   
            const int pageSize = 4;
            //页码 0也就是第一条 
            int pageNum = 0;

            while (pageNum * pageSize < paging.Count())
            {
                //分页   
                var query = paging.Skip(pageNum * pageSize).Take(pageSize);
                Console.WriteLine();
                Console.WriteLine($"輸出第 {pageNum + 1} 的頁面");
                //输出每页内容   
                foreach (var q in query)
                {
                    Console.WriteLine(q);
                }
                pageNum++;
            }


            Console.ReadLine();
        }
    }
}
