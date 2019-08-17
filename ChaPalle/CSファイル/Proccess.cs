using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MathNet.Numerics.Random;

namespace PalletMaster
{
    class Proccess
    {
        //MersenneTwister: Mersenne Twister 19937 generator
        readonly System.Random random = new MersenneTwister();　

        public Proccess()
        {

        }

        //csvファイルを読み込む
        public static Dictionary<string, string> ReadCSVToDictionary(string filePath)
        {

            var list = new Dictionary<string, string>();
            try
            {
                StreamReader reader = new StreamReader(filePath, Encoding.GetEncoding("Shift_JIS"));
                //StreamReader reader = new StreamReader(filePath);
                while (reader.Peek() >= 0)
                {
                    string[] cols = reader.ReadLine().Split(',');
                    list.Add(cols[0], cols[1]);
                }
                return list;
            }
            catch (FileNotFoundException)
            {
                MessageBox.Show("正しいファイル名を入力してください。",
                "エラー",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            }

            return list;
        }

        //csvファイルを読み込む
        public static List<List<string>> ReadCSVToList(string filePath)
        {

            var list = new List<List<string>>();
            try
            {
                StreamReader reader = new StreamReader(filePath, Encoding.GetEncoding("Shift_JIS"));
                //StreamReader reader = new StreamReader(filePath);
                while (reader.Peek() >= 0)
                {
                    string[] cols = reader.ReadLine().Split(',');
                    list.Add(cols.ToList());
                }
                return list;
            }
            catch (FileNotFoundException)
            {
                MessageBox.Show("正しいファイル名を入力してください。",
                "エラー",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            }

            return list;
        }

        //listViewの要素を削除した後、指定のリストの要素を詰め込む
        public static void RefreshSkillList(ListView listView, Dictionary<string, string> ts)
        {
            listView.Items.Clear();

            if (ts == null) return;

            //探索者固有(成長させた)技能をリストビューに入力
            foreach (KeyValuePair<string, string> kvp in ts)
            {
                string id = kvp.Key;
                string name = kvp.Value;

                string[] item1 = { id, name };
                listView.Items.Add(new ListViewItem(item1));
            }
        }

        //listViewの要素を削除した後、指定のリストの要素を詰め込む
        public static void RefreshSkillListNewChara(ListView listView, List<Skill> skills)
        {
            listView.Items.Clear();

            if (skills == null) return;

            //探索者固有(成長させた)技能をリストビューに入力
            foreach (var skill in skills)
            {
                string name = skill.name;
                string value = skill.value.ToString();
                string type = skill.workValue > 0 ? "職業":
                                skill.intererstValue > 0 ? "興味":
                                "";

                string[] item1 = { name, value, type };
                listView.Items.Add(new ListViewItem(item1));
            }
        }

        //listViewの要素を削除した後、指定のリストの要素を詰め込む
        public static void RefreshSkillList(ListView listView, List<Skill> skills)
        {
            listView.Items.Clear();

            if (skills == null) return;

            //探索者固有(成長させた)技能をリストビューに入力
            foreach (var item in skills)
            {
                string id = item.name;
                int name = item.value;

                string[] item1 = { id, name.ToString() };
                listView.Items.Add(new ListViewItem(item1));
            }
            
        }

        //bcdice_apiにGET通信でアクセスする
        public static GetBCDice_API SendGetBCDice_API(string text, string url)
        {
            if (text == "") return null;

            var result = new GetBCDice_API();
            var json = getWebAPI(url + "/v1/diceroll?system=Cthulhu&command=" + text);
            result = JsonConvert.DeserializeObject <GetBCDice_API> (json);

            return result;
        }

        private static string getWebAPI(string text)
        {
            WebRequest req = WebRequest.Create(text);
            WebResponse rsp = req.GetResponse();
            Stream stm = rsp.GetResponseStream();
            var json = "";

            if (stm != null)
            {
                StreamReader reader = new StreamReader(stm, System.Text.Encoding.GetEncoding("UTF-8"));
                json = reader.ReadToEnd();
                stm.Close();
            }
            rsp.Close();

            return json;
        }

        //discordのwebhookにテキストをPOST送信で送付する
        public async Task SendPostWebhookAsync(string text, string url, string userName)
        {            
            var sendHook = new SendWebHook(text);
            var json = JsonConvert.SerializeObject(sendHook);

            using (var client = new HttpClient())
            {
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await client.PostAsync(url, content);  
            }
        }

        [JsonObject]
        public class SendWebHook
        {
            [JsonProperty("content")]
            public string Text { get; private set; }

            public SendWebHook(string text)
            {
                this.Text = text;
            }
        }

        [JsonObject]
        public class GetBCDice_API
        {
            [JsonProperty("ok")]
            public bool ok { get; private set; }

            [JsonProperty("result")]
            public string result { get; private set; }

            [JsonProperty("secret")]
            public bool secret { get; private set; }

            [JsonProperty("dices")]
            public List<Dictionary<string, int>> dices { get; private set; }
            
        }

        internal void ShowResultDialog(string text, string skill)
        {
            string[] separatingStrings = { "<=" };
            var list = text.Split(separatingStrings, System.StringSplitOptions.RemoveEmptyEntries);

            string result = "";
            if (list.Count() == 1)
                result = TotalDice(text).Sum().ToString();
            else if (list[0] == "CCB")
                result = TotalDice("1D100")[0] > int.Parse(list[1]) ?
                    "失敗" :
                    "成功" ;


            DiceResult u_form = new DiceResult();
            u_form.set(result, skill);
            u_form.ShowDialog();

        }

        [JsonObject]
        public class SkillSet
        {
            [JsonProperty(PropertyName = "skillSetType")]
            public string SetType { get; set; }

            [JsonProperty(PropertyName = "skills")]
            public List<Skill> Skills { get; set; }
        }

        public static List<Skill> GetSkillSet()
        {
            try
            {
                var fileName = AppDomain.CurrentDomain.BaseDirectory + "characterMakingSkills.json";
                var json = System.IO.File.ReadAllText(fileName, Encoding.GetEncoding("Shift_JIS"));
                SkillSet sSet = JsonConvert.DeserializeObject<SkillSet>(json);
                return sSet.Skills;
            }
            catch (Exception e)
            {
                MessageBox.Show("読み込み時エラーが発生しました。\n" + e.Message,
                "エラー",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
                return null;
            }
        }

        internal void SendPostWebhookBCDiceAPI(string text, string webhookURL, string bcdiceURL, string userName, string skill)
        {
            var result = SendGetBCDice_API(text, bcdiceURL);
            if (!result.ok) return;

            var sendWebhookText = userName + result.result;
            _ = SendPostWebhookAsync(sendWebhookText + " " + skill, webhookURL, userName);
        }

        //diceで書かれたダイスロールを行った結果
        public static List<int> TotalDice(string dice)
        {
            List<int> total = new List<int>();

            string[] arr = dice.Split('+');
            foreach (var tex in arr)
            {
                if (!tex.Contains("d") && !tex.Contains("D"))
                {
                    total.Add(int.Parse(tex));
                }
                else
                {
                    total.AddRange(DDice(tex));
                }
            }
            return total;
        }

        // dice = "nDm" n面ダイスをm回振った時の結果
        public static List<int> DDice(string dice)
        {
            List<int> total = new List<int>();

            string[] arr = dice.Split(new char[] { 'D', 'd' });
            for(var i = 0; i < int.Parse(arr[0]); i++)
            {
                total.Add(mersenneOneDice(int.Parse(arr[1])));
            }
            return total;
        }

        //max面ダイスを振った時の結果
        private static int mersenneOneDice(int max)
        {
            return (int)((double)max * new MersenneTwister().NextDouble() + 1);
        }
    }
}
