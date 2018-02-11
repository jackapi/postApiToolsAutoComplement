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
            richTextBox1.TextChanged += AutoComplement.RichTextBoxTextChangedVoid;
            fastColoredTextBox.TextChanged += AutoComplement.FastColoredTextBoxTextChangedVoid;
        }

    }
}
