using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;
using Microsoft.Xna.Framework;
using TremorMod;
using TremorMod.Content.Projectiles;
using TremorMod.Content.Buffs;
using TremorMod.Utilities;

namespace TremorMod.Content.Items.Weapons.Alchemical
{
	// todo: redo
	public class WallOfShadowsFlask : ModItem
    {
		const float ShootRange = 600.0f;
		const float ShootKN = 1.0f;
		const int ShootRate = 180;
		int ShootCount = 3;
		const float ShootSpeed = 8f;
		const int spread = 45;
		const float spreadMult = 0.045f;
		int TimeToShoot = ShootRate;

		public override void SetDefaults()
		{
            Item.DamageType = TremorMod.alchemicalDamage ?? DamageClass.Generic;
            Item.damage = 70;
			Item.knockBack = 3;
			Item.width = 26;
			Item.height = 30;
			Item.crit = 4;
			Item.value = Item.sellPrice(gold: 5);
			Item.rare = 9;
			Item.expert = true;
			Item.accessory = true;
		}

		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("Flask of Shadows");
			//Tooltip.SetDefault("Casts shadow flask at nearby enemies\n" +
			//"The less health, the more count of flasks");
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			if (--TimeToShoot <= 0)
			{
				TimeToShoot = ShootRate;
				int Target = GetTarget();
				if (Target != -1) Shoot(Target, GetDamage());
			}
		}

		int GetTarget()
		{
			int Target = -1;
			for (int k = 0; k < Main.npc.Length; k++)
			{
				if (Main.npc[k].active && Main.npc[k].lifeMax > 5 && !Main.npc[k].dontTakeDamage && !Main.npc[k].friendly && Main.npc[k].Distance(Main.player[Item.playerIndexTheItemIsReservedFor].Center) <= ShootRange && Collision.CanHitLine(Main.player[Item.playerIndexTheItemIsReservedFor].Center, 4, 4, Main.npc[k].Center, 4, 4))
				{
					Target = k;
					break;
				}
			}
			return Target;
		}

		int GetDamage()
		{
			return (10 * (int)Main.player[Item.playerIndexTheItemIsReservedFor].GetModPlayer<MPlayer>().alchemicalDamage) + 50;
		}

		void Shoot(int Target, int Damage)
		{
			if (Main.player[Item.playerIndexTheItemIsReservedFor].statLife < 50)
			{
				ShootCount = 7;
			}
			if (Main.player[Item.playerIndexTheItemIsReservedFor].statLife < 100)
			{
				ShootCount = 6;
			}
			if (Main.player[Item.playerIndexTheItemIsReservedFor].statLife < 200)
			{
				ShootCount = 5;
			}
			if (Main.player[Item.playerIndexTheItemIsReservedFor].statLife < 300)
			{
				ShootCount = 4;
			}

			Vector2 velocity = Helper.VelocityToPoint(Main.player[Item.playerIndexTheItemIsReservedFor].Center, Main.npc[Target].Center, ShootSpeed);
			for (int l = 0; l < ShootCount; l++)
			{
				velocity.X = velocity.X + Main.rand.Next(-spread, spread + 1) * spreadMult;
				velocity.Y = velocity.Y + Main.rand.Next(-spread, spread + 1) * spreadMult;
                int i = Projectile.NewProjectile(Main.player[Item.playerIndexTheItemIsReservedFor].GetSource_FromThis(), Main.player[Item.playerIndexTheItemIsReservedFor].Center.X, Main.player[Item.playerIndexTheItemIsReservedFor].Center.Y, velocity.X, velocity.Y, ModContent.ProjectileType<WallOfShadowsFlask_Proj>(), Damage, ShootKN, Item.playerIndexTheItemIsReservedFor);

            }
        }
	}
}
