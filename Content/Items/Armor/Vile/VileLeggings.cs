using Terraria;
using Terraria.ModLoader;

namespace TremorMod.Content.Items.Armor.Vile
{
	[AutoloadEquip(EquipType.Legs)]
	public class VileLeggings : ModItem
	{

		public override void SetDefaults()
		{

			Item.width = 38;
			Item.height = 22;

			Item.value = 30000;
			Item.rare = 1;
			Item.defense = 1;
		}

		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Vile Leggings");
			/* Tooltip.SetDefault("6% increased minion damage\n" +
"Increases your max number of minions"); */
		}

		public override void UpdateEquip(Player player)
		{
			player.maxMinions += 1;
			player.GetDamage(DamageClass.Summon) += 0.06f;
		}

	}
}
