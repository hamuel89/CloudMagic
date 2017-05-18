//////////////////////////////////////////////////
//                                              //
//   See License.txt for Licensing information  //
//                                              //
//////////////////////////////////////////////////

using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Management;
using System.Threading;
using System.Windows.Forms;
using Microsoft.CSharp;
using CloudMagic.Helpers;
using CloudMagic.Rotation;
using static CloudMagic.Helpers.NativeMethods;
using System.Runtime.InteropServices;
using System.Speech.Synthesis;

// ReSharper disable once CheckNamespace
namespace CloudMagic.GUI
{
    public partial class frmMain : Form
    {
        internal static CombatRoutine combatRoutine;
        private readonly Dictionary<int, string> classes;
        private KeyboardHook hook;
        SelectWoWProcessToAttachTo frmSelect;

        private static string Exe_Version => File.GetLastWriteTime(System.Reflection.Assembly.GetEntryAssembly().Location).ToString("yyyy.MM.dd");
        
        private readonly int LocalVersion = int.Parse(Application.ProductVersion.Split('.')[0]);

        internal frmMain()
        {
            InitializeComponent();

            classes = new Dictionary<int, string>
            {
                { 1, "Warrior"},
                { 2, "Paladin"},
                { 3, "Hunter"},
                { 4, "Rogue"},
                { 5, "Priest"},
                { 6, "DeathKnight"},
                { 7, "Shaman"},
                { 8, "Mage"},
                { 9, "Warlock"},
                { 10, "Monk"},
                { 11, "Druid"},
                { 12, "DemonHunter"}
            };
        }

        private static string OperatingSystem
        {
            get
            {
                var result = string.Empty;

                var moc = new ManagementObjectSearcher(@"SELECT * FROM Win32_OperatingSystem ");
                foreach (var managementBaseObject in moc.Get())
                {
                    var o = (ManagementObject) managementBaseObject;
                    var x64 = Environment.Is64BitOperatingSystem ? "(x64)" : "(x86)";
                    result = $@"{o["Caption"]} {x64} Version {o["Version"]} SP {o["ServicePackMajorVersion"]}.{o["ServicePackMinorVersion"]}";
                    break;
                }

                return result.Replace("Microsoft", "").Trim();
            }
        }

        

        private void frmMain_Load(object sender, EventArgs e)
        {   
            toolStripStatusLabel1.Text = string.Format(toolStripStatusLabel1.Text, Exe_Version);
            toolStripStatusLabel3.Text = string.Format(toolStripStatusLabel3.Text, LocalVersion);
            frmSelect = new SelectWoWProcessToAttachTo(this);

            prgPlayerHealth.Value = 0;
            prgPower.Value = 0;
            prgTargetHealth.Value = 0;

            // Its annoying as hell when people use incorrect culture info, this will force it to use the correct number and date formats.
            var ci = new CultureInfo("en-ZA") { DateTimeFormat = {ShortDatePattern = "yyyy/MM/dd"}, NumberFormat = { NumberDecimalSeparator = ".", CurrencyDecimalSeparator = "." } };
            Thread.CurrentThread.CurrentCulture = ci;
            Thread.CurrentThread.CurrentUICulture = ci;

            FormClosing += FrmMain_FormClosing;
            Shown += FrmMain_Shown;
            Log.Initialize(rtbLog, this);

            Log.WriteNoTime("Should you encounter rotation issues at low health ensure that flashy red screen is turned off in interface options.", Color.Green);

            var processName = Process.GetCurrentProcess().ProcessName.ToUpper();

            if (processName == "CLOUDMAGIC")
            {
                Log.WriteNoTime("It has been detected that you have not renamed 'CloudMagic.exe' before running it, it is recommended to rename it", Color.Red);
            }

            Log.HorizontalLine = "-".PadLeft(152, '-');
            Log.DrawHorizontalLine();
        }

