using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Speech.Synthesis;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CloudMagic.Helpers;

namespace CloudMagic.GUI
{
    public partial class frmLicenseAgreement : Form
    {
        public frmLicenseAgreement()
        {
            InitializeComponent();
        }

        private void cmdRead_Click(object sender, EventArgs e)
        {
            cmdRead.Enabled = false;
            cmdAgree.Enabled = false;
            Application.DoEvents();
            synthesizer.Speak(richTextBox1.Text);
            cmdAgree.Enabled = true;
            cmdRead.Enabled = true;
        }

        private static SpeechSynthesizer synthesizer;

        private void frmLicenseAgreement_Load(object sender, EventArgs e)
        {
            synthesizer = new SpeechSynthesizer();
            synthesizer.Volume = 100;  // 0...100
            synthesizer.Rate = 3;     // -10...10
            synthesizer.SelectVoiceByHints(VoiceGender.Female, VoiceAge.Adult);
        }

        private void cmdDecline_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void cmdAgree_Click(object sender, EventArgs e)
        {
            ConfigFile.LicenseAccepted = true;
            Close();
        }
    }
}
