using Terraria.ID;
using Terraria.ModLoader;

namespace TremorMod.Content.Items.Weapons.Magic
{
	public class StarfallTome : ModItem
	{
		public override void SetDefaults()
		{
			Item.damage = 25;
			Item.DamageType = DamageClass.Magic;
			Item.width = 50;
			Item.height = 55;
			Item.useTime = 30;
			Item.mana = 20;
			Item.useAnimation = 30;
			Item.useStyle = 5;
			Item.shoot = 9;
			Item.shootSpeed = 30f;
			Item.knockBack = 3;
			Item.value = 30000;
			Item.rare = 3;
			Item.UseSound = SoundID.Item4;
			Item.autoReuse = false;
		}

		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Starfall Tome");
			// Tooltip.SetDefault("");
		}

	}
}
