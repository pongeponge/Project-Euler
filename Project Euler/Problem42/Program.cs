using System;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace Problem42
{
    class Program
    {
        static void Main(string[] args)
        {
            P42 p = new P42();
            Debug.WriteLine(p.Solve());
        }
    }

    class P42
    {
        string[] words;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public P42()
        {

        }

        /// <summary>
        /// 解く
        /// </summary>
        /// <returns></returns>
        public int Solve()
        {
            int count = 0;

            this.GetWords();

            foreach (string word in this.words)
            {
                if (this.IsTriangleWord(word) == true)
                {
                    count++;
                }
            }

            return count;
        }

        /// <summary>
        /// テキストを読み込む
        /// </summary>
        /// <returns>読み込んだ文字列</returns>
        private string ReadText()
        {
            string path = @"../../words.txt";
            string str = String.Empty;

            using (StreamReader sr = new StreamReader(new FileStream(path, FileMode.Open)))
            {
                str = sr.ReadToEnd();
            }

            return str;
        }

        /// <summary>
        /// クオーテーションを削除する
        /// </summary>
        /// <param name="str">文字列</param>
        /// <returns>クオーテーションを削除した文字列</returns>
        private string RemoveQuotation(string str)
        {
            StringBuilder sb = new StringBuilder();

            foreach (char ch in str)
            {
                if (ch != '"') sb.Append(ch);
            }

            return sb.ToString();
        }

        /// <summary>
        /// 単語列を取得する
        /// </summary>
        private void GetWords()
        {
            string line = this.ReadText();
            line = this.RemoveQuotation(line);

            this.words = line.Split(',');
        }

        /// <summary>
        /// 単語の値を求める
        /// </summary>
        /// <param name="word">値を求める単語</param>
        /// <returns>単語の値</returns>
        private int CalcWordValue(string word)
        {
            int val = 0;
            int baseChar = 'A' - 1;

            foreach (char c in word)
            {
                val += c - baseChar;
            }

            return val;
        }

        /// <summary>
        /// 三角数か？
        /// </summary>
        /// <param name="val">検査する値</param>
        /// <returns></returns>
        private bool IsTriangleNumber(int val)
        {
            val = 2 * val;

            int limit = (int)Math.Sqrt(val);

            for (int n = limit; n >= 1; n--)
            {
                int e = n * (n + 1);

                if (e < val) return false;
                else if (e == val) return true;

            }

            return false;
        }

        /// <summary>
        /// 三角単語か？
        /// </summary>
        /// <param name="word">検査する単語</param>
        /// <returns></returns>
        private bool IsTriangleWord(string word)
        {
            int val = this.CalcWordValue(word);

            return this.IsTriangleNumber(val);
        }
    }
}
