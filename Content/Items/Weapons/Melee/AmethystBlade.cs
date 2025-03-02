using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TremorMod.Content.Items.Weapons.Melee
{
	public class AmethystBlade : ModItem
	{
		public override void SetDefaults()
		{
			Item.damage = 13;
            Item.DamageType = DamageClass.Melee;
            Item.width = 46;
			Item.height = 48;
			Item.useTime = 25;
			Item.useAnimation = 25;
			Item.useStyle = 1;
			Item.knockBack = 3;
			Item.value = 6400;
			Item.rare = 2;
			Item.UseSound = SoundID.Item15;
			Item.autoReuse = true;
			Item.useTurn = true;
		}

		/*public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Amethyst Blade");
			Tooltip.SetDefault("");
		}*/

		public override void MeleeEffects(Player player, Rectangle hitbox)
		{
			int dust = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, 62);
		}

		public override void AddRecipes()
		{
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.Amethyst, 12);
			//recipe.SetResult(this);
			recipe.AddTile(16);
            recipe.Register();
        }
	}
}
