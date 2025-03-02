using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using TremorMod.Content.Projectiles.Minions;
using TremorMod.Content.Buffs;

namespace TremorMod.Content.Items.Weapons.Summon
{
	public class QuetzalcoatlStave : ModItem
	{
		public override void SetDefaults()
		{
			Item.damage = 80;
            Item.DamageType = DamageClass.Summon;
            Item.mana = 10;
			Item.width = 26;
			Item.height = 28;
			Item.useTime = 36;
			Item.useAnimation = 36;
			Item.useStyle = 1;
			Item.noMelee = true;
			Item.knockBack = 3;
			Item.value = 1000000;
			Item.rare = 11;
			Item.UseSound = SoundID.Item44;
			Item.shoot = ModContent.ProjectileType<QuetzalcoatlPro>();
			Item.shootSpeed = 2f;
			Item.buffType = ModContent.BuffType<QuetzalcoatlBuff>();
			Item.buffTime = 3600;
		}

		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("Baby Quetzalcoatl Stave");
			//Tooltip.SetDefault("Summons a baby quetzalcoatl to fight for you.");
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
