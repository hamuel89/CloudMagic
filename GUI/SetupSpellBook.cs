//////////////////////////////////////////////////
//                                              //
//   See License.txt for Licensing information  //
//                                              //
//////////////////////////////////////////////////

// Icon Backlink: http://www.aha-soft.com/

using System;
using System.Windows.Forms;
using CloudMagic.Helpers;
using System.Globalization;
using System.Linq;
using System.Data;

// ReSharper disable once CheckNamespace
#pragma warning disable 168

namespace CloudMagic.GUI
{
    public partial class SetupSpellBook : Form
    {
        public SetupSpellBook()
        {
            InitializeComponent();
        }

        private string AddonInterfaceVersion => cmbWowVersion.Text;

        private void SetupSpellBook_Load(object sender, EventArgs e)
        {
            dgSpells.AllowUserToAddRows = false;

            var ti = new CultureInfo("en-ZA", false).TextInfo;
            txtAddonAuthor.Text = ti.ToTitleCase(Environment.UserName);

            var machineName = new string(Environment.MachineName.Where(char.IsLetter).ToArray()).ToLower();
            txtAddonName.Text = ti.ToTitleCase(machineName);

            txtAddonAuthor.Text = SpellBook.AddonAuthor;
            txtAddonName.Text = ConfigFile.ReadValue("CloudMagic", "AddonName");

            cmbKeyBind.DataSource = Enum.GetNames(typeof(WoW.Keys));
            cmbKeyBinds.DataSource = Enum.GetNames(typeof(WoW.Keys));

            try
            {
                foreach (var item in cmbWowVersion.Items)
                {
                    if (item.ToString().Contains(SpellBook.NumericInterfaceVersion.ToString()))
                        cmbWowVersion.SelectedItem = item;
                }
            }
            catch(Exception ex)
            {
                // Do nothing - ignore
            }

            BindingSource source = new BindingSource();
            source.DataSource = SpellBook.dtSpells;
            dgSpells.DataSource = source;

            dgSpells.DataError += DgSpells_DataError;
            dgAuras.DataSource = SpellBook.dtAuras;
            dgItems.DataSource = SpellBook.dtItems;
        }

        private void DgSpells_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            // Ignore this is issue with enums see: stackoverflow.com/questions/654829/datagridviewcomboboxcell-binding-value-is-not-valid
        }

        private void cmdAddSpell_Click(object sender, EventArgs e)
        {
            SpellBook.AddSpell(nudSpellId, txtSpellName, cmbKeyBind);
        }

        private void cmdRemoveSpell_Click(object sender, EventArgs e)
        {
            SpellBook.RemoveSpell(nudSpellId);
        }

        private void cmdAddAura_Click(object sender, EventArgs e)
        {
            SpellBook.AddAura(nudAuraId, txtAuraName);
        }

        private void cmdRemoveAura_Click(object sender, EventArgs e)
        {
            SpellBook.RemoveAura(nudAuraId);
        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            if (cmbWowVersion.Text == "")
            {
                MessageBox.Show("Please select a valid wow version", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            SpellBook.Save(txtAddonAuthor, AddonInterfaceVersion);
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void cmdAddItem_Click(object sender, EventArgs e)
        {
            SpellBook.AddItem(nudItemId, txtItemName);
        }

        private void cmdRemoveItem_Click(object sender, EventArgs e)
        {
            SpellBook.RemoveItem(nudItemId);
        }
    }
}