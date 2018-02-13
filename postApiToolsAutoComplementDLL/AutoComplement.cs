using FastColoredTextBoxNS;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace postApiToolsAutoComplementDLL
{
    public class AutoComplement
    {
        static Thread th;

        /// <summary>
        /// 单一不带描述
        /// </summary>
        public static string[] textlist = new string[] {
                "http://",
                "https://",
                "http://www.apizl.com ",
                "http://www.qq.com ",
                "http://www.google.com ",
                "http://www.youtube.com",
                "http://www.sohu.com",
                "http://www.yidugzs.com",
                "http://www.postapitools.com",
                "http://www.yii.com",
                "http://www.pc6.com",
                "http://www.xiazaiba.com",
                "http://www.xunlei.com",
                "apizl",
                "jackapi",
                "yd",
                "com",
        };

        /// <summary>
        /// 带描述
        /// </summary>
        public static List<listModels> listData = new List<listModels>();

        /// <summary>
        /// RichTextBox自动补全
        /// </summary>
        /// <param name="obj1"></param>
        /// <param name="obj2"></param>
        public static void RichTextBoxTextChangedVoid(object obj1, object obj2)
        {
            if (th != null) { th.Abort(); th = null; }
            RichTextBox rtb = (RichTextBox)obj1;
            string result = "";
            string text = rtb.Text;
            string startText = text.Substring(0, rtb.SelectionStart);
            string endtext = "";
            string selectText = "";
            if (rtb.SelectionStart != text.Length)
            {
                if (startText != "")
                {
                    endtext = text.Replace(startText, "");
                }
            }
            string[] array = System.Text.RegularExpressions.Regex.Split(startText, @"\s{1,}");
            if (array.Length >= 1)
            {
                selectText = array[array.Length - 1];
            }
            else
            {
                selectText = "";
            }

            if (th == null)
            {
                th = new System.Threading.Thread((System.Threading.ThreadStart)delegate
                {
                    Form1 f;
                    Point p = winApi.CaretPos();
                    f = new Form1(selectText, textlist, new Point(p.X + 10, p.Y + 20));
                    try
                    {
                        if (!f.IsDisposed)
                        {
                            Application.Run(f);
                            result = f.result;
                            if (result != "")
                            {
                                rtb.BeginInvoke(new Action(() =>
                                {
                                    startText = startText.Substring(0, startText.Length - selectText.Length) + result;//处理
                                    rtb.Text = startText + endtext;
                                    rtb.SelectionStart = startText.Length;//增加后的光标位置
                                }));
                            }
                        }
                    }
                    catch (Exception ex) { f.Close(); }
                });
                th.SetApartmentState(ApartmentState.STA);
                th.IsBackground = true;
                th.Start();

            }
        }

        /// <summary>
        /// RichTextBox自动补全
        /// </summary>
        /// <param name="obj1"></param>
        /// <param name="obj2"></param>
        public static void FastColoredTextBoxTextChangedVoid(object obj1, object obj2)
        {
            if (th != null) { th.Abort(); th = null; }
            FastColoredTextBox rtb = (FastColoredTextBox)obj1;
            string result = "";
            string text = rtb.Text;
            string startText = text.Substring(0, rtb.SelectionStart);
            string endtext = "";
            string selectText = "";
            if (rtb.SelectionStart != text.Length)
            {
                if (startText != "")
                {
                    endtext = text.Replace(startText, "");
                }
            }
            string[] array = System.Text.RegularExpressions.Regex.Split(startText, @"\s{1,}");
            if (array.Length >= 1)
            {
                selectText = array[array.Length - 1];
            }
            else
            {
                selectText = "";
            }

            if (th == null)
            {
                th = new System.Threading.Thread((System.Threading.ThreadStart)delegate
                {
                    Form1 f;
                    Point p = winApi.CaretPos();
                    f = new Form1(selectText, textlist, new Point(p.X + 10, p.Y + 20));
                    try
                    {
                        if (!f.IsDisposed)
                        {
                            Application.Run(f);
                            result = f.result;
                            if (result != "")
                            {
                                rtb.BeginInvoke(new Action(() =>
                                {
                                    startText = startText.Substring(0, startText.Length - selectText.Length) + result;//处理
                                    rtb.Text = startText + endtext;
                                    rtb.SelectionStart = startText.Length;//增加后的光标位置
                                }));
                            }
                        }
                    }
                    catch (Exception ex) { f.Close(); }
                });
                th.SetApartmentState(ApartmentState.STA);
                th.IsBackground = true;
                th.Start();

            }
        }
    }
}

