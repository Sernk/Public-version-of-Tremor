using Terraria;
using Terraria.ID;
using Terraria.DataStructures;
using Terraria.ModLoader;

namespace TremorMod.Content.Items.Accessories
{
	public class DopelgangerCandle : ModItem
	{
		public override void SetDefaults()
		{
			Item.width = 22;
			Item.height = 36;
			Item.value = 1250;
			Item.rare = 5;
			Item.accessory = true;
		}

		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("Dopelganger Candle");
			//Tooltip.SetDefault("'Takes a piece of your soul in return for additional minion'\n" +
			//"6% increased minion damage");
			Main.RegisterItemAnimation(Item.type, new DrawAnimationVertical(10, 4));
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.statLifeMax2 -= 25;
			player.maxMinions += 1;
			player.GetDamage(DamageClass.Summon) += 0.06f;
        }
	}
}