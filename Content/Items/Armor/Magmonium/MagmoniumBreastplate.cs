using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TremorMod.Content.Items.Materials.OreAndBar;
using TremorMod.Utilities;

namespace TremorMod.Content.Items.Armor.Magmonium
{
	[AutoloadEquip(EquipType.Body)]
	public class MagmoniumBreastplate : ModItem
	{

		public override void SetDefaults()
		{
			Item.defense = 25;
			Item.width = 22;
			Item.height = 30;
			Item.value = 60000;
			Item.rare = 8;
		}

		/*public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Magmonium Breastplate");
			Tooltip.SetDefault("12% increased damage");
		}*/

		public override void UpdateEquip(Player player)
		{
            player.GetDamage(DamageClass.Melee) += 0.12f;   // +13% к ближнему урону
            player.GetDamage(DamageClass.Magic) += 0.12f;   // +13% к магическому урону
            player.GetDamage(DamageClass.Ranged) += 0.12f;  // +13% к дальнему урону
            player.GetDamage(DamageClass.Throwing) += 0.12f; // +13% к урону бросков
            player.GetDamage(DamageClass.Summon) += 0.12f;  // +13% к урону прислужников
            player.GetModPlayer<MPlayer>().alchemicalDamage += 0.12f; // +12% к алхимическому урону
        }

        public override void AddRecipes()
		{
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<MagmoniumBar>(), 25);
            //recipe.SetResult(this);
			recipe.AddTile(134);
            recipe.Register();
        }
	}
}
