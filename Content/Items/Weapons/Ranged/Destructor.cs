using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TremorMod.Content.Items.Weapons.Ranged
{
	public class Destructor : ModItem
	{
		public override void SetDefaults()
		{
			Item.damage = 40;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 40;
			Item.height = 40;
			Item.useTime = 10;
			Item.useAnimation = 10;
			Item.shoot = 14;
			Item.shootSpeed = 8f;
			Item.useAmmo = AmmoID.Bullet;
			Item.useStyle = 5;
			Item.knockBack = 4;
			Item.value = 60000;
			Item.rare = 5;
			Item.UseSound = SoundID.Item11;
			Item.autoReuse = true;
		}

		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("The Destructor");
			//Tooltip.SetDefault("'Exterminate!'");
		}

        public override bool CanConsumeAmmo(Item ammo, Player player)
        {
            return !Main.rand.NextBool(2); 
        }

        public override Vector2? HoldoutOffset()
		{
			return new Vector2(-18, -4);
		}
	}
}
