using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TremorMod.Content.Items.Buffs;
using TremorMod.Content.Mounts;

namespace TremorMod.Content.Items
{
	public class WolfToothNecklace : ModItem
	{
		public override void SetDefaults()
		{

			Item.width = 20;
			Item.height = 30;

			Item.useTime = 20;
			Item.useAnimation = 20;
			Item.pick = 220;
			Item.useStyle = 1;
			Item.knockBack = 6;
			Item.value = 30000;
			Item.rare = 2;
			Item.UseSound = SoundID.Item79;
			Item.noMelee = true;
			Item.mountType = ModContent.MountType<Wolf>();
		}

		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Wolf Tooth Necklace");
			// Tooltip.SetDefault("This is a modded mount.");
		}

	}
}
