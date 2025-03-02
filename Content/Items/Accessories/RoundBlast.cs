using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TremorMod.Content.Buffs;
using TremorMod.Utilities;
using TremorMod.Content.Items.Materials.OreAndBar;

namespace TremorMod.Content.Items.Accessories
{
	public class RoundBlast : ModItem
	{
		/*public override bool CanEquipAccessory(Player player, int slot)
		{
			for (int i = 0; i < player.armor.Length; i++)
			{
				MPlayer modPlayer = (MPlayer)player.GetModPlayer(mod, "MPlayer");
				if (modPlayer.pyro)
				{
					return false;
				}
			}
			return true;
		}*/

		public override void SetDefaults()
		{
			Item.width = 22;
			Item.height = 44;
			Item.value = 300000;
			Item.rare = 6;
			Item.accessory = true;
		}

		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("Round Blast");
			//Tooltip.SetDefault("Alchemical projectiles leave explosions in the shape of round");
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.ExplosivePowder, 25);
			recipe.AddIngredient(ModContent.ItemType<Chemikaze>(), 1);
			recipe.AddIngredient(ModContent.ItemType<ChaosBar>(), 25);
			recipe.AddIngredient(ItemID.SoulofSight, 3);
			//recipe.SetResult(this);
			recipe.AddTile(114);
			recipe.Register();
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
            MPlayer modPlayer = player.GetModPlayer<MPlayer>();
            player.AddBuff(ModContent.BuffType<RoundBlastBuff>(), 2);
            modPlayer.nitro = true;
        }
	}
}
