using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using TremorMod.Content.Projectiles;
using TremorMod.Content.Buffs;

namespace TremorMod.Content.Items.Weapons.Summon
{
	public class StrayStaff : ModItem
	{

		public override void SetDefaults()
		{

			Item.damage = 120;
			Item.DamageType = DamageClass.Summon;
			Item.mana = 12;
			Item.width = 26;
			Item.height = 28;

			Item.useTime = 15;
			Item.useAnimation = 15;
			Item.useStyle = 1;
			Item.noMelee = true;
			Item.value = Item.buyPrice(0, 2, 0, 0);
			Item.rare = 11;
			Item.UseSound = SoundID.Item44;
			Item.shoot = ModContent.ProjectileType<Mini_Cyber>();
			Item.shootSpeed = 1f;
			Item.buffType = ModContent.BuffType<CyberBuff>();
			Item.buffTime = 3600;
		}

		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Stray Staff");
			// Tooltip.SetDefault("Summons a cyber stray to fight for you");
		}

		public override bool AltFunctionUse(Player player)
		{
			return true;
		}

		public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
		{
			return player.altFunctionUse != 2;
		}
	}
}
