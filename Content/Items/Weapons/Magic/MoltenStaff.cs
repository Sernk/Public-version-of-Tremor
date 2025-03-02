using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TremorMod.Content.Items.Materials;
using TremorMod.Content.Items.HeaterOfWorldsItems;

namespace TremorMod.Content.Items.Weapons.Magic
{
	public class MoltenStaff : ModItem
	{
		public override void SetDefaults()
		{
			Item.damage = 26;
			Item.DamageType = DamageClass.Magic;
			Item.mana = 8;
			Item.width = 48;
			Item.height = 48;
			Item.useTime = 25;
			Item.useAnimation = 25;
			Item.useStyle = 5;
			Item.staff[Item.type] = true;
			//Item.noMelee = true;
			Item.knockBack = 5;
			Item.value = 17500;
			Item.rare = 2;
			Item.UseSound = SoundID.Item20;
			Item.autoReuse = true;
			Item.shoot = 85;
			Item.shootSpeed = 6f;
		}

		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("Molten Staff");
			//Tooltip.SetDefault("Casts flames to burn your enemies!");
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<FireFragment>(), 15);
			recipe.AddIngredient(ModContent.ItemType<MoltenParts>(), 1);
			//recipe.SetResult(this);
			recipe.AddTile(16);
			recipe.Register();
		}
	}
}