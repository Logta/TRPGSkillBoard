﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PalletMaster
{
    public partial class HistoryAbilityControl : UserControl
    {

        ListViewItemComparer listViewItemSorter = new ListViewItemComparer();
        PalletMaster PalletMaster = new PalletMaster();
        Proccess Proccesser = new Proccess();

        public HistoryAbilityControl()
        {
            InitializeComponent();

            //ListViewItemSorterを指定する
            listViewHistory.ListViewItemSorter = listViewItemSorter;

            //ListViewItemComparerの作成と設定
            listViewItemSorter.ColumnModes =
                new ListViewItemComparer.ComparerMode[]
            {
                ListViewItemComparer.ComparerMode.String,
                ListViewItemComparer.ComparerMode.DateTime
            };
        }

        public void SetPalletMaster(PalletMaster palletMaster)
        {
            PalletMaster = palletMaster;
        }

        //
        //
        //====================================履歴と能力値ロールタブ==========================
        //
        //

        private void buttonAbilityRole_Click(object sender, EventArgs e)
        {
            int m_ability = PalletMaster.Searcher.GetAbilityValue(listBoxAbility.Text);
            int m_magni;
        
            if (m_ability == -1 || !int.TryParse(listBoxValue.Text, out m_magni)) return;
            
            PalletMaster.SetSkillHistory(listBoxAbility.Text + "×" + listBoxValue.Text, ロール.能力);
            PalletMaster.SetTextRole(PalletMaster.GetDiceText(Convert.ToString(m_ability * m_magni)), listBoxAbility.Text + "×" + listBoxValue.Text);
            
            PalletMaster.RefreshListView();
        }

        private void listViewHistory_DoubleClick(object sender, EventArgs e)
        {
            //項目が１つも選択されていない場合
            if (listViewHistory.SelectedItems.Count == 0)
                //処理を抜ける
                return;

            ListViewItem itemx = new ListViewItem();

            //1番目に選択されているアイテムをitemxに格納
            itemx = listViewHistory.SelectedItems[0];

            //選択されているアイテムを取得する
            if (itemx.SubItems[2].Text == "技能")
            {
                var skillName = itemx.SubItems[0].Text;
                PalletMaster.SetClipboardSearchSkillValue(skillName);
            }
            else
            {
                char[] del = { '×' };
                string[] arr = itemx.SubItems[0].Text.Split(del, StringSplitOptions.RemoveEmptyEntries);

                int m_ability = PalletMaster.Searcher.GetAbilityValue(arr[0]);
                if (m_ability == -1) return;
                
                Clipboard.SetText(PalletMaster.GetDiceText(Convert.ToString(m_ability * int.Parse(arr[1]))));
                PalletMaster.SetSkillHistory(arr[0] + " × " + arr[1], ロール.能力);
                
            }

            PalletMaster.RefreshListView();

        }

        internal void SelectedIndexListBoxAbility(int v)
        {
            listBoxAbility.SelectedIndex = v;
        }

        internal void SelectedIndexListBoxValue(int v)
        {
            listBoxValue.SelectedIndex = v;
        }

        internal void RefreshSkillList()
        {
            listViewHistory.Items.Clear();

            //使用した技能をリストビューに入力
            foreach (var item in PalletMaster.ActionHistorys)
            {
                string id = item.Skill;
                string name = item.Time;
                string type = item.Type == ロール.技能 ? "技能" : "能力";

                string[] setItem = { id, name, type };
                listViewHistory.Items.Add(new ListViewItem(setItem));
            }
        }

        private void listViewHistory_ColumnClick_1(object sender, ColumnClickEventArgs e)
        {
            //クリックされた列を設定
            listViewItemSorter.Column = e.Column;
            //並び替える
            listViewHistory.Sort();
        }
    }
}
