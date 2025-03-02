using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TremorMod.Content.Items.Accessories
{
	[AutoloadEquip(EquipType.Shield)]
	public class OrganicShield : ModItem
	{
		public override void SetDefaults()
		{
			Item.width = 26;
			Item.height = 26;
			Item.value = 12600;
			Item.rare = 8;
			Item.accessory = true;
			Item.defense = 12;
		}

		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("Organic Shield");
			//Tooltip.SetDefault("Gives health when in Corruption and Crimson");
		}

		public override void UpdateEquip(Player player)
		{
			player.moveSpeed -= 0.30f;
			player.aggro += 300;
			if (player.ZoneCorrupt || player.ZoneCrimson)
			{
				player.statLifeMax2 += 100;
			}
		}
		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<MeatShield>(), 1);
			recipe.AddIngredient(ModContent.ItemType<DarkAbsorber>(), 1);
			//recipe.SetResult(this);
			recipe.AddTile(114);
			recipe.Register();

			Recipe recipe1 = CreateRecipe();
            recipe1.AddIngredient(ModContent.ItemType<MeatShield>(), 1);
            recipe1.AddIngredient(ModContent.ItemType<PatronoftheMind>(), 1);
            //recipe.SetResult(this);
            recipe1.AddTile(114);
            recipe1.Register();
        }
	}
}
