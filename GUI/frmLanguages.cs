using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CloudMagic.GUI.GUI
{
    public partial class frmLanguages : Form
    {
        public frmLanguages()
        {
            InitializeComponent();
        }

        private void frmLanguages_Load(object sender, EventArgs e)
        {
            dsLanguages.ReadXml($"{Application.StartupPath}\\Languages\\Languages.xml");
            CultureInfo ci = new CultureInfo("af-ZA");
            Thread.CurrentThread.CurrentCulture = ci;
            Thread.CurrentThread.CurrentUICulture = ci;

            ResourceManager resourceManager = ResourceManager.CreateFileBasedResourceManager("resource", Application.StartupPath + "\\Languages", null);
            label1.Text = resourceManager.GetString("1");
            resourceManager.ReleaseAllResources();
        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            if (!Directory.Exists($"{Application.StartupPath}\\Languages"))
                Directory.CreateDirectory($"{Application.StartupPath}\\Languages");

            dsLanguages.WriteXml($"{Application.StartupPath}\\Languages\\Languages.xml");
            ResourceWriter englishResourceWriter =  new ResourceWriter($"{Application.StartupPath}\\Languages\\resource.en-ZA.resources");
            ResourceWriter afrikaansResourceWriter = new ResourceWriter($"{Application.StartupPath}\\Languages\\resource.af-ZA.resources");

            foreach (dsLanguages.LanguagesRow row in dsLanguages.Languages.Rows)
            {
                englishResourceWriter.AddResource(row.Id, row.English);
                afrikaansResourceWriter.AddResource(row.Id, row.Afrikaans);
            }

            englishResourceWriter.Generate();
            englishResourceWriter.Close();

            afrikaansResourceWriter.Generate();
            afrikaansResourceWriter.Close();

            MessageBox.Show("Saved", "CloudMagic", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
