using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Text;
using System.Collections;

using System.Linq;

/// <summary>
/// string 型の拡張メソッドを管理するクラス
/// </summary>
public static partial class StringExtensions
{
    /// <summary>
    /// 文字列が指定されたいずれかの文字列と等しいかどうかを返します
    /// </summary>
    public static bool IsAny(this string self, params string[] values)
    {
        return values.Any(c => c == self);
    }
}
namespace ChaPalle
{
    static class Program
    {
        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        [STAThread]
        static void Main()
        {
            dataset data = new dataset();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm(ref data));
        }
    }

    public class dataset
    {
        public Dictionary<string, string> m_defaultSkillList = new Dictionary<string, string>();
        public Dictionary<string, string> m_uniqueSkillList = new Dictionary<string, string>();
        public Dictionary<string, string> m_fightSkillList = new Dictionary<string, string>();
        public int m_useDiceBotFlg = 0;
        public Dictionary<string, string> m_abilityValueList = new Dictionary<string, string>()
        { { "STR", ""}, { "CON", ""}, { "POW", ""}, { "DEX", ""}, { "APP", ""}, { "SIZ", ""}, { "INT", ""}, { "EDU", ""}, { "HP", ""}, { "MP", ""} };
        public Dictionary<string, string> m_sarcherInfoList = new Dictionary<string, string>()
        { { "キャラクター名", ""}, { "HP", ""}, { "MP", ""}, { "SAN", ""},{ "ダメージボーナス", ""}};

        public void charaBankTxtRead()
        {
            string line = "";
            var al = new List<string>();
            OpenFileDialog ofDialog = new OpenFileDialog();

            // デフォルトのフォルダを指定する
            ofDialog.InitialDirectory = @"C:";

            //ダイアログのタイトルを指定する
            ofDialog.Title = "キャラクター保管所txtファイル読み込み";

            //ダイアログを表示する
            if (ofDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    using (StreamReader sr = new StreamReader(
                        ofDialog.FileName, Encoding.GetEncoding("Shift_JIS")))
                    {
                        while ((line = sr.ReadLine()) != null)
                        {
                            if (line == "") continue;
                            if (line == "■所持品■") break;
                            al.Add(line);
                        }
                    }

                    char[] del = { '-', '-', '《', '》', '：', '/' , ' ', '％','　', '●' };
                    string importFlg = "base";
                    foreach (string charaLine in al)
                    {
                        string[] arr = charaLine.Split(del, StringSplitOptions.RemoveEmptyEntries);
                        if (arr[0].IsAny("職業","年齢","出身","髪の色","身長", "体重", "STR", "作成時", "成長等", "他修正", "習得", "名称")) continue;

                        switch (importFlg)
                        {
                            case "base":
                                //能力値のインポート

                                if (arr[0] == "=合計=")
                                {
                                    m_abilityValueList["STR"] = arr[1];
                                    m_abilityValueList["CON"] = arr[2];
                                    m_abilityValueList["POW"] = arr[3];
                                    m_abilityValueList["DEX"] = arr[4];
                                    m_abilityValueList["APP"] = arr[5];
                                    m_abilityValueList["SIZ"] = arr[6];
                                    m_abilityValueList["INT"] = arr[7];
                                    m_abilityValueList["EDU"] = arr[8];
                                    m_abilityValueList["HP"] = arr[9];
                                    m_abilityValueList["MP"] = arr[10];
                                }

                                else
                                {
                                    //探索者情報のインポート
                                    try
                                    {
                                        m_sarcherInfoList[arr[0]] = arr[1];
                                    }
                                    catch (Exception ee) { }
                                }

                                break;


                            case "fightSkill":
                                //探索者情報のインポート
                                for (int i = 0; i <= arr.Length; i += 2)
                                {
                                    try
                                    {
                                        if (m_defaultSkillList.ContainsKey(arr[i]))
                                        {
                                            m_fightSkillList[arr[i]] = arr[i + 1];
                                            if (m_defaultSkillList[arr[i]] != arr[i + 1])
                                            { m_uniqueSkillList[arr[i]] = arr[i + 1]; }
                                        }else
                                        {
                                            { m_uniqueSkillList[arr[i]] = arr[i + 1]; }
                                        }
                                    }
                                    catch (Exception ee) { }
                                }
                                break;

                            case "actSkill":
                            case "sarchSkill":
                            case "negotiationSkill":
                            case "wisdomSkill":
                                //探索者情報のインポート

                                for (int i = 0; i <= arr.Length; i += 2)
                                {
                                    try
                                    {
                                        if (m_defaultSkillList.ContainsKey(arr[i]))
                                        {
                                            if (m_defaultSkillList[arr[i]] != arr[i + 1])
                                            { m_uniqueSkillList[arr[i]] = arr[i + 1]; }
                                        }
                                        else
                                        {
                                            { m_uniqueSkillList[arr[i]] = arr[i + 1]; }

                                        }
                                    }
                                    catch (Exception ee) { }
                                }
                                break;

                            case "fight":
                                if(arr[0] == "ダメージボーナス")
                                {
                                    m_abilityValueList[arr[0]] = arr[1];
                                }
                                break;
                        }

                        switch (arr[0])
                        {
                            //戦闘系技能のインポート
                            case "■技能■":
                                importFlg = "fightSkill";
                                break;

                            case "探索系技能":
                                importFlg = "sarchSkill";
                                break;

                            case "行動系技能":
                                importFlg = "actSkill";
                                break;

                            case "交渉系技能":
                                importFlg = "negotiationSkill";
                                break;

                            case "知識系技能":
                                importFlg = "wisdomSkill";
                                break;

                            case "■戦闘■":
                                importFlg = "fight";
                                break;
                        }
                    }
                }
                catch (Exception ee)
                {
                    Console.WriteLine(ee.Message);
                }
            }
            else
            {
                Console.WriteLine("キャンセルされました");
            }

            // オブジェクトを破棄する
            ofDialog.Dispose();
        }
    }
}
