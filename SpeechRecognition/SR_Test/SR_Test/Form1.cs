using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Globalization;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

using Microsoft.Speech.Recognition;
using Microsoft.Speech.Synthesis;

namespace SR_Test
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            initRS();
            initTTS();
        }

        public void initRS()
        {
            try
            {
                SpeechRecognitionEngine sre = new SpeechRecognitionEngine(new CultureInfo("en-US"));

                var words = new Choices();
                words.Add("Hello");
                words.Add("Jump");
                words.Add("Left");
                words.Add("Right");

                var gb = new GrammarBuilder();
                gb.Culture = new System.Globalization.CultureInfo("en-US");
                gb.Append(words);
                Grammar g = new Grammar(gb);

                sre.LoadGrammar(g);
                
                sre.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(sre_SpeechRecognized);
                sre.SetInputToDefaultAudioDevice();
                sre.RecognizeAsync(RecognizeMode.Multiple);
            }
            catch (Exception e)
            {
                label1.Text = "init RS Error : " + e.ToString();
            }
        }


        SpeechSynthesizer tts;
        public void initTTS()
        {
            try 
            {
                tts = new SpeechSynthesizer();
                tts.SelectVoice("Microsoft Server Speech Text to Speech Voice (en-US, Helen)");
                tts.SetOutputToDefaultAudioDevice();
                tts.Volume = 100;
            }
            catch(Exception e)
            {
                label1.Text = "init TTS Error : " + e.ToString();
            }
        }

        void sre_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            label1.Text = e.Result.Text;

            switch(e.Result.Text)
            {
                case "Hello":
                    tts.SpeakAsync("Hello");
                    break;

                case "Jump":
                    tts.SpeakAsync("Jump");
                    break;

                case "Left":
                    tts.SpeakAsync("Left");
                    break;

                case "Right":
                    tts.SpeakAsync("Right");
                    break;
            }
        }

        /*
        //To excute Program
        private static void doProgram(string filename, string arg)
        {
            ProcessStartInfo psi;
            if(arg.Length != 0)
                psi = new ProcessStartInfo(filename, arg);
            else
                psi = new ProcessStartInfo(filename);
            Process.Start(psi);
        }

        private static void closeProcess(string filename)
        {
            Process[] myProcesses;
            // Returns array containing all instances of Notepad.
            myProcesses = Process.GetProcessesByName(filename);
            foreach (Process myProcess in myProcesses)
            {
                myProcess.CloseMainWindow();
            }
        }
        */
    }
}
