using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TremorMod.Content.Buffs;

namespace TremorMod.Content.Items.Fungus
{
	public class GoldenGlowingRing : ModItem
	{
		public override void SetDefaults()
		{
			Item.width = 22;
			Item.height = 44;
			Item.value = 10000;
			Item.rare = 11;
			Item.expert = true;
			Item.accessory = true;
		}

		/*public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Golden Glowing Ring");
			Tooltip.SetDefault("Summons two blades to protect you\n" +
			"Blue has a chance to inflict confusion on enemy, yellow can inflict midas.");
		}*/

		public override void UpdateEquip(Player player)
		{
			player.AddBuff(ModContent.BuffType<GoldenGlowingRingBuff>(), 2);
		}
	}
}
