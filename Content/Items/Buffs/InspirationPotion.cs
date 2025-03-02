using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TremorMod.Content.Items.Materials;
using TremorMod.Content.Buffs;

namespace TremorMod.Content.Items.Buffs
{
	public class InspirationPotion : ModItem
	{
		public override void SetDefaults()
		{
			Item.width = 38;
			Item.height = 32;
			Item.maxStack = 20;
			Item.rare = 3;
			Item.useAnimation = 15;
			Item.useTime = 15;
			Item.useStyle = 2;
			Item.UseSound = SoundID.Item3;
			Item.consumable = true;
		}

		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("Inspiration Potion");
			//Tooltip.SetDefault("Increases maximum mana");
		}

		public override bool? UseItem(Player player)
		{
			player.AddBuff(ModContent.BuffType<MaximumCharge>(), 14400);
			return true;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.BottledWater, 1);
			recipe.AddIngredient(314, 1);
			recipe.AddIngredient(313, 1);
			recipe.AddIngredient(ModContent.ItemType<ManaFruit>(), 6);
			recipe.AddTile(13);
			//recipe.SetResult(this);
			recipe.Register();
		}
	}
}