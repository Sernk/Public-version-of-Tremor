using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TremorMod.Content.Items.Armor.Orcish
{
	[AutoloadEquip(EquipType.Body)]
	public class OrcishBreastplate : ModItem
	{

		public override void SetDefaults()
		{
			Item.width = 26;
			Item.height = 18;
			Item.value = 600;
			Item.rare = 1;
			Item.defense = 4;
		}

		/*public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Orcish Breastplate");
			Tooltip.SetDefault("15% increased melee speed");
		}*/

		public override void UpdateEquip(Player player)
		{
            player.GetAttackSpeed(DamageClass.Melee) += 0.15f;
        }

	}
}
