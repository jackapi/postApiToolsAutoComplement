using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace postApiToolsAutoComplement
{
    public partial class TextBox : Form
    {
        public TextBox()
        {
            InitializeComponent();
        }

        private void TextBox_Load(object sender, EventArgs e)
        {
            richTextBox1.TextChanged += TextChangedVoid;
            fastColoredTextBox.TextChanged += TextChangedVoid;
        }


        Thread th;
        /// <summary>
        /// 窗体改变事件
        /// </summary>
        /// <param name="obj1"></param>
        /// <param name="obj2"></param>
        public void TextChangedVoid(object obj1, object obj2)
        {
            if (th != null) { th.Abort(); th = null; }
            RichTextBox rtb = (RichTextBox)obj1;
            string result = "";
            string text = rtb.Text;
            string[] array = text.Split(' ');
            if (array.Length >= 1)
            {
                text = array[array.Length - 1];
            }
            string[] list = new string[] {
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
            };

            this.richTextBox1.Focus();
            if (th == null)
            {
                th = new System.Threading.Thread((System.Threading.ThreadStart)delegate
                {
                    Form1 f;
                    Point p = winApi.CaretPos();
                    f = new Form1(text, list, new Point(p.X + 10, p.Y + 20));
                    try
                    {
                        if (!f.IsDisposed)
                        {
                            Application.Run(f);
                            result = f.result;
                            if (result != "")
                            {
                                richTextBox1.BeginInvoke(new Action(() =>
                                {
                                    this.richTextBox1.Text = result;
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
            this.richTextBox1.Focus();
        }


    }
}
