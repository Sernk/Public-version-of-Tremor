using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TremorMod.Content.Items.Buffs
{
	public class SpiderMeat : ModItem
	{
		public override void SetDefaults()
		{
			Item.width = 20;
			Item.height = 30;
			Item.maxStack = 20;
			Item.rare = 1;
			Item.useAnimation = 15;
			Item.useTime = 15;
			Item.useStyle = 2;
			Item.UseSound = SoundID.Item2;
			Item.consumable = true;
		}

		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("Spider Meat");
			//Tooltip.SetDefault("'I don't see anything wrong with it, eat it!'");
		}

		public override bool? UseItem(Player player)
		{
			player.AddBuff(BuffID.Darkness, 10000, true);
			player.AddBuff(BuffID.Slow, 10000, true);
			player.AddBuff(BuffID.Confused, 10000, true);
			return true;
		}
	}
}
