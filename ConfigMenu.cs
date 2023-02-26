using System;
using OptionalUI;
using UnityEngine;

namespace PhysicsSpeedConfig
{
	public class Config : OptionInterface
	{
		public Config() : base(PhysicsSpeedConfig.instance)
		{
		}

		public override bool Configuable()
		{
			return true;
		}

		public override void ConfigOnChange()
		{
			PhysicsSpeedConfig.SlowDownMult = float.Parse(config["D1"]) / 100f;
			PhysicsSpeedConfig.SpeedUpMult  = float.Parse(config["D2"]) / 100f;
			PhysicsSpeedConfig.SlowDownKey  = (KeyCode)Enum.Parse(typeof(KeyCode), config["D3"]);
			PhysicsSpeedConfig.SpeedUpKey   = (KeyCode)Enum.Parse(typeof(KeyCode), config["D4"]);
			PhysicsSpeedConfig.DoToggle     = !bool.Parse(config["D5"]);
		}

		public override void Initialize()
		{
			base.Initialize();
			this.Tabs = new OpTab[]
			{
				new OpTab("Config")
			};
			OpLabel labelAuthor = new OpLabel(20f, 570f, "physicsspeedconfig mod by pinecubes", true);
			OpLabel labelPing = new OpLabel(20f, 500f, "laura#2871 for any questions or suggestions!", false);
			OpLabel labelNote = new OpLabel(200f, 530f, "Configure keys to change the physics speed while ingame!", false);

			int top = 200;

			OpLabel labelSlowMul = new OpLabel(20f, (600 - top), "Slowdown multiplier", false);
			OpLabel labelSlowPercent = new OpLabel(356f, (600 - top + 2), "%", false);
			OpTextBox typerSlowMul = new OpTextBox(new Vector2(300f, (600 - top)), 50, "D1", "25", OpTextBox.Accept.Int)
			{
				description = "25% by default",
				colorEdge = Color.clear,
				colorText = new Color(122f, 216f, 255f)
			};
			OpLabel labelSpeedMul = new OpLabel(20f, (600 - top - 30), "Speedup multiplier", false);
			OpLabel labelSpeedPercent = new OpLabel(356f, (600 - top - 30 + 2), "%", false);
			OpTextBox typerSpeedMul = new OpTextBox(new Vector2(300f, (600 - top - 30)), 50, "D2", "300", OpTextBox.Accept.Int)
			{
				description = "300% by default",
				colorEdge = Color.clear,
				colorText = new Color(122f, 216f, 255f)
			};
			OpLabel labelSlowKey = new OpLabel(20f, (600 - top - 60), "Slowdown keybind", false);
			OpKeyBinder binderSlowKey = new OpKeyBinder(new Vector2(300f, 600 - top - 60), new Vector2(50, 15), mod.ModID, "D3", 334.ToString(), true, OpKeyBinder.BindController.AnyController)
			{ };
			OpLabel labelSpeedKey = new OpLabel(20f, (600 - top - 90), "Speedup keybind", false);
			OpKeyBinder binderSpeedKey = new OpKeyBinder(new Vector2(300f, (600 - top - 90)), new Vector2(50, 15), mod.ModID, "D4", 335.ToString(), true, OpKeyBinder.BindController.AnyController)
			{ };
			OpLabel labelToggleToggle = new OpLabel(20f, (600 - top - 120), "Require key held", false);
			OpCheckBox toggleToggleToggle = new OpCheckBox(new Vector2(300f, (600 - top - 120)), "D5")
			{
				description = "off by default"
			};
			this.Tabs[0].AddItems(new UIelement[]
			{
				labelAuthor,
				labelPing,
				labelNote,
				labelSlowMul,
				labelSlowPercent,
				typerSlowMul,
				labelSpeedMul,
				labelSpeedPercent,
				typerSpeedMul,
				labelSlowKey,
				binderSlowKey,
				labelSpeedKey,
				binderSpeedKey,
				labelToggleToggle,
				toggleToggleToggle,
			});
		}
	}
}
