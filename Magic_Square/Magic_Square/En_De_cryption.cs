using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magic_Square
{
    class En_De_cryption
    {
        /// <summary>
        ///     Осуществляет кодирование магическим квадратом.
        /// </summary>
        /// <param name="source">Открытый текст.</param>
        /// <param name="key">
        ///     Массив - магический квадрат, записанный в виде одной строки (последовательное чтение слева-направо,
        ///     сверху-вниз).
        /// </param>
        /// <returns>Строка - зашифрованное сообщение.</returns>
        public static string EnDe_code(string source, int[] key)
        {
            char[] arrSource = source.ToCharArray();
            char[] newArr = new char[arrSource.Length];

            for (int i = 0; i < key.Length; i++)
            {
                newArr[i] = arrSource[key[i] - 1];
            }
            return String.Join("", newArr);
        }

        public static bool MagicSquare(int[] key)
        {
            int n = 1;
            while (n * n < key.Length) n++;
            if (n * n != key.Length) return false;
            int magicConst = n * (n * n + 1) / 2;
            int mainDiagSum = 0;
            int secDiagSum = 0;
            for (int i = 0; i < n; i++)
            {
                int currColumnSum = 0;
                int currRowSum = 0;
                mainDiagSum += key[i * n + i];
                secDiagSum += key[i * n + n - i - 1];
                for (int j = 0; j < n; j++)
                {
                    currRowSum += key[i * n + j];
                    currColumnSum += key[i + j * n];
                }

                if (currRowSum != magicConst || currColumnSum != magicConst)
                    return false;
            }

            if (mainDiagSum != magicConst || secDiagSum != magicConst)
                return false;
            return true;
        }
    }
}
