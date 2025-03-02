using Terraria;
using Terraria.ModLoader;
using TremorMod.Content.Buffs;
using TremorMod.Utilities;

namespace TremorMod.Content.Items.Accessories
{
	public class Pyro : ModItem
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
			Item.rare = 5;
			Item.accessory = true;
		}

		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("The Pyro");
			//Tooltip.SetDefault("Alchemical flasks leaves an explosion");
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
            MPlayer modPlayer = player.GetModPlayer<MPlayer>();
            player.AddBuff(ModContent.BuffType<PyroBuff>(), 2);
            modPlayer.enchanted = true;
        }
	}
}
