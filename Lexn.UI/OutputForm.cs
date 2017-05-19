using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Lexn.UI
{
    public partial class OutputForm : Form
    {
        public OutputForm()
        {
            InitializeComponent();
        }

        public void InitOutputTextbox(List<string> output)
        {
            foreach (var item in output)
            {
                txtOutput.AppendText(item + Environment.NewLine);
            }
        }
    }
}
