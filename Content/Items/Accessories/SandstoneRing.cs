using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TremorMod.Content.Items.Accessories
{
	public class SandstoneRing : ModItem
	{

		public override void SetDefaults()
		{
			Item.width = 28;
			Item.height = 20;
			Item.value = 10000;
			Item.rare = 1;
			Item.accessory = true;
			Item.defense = 3;
		}

        /*public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Sandstone Ring ");
			Tooltip.SetDefault("5% increased melee damage\n" +
			"Increases melee critical strike chance by 5");
		}*/

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetDamage(DamageClass.Melee) += 0.05f; // Увеличение урона ближнего боя на 5%
            player.GetCritChance(DamageClass.Melee) += 5; // Увеличение шанса критического удара на 5%
        }
    }
}