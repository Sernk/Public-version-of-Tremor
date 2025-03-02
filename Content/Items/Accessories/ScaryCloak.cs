using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TremorMod.Content.Items.Accessories
{
	public class ScaryCloak : ModItem
	{

		public override void SetDefaults()
		{

			Item.width = 26;
			Item.height = 20;
			Item.alpha = 100;
			Item.value = 1100;
			Item.rare = 3;
			Item.defense = 3;

			Item.accessory = true;
		}

		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Scary Cloak");
			/* Tooltip.SetDefault("Makes the player invisible\n" +
	  "Increases magic and summon damage and critical strike chanse by 8"); */
		}

		public override void UpdateAccessory(Player player, bool hideVisual)

		{
			player.GetDamage(DamageClass.Magic) += 0.08f;
			player.GetCritChance(DamageClass.Magic) += 8;
			player.GetDamage(DamageClass.Summon) += 0.08f;
			//player.minionCrit += 8;
			player.shroomiteStealth = true;
		}
	}
}
