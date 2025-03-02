using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TremorMod.Content.Items.EvilCornItems
{
	public class FarmerShovel : ModItem
	{

		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("Farmer's Shovel");
			//Tooltip.SetDefault("''She wants to get it back..''\n" +
			//"Allows the Farmer to move in");
		}

		public override void SetDefaults()
		{
			Item.damage = 8;
			Item.DamageType = DamageClass.Melee;
			Item.width = 42;
			Item.height = 42;
			Item.useTime = 17;
			Item.useAnimation = 17;
			Item.pick = 45;
			Item.useStyle = 1;
			Item.knockBack = 2;
			Item.value = 1000;
			Item.rare = 1;
			Item.UseSound = SoundID.Item1;
			Item.useTurn = true;
			Item.autoReuse = true;
		}
	}
}