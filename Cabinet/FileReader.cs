using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cabinet
{
    public class FileReader
    {
        static public string ReadTextFile(string pathToFile)
        {
            string line;
            //Обьект, который получает доступ к путям файлов
            StreamReader sr = new StreamReader(pathToFile);
            //В переменную line записываем то, что этот обьект прочитал
            line = sr.ReadToEnd();
            //Если файл пуст, выдаём exception
            if (line == null) throw new Exception("File is empty");
            return line;
        }
    }
}
