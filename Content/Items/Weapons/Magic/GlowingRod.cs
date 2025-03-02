using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TremorMod.Content.Projectiles;
using TremorMod.Content.Items.Materials;

namespace TremorMod.Content.Items.Weapons.Magic
{
	public class GlowingRod : ModItem
	{
		public override void SetDefaults()
		{
			Item.damage = 20;
			Item.DamageType = DamageClass.Magic;
			Item.mana = 11;
			Item.width = 40;
			Item.height = 40;
			Item.useTime = 18;
			Item.useAnimation = 18;
			Item.useStyle = 5;
			Item.noMelee = true;
			Item.knockBack = 3;
			Item.value = 13800;
			Item.rare = 4;
			Item.UseSound = SoundID.Item43;
			Item.autoReuse = false;
			Item.staff[Item.type] = true;
			Item.shoot = ModContent.ProjectileType<ZootalooRodPro>();
			Item.shootSpeed = 15f;
		}

		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("Glowing Rod");
			//Tooltip.SetDefault("");
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.AmethystStaff, 1);
			recipe.AddIngredient(ModContent.ItemType<LightBulb>(), 8);
			recipe.AddIngredient(ModContent.ItemType<RockHorn>(), 3);
			recipe.AddTile(16);
			recipe.Register();

            Recipe recipe1 = CreateRecipe();
            recipe1.AddIngredient(ItemID.TopazStaff, 1);
            recipe1.AddIngredient(ModContent.ItemType<LightBulb>(), 8);
            recipe1.AddIngredient(ModContent.ItemType<RockHorn>(), 3);
            recipe1.AddTile(16);
            recipe1.Register();

            Recipe recipe2 = CreateRecipe();
            recipe2.AddIngredient(ItemID.SapphireStaff, 1);
            recipe2.AddIngredient(ModContent.ItemType<LightBulb>(), 8);
            recipe2.AddIngredient(ModContent.ItemType<RockHorn>(), 3);
            recipe2.AddTile(16);
            recipe2.Register();

            Recipe recipe3 = CreateRecipe();
            recipe3.AddIngredient(ItemID.EmeraldStaff, 1);
            recipe3.AddIngredient(ModContent.ItemType<LightBulb>(), 8);
            recipe3.AddIngredient(ModContent.ItemType<RockHorn>(), 3);
            recipe3.AddTile(16);
            recipe3.Register();

            Recipe recipe4 = CreateRecipe();
            recipe4.AddIngredient(ItemID.DiamondStaff, 1);
            recipe4.AddIngredient(ModContent.ItemType<LightBulb>(), 8);
            recipe4.AddIngredient(ModContent.ItemType<RockHorn>(), 3);
            recipe4.AddTile(16);
            recipe4.Register();

            Recipe recipe5 = CreateRecipe();
            recipe5.AddIngredient(ItemID.DiamondStaff, 1);
            recipe5.AddIngredient(ModContent.ItemType<LightBulb>(), 8);
            recipe5.AddIngredient(ModContent.ItemType<RockHorn>(), 3);
            recipe5.AddTile(16);
            recipe5.Register();

		}
	}
}
