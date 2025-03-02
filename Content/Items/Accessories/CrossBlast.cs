using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TremorMod.Utilities;
using TremorMod.Content.Buffs;
using TremorMod.Content.Items.Materials;

namespace TremorMod.Content.Items.Accessories
{
	public class CrossBlast : ModItem
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
			//DisplayName.SetDefault("Cross Blast");
			//Tooltip.SetDefault("Alchemical projectiles leave explosions in the shape of cross");
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.ExplosivePowder, 25);
			recipe.AddIngredient(ModContent.ItemType<Chemikaze>(), 1);
			recipe.AddIngredient(ItemID.HellstoneBar, 25);
			recipe.AddIngredient(ItemID.SoulofMight, 3);
			//recipe.SetResult(this);
			recipe.AddTile(114);
			recipe.Register();

			Recipe recipe1 = CreateRecipe();
			recipe1.AddIngredient(ItemID.ExplosivePowder, 25);
			recipe1.AddIngredient(ModContent.ItemType<Chemikaze>(), 1);
			recipe1.AddIngredient(ItemID.HellstoneBar, 25);
			recipe1.AddIngredient(ModContent.ItemType<SoulofMind>(), 3);
			//recipe.SetResult(this);
			recipe1.AddTile(114);
			recipe1.Register();
		}

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            MPlayer modPlayer = player.GetModPlayer<MPlayer>();
            player.AddBuff(ModContent.BuffType<CrossBlastBuff>(), 2);
            modPlayer.enchanted = true;
        }
    }
}
