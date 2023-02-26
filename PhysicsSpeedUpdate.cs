using System.Collections.Generic;
using System.Linq;
using System.Text;
using OptionalUI;
using Partiality.Modloader;
using UnityEngine;

namespace PhysicsSpeedConfig
{
    public class PhysicsSpeedConfig : PartialityMod
    {
        public static OptionInterface LoadOI()
        {
            return new Config();
        }

        public PhysicsSpeedConfig()
        {
            instance = this;
            this.ModID = "PhysicsSpeedConfig";
            this.Version = "1";
            this.author = "laura#2871";
        }
        public static PhysicsSpeedConfig instance;

        public override void OnEnable()
        {
            base.OnEnable();
            On.MainLoopProcess.RawUpdate += MainLoopProcess_RawUpdate;
        }

        private void MainLoopProcess_RawUpdate(On.MainLoopProcess.orig_RawUpdate orig, MainLoopProcess self, float dt)
        {
            if (DoToggle)
            {
                if (Input.GetKey(SlowDownKey))
                {
                    if (!SlowKeyPressed)
                    {
                        IsSlowed = !IsSlowed;
                        SlowKeyPressed = true;
                    }
                }
                else if (SlowKeyPressed) SlowKeyPressed = false;

                if (Input.GetKey(SpeedUpKey))
                {
                    if (!SpeedKeyPressed)
                    {
                        IsSpeeded = !IsSpeeded;
                        SpeedKeyPressed = true;
                    }
                }
                else if (SpeedKeyPressed) SpeedKeyPressed = false;
            }
            else
            {
                if (Input.GetKey(SlowDownKey)) IsSlowed = true;
                else IsSlowed = false;

                if (Input.GetKey(SpeedUpKey)) IsSpeeded = true;
                else IsSpeeded = false;
            }

            if (IsSlowed)
            {
                self.framesPerSecond = Mathf.RoundToInt(self.framesPerSecond * SlowDownMult);
            }
            if (IsSpeeded)
            {
                self.framesPerSecond = Mathf.RoundToInt(self.framesPerSecond * SpeedUpMult);
            }

            orig(self, dt);
        }

        public static float SlowDownMult;
        public static float SpeedUpMult;
        public static KeyCode SlowDownKey;
        public static KeyCode SpeedUpKey;
        public static bool DoToggle;
        public bool SlowKeyPressed = false;
        public bool SpeedKeyPressed = false;
        public bool IsSlowed = false;
        public bool IsSpeeded = false;
    }
}