using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ModLoader;
using TremorMod.Utilities;

namespace TremorMod.Content.Items.Accessories
{
	public class PoisonousPhylactery : ModItem
	{

		const int ShootType = 95; 
		const float ShootRange = 600.0f; 
		const float ShootKN = 1.0f; 
		const int ShootRate = 120; 
		const int ShootCount = 1; 
		const float ShootSpeed = 30f; 
		const int spread = 45; 
		const float spreadMult = 0.045f; 
		int TimeToShoot = ShootRate;

		public override void SetDefaults()
		{

			Item.width = 28;
			Item.height = 36;
			Item.value = 2500;
			Item.rare = 5;

			Item.accessory = true;
		}

		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Poisonous Phylactery");
			/* Tooltip.SetDefault("Melee attacks inflicts poison on enemies\n" +
	  "Shoots out poison bolts at enemies"); */
			Main.RegisterItemAnimation(Item.type, new DrawAnimationVertical(6, 4));
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.AddBuff(79, 60, true);
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
            return (10 * ((int)Main.player[Item.playerIndexTheItemIsReservedFor].GetTotalDamage(DamageClass.Magic).ApplyTo(1f) +
                          (int)Main.player[Item.playerIndexTheItemIsReservedFor].GetTotalDamage(DamageClass.Melee).ApplyTo(1f) +
                          (int)Main.player[Item.playerIndexTheItemIsReservedFor].GetTotalDamage(DamageClass.Summon).ApplyTo(1f) +
                          (int)Main.player[Item.playerIndexTheItemIsReservedFor].GetTotalDamage(DamageClass.Ranged).ApplyTo(1f) +
                          (int)Main.player[Item.playerIndexTheItemIsReservedFor].GetTotalDamage(DamageClass.Throwing).ApplyTo(1f))) + 15;
        }

        void Shoot(int Target, int Damage)
		{
			Vector2 velocity = Helper.VelocityToPoint(Main.player[Item.playerIndexTheItemIsReservedFor].Center, Main.npc[Target].Center, ShootSpeed);
			for (int l = 0; l < ShootCount; l++)
			{
				velocity.X = velocity.X + Main.rand.Next(-spread, spread + 1) * spreadMult;
				velocity.Y = velocity.Y + Main.rand.Next(-spread, spread + 1) * spreadMult;
				int i = Projectile.NewProjectile(Item.GetSource_FromThis(), Main.player[Item.playerIndexTheItemIsReservedFor].Center.X, Main.player[Item.playerIndexTheItemIsReservedFor].Center.Y, velocity.X, velocity.Y, ShootType, Damage, ShootKN, Item.playerIndexTheItemIsReservedFor);
			}
		}
	}
}
