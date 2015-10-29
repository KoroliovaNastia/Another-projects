using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;


public  class AAtkin
{
    private readonly long _limit;
    public ulong[] IsPrimes;
  //  private string all="";

    public AAtkin(long limit)
    {
        _limit = limit;
        FindPrimes();
    }

   

    public void FindPrimes()
    {
      
        IsPrimes = new ulong[_limit + 1];
        const ulong S = 64;
        double sqrt = Math.Sqrt(_limit);
    
            var limit = (ulong)_limit;
            for (ulong x = 1; x <= sqrt; x++)
                for (ulong y = 1; y <= sqrt; y++)
                {
                    ulong x2 = x * x;
                    ulong y2 = y * y;
                    ulong n = 4 * x2 + y2;
                    if (n <= limit && (n % 12 == 1 || n % 12 == 5))
                    {
                  //IsPrimes[n] ^= true;
                       // IsPrimes[n / S] ^= (1u << (int)(n % S)) | ~IsPrimes[n / S];
                        IsPrimes[n / S] ^= (1u << (int)(n % S)) ;
              }

                    n -= x2;
                    if (n <= limit && n % 12 == 7)
                    {
                       // IsPrimes[n] ^= true;
                       // IsPrimes[n / S] ^= (1u << (int)(n % S)) | ~IsPrimes[n / S];
                        IsPrimes[n / S] ^= (1u << (int)(n % S));
                    }

                    n -= 2 * y2;
                    if (x > y && n <= limit && n % 12 == 11)
                    {
                        //IsPrimes[n] ^= true;
                        //IsPrimes[n / S] ^= (1u << (int)(n % S)) | ~IsPrimes[n / S];
                        IsPrimes[n / S] ^= (1u << (int)(n % S));
                    }
                }

            for (ulong n = 5; n <= sqrt; n += 2)
                if ((IsPrimes[n / S] & (1u << (int)(n % S))) == 0)
                {
                    ulong s = n * n;
                    for (ulong k = s; k <= limit; k += s)
                    {
                       // IsPrimes[k] ^= false;
                        IsPrimes[k / S] &= ~(1u << (int)(k % S));
                    }
                }
        //}
        //IsPrimes[2] = true;
        //IsPrimes[3] = true;
      //  System.IO.File.OpenWrite(@"C:\Users\WriteLines1.txt");
        FileStream str=new FileStream(@"C:\Users\WriteLines2.txt",FileMode.Append,FileAccess.Write);
        StreamWriter sw=new StreamWriter(str);
        for (ulong  i = 0; i < (ulong)IsPrimes.Length; i++)
      {
          for (int k = 0; k < 63; k++)
          {
              if((IsPrimes[i]&(1u<<k))!=0)

                 sw.WriteLine(i*S+(ulong)k);

          }
          //    if (IsPrimes[i])
      //    {
      //        int k = 10;
      //        int q = i;
      //        int r = 0;
      //        char[] rtn = new char[11];
      //        while (q >= 36)
      //        {

      //            r = q % 36;
      //            q = q / 36;
      //            if (r < 10)
      //            {
      //                rtn[k] = Convert.ToChar(r + 48);
      //                k--;
      //            }
      //            else
      //            {
      //                rtn[k] = Convert.ToChar(r + 55);
      //                k--;
      //            }
      //        }
      //        if (q < 10)
      //        {
      //            rtn[k] = Convert.ToChar(q + 48);
      //            k--;
      //        }
      //        else
      //        {
      //            rtn[k] = Convert.ToChar(q + 55);
      //            k--;
      //        }
      //        //rtn = rtn.Where(x => x != 0).ToArray();

      //        all = new string(rtn, k + 1, 10 - k);
      //        System.IO.File.AppendAllText(@"C:\Users\WriteLines1.txt", all);
          }
        sw.Flush();
       
      //}
     // Console.Write(all.IndexOf(found));
        
        Console.Write("All");
    }
    //public void Show(AAtkin[] a)
    //{
    //    for (int i = 0; i < a.Length; i++)
    //    {

    //        Console.Write("a[" + i + "]" + a[i]);

    //    }
    //}
}



namespace ConsoleApplication1
{
    class Program
    {
       

        static void Main()
        {
            long n = 100000000;//00000;//(ulong)System.Math.Pow(2,40);
            
            AAtkin number = new AAtkin(n);
            //string patch = @"C:\Users\WriteLines.txt";
            //string str = new StringReader(@"C:\Users\WriteLines.txt");
           // char[] s = new char[patch.Length];
            //Console.WriteLine(patch.Length);
           /// for (int i = 0; i < s.Length; i++)
           // {
            //FileStream reader = new FileStream("C:\\Users\\WriteLines.txt", FileMode.Open, FileAccess.Read);
            // byte[] s = new byte[100];
            //reader.Read(s, 0, s.Length);
           // StringBuilder str = StringBuilder(
           //     .ToString(s);
           // string w=s.ToString();
           //Console.WriteLine(str.IndexOf("IPARTY"));
            //}
            Console.ReadKey();






          
        }
    }
}
