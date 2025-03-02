using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TremorMod.Utilities;
using TremorMod.Content.Items.HeaterOfWorldsItems;
using TremorMod.Content.Buffs;

namespace TremorMod.Content.Items.Accessories
{
	public class FlaskCore : ModItem
	{
		public override void SetDefaults()
		{
			Item.width = 22;
			Item.height = 24;

			Item.value = 50000;
			Item.rare = 6;
			Item.accessory = true;
		}

		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Flask Core");
			// Tooltip.SetDefault("Flasks now have autoreuse");
		}

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.AddBuff(ModContent.BuffType<FlaskCoreBuff>(), 2);
            MPlayer modPlayer = player.GetModPlayer<MPlayer>();
            modPlayer.core = true;
        }
    }
}
