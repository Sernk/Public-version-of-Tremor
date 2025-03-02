using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TremorMod.Content.Projectiles;
using TremorMod.Content.Items.Materials;

namespace TremorMod.Content.Items.Weapons.Throwing
{
	public class HorrificKnife : ModItem
	{
		public override void SetDefaults()
		{
			Item.damage = 80;
			Item.DamageType = DamageClass.Throwing;
			Item.width = 26;
			Item.noUseGraphic = true;
			Item.maxStack = 999;
			Item.consumable = true;
			Item.height = 30;
			Item.useTime = 20;
			Item.useAnimation = 20;
			Item.shoot = ModContent.ProjectileType<HorrificKnifePro>();
			Item.shootSpeed = 22f;
			Item.useStyle = 1;
			Item.knockBack = 4;
			Item.value = 7;
			Item.rare = 11;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
		}

		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("Horrific Knife");
			//Tooltip.SetDefault("");
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe(50);
			recipe.AddIngredient(ItemID.ThrowingKnife, 50);
			recipe.AddIngredient(ModContent.ItemType<ConcentratedEther>(), 1);
			recipe.AddIngredient(ModContent.ItemType<NightmareBar>(), 1);
			//recipe.SetResult(this, 50);
			recipe.AddTile(412);
			recipe.Register();
		}
	}
}
