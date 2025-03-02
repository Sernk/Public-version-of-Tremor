using Terraria;
using Terraria.ModLoader;
using TremorMod;
using TremorMod.Content.Buffs;
using TremorMod.Utilities;

namespace TremorMod.Content.Items.Accessories
{
	public class BottledSpirit : ModItem
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
			Item.value = 60000;
			Item.rare = 7;
			Item.accessory = true;
			Item.defense = 3;
		}

		/*public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Bottled Spirit");
			Tooltip.SetDefault("Using flask also spawns two homing souls\n" +
			"Damage of the souls scales on flask damage");
		}*/

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
            MPlayer modPlayer = player.GetModPlayer<MPlayer>();
            player.AddBuff(ModContent.BuffType<BottledSpiritBuffs>(), 2);
            modPlayer.enchanted = true;
        }
	}
}
