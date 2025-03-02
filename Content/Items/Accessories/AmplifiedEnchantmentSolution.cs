using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TremorMod;
using TremorMod.Content.Buffs;
using TremorMod.Content.Items.Weapons.Alchemical;
using TremorMod.Utilities;

namespace TremorMod.Content.Items.Accessories
{
	public class AmplifiedEnchantmentSolution : ModItem
	{
		/*public override bool CanEquipAccessory(Player player, int slot)
		{
			for (int i = 0; i < player.armor.Length; i++)
			{
				MPlayer modPlayer = (MPlayer)player.GetModPlayer(mod, "MPlayer");
				if (modPlayer.enchanted)
				{
					return false;
				}
			}
			return true;
		}*/

		public override void SetDefaults()
		{
			Item.width = 26;
			Item.height = 30;
			Item.value = 350000;
			Item.rare = 7;
			Item.accessory = true;
		}

		/*public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Amplified Enchantment Solution");
			Tooltip.SetDefault("45% chance not to consume flask");
		}*/

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<EnchantmentSolution>(), 2);
			recipe.AddIngredient(ItemID.Bottle, 10);
			recipe.AddIngredient(ItemID.SoulofLight, 14);
			recipe.AddIngredient(ItemID.SoulofNight, 14);
			recipe.AddIngredient(ItemID.ChlorophyteBar, 10);
			recipe.AddIngredient(ItemID.HallowedBar, 6);
			recipe.AddIngredient(ItemID.ManaCrystal, 3);
			recipe.AddIngredient(ItemID.LifeCrystal, 3);
			recipe.AddIngredient(ModContent.ItemType<BasicFlask>(), 15);
			//recipe.SetResult(this);
			recipe.AddTile(134);
			recipe.Register();
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
            MPlayer modPlayer = player.GetModPlayer<MPlayer>();
            player.AddBuff(ModContent.BuffType<AmplifiedEnchantmentSolutionBuffs>(), 2);
            modPlayer.enchanted = true;
        }
	}
}
