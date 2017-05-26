//////////////////////////////////////////////////
//                                              //
//   See License.txt for Licensing information  //
//                                              //
//////////////////////////////////////////////////

using System;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using CloudMagic.GUI;
using CloudMagic.Helpers;
using System.Media;
using System.Runtime.InteropServices;
using System.IO;

// ReSharper disable FunctionNeverReturns
// ReSharper disable MemberCanBeProtected.Global
// ReSharper disable PublicConstructorInAbstractClass
// ReSharper disable UnusedMember.Global
// ReSharper disable MemberCanBePrivate.Global

namespace CloudMagic.Rotation
{
    [SuppressMessage("ReSharper", "ParameterHidesMember")]
    public abstract class CombatRoutine
    {
        public enum RotationState
        {
            Stopped = 0,
            Running = 1
        }

        public enum RotationType
        {
            SingleTarget = 0,
            SingleTargetCleave = 1,     // Some classes like Warriors need support for this
            AOE = 2
        }

        public volatile RotationType _rotationType = RotationType.SingleTarget;

        public CombatRoutine combatRoutine;
        private Thread mainThread;

        private frmMain parent;

        private readonly ManualResetEvent pause = new ManualResetEvent(false);

        private int PulseFrequency = 100;

        private readonly Random random;

        public CombatRoutine()
        {
            random = new Random(DateTime.Now.Second);
        }

        public RotationState State { get; private set; } = RotationState.Stopped;
        
        public RotationType Type => _rotationType;

        public abstract string Name { get; }
         public virtual string Class { get; }
        public virtual int CLEAVE { get; }
        public abstract int AOE { get; }
        public abstract int SINGLE { get; }

        [DllImport("User32.dll")]
        private static extern short GetAsyncKeyState(Keys vKey);

        private void MainThreadTick()
        {
            try
            {
                while (true)
                {
                    var key = GetAsyncKeyState(Keys.LShiftKey);
                    if ((key & 0x8000) != 0)
                    {
                        // Pause rotation when left shift is down
                    }
                    else
                    {
                        pause.WaitOne();

                        Overlay.UpdateLabelsCooldowns();
                        Pulse();
                    }
                    
                    Thread.Sleep(PulseFrequency + random.Next(50));
                }
            }
            catch (Exception ex)
            {
                Log.Write(ex.Message, Color.Red);
            }
            Thread.Sleep(random.Next(50)); // Make the bot more human-like add some randomness in
        }

        public bool Load(frmMain parent)
        {
            this.parent = parent;
            PulseFrequency = int.Parse(ConfigFile.Pulse.ToString());
            Log.Write("Using Pulse Frequency (ms) = " + PulseFrequency);

            mainThread = new Thread(MainThreadTick) {IsBackground = true};
            mainThread.Start();

            combatRoutine = this;

            Initialize();
            if (SINGLE == 0 || CLEAVE == 0 || AOE == 0)
            {
                Log.Write("Please set AOE settings with WoWGuiMode(aoe,cleave,single)", Color.Red);
                pause.Reset();
                return false;
            }
            Log.Write($"Single : {SINGLE} Cleave : {CLEAVE} AOE : {AOE} ");
            using (var sr = new StreamWriter($"{SpellBook.AddonPath}\\Gui.Lua"))
            {
                var GuiFile = Directory.GetCurrentDirectory() + "\\LUA\\Gui.lua";
                var GuiContents = File.ReadAllText(GuiFile);
                sr.WriteLine($"local Auto = {{ Single = {SINGLE}, Cleave = {CLEAVE}, AOE = {AOE} }} ");
                sr.WriteLine(GuiContents);
                sr.Close();
            }
            return true;
        }

        public string FileName = "";

        internal void Dispose()
        {
            Log.Write("Stopping Character Info Thread...");
            Log.Write("Stopping Pulse() timer...");

            Pause();

            Thread.Sleep(100); // Wait for it to close entirely so that all bitmap reading is done
        }

        internal void ForcePulseUpdate()
        {
            PulseFrequency = int.Parse(ConfigFile.Pulse.ToString());
            Log.Write("Using Pulse Frequency (ms) = " + PulseFrequency);
        }

        public void Start()
        {
            try
            {
                if (State == RotationState.Stopped)
                {
                    Log.Write("Starting bot...", Color.Green);
                    
                    if (WoW.Process == null)
                    {
                        Log.Write("World of warcraft is not detected / running, please login before attempting to restart the bot", Color.Red);
                        return;
                    }

                    pause.Set();

                    State = RotationState.Running;

                    Overlay.StartLabelUpdate();
                }
            }
            catch (Exception ex)
            {
                Log.Write("Error Starting Combat Routine", Color.Red);
                Log.Write(ex.Message, Color.Red);
            }
        }

        public void Pause()
        {
            try
            {
                if (State == RotationState.Running)
                {
                    Log.Write("Stopping bot.", Color.Black);

                    Stop();

                    pause.Reset();

                    State = RotationState.Stopped;

                    Log.Write("Combat routine has been stopped sucessfully.", Color.IndianRed);

                    Overlay.StopLabelUpdate();
                }
            }
            catch (Exception ex)
            {
                Log.Write("Error Stopping Combat Routine", Color.Red);
                Log.Write(ex.Message, Color.Red);
            }
        }

        public void ChangeType(RotationType rotationType)
        {
            if (_rotationType == rotationType ||WoW.WoWGuiOn) return;

            _rotationType = rotationType;

            Log.Write("Rotation type: " + rotationType);

            WoW.Speak(rotationType.ToString());

            if (ConfigFile.PlayErrorSounds)
            {
                SystemSounds.Beep.Play();
            }

            Overlay.updateLabels();
        }




        private bool lastNamePlate = false;
        public void SelectRotation(int aoe, int cleave, int single)
        {
            int count = WoW.CountEnemyNPCsInRange;
            if (!lastNamePlate)
            {
                ChangeType(RotationType.SingleTarget);
                lastNamePlate = true;
            }
            lastNamePlate = WoW.Nameplates;
            if (count >= aoe )
                ChangeType(RotationType.AOE);
            if (count == cleave)
                ChangeType(RotationType.SingleTargetCleave);
            if (count <= single)
                ChangeType(RotationType.SingleTarget);

        }

        private bool useCooldowns;

        public bool UseCooldowns
        {
            get
            {
                return useCooldowns;
            }
            set
            {
                useCooldowns = value;

                Log.Write("UseCooldowns = " + value);

                Overlay.UpdateLabelsCooldowns();
            }
        }
       
        public abstract void Initialize();
        public abstract void Stop();
        public abstract void Pulse();
        public abstract Form SettingsForm { get; set; }
    }
}