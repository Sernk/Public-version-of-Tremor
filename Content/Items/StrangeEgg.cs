using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TremorMod.Content.Buffs;
using TremorMod.Content.Projectiles;

namespace TremorMod.Content.Items
{
	public class StrangeEgg : ModItem
	{
		public override void SetDefaults()
		{
			Item.CloneDefaults(ItemID.Carrot);
			Item.useTime = 25;
			Item.useAnimation = 25;
			Item.rare = 11;
			Item.shoot = ModContent.ProjectileType<Brutty>();
			Item.buffType = ModContent.BuffType<BruttyBuff>();
		}

		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("Strange Egg");
			//Tooltip.SetDefault("Summons an brutty");
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
