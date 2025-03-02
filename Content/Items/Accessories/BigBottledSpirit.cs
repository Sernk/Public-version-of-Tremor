using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TremorMod.Content.Buffs;
using TremorMod.Utilities;

namespace TremorMod.Content.Items.Accessories
{
	public class BigBottledSpirit : ModItem
	{
		/*public override bool CanEquipAccessory(Player player, int slot)
		{
			for (int i = 0; i < player.armor.Length; i++)
			{
				MPlayer modPlayer = (MPlayer)player.GetModPlayer(mod, "MPlayer");
				if (modPlayer.spirit)
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
			Item.value = 80000;
			Item.rare = 7;
			Item.accessory = true;
			Item.defense = 4;
		}

		/*public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Big Bottled Spirit");
			Tooltip.SetDefault("Using flask also spawns four homing souls\n" +
			"Damage of the souls scales on flask damage");
		}*/

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
            MPlayer modPlayer = player.GetModPlayer<MPlayer>();
            player.AddBuff(ModContent.BuffType<BigBottledSpiritBuffs>(), 2);
            modPlayer.enchanted = true;
        }

        public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.Bottle, 3);
			recipe.AddIngredient(ItemID.HallowedBar, 12);
			recipe.AddIngredient(ItemID.Ectoplasm, 15);
			recipe.AddIngredient(ItemID.Sapphire, 8);
			recipe.AddIngredient(ModContent.ItemType<BottledSpirit>(), 1);
			//recipe.SetResult(this);
			recipe.AddTile(134);
			recipe.Register();
		}
	}
}
