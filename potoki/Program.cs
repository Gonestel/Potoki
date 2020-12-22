using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.IO;
using System;

namespace potoki
{
    class Program
    {
        static void Main(string[] args)
        {
        Start:
            Console.WriteLine("Введите путь к файлу");
            string path = Console.ReadLine();
            FileInfo fileInf = new FileInfo(path);

            if (fileInf.Exists)
            {
                Console.WriteLine("Имя файла: {0}", fileInf.Name);
                Console.WriteLine("Время создания: {0}", fileInf.CreationTime);
                Console.WriteLine("Размер: {0}", fileInf.Length);

                Console.WriteLine("Введите число, чтобы: 1. Удалить файл. 2. Копировать файл по выбранному пути. 3. Переместить файл по выбранному пути");
                int v = Convert.ToInt32(Console.ReadLine());

                if (v == 1)
                {
                    fileInf.Delete();
                    Console.WriteLine("Файл удалён");
                }
                else
                {
                    if (v == 2)
                    {
                        Console.WriteLine("Введите путь");
                        string newpath = Console.ReadLine();
                        fileInf.CopyTo(newpath, true);
                        Console.WriteLine("Файл скопирован");
                    }
                    else
                    {
                        if (v == 3)
                        {
                            Console.WriteLine("Введите путь");
                            string newpath = Console.ReadLine();
                            fileInf.MoveTo(newpath);
                            Console.WriteLine("Файл перемещён");
                        }
                    }
                }
            }
            else { Console.WriteLine("Файла {0} не существует", path); }

            string path2 = @"E:\text.txt";
            Console.WriteLine("По пути {0} создан файл.", path2);
            Console.WriteLine("Введите текст, который хотите ввести в этот файл");
            string text = Console.ReadLine();
            FileStream file = new FileStream(path2, FileMode.Append, FileAccess.Write);
            StreamWriter writer = new StreamWriter(file);
            writer.Write(text);
            writer.Close();

            StreamReader reader = new StreamReader(path2);
            Console.WriteLine("Запись в файле: {0}", reader.ReadToEnd());
            reader.Close();

            
            
            

            string path3 = @"E:\text2.txt";
            Console.WriteLine("По пути {0} создан файл.", path3);
            using (FileStream file2 = new FileStream(path3, FileMode.OpenOrCreate))

            {

                string text2 = " Четыре черненьких чумазеньких чертенка. Чертили черными чернилами чертеж. Чрезвычайно четко! ";
                Console.WriteLine("Введите приписку, которую хотите сделать в начале текста:");
                string Text1 = Console.ReadLine();
                file2.Seek(0, SeekOrigin.Begin); 
                byte[] input = Encoding.Default.GetBytes(text2);
                file2.Write(input, 0, input.Length);
                file2.Seek(0, SeekOrigin.Begin);
                input = Encoding.Default.GetBytes(Text1);
                file2.Write(input, 0, input.Length);

                Console.WriteLine("Введите приписку, которую хотите сделать в середине текста:");
                string Text2 = Console.ReadLine();
                file2.Seek(+75, SeekOrigin.Begin);
                input = Encoding.Default.GetBytes(Text2);
                file2.Write(input, 0, input.Length);
                file2.Seek(0, SeekOrigin.Begin);


                Console.WriteLine("Введите приписку, которую хотите сделать в конце текста:");
                string Text3 = Console.ReadLine();
                file2.Seek(0, SeekOrigin.End);
                input = Encoding.Default.GetBytes(Text3);
                file2.Write(input, 0, input.Length);
                file2.Seek(0, SeekOrigin.Begin);

                byte[] output = new byte[file2.Length];
                file2.Read(output, 0, output.Length);



                string textFromFile = Encoding.Default.GetString(output);
                Console.WriteLine("Запись в файле: {0}", textFromFile);


            }
        }
    }
}