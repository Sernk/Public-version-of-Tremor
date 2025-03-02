using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace TremorMod.Content.Items
{
	class UnpredictableСompass : ModItem
	{
		public override void SetDefaults()
		{

			Item.width = 44;
			Item.height = 48;

			Item.useTime = 30;
			Item.useAnimation = 30;
			Item.useStyle = 4;
			Item.knockBack = 0;
			Item.shoot = 1;
			Item.value = 240000;
			Item.rare = 9;
			Item.expert = true;
			Item.UseSound = SoundID.Item6;
		}

		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Unpredictable compass");
			// Tooltip.SetDefault("Teleports you to a random location");
		}

		public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
		{
			player.TeleportationPotion();
			return false;
		}
	}
}
