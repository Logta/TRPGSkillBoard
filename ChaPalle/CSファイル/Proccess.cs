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

namespace PalletMaster
{
    class Proccess
    {
        public Proccess()
        {

        }

        //csvファイルを読み込む
        public Dictionary<string, string> ReadCSV(string filePath)
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

        //listViewの要素を削除した後、指定のリストの要素を詰め込む
        public void RefreshSkillList(ListView listView, Dictionary<string, string> ts)
        {
            listView.Items.Clear();

            //探索者固有(成長させた)技能をリストビューに入力
            if (ts != null)
            {
                foreach (KeyValuePair<string, string> kvp in ts)
                {
                    string id = kvp.Key;
                    string name = kvp.Value;

                    string[] item1 = { id, name };
                    listView.Items.Add(new ListViewItem(item1));
                }
            }
        }

        //bcdice_apiにGET通信でアクセスする
        public GetBCDice_API SendGetBCDice_API(string text, string url)
        {
            if (text == "") return null;

            var result = new GetBCDice_API();
            var json = getWebAPI(url + "/v1/diceroll?system=Cthulhu&command=" + text);
            result = JsonConvert.DeserializeObject <GetBCDice_API> (json);

            return result;
        }

        private string getWebAPI(string text)
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

        internal void SendPostWebhookBCDiceAPI(string text, string webhookURL, string bcdiceURL, string userName, string skill)
        {
            var result = SendGetBCDice_API(text, bcdiceURL);
            if (!result.ok) return;

            var sendWebhookText = userName + result.result;
            SendPostWebhookAsync(sendWebhookText + " " + skill, webhookURL, userName);
        }
    }
}
