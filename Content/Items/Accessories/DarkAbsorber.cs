using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TremorMod.Content.Items.Accessories
{
	[AutoloadEquip(EquipType.Shield)]
	public class DarkAbsorber : ModItem
	{
		public override void SetDefaults()
		{
			Item.width = 24;
			Item.height = 28;
			Item.value = 45000;
			Item.rare = 5;
			Item.accessory = true;
			Item.defense = 3;
		}

		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("Dark Absorber");
			//Tooltip.SetDefault("Gives health when in Corruption");
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			if (player.ZoneCorrupt)
			{
				player.statLifeMax2 += 100;
			}
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.DemoniteBar, 28);
			recipe.AddIngredient(ItemID.ShadowScale, 45);
			recipe.AddIngredient(ItemID.SoulofNight, 15);
			//recipe.SetResult(this);
			recipe.AddTile(134);
			recipe.Register();
		}
	}
}
