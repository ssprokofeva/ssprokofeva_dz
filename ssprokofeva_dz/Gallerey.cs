using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace ssprokofeva_dz
{
    public partial class Form1 : Form
    {
        private Dictionary<string, string> images = new Dictionary<string, string>();
         
        

        public Form1()
        {
            InitializeComponent();
        }
        
        private void btnLoad_Click(object sender, EventArgs e)
        {
             
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";

            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                 
                using (StreamReader reader = new StreamReader(fileDialog.FileName))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        
                        string[] parts = line.Split(',');
                        if (parts.Length >= 2)
                        {
                            string path = parts[0].Trim();
                            string title = parts[1].Trim();

                            
                            if (File.Exists(path))
                            {
                                images[path] = title;
                                 
                            }
                        }
                    }

                }
            }
        }
         
        private void lstImages_SelectedIndexChanged(object sender, EventArgs e)
        {
             
        }
         
        private void btnSave_Click(object sender, EventArgs e)
        {
            
            SaveFileDialog fileDialog = new SaveFileDialog();
            fileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";

            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    using (StreamWriter writer = new StreamWriter(fileDialog.FileName))
                    {
                        foreach (var pair in images)
                        {
                             Console.WriteLine($"{pair.Key},{pair.Value}");
                        }
                    }
                    MessageBox.Show("Изменения сохранены успешно!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка при сохранении файла: " + ex.Message);
                }
            }
        }
    }
}