        private bool LoadProfile(string fileName, bool reloadUI = true)
        {
            using (var sr = new StreamReader(fileName))
            {
                var code = sr.ReadToEnd();

                if (code.Trim() == "")
                {
                    MessageBox.Show("Please select a non blank file", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                if (fileName.EndsWith(".enc"))
                {
                    Log.Write("Decrypting profile...", Color.Black);

                    try
                    {
                        code = Encryption.Decrypt(code);

                        if (Debugger.IsAttached)
                        {
                            StreamWriter sw =  new StreamWriter(fileName.Replace(".enc", ".cs"));
                            sw.Write(code);
                            sw.Flush();
                            sw.Close();
                        }

                        Log.Write("Profile has been decrypted successfully", Color.Green);
                    }
                    catch (Exception ex)
                    {
                        Log.Write(ex.Message, Color.Red);
                    }
                }

                Log.Write($"Compiling profile [{fileName}]...", Color.Black);

                var provider = new CSharpCodeProvider();
                var parameters = new CompilerParameters();

                parameters.ReferencedAssemblies.Add("System.Windows.Forms.dll"); // For Windows Forms use
                parameters.ReferencedAssemblies.Add("System.Drawing.dll"); // For System.Drawing.Point and System.Drawing.Color use
                parameters.ReferencedAssemblies.Add("System.Data.dll");
                parameters.ReferencedAssemblies.Add("System.Xml.dll");
                parameters.ReferencedAssemblies.Add("System.Linq.dll");
                parameters.ReferencedAssemblies.Add("System.dll");
                parameters.ReferencedAssemblies.Add("System.IO.dll");
                parameters.ReferencedAssemblies.Add("System.Threading.dll");
                parameters.ReferencedAssemblies.Add(Application.ExecutablePath);
                parameters.GenerateInMemory = true;
                parameters.GenerateExecutable = false;

                var results = provider.CompileAssemblyFromSource(parameters, code);

                if (results.Errors.HasErrors)
                {
                    foreach (CompilerError error in results.Errors)
                    {                        
                        Log.Write($"Error on line [{error.Line}] - ({error.ErrorNumber}): {error.ErrorText}", Color.Red);
                    }

                    return false;
                }

                var assembly = results.CompiledAssembly;

                foreach (var t in assembly.GetTypes())
                {
                    if (t.IsClass)
                    {
                        var obj = Activator.CreateInstance(t);
                        combatRoutine = (CombatRoutine)obj;

                        combatRoutine.Load(this);
                        combatRoutine.FileName = fileName;

                        Log.Write("Successfully loaded combat routine: " + combatRoutine.Name, Color.Green);
                        
                        if (SpellBook.Initialize(fileName, reloadUI))
                        {
                            spellbookToolStripMenuItem.Enabled = true;
                            submitTicketToolStripMenuItem.Enabled = true;

                            cmdStartBot.Enabled = true;
                            cmdStartBot.BackColor = Color.LightGreen;
                            cmdRotationSettings.Enabled = true;
                            cmdReloadRotation.Enabled = true;
                            cmdReloadRotationAndUI.Enabled = true;

                            return true;
                        }

                        spellbookToolStripMenuItem.Enabled = false;
                        submitTicketToolStripMenuItem.Enabled = false;

                        cmdStartBot.Enabled = false;
                        cmdStartBot.BackColor = Color.WhiteSmoke;
                        return false;
                    }
                }

                return false;
            }
        }

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                Log.Write("Performing Cleanup, application closing...");
                Log.Write(" - Keyboard Hotkey Hooks...");
                hook?.Dispose();
                Log.Write(" - Done.");
                Log.Write(" - Combat Routine...");
                combatRoutine?.Dispose();
                Log.Write(" - Done");
                Log.Write(" - WoW Pixel Reading System...");
                WoW.Dispose();
                Log.Write(" - Done");
                Log.Write(" - Mouse Hook");
                MouseHook.ForceUnsunscribeFromGlobalMouseEvents();
                Log.Write(" - Done");
                Log.Write("Cleanup Completed.");
                e.Cancel = false;
            }
            catch (Exception ex)
            {
                Log.Write(ex.Message, Color.Red);
            }
        }

