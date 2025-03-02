using Terraria;
using Terraria.ModLoader;

namespace TremorMod.Content.Items.Armor.Golden
{
	[AutoloadEquip(EquipType.Body)]
	public class GoldenRobe : ModItem
	{

		public override void SetDefaults()
		{
			Item.width = 250;
			Item.height = 28;
			Item.value = 35000;
			Item.rare = 2;
			Item.defense = 6;
		}

		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("Golden Robe");
			//Tooltip.SetDefault("5% decreased magic damage\n" +
			//"Increases maximum mana by 40");
		}

		public override void UpdateEquip(Player player)
		{
            player.GetDamage(DamageClass.Magic) -= 0.05f;
			player.statManaMax2 += 40;
		}
	}
}
