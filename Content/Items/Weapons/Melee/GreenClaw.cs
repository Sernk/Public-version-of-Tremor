using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TremorMod.Content.Items.Weapons.Melee
{
	public class GreenClaw : ModItem
	{
		public override void SetDefaults()
		{
			Item.useStyle = 3;
			Item.useTurn = false;
			Item.useAnimation = 12;
			Item.useTime = 12;
			Item.width = 24;
			Item.height = 28;
			Item.damage = 19;
			Item.knockBack = 4f;
			Item.scale = 0.9f;
			Item.UseSound = SoundID.Item1;
			Item.useTurn = true;
			Item.value = 8400;
			Item.DamageType = DamageClass.Melee;
		}

		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("Green Claw");
			//Tooltip.SetDefault("");
		}
	}
}