using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace postApiToolsAutoComplementDLL
{
    public partial class Form1 : Form
    {
        public static Form1 f;
        /// <summary>
        /// 返回结果
        /// </summary>
        public string result = "";

        /// <summary>
        /// list
        /// </summary>
        public string[] list;

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="text"></param>
        /// <param name="list"></param>
        /// <param name="point"></param>
        public Form1(string text, string[] list, Point point)
        {
            InitializeComponent();
            timer.Start();
            if (text == "")
            {
                this.Close();
                this.Dispose();
                return;
            }
            this.list = list;//指定数据
            this.listBox_list.DoubleClick += listBoxDoubleClick;//绑定事件
            this.Location = point;
            this.ShowInTaskbar = false;//不显示在任务栏
            if (!diff(text, list))
            {
                this.Close();
                this.Dispose();
                return;
            }

            listBox_list.DataSource = listResult(text, list);
            this.LostFocus += LostFocusVoid;
            this.listBox_list.LostFocus += LostFocusVoid;
            ShowWindow(new HandleRef(this, this.Handle), 4);
            f = this;
        }

        /// <summary>
        /// 失去焦点事件
        /// </summary>
        /// <param name="obj1"></param>
        /// <param name="obj2"></param>
        public void LostFocusVoid(object obj1, object obj2)
        {
            this.Close();
        }

        /// <summary>
        /// 对比
        /// </summary>
        /// <param name="text"></param>
        /// <param name="list"></param>
        /// <returns></returns>
        public bool diff(string text, string[] list)
        {
            foreach (var item in list)
            {
                if (item.IndexOf(text) >= 0 && item != text)
                {
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// 处理相近的
        /// </summary>
        /// <param name="text"></param>
        /// <param name="list"></param>
        /// <returns></returns>
        public string[] listResult(string text, string[] list)
        {
            List<string> listString = new List<string>();
            foreach (var item in list)
            {
                if (item.IndexOf(text) >= 0)
                {
                    listString.Add(item);
                }
            }
            int count = listString.Count;
            string[] temp = new string[count];
            for (int i = 0; i < count; i++)
            {
                temp[i] = listString[i];
            }
            return temp;
        }
        /// <summary>
        /// 双击控件事件
        /// </summary>
        /// <param name="obj1"></param>
        /// <param name="obj2"></param>
        public void listBoxDoubleClick(object obj1, object obj2)
        {
            if (obj1 == null) { return; }
            ListBox lb = (ListBox)obj1;
            string text = lb.SelectedItem.ToString();

            result = text;//获取结果
            this.Close();
        }

        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern bool ShowWindow(HandleRef hWnd, int nCmdShow);

        /// <summary>
        /// timer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer_Tick(object sender, EventArgs e)
        {
            if (IsDisposed)
            {
                this.Dispose();
            }
        }
    }
}
