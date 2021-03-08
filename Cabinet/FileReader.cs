using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cabinet
{
    class FileReader
    {
        //К сожалению, даный метод не может прочитать больше одной первой строчки.
        static public string ReadTextFile(string pathToFile)
        {
            string line;
            //Обьект, который получает доступ к путям файлов
            StreamReader sr = new StreamReader(pathToFile);
            //В переменную line записываем то, что этот обьект прочитал
            line = sr.ReadLine();
            //Если файл пуст, выдаём exception
            if (line == null) throw new Exception("File is empty");
            return line;
        }
    }
}
