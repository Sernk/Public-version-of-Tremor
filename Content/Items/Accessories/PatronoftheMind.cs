using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TremorMod.Content.Items.Accessories
{
	[AutoloadEquip(EquipType.Shield)]
	public class PatronoftheMind : ModItem
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
			//DisplayName.SetDefault("Patron of the Mind");
			//Tooltip.SetDefault("Gives health when in Crimson");
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			if (player.ZoneCrimson)
			{
				player.statLifeMax2 += 100;
			}
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.CrimtaneBar, 28);
			recipe.AddIngredient(ItemID.TissueSample, 45);
			recipe.AddIngredient(ItemID.SoulofNight, 15);
			//recipe.SetResult(this);
			recipe.AddTile(134);
			recipe.Register();
		}
	}
}
