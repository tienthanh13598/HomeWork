using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CSharp_FindPrime_VuTienThanh
{
    class Program
    {
        public static Task<bool> IsPrime(int number)
        {
            return Task.Run(() => {
            if (number <= 1) return false;
            if (number == 2) return true;
            if (number % 2 == 0) return false;

            var boundary = (int)Math.Floor(Math.Sqrt(number));
                
            for (int i = 3; i <= boundary; i += 2)
                if (number % i == 0)
                    return false;
            
            return true;
            });     
        }

        public static async Task<List<int>> AddPrimeNumbers()
        {
            List<int> list = new List<int>();
            
            for (int i=1; i<=100; i++){
                if (await IsPrime(i)) {
                    list.Add(i);
                }
            }
            return list;
        }
        public static void ShowList(List<int> list) {
            foreach (int i in list) {
                Console.WriteLine(i);
            }
        }
        static void Main(string[] args)
        {
            ShowList(list);
        }
    }
}
