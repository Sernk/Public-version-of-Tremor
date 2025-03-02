using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TremorMod.Content.Items.Accessories
{
	public class StrongBelt : ModItem
	{
		public override void SetDefaults()
		{
			Item.width = 30;
			Item.height = 24;
			Item.value = 25000;
			Item.rare = 2;
			Item.accessory = true;
		}

		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("Strong Belt");
			//Tooltip.SetDefault("15% increased minion knockback");
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
            player.GetKnockback(DamageClass.Summon) += 0.15f;
        }
    }
}
