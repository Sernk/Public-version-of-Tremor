using Terraria;
using Terraria.DataStructures;
using Terraria.ModLoader;
using TremorMod.Utilities;
using TremorMod.Content.Buffs;

namespace TremorMod.Content.Items.Accessories
{
	public class BlackCauldron : ModItem
	{
		public override void SetDefaults()
		{
			Item.width = 22;
			Item.height = 44;
			Item.value = 100000;
			Item.rare = 4;
			Item.accessory = true;
		}

		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("Black Cauldron");
			//Tooltip.SetDefault("Increased alchemical damage by 12%\n" +
			//"Alchemical weapons confuse your enemies");
			Main.RegisterItemAnimation(Item.type, new DrawAnimationVertical(8, 4));
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
            MPlayer modPlayer = player.GetModPlayer<MPlayer>();
            player.AddBuff(ModContent.BuffType<CursedCloudBuff>(), 2);
            modPlayer.enchanted = true;
        }
	}
}
