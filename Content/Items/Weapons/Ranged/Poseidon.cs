using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TremorMod.Content.Items.Weapons.Ranged
{
	public class Poseidon : ModItem
	{
		public override void SetDefaults()
		{
			Item.damage = 26;
			Item.width = 16;
			Item.height = 32;
			Item.useTime = 27;
			Item.DamageType = DamageClass.Ranged;
			Item.shoot = 1;
			Item.shootSpeed = 15f;
			Item.useAnimation = 27;
			Item.useStyle = 5;
			Item.knockBack = 5;
			Item.value = 12540;
			Item.useAmmo = AmmoID.Arrow;
			Item.rare = 3;
			Item.UseSound = SoundID.Item5;
			Item.autoReuse = true;
		}

		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("Poseidon");
			//Tooltip.SetDefault("");
		}

		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-8, 0);
		}

		//public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		//{		
		//	type = mod.ProjectileType("ElectricBolt");			
		//	return base.Shoot(player, ref position, ref speedX, ref speedY, ref type, ref damage, ref knockBack);
		//}	

	}
}
