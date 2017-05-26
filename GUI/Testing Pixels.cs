using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using CloudMagic.Helpers;

namespace CloudMagic.GUI
{
    public partial class Testing_Pixels : Form
    {
        public Testing_Pixels()
        {
            InitializeComponent();
        }

        private void Testing_Pixels_Load(object sender, EventArgs e)
        {
            Log.Initialize(richTextBox1, this);
            Log.Write("Press Refresh");
        }

        private void cmdRefresh_Click(object sender, EventArgs e)
        {
            WoW.KeyPressRelease(WoW.Keys.D0);
            Thread.Sleep(400);

            Log.Clear();
            // Row 1 Pixel Testing 
            Log.Write("Player Health: " + WoW.HealthPercent);
            Log.Write("Player Level: " + WoW.Level);
            Log.Write("Player Power: " + WoW.Power);
            Log.Write("Target Health: " + WoW.TargetHealthPercent);
            Log.Write("Unit In Combat: " + WoW.IsInCombat);
            Log.Write("Unit Power: " + WoW.UnitPower);
            Log.Write("Target Is Friend: " + WoW.TargetIsFriend);
            Log.Write("Has Target: " + WoW.HasTarget);
            Log.Write("Player Is Casting: " + WoW.PlayerIsCasting);
            Log.Write("Target Is Casting: " + WoW.TargetIsCasting);
            Log.Write("Player Haste Percent: " + WoW.HastePercent);
            Log.Write("Target Visible: " + WoW.TargetIsVisible);
            Log.Write("Pet Out: " + WoW.HasPet);
            Log.Write("Pet Health: " + WoW.PetHealthPercent);
            Log.Write("Wild Imps Count: " + WoW.WildImpsCount);
            Log.Write("Dreadstalkers Count: " + WoW.DreadstalkersCount);
            // Row 2 Pixel Testing 

            Log.Write("Is Moving: " + WoW.IsMoving);
            Log.Write("Auto Attacking: " + WoW.AutoAtacking);
            Log.Write("Target Is Player: " + WoW.TargetIsPlayer);
            Log.Write("Flag: " + WoW.Flag);
            Log.Write("Last Casted Id: " + WoW.LastSpellCastedID);
            Log.Write("Target Casting Id: " + WoW.TargetCastingSpellID);
            for (int i = 1; i < 8; i++)
            {
                Log.Write($"Talent {i} : " + WoW.Talent(i));
            }
            Log.Write($"Race : " + WoW.PlayerRace + " Spec : " + WoW.PlayerSpec);
            for (int i = 19; i < 21; i++)
            {
                Log.Write($"SetBonus T{i}: " + WoW.SetBonus(i));
            }
            for (int i = 1; i < 3; i++)
            {
                Log.Write($"Legendary {i}: " + WoW.Legendary(i));
            }

            while (WoW.TargetCastingSpellID != 0) 
            {
                Log.Write("Target % Cast: " + WoW.TargetPercentCast);
                Thread.Sleep(100);
            }
            Log.Write("WoW Gui Info Displayed :" + WoW.WoWGui);
            Log.Write("WoW Gui On :" + WoW.WoWGuiOn);
            Log.Write("WoW Gui CoolDown :" + WoW.WoWGuiCoolDown);
            Log.Write("WoW Gui Rotation :" + WoW.WoWGuiMode);
        }
    }
}
