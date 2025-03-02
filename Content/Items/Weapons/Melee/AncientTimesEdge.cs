using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TremorMod.Content.Items.Weapons.Melee
{
	public class AncientTimesEdge : ModItem
	{
		public override void SetDefaults()
		{
			Item.damage = 18;
			Item.DamageType = DamageClass.Melee;
			Item.width = 36;
			Item.height = 44;
			Item.useTime = 35;
			Item.useAnimation = 35;
			Item.useStyle = 1;
			Item.useTurn = true;
			Item.knockBack = 6f;
			Item.value = 30000;
			Item.rare = 2;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
			Item.shootSpeed = 15f;
			Item.shoot = 270;
		}

		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("Ancient Times Edge");
			//Tooltip.SetDefault("Summons ancient skulls on swing");
		}
	}
}