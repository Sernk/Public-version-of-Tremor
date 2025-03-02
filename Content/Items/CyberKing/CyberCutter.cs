using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TremorMod.Content.Projectiles;

namespace TremorMod.Content.Items.CyberKing
{
	public class CyberCutter : ModItem
	{
		public override void SetDefaults()
		{
			Item.damage = 76;
			Item.DamageType = DamageClass.Magic;
            Item.width = 38;
			Item.height = 38;
			Item.scale = 1.1f;
			Item.maxStack = 1;
			Item.useTime = 45;
			Item.useAnimation = 45;
			Item.knockBack = 4f;
			Item.UseSound = SoundID.Item23;
			Item.noMelee = true;
			Item.channel = true;
			Item.noUseGraphic = true;
			Item.useTurn = true;
			Item.useStyle = 5;
			Item.value = 10000;
			Item.rare = 5;
            Item.shoot = ModContent.ProjectileType<CyberCutterPro>();
            Item.shootSpeed = 5f;
			Item.mana = 14;
		}

        /*public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Cyber Cutter");
			Tooltip.SetDefault("Casts a controllable saw");
		}*/

        public override bool Shoot(Player player, Terraria.DataStructures.EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            player.channel = true; // Установка свойства "channel" для конкретного игрока
            return true;
        }

    }
}
