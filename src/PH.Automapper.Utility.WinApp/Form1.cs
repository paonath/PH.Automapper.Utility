using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PH.Automapper.Utility.WinApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnSelectAssembly_Click(object sender, EventArgs e)
        {
            txtAssembly.Text = string.Empty;
            
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory =  "c:\\";
                openFileDialog.Filter           = @"assembly files (*.dll)|*.dll";
                openFileDialog.FilterIndex      = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //Get the path of specified file
                    var filePath = openFileDialog.FileName;
                    txtAssembly.Text = filePath;
                }
            }

        }
    }
}
