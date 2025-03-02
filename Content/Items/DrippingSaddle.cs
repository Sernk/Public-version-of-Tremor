using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TremorMod.Content.Mounts;
using TremorMod.Content.Items.Materials;

namespace TremorMod.Content.Items
{
	public class DrippingSaddle : ModItem
	{
		public override void SetDefaults()
		{
			Item.width = 14;
		    Item.height = 36;
			Item.useTime = 30;
			Item.useAnimation = 30;
			Item.useStyle = 1;
			Item.value = 8000;
			Item.rare = 3;
			Item.UseSound = SoundID.Item44;
			Item.noMelee = true;
			Item.mountType = ModContent.MountType<DripplerMount>();
		}
    

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.GoldBar, 5);
            recipe.AddIngredient(ModContent.ItemType<AtisBlood>(), 10);
            recipe.AddIngredient(ModContent.ItemType<DrippingRoot>(), 15);
            //recipe.SetResult(this);
            recipe.AddTile(134);
            recipe.Register();    

            Recipe recipe1 = CreateRecipe();
            recipe1.AddIngredient(ItemID.PlatinumBar, 5);
            recipe1.AddIngredient(ModContent.ItemType<AtisBlood>(), 10);
            recipe1.AddIngredient(ModContent.ItemType<DrippingRoot>(), 15);
            //recipe1.SetResult(this);
            recipe1.AddTile(134);
            recipe1.Register();
        }
    }
}