using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TremorMod.Content.Items.Armor.Paladin
{
	[AutoloadEquip(EquipType.Body)]
	public class PaladinBreastplate : ModItem
	{

		public override void SetDefaults()
		{
			Item.width = 26;
			Item.height = 18;
			Item.value = 600000;
			Item.rare = 10;
			Item.defense = 32;
		}

		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("Paladin Breastplate");
			//Tooltip.SetDefault("25% increased melee critical strike chance");
		}

		public override void UpdateEquip(Player player)
		{
			player.GetCritChance(DamageClass.Melee) += 25;
		}
	}
}
