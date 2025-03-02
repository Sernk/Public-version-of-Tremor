using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TremorMod.Content.Buffs;
using TremorMod.Utilities;

namespace TremorMod.Content.Items.Accessories
{
	public class Nitro : ModItem
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
			Item.value = 250000;
			Item.rare = 6;
			Item.accessory = true;
		}

		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("The Nitro");
			//Tooltip.SetDefault("Alchemical flasks leave death flames");
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
            MPlayer modPlayer = player.GetModPlayer<MPlayer>();
            player.AddBuff(ModContent.BuffType<NitroBuff>(), 2);
            modPlayer.nitro = true;
        }
	}
}