        private void ReloadHotkeys()
        {
            hook?.Dispose();

            hook = new KeyboardHook();
            hook.KeyPressed += Hook_KeyPressed;

            MouseHook.MouseClick += MouseHook_MouseClick;
            
            if (ConfigFile.ReadValue("Hotkeys", "cmbStartRotationKey") != "")
            {
                hook.RegisterHotKey(Keyboard.StartRotationModifierKey, Keyboard.StartRotationKey, "Start Rotation");

                if (Keyboard.StartRotationModifierKey != Keyboard.StopRotationModifierKey || Keyboard.StartRotationKey != Keyboard.StopRotationKey)
                    hook.RegisterHotKey(Keyboard.StopRotationModifierKey, Keyboard.StopRotationKey, "Stop Rotation");

                hook.RegisterHotKey(Keyboard.SingleTargetModifierKey, Keyboard.SingleTargetKey, "Single Target");

                if (Keyboard.SingleTargetModifierKey != Keyboard.AOEModifierKey || Keyboard.SingleTargetKey != Keyboard.AOEKey)
                    hook.RegisterHotKey(Keyboard.AOEModifierKey, Keyboard.AOEKey, "AOE Targets");
            }
            else
            {
                // Defaults - Hotkeys not setup

                hook.RegisterHotKey(Helpers.ModifierKeys.Ctrl, Keys.S, "Start / Stop Rotation");
                hook.RegisterHotKey(Helpers.ModifierKeys.Alt, Keys.S, "Single Target");
                hook.RegisterHotKey(Helpers.ModifierKeys.Alt, Keys.A, "AOE Targets");
                hook.RegisterHotKey(Helpers.ModifierKeys.Alt, Keys.C, "Single Target Cleave Targets");
            }

            hook.RegisterHotKey(Helpers.ModifierKeys.Ctrl, Keys.F5, "Reload Rotation & UI");
            hook.RegisterHotKey(Helpers.ModifierKeys.Ctrl, Keys.F6, "Reload Rotation");
        }

        private void MouseHook_MouseClick(object sender, MouseEventArgs e)
        {
            txtMouseXYClick.Text = $"{e.X}, {e.Y}";
        }

        private Process _process;

        public Process process
        {
            get
            {
                return _process;
            }
            set
            {
                _process = value;
                Log.Write("Process Id = " + value.Id);
            }
        }

