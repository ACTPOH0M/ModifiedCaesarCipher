using System;
using System.Diagnostics;
using System.Text;

namespace ModifiedCaesarCipher
{

    internal class Encryptor
    {
        AnalysisWindow analysisWindow = new AnalysisWindow();
        Stopwatch stopwatch = new Stopwatch();
        private int FirstKey,SecondKey;
        private string InitialAlphabet = "АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯабвгдеёжзийклмнопрстуфхцчшщъыьэюя 1234567890!@#$%^&*()_+=№;%:?-{}[]";
        private string[] PrefixKit = {"Выц","ДнП","!в%","Ф9*","СУ_","ЮьЕ","_П;","ЯЦ&"};
        private string FinalAlphabet;
        public string startEncryptor(string TimeZone,string InputText)
        {
            //метод начала шифрования
            analysisWindow.IntermediateResult.Text += "\nНовое Шифрование\n";
            analysisWindow.Hide();
            analysisWindow.Show();
            stopwatch.Start();
            CreateKeys(TakeTimeZone(TimeZone));
            if (IsKeysValid())
                MixAlphabet();
            return AddKeysToMessage(Encrypt(InputText));
        }

        private string Encrypt(string TextToEncrypt)
        {
            //Шифруем сообщение
            analysisWindow.IntermediateResult.Text += "\nНачало шифрования, входная строка: "+TextToEncrypt + "\n";
            StringBuilder stringBuilder= new StringBuilder();
            for (int  i = 0;  i < TextToEncrypt.Length;  i++)
                for (int k = 0; k < InitialAlphabet.Length; k++)
                    if (TextToEncrypt[i] == InitialAlphabet[k])
                        stringBuilder.Append(FinalAlphabet[k]);
            analysisWindow.IntermediateResult.Text += "\nСтрока после шифрования "+stringBuilder.ToString() + "\n";
            return stringBuilder.ToString();
        }
        private string AddKeysToMessage(string TextForAddKeys)
        {
            //добавляем ключи в сообщение
            analysisWindow.IntermediateResult.Text += "\nДобавлении ключей в строку...\n";
            Random rnd = new Random();
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append(TextForAddKeys);

            string str = (PrefixKit[rnd.Next(0, PrefixKit.Length-1)]) + FirstKey + "|" + SecondKey+ (PrefixKit[rnd.Next(0, PrefixKit.Length - 1)]);
            stringBuilder.Insert(rnd.Next(0,stringBuilder.Length-1),str);

            analysisWindow.IntermediateResult.Text += "\nрезультат добавления ключей в строку "+stringBuilder.ToString()+"\n";
            stopwatch.Stop();
            analysisWindow.IntermediateResult.Text += "\nВремя затраченное на зашифрование информации: " + stopwatch.Elapsed.ToString()+"\n";
            return stringBuilder.ToString();
        }
        private void MixAlphabet()
        {
            //создаем новый алфавит
            analysisWindow.IntermediateResult.Text += "\nНачало создание нового алфавита...\n";
            StringBuilder stringBuilder = new StringBuilder();
            string mas = InitialAlphabet;
            for (int i = 0; i < InitialAlphabet.Length; i++)
            {
                int k = MathNewPositionOfLetter(i, mas.Length);
                stringBuilder.Append(mas[k]);
                mas = mas.Remove(k, 1);
            }
            analysisWindow.IntermediateResult.Text += "\nНовый алфавит: " + stringBuilder.ToString() + "\n";
            FinalAlphabet = stringBuilder.ToString();
        }
        private void CreateKeys(DateTime time)
        {
            //создание ключей, ьерем день в году и час
            FirstKey = time.Hour;
            SecondKey = time.DayOfYear;
            analysisWindow.IntermediateResult.Text += "Ключ 1: " +FirstKey+" Ключ 2: " +SecondKey + "\n";
        }
        private DateTime TakeTimeZone(string TimeZone)
        {
            //берем часовой пояс
            TimeZoneInfo time = TimeZoneInfo.FindSystemTimeZoneById(TimeZone);
            DateTime dateTime_Indian = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, time);
            return dateTime_Indian;
        }
        private bool IsKeysValid()
        { 
            //проверяем чтобы ключи не были равны нулю
            if (FirstKey == 0)
            {
                analysisWindow.IntermediateResult.Text += "\nПервый ключ равен 0, добавление 1\n";
                FirstKey += 1;
            }
            if (SecondKey == 0)
            {
                analysisWindow.IntermediateResult.Text += "\nВторой ключ равен 0, добавление 1\n";
                SecondKey += 1;
            }
            return true;
        }

        private int MathNewPositionOfLetter(int IndexOfLetter,int CountLetters)
        {
            //рассчитываем новый индекс
            return (((FirstKey * IndexOfLetter + (SecondKey + IndexOfLetter) * FirstKey)) % CountLetters);
        }
    }
}
