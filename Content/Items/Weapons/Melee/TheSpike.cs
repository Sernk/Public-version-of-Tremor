using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TremorMod.Content.Projectiles;

namespace TremorMod.Content.Items.Weapons.Melee
{
	public class TheSpike : ModItem
	{
		public override void SetDefaults()
		{
			Item.CloneDefaults(3279);

			Item.damage = 23;
			Item.width = 30;
			Item.height = 26;
			Item.shoot = ModContent.ProjectileType<TheSpikePro>();
			Item.knockBack = 4;
			Item.value = 30000;
			Item.rare = 3;
		}

		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("The Spike");
			// Tooltip.SetDefault("");
		}

	}
}
