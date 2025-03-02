using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TremorMod.Content.Items.Materials;
using TremorMod.Content.Tiles;
using TremorMod.Content.Projectiles;

namespace TremorMod.Content.Items.Weapons.Magic
{
	public class DeadFlower : ModItem
	{
		public override void SetDefaults()
		{
			Item.damage = 12;
			Item.DamageType = DamageClass.Magic;
            Item.mana = 4;
			Item.width = 40;
			Item.height = 40;
			Item.useTime = 25;
			Item.useAnimation = 25;
			Item.useStyle = 5;
			Item.staff[Item.type] = true; //this makes the useStyle animate as a staff instead of as a gun
			//item.noMelee = true; //so the item's animation doesn't do damage
			Item.knockBack = 5;
			Item.value = 700;
			Item.rare = 2;
			Item.UseSound = SoundID.Item20;
			Item.autoReuse = true;
			Item.shoot = ModContent.ProjectileType<DeadFlowerPro>();
			Item.shootSpeed = 15f;
		}

		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("Dead Flower");
			//Tooltip.SetDefault("");
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.Wood, 12);
			recipe.AddIngredient(ModContent.ItemType<UntreatedFlesh>(), 5);
			recipe.AddIngredient(ItemID.Lens, 2);
			recipe.AddIngredient(ItemID.FallenStar, 1);
			recipe.AddTile(ModContent.TileType<FleshWorkstationTile>());
			recipe.Register();
		}
	}
}
