using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TremorMod.Content.Items.Materials;

namespace TremorMod.Content.Items.Armor.Berserker
{
	[AutoloadEquip(EquipType.Body)]
	public class BerserkerChestplate : ModItem
	{

		public override void SetDefaults()
		{
			Item.width = 26;
			Item.height = 18;
			Item.value = 600;
			Item.rare = 2;
			Item.defense = 6;
		}

        /*public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Berserker Chestplate");
			Tooltip.SetDefault("7% increased melee critical strike chance");
		}*/

        public override void UpdateEquip(Player player)
        {
            player.GetCritChance(DamageClass.Melee) += 7; // Увеличивает шанс крита для ближнего боя на 7%
        }


        public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<SteelBar>(), 20);
            recipe.AddIngredient(ModContent.ItemType<MinotaurHorn>(), 1);
            recipe.AddIngredient(ModContent.ItemType<EarthFragment>(), 10);
			recipe.AddTile(16);
			recipe.Register();
		}
	}
}
