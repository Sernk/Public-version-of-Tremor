using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TremorMod.Content.Items.Weapons.Magic
{
	//ported from my tAPI mod because I don't want to make more artwork
	public class Eyezor : ModItem
	{
		public override void SetDefaults()
		{
			Item.damage = 37;
			Item.DamageType = DamageClass.Magic;
			Item.width = 20;
			Item.height = 12;
			Item.useTime = 6;
			Item.useAnimation = 20;
			Item.useStyle = 5;
			Item.knockBack = 6;
			Item.value = Item.buyPrice(0, 5, 0, 0);
			Item.rare = 5;
			Item.mana = 7;
			Item.useStyle = 5;
			Item.UseSound = SoundID.Item20;
			Item.noMelee = true;
			Item.autoReuse = true;
			Item.shoot = 606;
			Item.shootSpeed = 30f;
		}

		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("Eyezor");
			//Tooltip.SetDefault("");
		}
	}
}