        private void FrmMain_Shown(object sender, EventArgs e)
        {
            try
            {
                ConfigFile.Initialize();

                if (!ConfigFile.LicenseAccepted)
                {
                    var f = new frmLicenseAgreement();
                    f.ShowDialog();
                }

                if (!ConfigFile.LicenseAccepted)
                    Close();

                chkDisableOverlay.Checked = ConfigFile.DisableOverlay; 
                chkDisableOverlay_CheckedChanged(null, null);

                Log.Write(OperatingSystem);

                if (GameDVR.IsAppCapturedEnabled || GameDVR.IsGameDVREnabled)
                {
                    DialogResult dialogResult = MessageBox.Show("Game DVR is currently ENABLED on this machine. Would you like to disable it? CloudMagic will NOT function correctly with it enabled.", "DisableGameDVR", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (dialogResult == DialogResult.Yes)
                    {
                        GameDVR.SetAppCapturedEnabled(0);
                        GameDVR.SetGameDVREnabled(0);
                        MessageBox.Show("Game DVR has been disabled. A restart maybe required to take effect.", "CloudMagic", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        Log.Write("CloudMagic cannot run until GameDVR is disabled", Color.Red);
                        return;
                    }
                }
                else
                {
                    Log.Write("GameDVR is disabled in Xbox app", Color.Green);
                }
                                
                var i = 0;
                foreach (var screen in Screen.AllScreens)
                {
                    i++;
                    Log.Write($"Screen [{i}] - depth: {screen.BitsPerPixel}bit - resolution: {screen.Bounds.Width}x{screen.Bounds.Height}");
                }
                
                foreach (var item in classes)
                {
                    if (!Directory.Exists(Application.StartupPath + "\\Rotations\\" + item.Value))
                        Directory.CreateDirectory(Application.StartupPath + "\\Rotations\\" + item.Value);
                }

                nudLatency.Value = ConfigFile.Latency;
                
                Log.Write($"Latency set to: {nudLatency.Value}ms");
                Log.Write($"Addon Latency set to: {ConfigFile.LatencyForAddon}");

                nudPulse.Value = ConfigFile.Pulse;

                checkForUpdatesToolStripMenuItem.PerformClick();

                frmSelect.ShowDialog();
                
                if (process == null)
                {
                    Close();
                }
                
                ReloadHotkeys();

                WoW.Initialize(process);                                               

                Log.Write("WoW Path: " + WoW.InstallPath, Color.Gray);
                Log.Write("AddOn Path: " + WoW.AddonPath, Color.Gray);

                if (!Directory.Exists(Path.Combine(WoW.AddonPath, "HideOrderHallBar")))
                {
                    MessageBox.Show("Please ensure you have installed the 'HideOrderHallBar' addon", "CloudMagic", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var hwnd = WoW.Process.MainWindowHandle;

                Rectangle myRect = new Rectangle();

                RECT rct;

                if (!GetWindowRect(hwnd, out rct))
                {
                    MessageBox.Show("Unable to find wow resolution from exe, please ensure WoW is running.", "CloudMagic", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }                

                myRect.X = rct.Left;
                myRect.Y = rct.Top;
                myRect.Width = rct.Right - rct.Left + 1;
                myRect.Height = rct.Bottom - rct.Top + 1;

                Log.Write($"Current WoW Resolution is '{(myRect.Width - 1)}x{(myRect.Height - 1)}'");

                if (myRect.Width != 1921 || myRect.Height != 1081)
                {
                    if (myRect.Width == 2561)
                    {
                        Log.Write("You are not running an officially supported resolution", Color.OrangeRed);
                        // Allow this res for Suitz he swears it works, if it breaks he will support you with it :P
                    }
                    else
                    {
                        MessageBox.Show("Please ensure you are running wow in 1920x1080 resolutions, others are not supported.", "CloudMagic", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Log.Write($"Current WoW Resolution is '{(myRect.Width - 1)}x{(myRect.Height - 1)}' only 1920x1080 is supported", Color.Red);
                        return;
                    }
                    
                }

                var mousePos = new Thread(delegate ()
                {
                    while (true)
                    {
                        Threads.UpdateTextBox(txtMouseXY, Cursor.Position.X + "," + Cursor.Position.Y);
                        Thread.Sleep(10);
                    }
                    // ReSharper disable once FunctionNeverReturns
                })
                { IsBackground = true };
                mousePos.Start();
                                
                Log.DrawHorizontalLine();
                Log.Write("Please select a rotation to load from 'File' -> 'Load Rotation...'", Color.Green);
                Log.Write("Please note that you can only start a bot, or setup the spellbook, once you have loaded a rotation", Color.Black);
                Log.DrawHorizontalLine();

                var lastRotation = ConfigFile.ReadValue("CloudMagic", "LastProfile");

                if (!File.Exists(lastRotation)) return;

                if (!LoadProfile(lastRotation))
                {
                    Log.Write("Failed to load profile, please select a valid file.", Color.Red);
                }

                //// For testing only
                //if (!Debugger.IsAttached)
                //    return;

                //var rot = new Warrior();
                //rot.Load(this);
                //combatRoutine = rot.combatRoutine;
                //combatRoutine.FileName = Application.StartupPath + @"\Rotations\Warrior\Warrior.cs";
                //Log.Write("Successfully loaded combat routine: " + combatRoutine.Name, Color.Green);
                //Overlay.showOverlay(new Point(20, 680));
                //if (SpellBook.Initialize(Application.StartupPath + @"\Rotations\Warrior\Warrior.cs"))
                //{
                //    spellbookToolStripMenuItem.Enabled = true;
                //    submitTicketToolStripMenuItem.Enabled = true;
                //    cmdStartBot.Enabled = true;
                //    cmdStartBot.BackColor = Color.LightGreen;
                //    cmdRotationSettings.Enabled = true;
                //}
                //else
                //{
                //    spellbookToolStripMenuItem.Enabled = false;
                //    submitTicketToolStripMenuItem.Enabled = false;
                //    cmdStartBot.Enabled = false;
                //    cmdStartBot.BackColor = Color.WhiteSmoke;
                //}
            }
            catch (Exception ex)
            {
                Log.Write(ex.Message, Color.Red);
            }
        }

        private void Hook_KeyPressed(object sender, KeyPressedEventArgs e)
        {
            lblHotkeyInfo.Text = e.Modifier + " + " + e.Key;

            if (e.Modifier == Helpers.ModifierKeys.Ctrl && e.Key == Keys.F5)
            {
                cmdReloadRotationAndUI.PerformClick();
            }

            if (e.Modifier == Helpers.ModifierKeys.Ctrl && e.Key == Keys.F6)
            {
                cmdReloadRotation.PerformClick();
            }

            if (ConfigFile.ReadValue("Hotkeys", "cmbStartRotationKey") != "")
            {
                if (e.Modifier == Keyboard.StartRotationModifierKey && e.Key == Keyboard.StartRotationKey)
                {
                    cmdStartBot_Click(null, null);
                    return;
                }

                if (e.Modifier == Keyboard.StopRotationModifierKey && e.Key == Keyboard.StopRotationKey)
                {
                    cmdStartBot_Click(null, null);
                    return;
                }

                if (combatRoutine == null)
                    return;


                if (Keyboard.SingleTargetModifierKey == Keyboard.AOEModifierKey && Keyboard.SingleTargetKey == Keyboard.AOEKey)
                {
                    if (e.Modifier == Keyboard.SingleTargetModifierKey && e.Key == Keyboard.SingleTargetKey) // or AOEKey - since they the same in this case
                    {
                        if (combatRoutine.Type == CombatRoutine.RotationType.SingleTarget)
                        {
                            combatRoutine.ChangeType(CombatRoutine.RotationType.AOE);
                            return;
                        }
                        if (combatRoutine.Type == CombatRoutine.RotationType.AOE)
                        {
                            combatRoutine.ChangeType(CombatRoutine.RotationType.SingleTargetCleave);
                            return;
                        }
                        
                        combatRoutine.ChangeType(CombatRoutine.RotationType.SingleTarget);
                    }
                }
                else
                {
                    if (e.Modifier == Keyboard.SingleTargetModifierKey && e.Key == Keyboard.SingleTargetKey)
                    {
                        if (combatRoutine.Type != CombatRoutine.RotationType.SingleTarget)
                        {
                            combatRoutine.ChangeType(CombatRoutine.RotationType.SingleTarget);
                            return;
                        }
                    }

                    if (e.Modifier == Keyboard.AOEModifierKey && e.Key == Keyboard.AOEKey)
                    {
                        if (combatRoutine.Type != CombatRoutine.RotationType.AOE)
                        {
                            combatRoutine.ChangeType(CombatRoutine.RotationType.AOE);
                        }
                        else
                        {
                            combatRoutine.ChangeType(CombatRoutine.RotationType.SingleTargetCleave);
                        }
                    }
                }
            }
            else  // If defaults are not setup, then use these as defaults
            {
                if (e.Modifier == Helpers.ModifierKeys.Ctrl)
                {
                    if (e.Key == Keys.S)
                    {
                        cmdStartBot_Click(null, null);
                    }
                }

                if (e.Modifier == Helpers.ModifierKeys.Alt)
                {
                    if (e.Key == Keys.S)
                    {
                        combatRoutine.ChangeType(CombatRoutine.RotationType.SingleTarget);
                    }

                    if (e.Key == Keys.A)
                    {
                        combatRoutine.ChangeType(CombatRoutine.RotationType.AOE);
                    }

                    if (e.Key == Keys.C)
                    {
                        combatRoutine.ChangeType(CombatRoutine.RotationType.SingleTargetCleave);
                    }
                }
            }
        }

        private void cmdStartBot_Click(object sender, EventArgs e)
        {
            if (combatRoutine == null)
            {
                MessageBox.Show("Please select a rotation to load before starting the bot.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (combatRoutine.State == CombatRoutine.RotationState.Stopped)
            {
                combatRoutine.Start();
                WoW.Speak("Starting Rotation");

                if (combatRoutine.State != CombatRoutine.RotationState.Running) return;

                cmdStartBot.Text = "Stop rotation";
                cmdStartBot.BackColor = Color.Salmon;
            }
            else
            {
                WoW.Speak("Stopping Rotation");
                combatRoutine.Pause();
                cmdStartBot.Text = "Start rotation";
                cmdStartBot.BackColor = Color.LightGreen;                
            }
        }

        //private void cmdDonate_Click(object sender, EventArgs e)
        //{
        //    // 1 $
        //    Process.Start("https://www.paypal.com/cgi-bin/webscr?cmd=_s-xclick&hosted_button_id=CPDNWHKSVWGKA");
        //    // 5 $
        //    //Process.Start("https://www.paypal.com/cgi-bin/webscr?cmd=_s-xclick&hosted_button_id=PM3737J8GG7BG");
        //}

        private void loadRotationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (combatRoutine?.State == CombatRoutine.RotationState.Running)
            {
                combatRoutine?.Pause();
            }

            var fileBrowser = new OpenFileDialog
            {
                Filter = "CS (*.cs)|*.cs|ENC (*.enc)|*.enc",
                InitialDirectory = Application.StartupPath + "\\Rotations"
            };
            var res = fileBrowser.ShowDialog();

            if (res == DialogResult.OK)
            {
                if (!LoadProfile(fileBrowser.FileName))
                {
                    Log.Write("Failed to load profile, please select a valid file.", Color.Red);
                }
                else
                {
                    // We loaded the profile successfully, save it as the current profile
                    ConfigFile.WriteValue("CloudMagic", "LastProfile", fileBrowser.FileName);
                }
            }
        }        

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (combatRoutine.State == CombatRoutine.RotationState.Running)
            {
                combatRoutine.Pause();
            }

            Application.Exit();
        }

        private void checkForUpdatesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Debugger.IsAttached)
                return;

            // Check versions                               
            Log.Write("Checking for updates...");

            Log.Write("Latest GitHub version: " + GitHubVersion);
            Log.Write("Current version: " + LocalVersion);

            if (GitHubVersion > LocalVersion)
            {
                Log.Write("Please note you are not running the latest version of the bot, please update it.", Color.Black);
                MessageBox.Show("Please note you are not running the latest version of the bot, please update it.\r\nThe application will now exit.", "CloudMagic", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
        }

        private void encryptCombatRoutineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ConfigFile.LastRotation.EndsWith(".enc"))
            {
                Log.Write("The currently selected routine is already encrypted", Color.Red);
                return;
            }

            if (ConfigFile.LastRotation != "")
            {
                try
                {
                    string rotationSource;

                    using (var sr = new StreamReader(ConfigFile.LastRotation))
                    {
                        var contents = sr.ReadToEnd();

                        var line1 = contents.Split('\r')[0].Trim();

                        if (!line1.Contains("@"))
                        {
                            throw new Exception("You are not permitted to encrypt a combat routine if you have not yet specified an email address on the top line of the routine");
                        }

                        rotationSource = Encryption.Encrypt(contents);
                    }

                    using (var sw = new StreamWriter(ConfigFile.LastRotation.Replace(".cs", ".enc")))
                    {
                        sw.Write(rotationSource);
                        sw.Flush();
                    }

                    Log.Write("File has beem encrypted successfully.", Color.Green);
                    Log.Write("Encrypted name: " + ConfigFile.LastRotation.Replace(".cs", ".enc"), Color.Green);
                }
                catch (Exception ex)
                {
                    Log.Write(ex.Message, Color.Red);
                }
            }
            else
            {
                Log.Write("Please load a rotation so that I know which rotation to encrypt.", Color.Red);
            }
        }

        private void hotkeysToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var f = new SetupHotkeys();
            f.ShowDialog();

            ReloadHotkeys();
        }

        private void spellbookToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var f = new SetupSpellBook();
            f.ShowDialog();
        }

        private void chkDisableOverlay_CheckedChanged(object sender, EventArgs e)
        {
            ConfigFile.DisableOverlay = chkDisableOverlay.Checked;
        }

        private void nudPulse_ValueChanged(object sender, EventArgs e)
        {
            ConfigFile.Pulse = nudPulse.Value;

            combatRoutine?.ForcePulseUpdate();
        }

        #region Get GIT Version

        private int _gitVersion;

        private int GitHubVersion
        {
            get
            {
                if (_gitVersion == 0)
                {
                    try
                    {
                        var versionInfo = Web.GetString("https://raw.githubusercontent.com/winifix/CloudMagic/master/CloudMagic/Properties/AssemblyInfo.cs").
                            Split('\r').
                            FirstOrDefault(r => r.Contains("AssemblyFileVersion"))?.
                            Replace("\n", "").
                            Replace("[assembly: AssemblyFileVersion(\"", "").
                            Replace("\")]", "").
                            Split('.')[0];

                        if (versionInfo == null)
                        {
                            throw new Exception();
                        }

                        if (versionInfo != null) _gitVersion = int.Parse(versionInfo);
                    }
                    catch
                    {
                        Log.Write("Unable to determine GitHub version", Color.Red);
                        Log.Write("Please ensure internet connectivity is working...", Color.Red);
                        _gitVersion = 0;
                    }
                }
                return _gitVersion;
            }
        }

        #endregion

        private void reloadAddonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!Debugger.IsAttached)
                WoW.SendMacro("/console scriptErrors 1");   // Show wow Lua errors

            WoW.SendMacro("/reload");
        }

