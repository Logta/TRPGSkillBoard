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
using System.Collections;

using Newtonsoft.Json;
using System.Net;
using System.Threading;

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
namespace PalletMaster
{
    static class Program
    {
        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Searcher searcher = new Searcher();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            FormSplash fs = new FormSplash();
            fs.Show();
            fs.Refresh();
            Thread.Sleep(1500);//時間のかかる処理
            fs.Close();

            Application.Run(new MainForm(searcher));
        }
    }
}
