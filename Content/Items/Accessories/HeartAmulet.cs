using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TremorMod;

namespace TremorMod.Content.Items.Accessories
{
	public class HeartAmulet : ModItem
	{
		public override void SetDefaults()
		{
			Item.width = 36;
			Item.height = 44;
			Item.value = 1000;
			Item.rare = 4;
			Item.accessory = true;
		}

        /*public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Heart Amulet");
			Tooltip.SetDefault("You respawn with 80% of maximum health after death");
		}*/

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            TremorPlayer modPlayer = player.GetModPlayer<TremorPlayer>();
            modPlayer.heartAmulet = true;
        }

    }
}
