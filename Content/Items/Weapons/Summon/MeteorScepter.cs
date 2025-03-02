using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TremorMod.Content.Projectiles.Minions;
using TremorMod.Content.Buffs;

namespace TremorMod.Content.Items.Weapons.Summon
{
	public class MeteorScepter : ModItem
	{
		public override void SetDefaults()
		{
			Item.damage = 19;
			Item.DamageType = DamageClass.Summon;
			Item.mana = 12;
			Item.width = 26;
			Item.height = 28;
			Item.useTime = 36;
			Item.useAnimation = 36;
			Item.useStyle = 1;
			Item.noMelee = true;
			Item.knockBack = 3;
			Item.value = Item.buyPrice(0, 2, 0, 0);
			Item.rare = 3;
			Item.UseSound = SoundID.Item44;
			Item.shoot = ModContent.ProjectileType<MeteorScepterPro>();
			Item.shootSpeed = 1f;
			Item.buffType = ModContent.BuffType<MeteorBuff>();
			Item.buffTime = 3600;
		}

		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("Meteor Scepter");
			//Tooltip.SetDefault("Summons a meteor head to fight for you.");
		}

        public override bool Shoot(Player player, Terraria.DataStructures.EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockBack)
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
