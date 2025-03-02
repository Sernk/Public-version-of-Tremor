using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TremorMod.Content.Projectiles;

namespace TremorMod.Content.Items.Weapons.Throwing
{
	public class IchorBreath : ModItem
	{
		public override void SetDefaults()
		{
			Item.damage = 55;
			Item.DamageType = DamageClass.Throwing;
			Item.width = 18;
			Item.height = 18;
			Item.useTime = 14;
			Item.maxStack = 999;
			Item.useAnimation = 14;
			Item.shoot = ModContent.ProjectileType<IchorBreathPro>();
			Item.shootSpeed = 8f;
			Item.useStyle = 1;
			Item.knockBack = 3;
			Item.value = 155;
			Item.rare = 5;
			Item.consumable = true;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
		}

		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("Ichor Breath");
			//Tooltip.SetDefault("");
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe(25);
			recipe.AddIngredient(ModContent.ItemType<DragonBreath>(), 25);
			recipe.AddIngredient(ItemID.Ichor, 3);
			recipe.AddTile(134);
			recipe.Register();
		}
	}
}