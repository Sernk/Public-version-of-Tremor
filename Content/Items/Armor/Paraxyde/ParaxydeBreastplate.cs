using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TremorMod.Content.Items.Materials;
using TremorMod.Content.Tiles;

namespace TremorMod.Content.Items.Armor.Paraxyde
{
	[AutoloadEquip(EquipType.Body)]
	public class ParaxydeBreastplate : ModItem
	{
		public override void SetDefaults()
		{
			Item.width = 38;
			Item.height = 22;
			Item.value = 10000;
			Item.rare = 5;
			Item.defense = 22;
		}

		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("Paraxyde Breastplate");
			//Tooltip.SetDefault("Increases melee and magic criticals strike chance by 15");
		}

		public override void UpdateEquip(Player player)
		{
			player.GetCritChance(DamageClass.Melee) += 15;
			player.GetCritChance(DamageClass.Magic) += 15;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<ParaxydeShard>(), 18);
			//recipe.SetResult(this);
			recipe.AddTile(ModContent.TileType<AlchematorTile>());
			recipe.Register();
		}
	}
}