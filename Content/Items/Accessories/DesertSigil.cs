using Terraria;
using Terraria.ModLoader;
using TremorMod.Content.Buffs;

namespace TremorMod.Content.Items.Accessories
{
	public class DesertSigil : ModItem
	{

		public override void SetDefaults()
		{

			Item.width = 38;
			Item.height = 34;

			Item.rare = 5;
			Item.accessory = true;
			Item.value = 50000;
		}

		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Desert Sigil");
			// Tooltip.SetDefault("Summons a sigil to shoot your enemies");
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.AddBuff(ModContent.BuffType<DesertSigilBuff>(), 60, true);
		}
	}
}
