using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TremorMod.Content.Items.Weapons.Melee
{
	public class GlorianaWrath : ModItem
	{
		public override void SetDefaults()
		{
			Item.damage = 54;
			Item.DamageType = DamageClass.Melee;
			Item.width = 40;
			Item.height = 40;
			Item.useTime = 20;
			Item.useAnimation = 20;
			Item.useStyle = 1;
			Item.knockBack = 6;
			Item.value = 20000;
			Item.rare = 9;
			Item.expert = true;
			Item.shoot = 10;
			Item.shootSpeed = 16f;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
		}

		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("Gloriana Wrath");
			//Tooltip.SetDefault("Cleanses infected areas.");
		}
	}
}