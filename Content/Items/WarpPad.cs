using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TremorMod.Content.Items
{
	public class WarpPad : ModItem
	{

		public override void SetDefaults()
		{

			Item.UseSound = SoundID.Item6;
			Item.useStyle = 4;
			Item.useAnimation = 30;
			Item.useTime = 30;
			Item.width = 32;
			Item.height = 32;

			Item.value = 60000;
			Item.rare = 8;
			Item.mana = 10;
		}

		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Warp Pad");
			// Tooltip.SetDefault("Teleports you to your last death point upon use");
		}

		public override bool? UseItem(Player player)/* tModPorter Suggestion: Return null instead of false */
		{
			if (player.lastDeathPostion != player.position && player.showLastDeath)
			{
				player.Teleport(player.lastDeathPostion, 1, 0);
				//NetMessage.SendData(65, -1, -1, "", 0, player.whoAmI, player.lastDeathPostion.X, player.lastDeathPostion.Y, 1, 0, 0);
				player.showLastDeath = false;
				return true;
			}
			return false;
		}

		public override bool CanUseItem(Player player)
		{
			if (!player.showLastDeath)
			{
				return false;
			}
			return true;
		}
	}
}
