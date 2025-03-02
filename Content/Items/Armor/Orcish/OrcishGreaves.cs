using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace TremorMod.Content.Items.Armor.Orcish
{
	[AutoloadEquip(EquipType.Legs)]
	public class OrcishGreaves : ModItem
	{

		public override void SetDefaults()
		{
			Item.width = 22;
			Item.height = 18;
			Item.value = 500;
			Item.rare = 1;
			Item.defense = 3;
		}

		/*public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Orcish Greaves");
			Tooltip.SetDefault("7% increased melee damage");
		}*/

		public override void UpdateEquip(Player player)
		{
            player.GetDamage(DamageClass.Melee) += 0.07f;   // +7% к ближнему урону
        }

	}
}
