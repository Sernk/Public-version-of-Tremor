using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TremorMod.Content.Items.BossLoot.TheDarkEmperor
{
	public class DelightfulClump : ModItem
	{
		public override void SetDefaults()
		{
			Item.accessory = true;
			Item.width = 22;
			Item.height = 18;
			Item.value = 250000;
			Item.rare = 11;
		}

		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("Delightful Clump");
			//Tooltip.SetDefault("Increases maximum life by 100\n" +
			//"15% increased critical strike chance");
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.statLifeMax2 += 100;
			player.GetCritChance(DamageClass.Ranged) += 5;
			player.GetCritChance(DamageClass.Melee) += 5;
			player.GetCritChance(DamageClass.Magic) += 5;
			player.GetCritChance(DamageClass.Throwing) += 5;
		}
	}
}