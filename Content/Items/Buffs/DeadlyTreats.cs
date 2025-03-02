using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TremorMod.Content.Items.Buffs
{
	public class DeadlyTreats : ModItem
	{
		public override void SetDefaults()
		{
			Item.width = 20;
			Item.height = 30;
			Item.maxStack = 20;
			Item.rare = 2;
			Item.useAnimation = 15;
			Item.useTime = 15;
			Item.useStyle = 2;
			Item.UseSound = SoundID.Item3;
			Item.consumable = true;
		}

		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("Deadly Treats");
			//Tooltip.SetDefault("Increases life regeneration\n" +
			//"Lowers visibilty");
		}

		public override bool? UseItem(Player player)
		{
            player.AddBuff(BuffID.Regeneration, 10000, true);
            player.AddBuff(BuffID.Darkness, 14400, true);
			player.AddBuff(BuffID.ManaRegeneration, 14400, true);
			return true;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.Bowl, 1);
			recipe.AddIngredient(ModContent.ItemType<SpiderMeat>(), 1);
			recipe.AddIngredient(ItemID.VileMushroom, 2);
			//recipe.SetResult(this);
			recipe.AddTile(96);
			recipe.Register();

			Recipe recipe1 = CreateRecipe();
			recipe1.AddIngredient(ItemID.Bowl, 1);
			recipe1.AddIngredient(ModContent.ItemType<SpiderMeat>(), 1);
			recipe1.AddIngredient(ItemID.ViciousMushroom, 2);
			//recipe1.SetResult(this);
			recipe1.AddTile(96);
			recipe1.Register();
		}
	}
}
