using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TremorMod;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics; 
using TremorMod.Content.NPCs.Bosses.NovaPillar.Items;

namespace TremorMod.Content.Items.Tools
{
	public class NovaHamaxe : ModItem
	{
		public override void SetDefaults()
		{
			Item.damage = 60;
			Item.DamageType = DamageClass.Melee;
			Item.width = 38;
			Item.height = 38;
			Item.useTime = 9;
			Item.useAnimation = 27;
			Item.axe = 20;
			Item.hammer = 150;
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
			//DisplayName.SetDefault("Nova Hamaxe");
			//Tooltip.SetDefault("");
			//TremorGlowMask.AddGlowMask(Item.type, $"{typeof(NovaHamaxe).NamespaceToPath()}/NovaHamaxe_Glow");
			AddGlowMask(Item.type, "TremorMod/Content/Items/Tools/NovaHamaxe_Glow");
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<NovaFragment>(), 14);
			recipe.AddIngredient(3467, 12);
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
