using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TremorMod.Content.Items.Materials;

namespace TremorMod.Content.Items.Accessories
{
	public class NecromancerBelt : ModItem
	{
		public override void SetDefaults()
		{
			Item.width = 30;
			Item.height = 24;
			Item.value = 30000;
			Item.rare = 2;
			Item.accessory = true;
		}

		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("Necromancer Belt");
			//Tooltip.SetDefault("Increases minion knockback by 20%\n" +
			//"Increases your maximum number of minions");
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
            player.GetKnockback(DamageClass.Summon) += 0.2f;
            player.maxMinions += 1;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<StrongBelt>());
			recipe.AddIngredient(1158, 1);
			recipe.AddIngredient(ModContent.ItemType<UntreatedFlesh>(), 25);
			recipe.AddIngredient(ItemID.Bone, 25);
			//recipe.SetResult(this);
			recipe.AddTile(114);
			recipe.Register();
		}
	}
}
