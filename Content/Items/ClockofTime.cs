using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TremorMod.Content.Items
{
	public class ClockofTime : ModItem
	{
		public override void SetDefaults()
		{

			Item.width = 16;
			Item.height = 16;

			Item.value = 00001000;
			Item.rare = 5;
			Item.useTurn = true;
			Item.autoReuse = false;
			Item.useStyle = 4;
			Item.useAnimation = 15;
			Item.useTime = 15;
			Item.maxStack = 1;
			Item.mana = 100;
			Item.UseSound = SoundID.Item8;
		}

		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Paradox Clock");
			// Tooltip.SetDefault("Allows you to control the time");
		}

		public override bool? UseItem(Player player)/* tModPorter Suggestion: Return null instead of false */
		{
			if (player.altFunctionUse == 2)
			{
				Main.bloodMoon = true;
				return true;
			}
			if (Main.netMode != 1)
			{
				Main.dayTime = !Main.dayTime;
				Main.time = (Main.dayTime ? 10000f : 0f);
				return true;
			}
			return true;
		}

		public override bool AltFunctionUse(Player player)
		{
			return true;
		}
	}
}
