using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TremorMod;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics; 
using TremorMod.Content.NPCs.Bosses.NovaPillar.Items;

namespace TremorMod.Content.Items.Tools
{
	public class NovaPickaxe : ModItem
	{
		public override void SetDefaults()
		{
			Item.damage = 80;
			Item.DamageType = DamageClass.Melee;
			Item.width = 38;
			Item.height = 38;
			Item.useTime = 7;
			Item.useAnimation = 11;
			Item.pick = 225;
			Item.useStyle = 1;
			Item.knockBack = 5;
			Item.value = 50000;
			Item.rare = 10;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
			Item.tileBoost += 4;
			Item.useTurn = true;
		}

		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("Nova Pickaxe");
			//Tooltip.SetDefault("");
			AddGlowMask(Item.type, "TremorMod/Content/Items/Tools/NovaPickaxe_Glow");
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<NovaFragment>(), 12);
			recipe.AddIngredient(3467, 10);
			recipe.AddTile(412);
			//recipe.SetResult(this);
			recipe.Register();
		}

        private void AddGlowMask(int itemType, string texturePath)
        {
            Texture2D texture = ModContent.Request<Texture2D>(texturePath).Value;
        }
    }
}
