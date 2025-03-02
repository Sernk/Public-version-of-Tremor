using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TremorMod.Content.Items.Armor.Stone
{
	[AutoloadEquip(EquipType.Body)]
	public class StoneChestplate : ModItem
	{
		public override void SetDefaults()
		{
			Item.width = 34;
			Item.height = 22;
			Item.value = Item.sellPrice(silver: 1);
			Item.rare = 1;
			Item.defense = 3;
		}

		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Stone Chestplate");
			// Tooltip.SetDefault("10% reduced melee speed\nThe stone protects you, but makes you slower");
		}

		public override void UpdateEquip(Player player)
		{
			player.GetAttackSpeed(DamageClass.Melee) -= 0.1f;
        }

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.StoneBlock, 45);
			//recipe.SetResult(this);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}