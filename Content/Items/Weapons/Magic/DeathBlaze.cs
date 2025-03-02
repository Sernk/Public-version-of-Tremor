using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TremorMod.Content.Items.Weapons.Magic
{
	public class DeathBlaze : ModItem
	{
		public override void SetDefaults()
		{
			Item.damage = 26;
			Item.DamageType = DamageClass.Magic;
			Item.width = 28;
			Item.height = 30;
			Item.useTime = 12;
			Item.useAnimation = 12;
			Item.shoot = 585;
			Item.shootSpeed = 11f;
			Item.mana = 4;
			Item.useStyle = 5;
			Item.knockBack = 3;
			Item.value = 99999;
			Item.rare = 5;
			Item.UseSound = SoundID.Item20;
			Item.autoReuse = true;
		}

		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("Death Blaze");
			//Tooltip.SetDefault("");
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.BookofSkulls, 1);
			recipe.AddIngredient(ItemID.SpellTome, 1);
			recipe.AddIngredient(ItemID.SoulofNight, 15);
			//recipe.SetResult(this);
			recipe.AddTile(101);
			recipe.Register();
		}
	}
}