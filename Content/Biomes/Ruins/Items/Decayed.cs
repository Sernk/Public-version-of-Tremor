using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TremorMod.Content.Biomes.Ruins.Items
{
	public class Decayed : ModItem
	{
		public override void SetDefaults()
		{
			Item.damage = 18;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 60;
			Item.height = 22;
			Item.useTime = 15;
			Item.useAnimation = 15;
			Item.shoot = 10;
			Item.shootSpeed = 12f;
			Item.useAmmo = AmmoID.Bullet;
			Item.useStyle = 5;
			Item.knockBack = 4;
			Item.value = 10000;
			Item.rare = 2;
			Item.UseSound = SoundID.Item11;
			Item.autoReuse = true;
		}

		/*public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Decayed");
			Tooltip.SetDefault("");
		}*/

		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-16, 0);
		}
	}
}
