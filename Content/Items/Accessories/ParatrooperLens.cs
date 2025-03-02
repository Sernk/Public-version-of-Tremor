using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TremorMod.Content.Buffs;

namespace TremorMod.Content.Items.Accessories
{
	public class ParatrooperLens : ModItem
	{

		public override void SetDefaults()
		{
			Item.width = 27;
			Item.height = 26;
			Item.rare = 11;
			Item.value = 3000000;
			Item.accessory = true;
		}

		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("Paratrooper's Lens");
			//Tooltip.SetDefault("Increases projectile's speed twice");
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.AddBuff(ModContent.BuffType<ShootSpeedBuff2>(), 2);
		}
	}
}
