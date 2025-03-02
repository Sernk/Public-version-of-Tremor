using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;

namespace TremorMod.Content.Biomes.Ice.Items
{
	[AutoloadEquip(EquipType.Shield)]
	public class FrostGuardian : ModItem
	{
		public override void SetDefaults()
		{
			Item.width = 26;
			Item.height = 34;
			Item.value = 110;
			Item.rare = 1;
			Item.accessory = true;
			Item.defense = 4;
		}

		/*public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Frost Guardian");
			Tooltip.SetDefault("Grants immunity to all frost debuffs \n" +
			"5% increased melee damage and speed");
		}*/

		public override void UpdateEquip(Player player)
		{
			player.moveSpeed += 0.20f;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.GetDamage(DamageClass.Melee) += 0.05f;
            player.GetAttackSpeed(DamageClass.Melee) += 0.05f; 
            player.buffImmune[44] = true;
			player.buffImmune[45] = true;
			player.buffImmune[46] = true;
			player.buffImmune[47] = true;
		}
	}
}
