using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TremorMod.Content.Items.Fungus;
using TremorMod.Utilities;

namespace TremorMod.Content.Items.Armor.Fungus
{
	[AutoloadEquip(EquipType.Body)]
	public class FungusBreastplate : ModItem
	{

		public override void SetDefaults()
		{

			Item.width = 18;
			Item.height = 18;
			Item.value = 50000;
			Item.rare = 3;
			Item.defense = 8;
		}

		/*public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Fungus Breastplate");
			Tooltip.SetDefault("13% increased damage");
		}*/

		public override void UpdateEquip(Player player)
		{
			player.GetDamage(DamageClass.Melee) += 0.13f;   // +13% к ближнему урону
			player.GetDamage(DamageClass.Magic) += 0.13f;   // +13% к магическому урону
			player.GetDamage(DamageClass.Ranged) += 0.13f;  // +13% к дальнему урону
			player.GetDamage(DamageClass.Throwing) += 0.13f; // +13% к урону бросков
			player.GetDamage(DamageClass.Summon) += 0.13f;  // +13% к урону прислужников

			// Пользовательский тип урона
			player.GetModPlayer<MPlayer>().alchemicalDamage += 0.13f; // +13% к алхимическому урону
		}


		public override void AddRecipes()
		{
			Recipe recipe1 = CreateRecipe();
			recipe1.AddIngredient(ModContent.ItemType<FungusElement>(), 18);
			recipe1.AddIngredient(ItemID.GlowingMushroom, 15);
			recipe1.AddIngredient(ItemID.GoldChainmail, 1);
			//recipe1.SetResult(this);
			recipe1.AddTile(16);
			recipe1.Register();

			Recipe recipe2 = CreateRecipe();
			recipe2.AddIngredient(ModContent.ItemType<FungusElement>(), 18);
			recipe2.AddIngredient(ItemID.GlowingMushroom, 15);
			recipe2.AddIngredient(ItemID.PlatinumChainmail, 1);
			//recipe2.SetResult(this);
			recipe2.AddTile(16);
			recipe2.Register();
		}
	}
}
/*    public override void AddRecipes()
		{
                        Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<SteelBar>(), 15);
            recipe.AddIngredient(ModContent.ItemType<PhantomSoul>(), 4);
            //recipe.SetResult(this);
            recipe.AddTile(16);
            recipe.Register();
        }*/
