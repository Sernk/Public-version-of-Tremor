using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TremorMod.Content.Projectiles;

namespace TremorMod.Content.Items.NPCsDrop
{
	public class AntlionFury : ModItem
	{
		public override void SetDefaults()
		{
			Item.damage = 28;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 48;
			Item.height = 24;
			Item.useTime = 15;
			Item.useAnimation = 15;
			Item.useStyle = 5;
			Item.shoot = ModContent.ProjectileType<Sand>();
			Item.shootSpeed = 17f;
			Item.knockBack = 4;
			Item.value = 10000;
			Item.rare = 5;
			Item.UseSound = SoundID.Item11;
			Item.autoReuse = true;
			Item.useAmmo = AmmoID.Sand;
		}

		/*public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Antlion Fury");
			Tooltip.SetDefault("Quickly shoots sand blocks\n" +
			"Uses sand blocks as ammo");
		}*/

		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-4, 0);
		}
	}
}
