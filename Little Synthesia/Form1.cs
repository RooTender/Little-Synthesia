using System;
using System.IO;
using System.Media;
using System.Threading;
using System.Windows.Forms;

namespace Little_Synthesia
{
    public partial class Form1 : Form
    {
        static string rootPath = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), "..\\..\\Notes\\\\"));

        SoundPlayer Z = new SoundPlayer(rootPath + "c3.wav");
        SoundPlayer S = new SoundPlayer(rootPath + "c-3.wav");
        SoundPlayer X = new SoundPlayer(rootPath + "d3.wav");
        SoundPlayer D = new SoundPlayer(rootPath + "d-3.wav");
        SoundPlayer C = new SoundPlayer(rootPath + "e3.wav");
        SoundPlayer V = new SoundPlayer(rootPath + "f3.wav");
        SoundPlayer G = new SoundPlayer(rootPath + "f-3.wav");
        SoundPlayer B = new SoundPlayer(rootPath + "g3.wav");
        SoundPlayer H = new SoundPlayer(rootPath + "g-3.wav");
        SoundPlayer N = new SoundPlayer(rootPath + "a3.wav");
        SoundPlayer J = new SoundPlayer(rootPath + "a-3.wav");
        SoundPlayer M = new SoundPlayer(rootPath + "b3.wav");

        public Form1()
        {
            InitializeComponent();
        }

        private void playSoundOnKey(string key)
        {
            switch (key.ToUpper())
            {
                case "Z": Z.Play(); break;
                case "S": S.Play(); break;
                case "X": X.Play(); break;
                case "D": D.Play(); break;
                case "C": C.Play(); break;
                case "V": V.Play(); break;
                case "G": G.Play(); break;
                case "B": B.Play(); break;
                case "H": H.Play(); break;
                case "N": N.Play(); break;
                case "J": J.Play(); break;
                case "M": M.Play(); break;
                default: break;
            }
        }

        private void instructionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("To start typing the music notes you have to use your computer keyboard.\nSo make sure you've got one there (Especially kashubian keyboard).", "The Instruction 1/3", MessageBoxButtons.OK, MessageBoxIcon.Information);
            MessageBox.Show("Real piano keys are associated with these on your keyboard. The structure of them is also really similar.\n\nWhite keys are from Z to M.\nBlack keys are: S, D, G, H, J.", "The Instruction 2/3", MessageBoxButtons.OK, MessageBoxIcon.Information);
            MessageBox.Show("It looks quite complicated for now, but soon or later you'll find it's dope. Don't get frustrated too easily and remember to have fun ;)", "The Instruction 3/3", MessageBoxButtons.OK, MessageBoxIcon.Information);
            System.Diagnostics.Process.Start(rootPath + "keyboard.png");
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            textBox2.Text = ""; // Clear textbox2;

            if (textBox1.Text == "") return;
            playSoundOnKey(textBox1.Text[textBox1.TextLength - 1].ToString().ToUpper());

            for (int i = 0; i < textBox1.Text.Length; i++)
            {
                switch (textBox1.Text[i].ToString().ToUpper())
                {
                    case "Z": textBox2.Text += "C "; break;
                    case "S": textBox2.Text += "#C "; break;
                    case "X": textBox2.Text += "D "; break;
                    case "D": textBox2.Text += "#D "; break;
                    case "C": textBox2.Text += "E "; break;
                    case "V": textBox2.Text += "F "; break;
                    case "G": textBox2.Text += "#F "; break;
                    case "B": textBox2.Text += "G "; break;
                    case "H": textBox2.Text += "#G "; break;
                    case "N": textBox2.Text += "A "; break;
                    case "J": textBox2.Text += "#A "; break;
                    case "M": textBox2.Text += "H "; break;
                    default: break;
                }
            }
        }

        private void playMySongToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "") return;

            for (int i = 0; i < textBox1.Text.Length; i++)
            {
                playSoundOnKey(textBox1.Text[i].ToString());
                Thread.Sleep(500);
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(textBox1.Text == "") 
            {
                MessageBox.Show("There is no song!");
                return;
            }

            SaveFileDialog SFD = new SaveFileDialog();
            SFD.Filter = "Little Synthesia Files (.ls)|*.ls";

            if(SFD.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllText(SFD.FileName, textBox1.Text);
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                MessageBox.Show("Are you sure you want to overwrite your song?", "Overwrite choice", MessageBoxButtons.YesNo);
                if(DialogResult == DialogResult.No) return;
            }

            OpenFileDialog OFD = new OpenFileDialog();
            OFD.Filter = "Little Synthesia Files (.ls)|*.ls";

            if(OFD.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = File.ReadAllText(OFD.FileName);
            }
        }
    }
}
