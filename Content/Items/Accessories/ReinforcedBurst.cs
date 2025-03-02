using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TremorMod.Content.Buffs;
using TremorMod.Utilities;
using TremorMod.Content.Items.Materials.OreAndBar;

namespace TremorMod.Content.Items.Accessories
{
	public class ReinforcedBurst : ModItem
	{
        /*public override bool CanEquipAccessory(Player player, int slot)
		{
			for (int i = 0; i < player.armor.Length; i++)
			{
				MPlayer modPlayer = (MPlayer)player.GetModPlayer(mod, "MPlayer");
				if (modPlayer.nitro)
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
			Item.value = 500000;
			Item.rare = 6;
			Item.accessory = true;
		}

		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("Reinforced Burst");
			//Tooltip.SetDefault("Alchemical flasks leave three death flames");
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.Obsidian, 10);
			recipe.AddIngredient(ModContent.ItemType<Nitro>(), 1);
			recipe.AddIngredient(ModContent.ItemType<ArgiteBar>(), 15);
			recipe.AddIngredient(ItemID.Hellstone);
			//recipe.SetResult(this);
			recipe.AddTile(114);
			recipe.Register();
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
            MPlayer modPlayer = player.GetModPlayer<MPlayer>();
            player.AddBuff(ModContent.BuffType<ReinforcedBurstBuff>(), 2);
            modPlayer.nitro = true;
        }
	}
}
