using System.Diagnostics;
bool Mainloop = true;
Random rnd =new Random();
ConsoleKeyInfo button;
string path = "E:\\TAKP.txt";
string[] FileArray;

while (Mainloop == true)
{
    try
    {
        int count = 0;
        int m, n;
        int ASD =0;
        bool innerloop = true;
        while (innerloop)
        {
            Console.WriteLine("Оберiть форму вводу: 1 якщо ввiд вручну, 2 якщо рандомнi значення, 3 якщо з файлу");
            ASD = Convert.ToInt16(Console.ReadLine());
            if (ASD == 1)
            {
                innerloop = false;
            }
            else if (ASD == 2)
            {
                innerloop = false;
            }
            else if (ASD == 3)
            {
                Console.WriteLine("Вкажiть шлях до файлу, врахуйте щоб мiж папками, дискми i файлами в шляху стояв \\\\ ");
                path = Console.ReadLine();
                if (Directory.Exists(path))
                {
                    throw new Exception("Данного шляху не iснує");
                }
                innerloop = false;
            }
        }
        Console.WriteLine("Введiть розмiр \"n\"");
        n = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Введiть розмiр \"m\"");
        m = Convert.ToInt32(Console.ReadLine());
        int[,] Array = new int[n, m];
        switch (ASD)
        {
            case 1:
                Console.WriteLine("Заповнiть масив");
                for (int i = 0; i < Array.GetLength(0); i++)
                {
                    for (int k = 0; k < Array.GetLength(1); k++)
                    {
                        Array[i, k] = Convert.ToInt32(Console.ReadLine());
                       
                    }
                }
                
                break;
            case 2 :
                for (int i = 0; i < Array.GetLength(0); i++)
                {
                    for (int k = 0; k < Array.GetLength(1); k++)
                    {
                        Array[i, k] = rnd.Next(-5,5);
                    }
                }
                break;
            case 3:
                StreamReader File = new StreamReader(path);
                FileArray = File.ReadLine().Trim().Replace("  "," ").Split(' ');
                File.Close();
                int j = 0;
                if (m*n== FileArray.Length)
                {
                    for (int k = 0; k < Array.GetLength(0); k++)
                    {
                        for (int i = 0; i < Array.GetLength(1); i++)
                        {
                            Array[k, i] = Convert.ToInt32(FileArray[j]);
                            j++;
                        }
                    }
                   
                }
                else
                {
                    throw new Exception("Можливо невірно заповнений файл");
                    
                }
               
                break;
        }
        if (ASD == 1 || ASD == 2 || ASD == 3)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            for (int i = 0; i < Array.GetLength(0); i++)
            {
                for (int k = 0; k < Array.GetLength(1); k++)
                {
                    if(Array[i, k] == 0)
                    {
                        count++;
                    }          
                }
            }
            stopwatch.Stop();
            TimeSpan elapsedTime = stopwatch.Elapsed;
            double elapsedMilliseconds = elapsedTime.TotalMilliseconds;
            //Console.WriteLine("Масив:");
            //for (int i = 0; i < Array.GetLength(0); i++)
            //{
            //    for (int k = 0; k < Array.GetLength(1); k++)
            //    {
            //        Console.Write(Array[i, k] + "\t");
            //    }
            //    Console.WriteLine();
            //}
            Console.WriteLine("Кількіть нулів:"+count);
            Console.WriteLine(elapsedMilliseconds);
            Mainloop = false;
        }


    }
    catch (Exception e)
    {
        Console.WriteLine(e.Message);
        Console.WriteLine("Натисніть \"Enter\"щоб почати ще раз, або будь-яку iншу клавішу щоб завершити");
        button = Console.ReadKey();
        switch (button.Key)
        {
            case ConsoleKey.Enter:

                break;
            default:
                Mainloop = false;
                break;
        }
        Console.Clear();
    }
}
