using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nahogdenie_Min__Goda___iz____tablici
{
    class Program
    {


        //------------------------------------ struct    
        public struct programm
        {
            public string famil, name, oth, pol;
            public int year, month, day;
        }
        //------------------------------------------------ struct




        static void Main(string[] args)
        {
            // -------- Распределил элименты таблици по матрице ------------

            string str = File.ReadAllText(@"C:\Users\днс\Desktop\text.txt");

            char r = '\n';

            string count = "";


            for (int i = 0; str[i] != r; i++)
            {
                count += str[i];
            }

            string[] stolb = count.Split(new Char[] { '\t' });

            string[] matrix = str.Split(new Char[] { '\n', '\t' });

            string[] strok = str.Split(new Char[] { '\n' });
            string[,] arr = new string[strok.Length, stolb.Length];

            int c = 0;
            for (int i = 0; i < strok.Length; i++)
            {
                for (int j = 0; j < stolb.Length; j++)
                {
                    arr[i, j] = matrix[c];
                    c++;
                }
            }

            for (int i = 0; i < strok.Length; i++)
            {


                for (int j = 0; j < stolb.Length; j++)
                {
                    Console.Write(arr[i, j]);

                }
                Console.WriteLine();
            }

            //---------Разобрал dd.mm.yyyy на составные части ------------------

            int[] got = new int[strok.Length];
            string k = "";
            for (int i = 1; i < strok.Length; i++)
            {
                k = "";
                for (int j = 6; j < 10; j++)
                {
                    string h = arr[i, 3];
                    k += h[j];
                }
                got[i] = Convert.ToInt32(k);
            }

            int[] mes = new int[strok.Length];
            k = "";
            for (int i = 1; i < strok.Length; i++)
            {
                k = "";
                for (int j = 3; j < 5; j++)
                {
                    string h = arr[i, 3];
                    k += h[j];
                }
                mes[i] = Convert.ToInt32(k);
            }

            int[] den = new int[strok.Length];
            k = "";
            for (int i = 1; i < strok.Length; i++)
            {
                k = "";
                for (int j = 0; j < 2; j++)
                {
                    string h = arr[i, 3];
                    k += h[j];
                }
                den[i] = Convert.ToInt32(k);
            }

            //------------------------------ Использовал структуру для инециализации элтментов матрици ----------------- 


            programm[] men = new programm[strok.Length];

            for (int i = 0; i < strok.Length; i++)
            {
                men[i].famil = arr[i, 0];
            }
            for (int i = 0; i < strok.Length; i++)
            {
                men[i].name = arr[i, 1];
            }
            for (int i = 0; i < strok.Length; i++)
            {
                men[i].oth = arr[i, 2];
            }
            for (int i = 0; i < strok.Length; i++)
            {
                men[i].pol = arr[i, 4];
            }
            for (int i = 1; i < strok.Length; i++)
            {
                men[i].year = got[i];
            }
            for (int i = 1; i < strok.Length; i++)
            {
                men[i].month = mes[i];
            }
            for (int i = 1; i < strok.Length; i++)
            {
                men[i].day = den[i];
            }

            ///---------------------------ПОИСК МИН ЗНАЧЕНИЯ ----------------------------------------------------

            int otvet = 0;
            
            //--------- год---------

            string z = "";
            int min = 99999999;
            for (int i = 1; i < strok.Length; i++)
            {
                if (men[i].year == min)
                {
                    z = z + i;
                }
                if (men[i].year < min)
                {
                    min = men[i].year;
                    z = "";
                    z = Convert.ToString(i);
                }

            }

            //-----------Месяц------------


            min = 99999999;
            string zz = "";
          
            for (int i = 0; i < z.Length; i++)
            {
                var t = Convert.ToString(z[i]);
                int tt = Convert.ToInt32(t);
                if (z.Length == 1)
                {
                    Console.WriteLine(men[tt].famil + " " + men[tt].name + " " + men[tt].oth + " " + men[tt].day + "." + men[tt].month + "." + men[tt].year + " " + men[tt].pol);
                    break;
                }
               
                if (men[tt].month == min)
                {
                    zz = zz + tt;
                }

                if (men[tt].month < min)
                {
                    min = men[tt].month;
                    zz = Convert.ToString(tt);
                }

            }


            //-------День---------

            min = 99999999;
            string zzz = "";
            for (int i = 0; i < Convert.ToString(zz).Length; i++)
            {
                var t = Convert.ToString(zz[i]);
                int tt = Convert.ToInt32(t);

                if (zz.Length == 1)
                {
                    Console.WriteLine(strok[Convert.ToInt32(z)]);
                    //Console.WriteLine(men[tt].famil + " " + men[tt].name + " " + men[tt].oth + " " + men[tt].day + "." + men[tt].month + "." + men[tt].year + " " + men[tt].pol);
                    break;
                }
               

                if (men[tt].day == min)
                {
                    zzz += zz[i];
                }
                if (men[tt].day < min)
                {
                    min = men[tt].day;
                    zzz = Convert.ToString(tt); 
                }

            }

            if (zzz.Length == 1)
            {
                    otvet = Convert.ToInt32(zzz);
                Console.WriteLine(strok[otvet]);
                //Console.WriteLine(men[otvet].famil + " " + men[otvet].name + " " + men[otvet].oth + " " + men[otvet].day + "." + men[otvet].month + "." + men[otvet].year + " " + men[otvet].pol);
            }
            else
            {
                for (int i = 0; i < zzz.Length; i++)
                {
                    var t = Convert.ToString(zzz[i]);
                    int tt = Convert.ToInt32(t);
                    otvet = tt;
                    Console.WriteLine(strok[tt]);
                    //Console.WriteLine(men[otvet].famil + " " + men[otvet].name + " " + men[otvet].oth + " " + men[otvet].day + "." + men[otvet].month + "." + men[otvet].year + " " + men[otvet].pol);
                }
            }
            Console.ReadKey();
        }
    }
}