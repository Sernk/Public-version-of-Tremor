using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TremorMod.Content.Projectiles.Minions;
using TremorMod.Content.Buffs;
using System;
using Terraria.Audio;

namespace TremorMod.Content.Items.Weapons.Summon
{
	public class BirbStaff : ModItem
	{
		public override void SetDefaults()
		{
			Item.damage = 7;
			Item.DamageType = DamageClass.Summon;
			Item.mana = 10;
			Item.width = 46;
			Item.height = 46;
			Item.useTime = 25;
			Item.useAnimation = 25;
			Item.useStyle = 1;
			Item.noMelee = true;
			Item.knockBack = 4;
			Item.value = 8000;
			Item.rare = 2;
			Item.UseSound = SoundID.Item44;
			Item.shoot = ModContent.ProjectileType<BirbStaffPro>();
			Item.shootSpeed = 1f;
			Item.buffType = ModContent.BuffType<BirbStaffBuff>();
			Item.buffTime = 3600;
		}

		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("Birb Staff");
			//Tooltip.SetDefault("Summons a birb to fight for you.");
		}

		public override bool AltFunctionUse(Player player)
		{
			return true;
		}

        public override bool Shoot(Player player, Terraria.DataStructures.EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
			return player.altFunctionUse != 2;
		}

        public override bool? UseItem(Player player)
        {
            if (player.altFunctionUse == 2)
            {
                player.MinionNPCTargetAim(true); 
            }
            return base.UseItem(player);
        }

    }
}
