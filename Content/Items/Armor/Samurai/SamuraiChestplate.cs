using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TremorMod.Content.Items.Armor.Samurai
{
	[AutoloadEquip(EquipType.Body)]
	public class SamuraiChestplate : ModItem
	{

		public override void SetDefaults()
		{
			Item.width = 30;
			Item.height = 18;
			Item.value = 100000;
			Item.rare = 5;
			Item.defense = 14;
		}

		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("Samurai Fullplate");
			//Tooltip.SetDefault("25% increased melee speed");
		}

		public override void UpdateEquip(Player player)
		{
            player.GetAttackSpeed(DamageClass.Generic) += 0.25f;
        }
	}
}
