using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChaPalle
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
    }
}
