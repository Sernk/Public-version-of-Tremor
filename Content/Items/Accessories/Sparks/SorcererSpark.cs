using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using TremorMod.Content.Items.Materials;

namespace TremorMod.Content.Items.Accessories.Sparks
{
	public class SorcererSpark : ModItem
	{
		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("Sorcerer Spark");
			//Tooltip.SetDefault("3% increased magic damage\n" +
			                   //"8% magic critical strike chance\n" +
			                   //"Increases maximum mana by 20");
			Main.RegisterItemAnimation(Item.type, new DrawAnimationVertical(6, 4));
		}

		public override void SetDefaults()
		{
			Item.width = 22;
			Item.height = 22;
			Item.rare = 1;
			Item.accessory = true;
			Item.value = Item.buyPrice(silver: 1);
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.statManaMax2 += 20;
            player.GetDamage(DamageClass.Magic) += 0.03f;
            player.GetCritChance(DamageClass.Magic) += 8;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<AdventurerSpark>());
			//recipe.SetResult(this);
			recipe.Register();
		}
	}
}
