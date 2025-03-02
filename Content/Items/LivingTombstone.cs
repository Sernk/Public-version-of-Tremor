using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TremorMod.Content.Projectiles;
using TremorMod.Content.Buffs;

namespace TremorMod.Content.Items
{
	public class LivingTombstone : ModItem
	{
		public override void SetDefaults()
		{
			Item.CloneDefaults(ItemID.Carrot);
			Item.useTime = 25;
			Item.useAnimation = 25;
			Item.shoot = ModContent.ProjectileType<LivingTombstonePro>();
			Item.buffType = ModContent.BuffType<LivingTombstoneBuff>();
			Item.value = 500000;
		}

		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("Living Tombstone");
			//Tooltip.SetDefault("Summons a living tombstone");
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
