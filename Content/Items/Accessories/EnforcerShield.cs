using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TremorMod.Content.Items.Accessories
{
	[AutoloadEquip(EquipType.Shield)]
	public class EnforcerShield : ModItem
	{
		public override void SetDefaults()
		{
			Item.width = 36;
			Item.height = 42;
			Item.value = 3000000;
			Item.defense = 50;
			Item.rare = 11;
			Item.accessory = true;
		}

		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("Enforcer's Shield");
			//Tooltip.SetDefault("Increases melee damage and speed as health lowers\n" +
			//"Increased invincibility after taking damage");
		}

		public override void UpdateAccessory(Player player, bool hideVisual)

		{
			player.longInvince = true;
			if (player.statLife <= (player.statLifeMax2 * 0.8f))
			{
				player.GetDamage(DamageClass.Melee) *= 1.2f;
                player.GetAttackSpeed(DamageClass.Melee) *= 1.05f;
			}
			else if (player.statLife <= (player.statLifeMax2 * 0.6f))
			{
                player.GetDamage(DamageClass.Melee) *= 1.1f;
                player.GetAttackSpeed(DamageClass.Melee) *= 1.4f;
            }
			else if (player.statLife <= (player.statLifeMax2 * 0.4f))
			{
                player.GetDamage(DamageClass.Melee) *= 1.15f;
                player.GetAttackSpeed(DamageClass.Melee) *= 1.6f;
            }
			else if (player.statLife <= (player.statLifeMax2 * 0.2f))
			{
                player.GetDamage(DamageClass.Melee) *= 1.2f;
                player.GetAttackSpeed(DamageClass.Melee) *= 1.8f;
            }
		}

	}
}
