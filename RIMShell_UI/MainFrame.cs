using RIM;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RuleInferenceMachine
{
    public partial class MainFrame : Form
    {
        static RIMEngine_UI rim = new RIMEngine_UI();
        public MainFrame()
        {
            InitializeComponent();
        }

        private void btn_importRule_Click(object sender, EventArgs e)
        {
            try
            {
                StreamReader sr = new StreamReader("Rule.rim");
                rim.ImportKB(sr);
                MessageBox.Show("Default file \"Rule.rim\" import successfully!", "File Imported", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btn_importRule.Text = "√ " + btn_importRule.Text;
                btn_importRule.BackColor = Color.YellowGreen;
                btn_importRule.Enabled = false;
            }
            catch (FileNotFoundException)
            {
                MessageBox.Show("Default file \"Rule.rim\" not found, you would create Rules first.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                StreamWriter sw = new StreamWriter("Rule.rim");
                rim.CreatKB(sw);
                btn_importRule.Text = "√ " + btn_importRule.Text;
                btn_importRule.BackColor = Color.YellowGreen;
                btn_importRule.Enabled = false;
            }
            catch (Exception)
            {
                MessageBox.Show("Open default file \"Rule.rim\"error, please try again", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_InputCon_Click(object sender, EventArgs e)
        {
            rim.InputDB();
            MessageBox.Show("Conditions add successfully!", "Conditions Added", MessageBoxButtons.OK, MessageBoxIcon.Information);
            btn_InputCon.Text = "√ " + btn_InputCon.Text;
            btn_InputCon.BackColor = Color.YellowGreen;
            btn_InputCon.Enabled = false;
        }

        private void btn_Inference_Click(object sender, EventArgs e)
        {
            rim.Think();
            btn_Inference.Text = "√ " + btn_Inference.Text;
            btn_Inference.BackColor = Color.YellowGreen;
            btn_Inference.Enabled = false;
        }

        private void btn_About_Click_1(object sender, EventArgs e)
        {
            About about = new About();
            about.ShowDialog();
        }
    }
}
