using Terraria;
using Terraria.ModLoader;
using TremorMod.Content.Buffs;

namespace TremorMod.Content.Items.Accessories
{
	public class BallnChain : ModItem
	{
		public override void SetDefaults()
		{
			Item.width = 22;
			Item.height = 44;
			Item.value = 75000;
			Item.rare = 3;
			Item.accessory = true;
			Item.defense = 3;
		}

		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("Ball n' Chain");
			//Tooltip.SetDefault("Grants a spinning ball around the player");
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.AddBuff(ModContent.BuffType<BallnChainBuff>(), 2);
		}
	}
}
