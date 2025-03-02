using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TremorMod.Content.Items.Armor.Stone
{
	[AutoloadEquip(EquipType.Legs)]
	public class StoneLeggings : ModItem
	{
		public override void SetDefaults()
		{
			Item.width = 26;
			Item.height = 18;
			Item.value = Item.sellPrice(silver: 1);
			Item.rare = 1;
			Item.defense = 2;
		}

		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Stone Leggings");
			// Tooltip.SetDefault("10% reduced movement speed\nThe stone protects you, but makes you slower");
		}

		public override void UpdateEquip(Player player)
		{
			player.maxRunSpeed -= 0.10f;
			player.moveSpeed -= 0.10f;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.StoneBlock, 30);
			//recipe.SetResult(this);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}
