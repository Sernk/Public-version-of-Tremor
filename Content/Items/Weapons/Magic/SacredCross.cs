using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TremorMod.Content.Items.Weapons.Melee;
using TremorMod.Content.Items.Materials;
using TremorMod.Content.Projectiles;

namespace TremorMod.Content.Items.Weapons.Magic
{
	public class SacredCross : ModItem
	{
		public override void SetDefaults()
		{
			Item.damage = 56;
			Item.DamageType = DamageClass.Magic;
			Item.mana = 8;
			Item.width = 40;
			Item.height = 40;
			Item.useTime = 35;
			Item.useAnimation = 35;
			Item.useStyle = 5;
			Item.staff[Item.type] = true; //this makes the useStyle animate as a staff instead of as a gun
			Item.noMelee = true; //so the item's animation doesn't do damage
			Item.knockBack = 5;
			Item.value = 700;
			Item.rare = 5;
			Item.UseSound = SoundID.Item75;
			Item.autoReuse = true;
			Item.shoot = ModContent.ProjectileType<SacredCrossPro>();
			Item.shootSpeed = 15f;
		}

		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("Sacred Cross");
			//Tooltip.SetDefault("Shoots magical crosses that heal you");
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<WoodenCross>(), 1);
			recipe.AddIngredient(ModContent.ItemType<Opal>(), 3);
			recipe.AddIngredient(ItemID.HallowedBar, 12);
			//recipe.SetResult(this);
			recipe.AddTile(134);
			recipe.Register();
		}
	}
}
