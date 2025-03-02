using Terraria;
using Terraria.ModLoader;
using TremorMod.Content.Buffs;

namespace TremorMod.Content.Items.Vanity
{
	[AutoloadEquip(EquipType.Head)]
	public class DakkharnsMask : ModItem
	{
		public override void SetDefaults()
		{
			Item.width = 38;
			Item.height = 22;
			Item.value = 1000000;
			Item.rare = 11;
			Item.defense = 50;
		}

		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("Dakkharn Mask");
			//Tooltip.SetDefault("Summons and ancient predator to defend you from foes\n" +
			//"Predator attacks enemies and inflicts curses");
		}

		public override void UpdateEquip(Player player)
		{
			player.AddBuff(ModContent.BuffType<AncientPredatorBuff>(), 2);
		}
	}
}
