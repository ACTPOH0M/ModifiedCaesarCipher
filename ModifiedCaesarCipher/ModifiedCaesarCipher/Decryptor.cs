using System;
using System.Diagnostics;
using System.Text;

namespace ModifiedCaesarCipher
{
    internal class Decryptor
    {
        AnalysisWindow analysisWindow = new AnalysisWindow();

        Stopwatch stopwatch = new Stopwatch();
        private int FirstKey, SecondKey;
        private string InitialAlphabet = "АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯабвгдеёжзийклмнопрстуфхцчшщъыьэюя 1234567890!@#$%^&*()_+=№;%:?-{}[]";
        private string[] PrefixKit = { "Выц", "ДнП", "!в%", "Ф9*", "СУ_", "ЮьЕ", "_П;", "ЯЦ&" };
        private string FinalAlphabet;
        private string MessageForDecrypt;

        public string StartDecrypt(string InputText)
        {
            analysisWindow.IntermediateResult.Text += "\nНовое Дешифрование\n";
            analysisWindow.Hide();
            analysisWindow.Show();
            stopwatch.Start();
            CreateKeys(InputText);
            if (IsKeysValid())
                MixAlphabet();
            return Dencrypt(MessageForDecrypt);
        }

        private string Dencrypt(string TextToDencrypt)
        { 
            //дешифрование сообщения
            analysisWindow.IntermediateResult.Text += "\nШифрованный текст: "+TextToDencrypt+"\n";
            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 0; i < TextToDencrypt.Length; i++)
                for (int k = 0; k < FinalAlphabet.Length; k++)
                    if (TextToDencrypt[i] == FinalAlphabet[k])
                        stringBuilder.Append(InitialAlphabet[k]);
            analysisWindow.IntermediateResult.Text += "\nТекст после расшифровки: "+stringBuilder.ToString()+"\n";
            stopwatch.Stop();
            analysisWindow.IntermediateResult.Text += "\nВремя затраченное на дешифрование информации: " + stopwatch.Elapsed.ToString()+"\n";
            return stringBuilder.ToString();
        }

        public void CreateKeys(string TextWithKeys)
        {
            //получаем ключи из сообщения отделяя их по префиксам
            analysisWindow.IntermediateResult.Text += "\nНачало получения ключей из сообщения...\n";
            string[] str=new string[2],newStr = new string[2], keys = new string[2]; 
            for (int i = 0; i < PrefixKit.Length; i++)
            {
                str = TextWithKeys.Split(PrefixKit[i]);
                if(str.Length >= 2)
                    if (!String.IsNullOrEmpty(str[0]) && !String.IsNullOrEmpty(str[1]))
                        break;
            }

            for (int k = 0; k < PrefixKit.Length; k++)
            {
                for (int i = 0; i < 2; i++)
                {
                    newStr = str[i].Split(PrefixKit[k]);
                    if(newStr.Length >= 2) 
                        if (newStr[0] != null && newStr[1] != null)
                            break;
                }
                if (newStr.Length >= 2)
                    if (newStr[0] != null && newStr[1] != null)
                        break;
            }
            
            for (int i = 0; i < 2; i++)
            {
                keys = newStr[i].Split("|");
                if(keys.Length >= 2)
                    if (keys[0] != null && keys[1]!=null)
                        break;
            }

            FirstKey = Convert.ToInt32(keys[0]);
            SecondKey = Convert.ToInt32(keys[1]);

            string str1 = TextWithKeys;
            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 0; i <PrefixKit.Length; i++)
                str1 = str1.Replace(PrefixKit[i],"");

            analysisWindow.IntermediateResult.Text += "\n Ключи: Первый ключ " + FirstKey+" Второй ключ "+SecondKey + "\n";
            stringBuilder.Append(str1.Replace(FirstKey + "|" + SecondKey, ""));
            MessageForDecrypt = stringBuilder.ToString();
        }
        private bool IsKeysValid()
        {
            //проверяем чтобы ключи не были равны нулю
            if (FirstKey == 0)
                FirstKey += 1;
            if (SecondKey == 0)
                SecondKey += 1;
            return true;
        }

        private void MixAlphabet()
        {
            //создаем новый алфавит
            analysisWindow.IntermediateResult.Text += "\nНачало получения алфавита для расшифровки...\n";
            StringBuilder stringBuilder = new StringBuilder();
            string mas = InitialAlphabet;
            for (int i = 0; i < InitialAlphabet.Length; i++)
            {
                int k = MathNewPositionOfLetter(i, mas.Length);
                stringBuilder.Append(mas[k]);
                mas = mas.Remove(k, 1);
            }
            analysisWindow.IntermediateResult.Text += "\n Алфивит для расшифровки "+stringBuilder.ToString() + "\n";
            FinalAlphabet = stringBuilder.ToString();
        }

        private int MathNewPositionOfLetter(int IndexOfLetter, int CountLetters)
        {//рассчитываем новый индекс
            return (((FirstKey * IndexOfLetter + (SecondKey + IndexOfLetter) * FirstKey)) % CountLetters);
        }
    }
}