        private void rtbLog_TextChanged(object sender, EventArgs e)
        {

        }

        private void statusStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void submitTicketToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var f = new frmSubmitTicket(rtbLog.Text);
            f.ShowDialog();
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void cmdRotationSettings_Click(object sender, EventArgs e)
        {
            try
            {
                combatRoutine.SettingsForm.ShowDialog();
            }
            catch
            {
                MessageBox.Show("The selected rotation does not have settings.");
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void txtTargetCasting_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtTargetHealth_TextChanged(object sender, EventArgs e)
        {

        }

        private void imageToByteArrayToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var f = new GUI.frmImageToByteArray();
            f.ShowDialog();
        }

        private void ReloadRotation(bool reloadUI = true)
        {
            Log.Clear();

            var currentRotationState = combatRoutine.State;
            var currentRotationType = combatRoutine.Type;

            if (currentRotationState == CombatRoutine.RotationState.Running)
            {
                cmdStartBot.PerformClick(); // The bot is running stop it first
                Log.DrawHorizontalLine();
            }

            // Then re-load the rotation
            var lastRotation = ConfigFile.ReadValue("CloudMagic", "LastProfile");

            if (!File.Exists(lastRotation)) return;

            if (!LoadProfile(lastRotation, reloadUI)) // Load the last rotation
            {
                Log.Write("Failed to load profile, please select a valid file.", Color.Red);
                return;
            }
            
            // Then start the bot if it was running
            if (currentRotationState == CombatRoutine.RotationState.Running)
            {
                Log.DrawHorizontalLine();

                cmdStartBot.PerformClick();
                combatRoutine.ChangeType(currentRotationType);
            }

            Log.DrawHorizontalLine();
        }

        private void cmdReloadRotation_Click(object sender, EventArgs e)
        {
            ReloadRotation(false);
        }

        private void cmdReloadRotationAndUI_Click(object sender, EventArgs e)
        {
            ReloadRotation();
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            Application.ExitThread();
        }

        private void cmdDiscord_Click(object sender, EventArgs e)
        {
            Process.Start("https://discord.gg/0rnM62Wx5pQp8tjT");
        }

        private void targetParty1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WoW.TargetPartyMember(1);
        }

        private void targetParty2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WoW.TargetPartyMember(2);
        }

        private void nudLatency_ValueChanged(object sender, EventArgs e)
        {
            ConfigFile.Latency = nudLatency.Value;
        }

        private void licenseAgreementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var f = new frmLicenseAgreement();
            f.ShowDialog();
        }

        private void cmd1_Click(object sender, EventArgs e)
        {
            // $ 1
            Process.Start("https://www.paypal.com/cgi-bin/webscr?cmd=_s-xclick&hosted_button_id=CPDNWHKSVWGKA");
        }

        private void cmd5_Click(object sender, EventArgs e)
        {
            // $ 5
            Process.Start("https://www.paypal.com/cgi-bin/webscr?cmd=_s-xclick&hosted_button_id=PM3737J8GG7BG");
        }
    }
}