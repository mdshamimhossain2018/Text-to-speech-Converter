using System;
using System.Windows.Forms;
using System.Speech;
using System.Speech.Synthesis;
using System.Threading.Tasks;
using System.Speech.Recognition;
using System.Drawing;

namespace Text_to_Speech
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        int i, j;
        Button[] buttons;

        SpeechSynthesizer reader = new SpeechSynthesizer();
        private void button1_Click(object sender, EventArgs e)
        {
            if(richTextBox1.Text != "")
            {
                reader.Dispose();
                reader = new SpeechSynthesizer();
                if (comboBox1.Text == "Male")
                {
                    reader.SelectVoiceByHints(VoiceGender.Male);
                }

                if (comboBox1.Text == "Female")
                {
                    reader.SelectVoiceByHints(VoiceGender.Female);
                }
                reader.SpeakAsync(richTextBox1.Text);
            }
            else
            {
                MessageBox.Show("Please Enter Some Text First !!!");
            }




            buttons = new Button[4] {button1,button2,button3,button4 };

            i = 0;
            timer1.Start();

           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(reader != null)
            {
                if (reader.State == SynthesizerState.Speaking)
                {
                    reader.Pause();
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (reader != null)
            {
                if (reader.State == SynthesizerState.Paused)
                {
                    reader.Resume();
                }
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if(reader != null)
            {
                reader.Dispose();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (i < buttons.Length)
            {
                buttons[i].BackColor = Color.Red;
                i = i+1;
            }
            else
            {
                timer1.Stop();
                for (j = 0; j < buttons.Length; j++)
                {
                    buttons[j].BackColor = Color.Green;
                    buttons[j].Font = new Font(this.Font.FontFamily, 10);
                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
