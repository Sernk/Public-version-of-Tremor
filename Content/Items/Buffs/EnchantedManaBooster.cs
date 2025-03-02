using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TremorMod.Content.Tiles;
using TremorMod.Content.Buffs;
using TremorMod.Content.Items.Materials;

namespace TremorMod.Content.Items.Buffs
{
	public class EnchantedManaBooster : ModItem
	{
		public override void SetDefaults()
		{
			Item.useAnimation = 15;
			Item.useTime = 15;
			Item.useStyle = 4;
			Item.width = 22;
			Item.UseSound = SoundID.Item43;
			Item.height = 18;
			Item.buffType = ModContent.BuffType<ExtendedManaBooster>();
			Item.value = 5160000;
			Item.rare = 11;
		}

		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("Enchanted Mana Booster");
			//Tooltip.SetDefault("Regenerates mana every 45 seconds");
		}

        public override void UseStyle(Player player, Rectangle heldItemFrame)
        {
			if (player.whoAmI == Main.myPlayer && player.itemTime == 0)
			{
				player.AddBuff(Item.buffType, 2700, true);
			}
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<ManaBooster>(), 1);
            recipe.AddIngredient(ModContent.ItemType<GoldenClaw>(), 15);
            recipe.AddIngredient(ModContent.ItemType<StarBar>(), 1);
            recipe.AddIngredient(ModContent.ItemType<AngryShard>(), 1);
            //recipe.SetResult(this);
            recipe.AddTile(ModContent.TileType<MagicWorkbenchTile>());
            recipe.Register();
        }
	}
}
