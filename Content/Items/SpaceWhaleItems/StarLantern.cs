using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TremorMod.Content.Items.SpaceWhaleItems
{
	public class StarLantern : ModItem
	{

		public override void SetDefaults()
		{
			Item.width = 24;
			Item.height = 28;
			Item.value = 50000;
			Item.rare = 11;
			Item.accessory = true;
		}

		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("Star Lantern");
			//Tooltip.SetDefault("25% increased magic damage\n" +
			//"Emits aura of light");
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
            player.AddBuff(BuffID.Shine, 600); // Бафф длится 10 секунд (600 тиков)
            player.GetDamage(DamageClass.Magic) += 0.25f;
		}
	}
}
