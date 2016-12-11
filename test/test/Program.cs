using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test
{
    class Program
    {
        static void Main(string[] args)
        {
            tes t = new tes();
        }
    }

    class tes
    {
        //デリゲート型を指定
        //デリゲート型芭蕉
        private delegate String basyou(String a, String b);
        //デリゲート型動物
        private delegate void doubutu(String s);

        public tes()
        {
            //例1
            basyou b = gyaku;
            Debug.WriteLine("芭蕉曰く「" + b("砕けない", "ダイヤモンドは") + "」");

            //例2
            List<basyou> k = new List<basyou>();

            k.Add(futuu);
            k.Add(gyaku);

            foreach (basyou i in k)
            {
                Debug.WriteLine("芭蕉曰く「" + i("君たちは", "腐ったミカンだ") + "」");
            }

            //例3(匿名型)
            basyou n = delegate (string a1, string a2) { return a1.Replace("神","ネコ") + a2; };
            Debug.WriteLine(n("神と", "和解せよ"));

            //例4(ラムダ式)
            basyou op = (c1, c2) => c2.Replace("か", "");
            Debug.WriteLine(op("力が", "欲しいか"));

            //例5(デリゲートの連結) ActionかFuncじゃないと無理？(未確認)
            doubutu pome, ame, nanika;
            pome = inu;
            ame = neko;
            nanika = pome + ame;
            nanika("ティラノサウルス");
        }

        //結合
        private String futuu(String a, String b)
        {
            return a + b;
        }

        //前後を逆にして結合
        private String gyaku(String a, String b)
        {
            return b + a;
        }

        //これは犬です
        private void inu(string s)
        {
            Debug.WriteLine(s + "は犬");
        }

        //疑いようもなく猫です
        private void neko(string s)
        {
            Debug.WriteLine(s + "は猫");
        }

    }
}
