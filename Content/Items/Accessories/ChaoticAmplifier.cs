using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TremorMod.Content.Items.Accessories
{
	public class ChaoticAmplifier : ModItem
	{

		public override void SetDefaults()
		{
			Item.width = 24;
			Item.height = 28;
			Item.value = 120000;
			Item.rare = 5;
			Item.accessory = true;
			Item.defense = 1;
		}

		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("Chaotic Amplifier");
			//Tooltip.SetDefault("The less health, the more crit chance...");
		}

		public override void UpdateAccessory(Player player, bool hideVisual)

		{
			if (player.statLife < 50)
			{
                player.GetCritChance(DamageClass.Magic) += 20;
                player.GetCritChance(DamageClass.Melee) += 20;
                player.GetCritChance(DamageClass.Ranged) += 20;
			}
			if (player.statLife < 100)
			{
                player.GetCritChance(DamageClass.Magic) += 15;
                player.GetCritChance(DamageClass.Melee) += 15;
                player.GetCritChance(DamageClass.Ranged) += 15;
            }
			if (player.statLife < 200)
			{
                player.GetCritChance(DamageClass.Magic) += 10;
                player.GetCritChance(DamageClass.Melee) += 10;
                player.GetCritChance(DamageClass.Ranged) += 10;
            }
			if (player.statLife < 300)
			{
                player.GetCritChance(DamageClass.Magic) += 5;
                player.GetCritChance(DamageClass.Melee) += 5;
                player.GetCritChance(DamageClass.Ranged) += 5;
            }
		}
	}
}
