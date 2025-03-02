using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using TremorMod.Content.Projectiles.Minions;
using TremorMod.Content.Buffs;

namespace TremorMod.Content.Items.Weapons.Summon
{
	public class RichMahoganySeed : ModItem
	{
		public override void SetDefaults()
		{
			Item.damage = 38;
            Item.DamageType = DamageClass.Summon;
            Item.mana = 10;
			Item.width = 26;
			Item.height = 28;
			Item.useTime = 36;
			Item.channel = true;
			Item.useAnimation = 36;
			Item.useStyle = 4;
			Item.noMelee = true;
			Item.knockBack = 3;
			Item.value = Item.buyPrice(0, 3, 0, 0);
			Item.rare = 3;
			Item.UseSound = SoundID.Item44;
			Item.shoot = ModContent.ProjectileType<Hunter>();
			Item.shootSpeed = 2f;
			Item.buffType = ModContent.BuffType<HunterBuff>();
			Item.buffTime = 3600;
		}

		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("Rich Mahogany Seed");
			//Tooltip.SetDefault("Summons a lil' snatcher to fight for you.");
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