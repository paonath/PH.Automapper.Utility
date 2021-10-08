using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
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

        private void BindAssembly()
        {
            checkedListBox1.Items.Clear();
            var f        = new FileInfo(txtAssembly.Text);
            var allFiles = f.Directory.GetFiles("*.dll");


            var resolver = new PathAssemblyResolver(allFiles.Select(x => x.FullName));
            var mlc      = new MetadataLoadContext(resolver);
            using (mlc)
            {
                // Load assembly into MetadataLoadContext.
                Assembly     assembly = mlc.LoadFromAssemblyPath(txtAssembly.Text);
                AssemblyName name     = assembly.GetName();

                // Print assembly attribute information.
                Console.WriteLine($"{name.Name} has following attributes: ");

                foreach (CustomAttributeData attr in assembly.GetCustomAttributesData())
                {
                    try
                    {
                        Console.WriteLine(attr.AttributeType);
                    }
                    catch (FileNotFoundException ex)
                    {
                        // We are missing the required dependency assembly.
                        Console.WriteLine($"Error while getting attribute type: {ex.Message}");
                    }
                }
            }
            //var a = Assembly.LoadFile(txtAssembly.Text);
            //foreach (var aDefinedType in a.GetExportedTypes())
            //{
            //    checkedListBox1.Items.Add(new )
            //    checkedListBox1.Items.Add(new ListViewItem() { Text = aDefinedType.Name, Name = aDefinedType.Name });
            //}
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
                    BindAssembly();
                }
            }

        }
    }
}
