using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TremorMod.Content.Buffs;

namespace TremorMod.Content.Items.Buffs
{
	public class HealthBooster : ModItem
	{
		public override void SetDefaults()
		{
			Item.useAnimation = 15;
			Item.useTime = 15;
			Item.useStyle = 4;
			Item.width = 22;
			Item.UseSound = SoundID.Item43;
			Item.height = 18;
			Item.buffType = ModContent.BuffType<HealthBoosterBuff>();
			Item.value = 5160000;
			Item.rare = 11;
		}

		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("Health Booster");
			//Tooltip.SetDefault("Regenerates health every minute");
		}

		public override void UseStyle(Player player, Rectangle heldItemFrame)
		{
			if (player.whoAmI == Main.myPlayer && player.itemTime == 0)
			{
				player.AddBuff(Item.buffType, 3600, true);
			}
		}

	}
}
