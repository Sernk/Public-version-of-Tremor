using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.DataStructures;
using TremorMod.Content.Projectiles;
using TremorMod.Content.Buffs;

namespace TremorMod.Utilities
{
	public class TremorProjectiles : GlobalProjectile
	{

		public override void SetDefaults(Projectile projectile)
		{
			if (Main.gameMenu) return;

			if (projectile.minion && Main.player[Main.myPlayer].active && Main.player[Main.myPlayer].FindBuffIndex(Mod.Find<ModBuff>("ZephyrhornBuff").Type) != -1)
			{
				projectile.scale = 1.5f;
				projectile.width *= (int)1.5f;
				projectile.height *= (int)1.5f;
			}

			if ((projectile.type != Mod.Find<ModProjectile>("SparkingCloudPro").Type || projectile.type != Mod.Find<ModProjectile>("AlchemasterPoisonCloudPro").Type) && (projectile.aiStyle == 92 || projectile.type == Mod.Find<ModProjectile>("PurpleBurst").Type || projectile.type == Mod.Find<ModProjectile>("PurpleSkull").Type || projectile.type == Mod.Find<ModProjectile>("PurpleSkullburst").Type || projectile.type == Mod.Find<ModProjectile>("ShadowBurst").Type || projectile.type == Mod.Find<ModProjectile>("ShadowSkull").Type || projectile.type == Mod.Find<ModProjectile>("ShadowSkullburst").Type || projectile.type == Mod.Find<ModProjectile>("ManaSkull").Type || projectile.type == Mod.Find<ModProjectile>("ManaSkullburst").Type || projectile.type == Mod.Find<ModProjectile>("MoonBurst").Type || projectile.type == Mod.Find<ModProjectile>("MoonSkull").Type || projectile.type == Mod.Find<ModProjectile>("MoonSkullburst").Type || projectile.type == Mod.Find<ModProjectile>("PoisonBurst").Type || projectile.type == Mod.Find<ModProjectile>("PoisonSkull").Type || projectile.type == Mod.Find<ModProjectile>("PoisonSkullburst").Type || projectile.type == Mod.Find<ModProjectile>("HealingSkullburst").Type || projectile.type == Mod.Find<ModProjectile>("HealingSkull").Type || projectile.type == Mod.Find<ModProjectile>("HealingSkullburst").Type || projectile.type == Mod.Find<ModProjectile>("ManaBurst").Type || projectile.type == Mod.Find<ModProjectile>("GoldenBurst").Type || projectile.type == Mod.Find<ModProjectile>("GoldenSkull").Type || projectile.type == Mod.Find<ModProjectile>("GoldenSkullburst").Type || projectile.type == Mod.Find<ModProjectile>("HealingBurst").Type || projectile.type == Mod.Find<ModProjectile>("FierySkullburst").Type || projectile.type == Mod.Find<ModProjectile>("FrostBurst").Type || projectile.type == Mod.Find<ModProjectile>("FrostSkull").Type || projectile.type == Mod.Find<ModProjectile>("FrostSkullburst").Type || projectile.type == Mod.Find<ModProjectile>("BasicBurst").Type || projectile.type == Mod.Find<ModProjectile>("BasicSkull").Type || projectile.type == Mod.Find<ModProjectile>("BasicSkullburst").Type || projectile.type == Mod.Find<ModProjectile>("BoomBurst").Type || projectile.type == Mod.Find<ModProjectile>("BoomSkull").Type || projectile.type == Mod.Find<ModProjectile>("BoomSkullburst").Type || projectile.type == Mod.Find<ModProjectile>("ClusterBurst").Type || projectile.type == Mod.Find<ModProjectile>("ClusterSkull").Type || projectile.type == Mod.Find<ModProjectile>("ClusterSkullburst").Type || projectile.type == Mod.Find<ModProjectile>("CrystalBurst").Type || projectile.type == Mod.Find<ModProjectile>("CrystalSkull").Type || projectile.type == Mod.Find<ModProjectile>("FieryBurst").Type || projectile.type == Mod.Find<ModProjectile>("CrystalSkull").Type || projectile.type == Mod.Find<ModProjectile>("FierySkull").Type || projectile.type == Mod.Find<ModProjectile>("BoomBlast").Type || projectile.type == Mod.Find<ModProjectile>("CrystalBlast").Type || projectile.type == Mod.Find<ModProjectile>("FieryBlast").Type || projectile.type == Mod.Find<ModProjectile>("FrostBlast").Type || projectile.type == Mod.Find<ModProjectile>("GoldenBlast").Type || projectile.type == Mod.Find<ModProjectile>("HealingBlast").Type || projectile.type == Mod.Find<ModProjectile>("ManaBlast").Type || projectile.type == Mod.Find<ModProjectile>("MoonBlast").Type || projectile.type == Mod.Find<ModProjectile>("PlagueBlast").Type || projectile.type == Mod.Find<ModProjectile>("PoisonBlast").Type || projectile.type == Mod.Find<ModProjectile>("PurpleBlast").Type || projectile.type == Mod.Find<ModProjectile>("ShadowBlast").Type || projectile.type == Mod.Find<ModProjectile>("SparkingBlast").Type || projectile.type == Mod.Find<ModProjectile>("SparkingBallz").Type) && Main.player[Main.myPlayer].active && Main.player[Main.myPlayer].FindBuffIndex(Mod.Find<ModBuff>("FlaskExpansionBuff").Type) != -1)
			{
				projectile.scale = 1.2f;
				projectile.width *= (int)1.2f;
				projectile.height *= (int)1.2f;
			}
		}

		public override void AI(Projectile projectile)
		{
			if (projectile.aiStyle == 88 && projectile.knockBack == .5f || (projectile.knockBack >= .2f && projectile.knockBack < .5f))
			{
				projectile.hostile = false;
				projectile.friendly = true;
				projectile.DamageType = DamageClass.Magic;
				projectile.penetrate = -1;
				if ((projectile.knockBack >= .45f && projectile.knockBack < .5f) && projectile.oldVelocity != projectile.velocity && Main.rand.Next(0, 4) == 0)
				{
					projectile.knockBack -= .0125f;
					Vector2 vector83 = projectile.velocity.RotatedByRandom(.1f);
					Projectile.NewProjectile(projectile.GetSource_FromThis(), projectile.Center.X, projectile.Center.Y, vector83.X, vector83.Y, projectile.type, projectile.damage, projectile.knockBack - .025f, projectile.owner, projectile.velocity.ToRotation(), projectile.ai[1]);
				}
			}
		}

		public override void OnHitNPC(Projectile projectile, NPC target, NPC.HitInfo hit, int damageDone)
		{
			if (projectile.aiStyle == 88 && (projectile.knockBack >= .2f && projectile.knockBack <= .5f))
			{
				target.immune[projectile.owner] = 6;
			}

			if ((projectile.type != Mod.Find<ModProjectile>("SparkingCloudPro").Type || projectile.type != Mod.Find<ModProjectile>("AlchemasterPoisonCloudPro").Type) && (projectile.aiStyle == 92 || projectile.type == Mod.Find<ModProjectile>("PurpleBurst").Type || projectile.type == Mod.Find<ModProjectile>("PurpleSkull").Type || projectile.type == Mod.Find<ModProjectile>("PurpleSkullburst").Type || projectile.type == Mod.Find<ModProjectile>("ShadowBurst").Type || projectile.type == Mod.Find<ModProjectile>("ShadowSkull").Type || projectile.type == Mod.Find<ModProjectile>("ShadowSkullburst").Type || projectile.type == Mod.Find<ModProjectile>("ManaSkull").Type || projectile.type == Mod.Find<ModProjectile>("ManaSkullburst").Type || projectile.type == Mod.Find<ModProjectile>("MoonBurst").Type || projectile.type == Mod.Find<ModProjectile>("MoonSkull").Type || projectile.type == Mod.Find<ModProjectile>("MoonSkullburst").Type || projectile.type == Mod.Find<ModProjectile>("PoisonBurst").Type || projectile.type == Mod.Find<ModProjectile>("PoisonSkull").Type || projectile.type == Mod.Find<ModProjectile>("PoisonSkullburst").Type || projectile.type == Mod.Find<ModProjectile>("HealingSkullburst").Type || projectile.type == Mod.Find<ModProjectile>("HealingSkull").Type || projectile.type == Mod.Find<ModProjectile>("HealingSkullburst").Type || projectile.type == Mod.Find<ModProjectile>("ManaBurst").Type || projectile.type == Mod.Find<ModProjectile>("GoldenBurst").Type || projectile.type == Mod.Find<ModProjectile>("GoldenSkull").Type || projectile.type == Mod.Find<ModProjectile>("GoldenSkullburst").Type || projectile.type == Mod.Find<ModProjectile>("HealingBurst").Type || projectile.type == Mod.Find<ModProjectile>("FierySkullburst").Type || projectile.type == Mod.Find<ModProjectile>("FrostBurst").Type || projectile.type == Mod.Find<ModProjectile>("FrostSkull").Type || projectile.type == Mod.Find<ModProjectile>("FrostSkullburst").Type || projectile.type == Mod.Find<ModProjectile>("BasicBurst").Type || projectile.type == Mod.Find<ModProjectile>("BasicSkull").Type || projectile.type == Mod.Find<ModProjectile>("BasicSkullburst").Type || projectile.type == Mod.Find<ModProjectile>("BoomBurst").Type || projectile.type == Mod.Find<ModProjectile>("BoomSkull").Type || projectile.type == Mod.Find<ModProjectile>("BoomSkullburst").Type || projectile.type == Mod.Find<ModProjectile>("ClusterBurst").Type || projectile.type == Mod.Find<ModProjectile>("ClusterSkull").Type || projectile.type == Mod.Find<ModProjectile>("ClusterSkullburst").Type || projectile.type == Mod.Find<ModProjectile>("CrystalBurst").Type || projectile.type == Mod.Find<ModProjectile>("CrystalSkull").Type || projectile.type == Mod.Find<ModProjectile>("FieryBurst").Type || projectile.type == Mod.Find<ModProjectile>("CrystalSkull").Type || projectile.type == Mod.Find<ModProjectile>("FierySkull").Type || projectile.type == Mod.Find<ModProjectile>("BoomBlast").Type || projectile.type == Mod.Find<ModProjectile>("CrystalBlast").Type || projectile.type == Mod.Find<ModProjectile>("FieryBlast").Type || projectile.type == Mod.Find<ModProjectile>("FrostBlast").Type || projectile.type == Mod.Find<ModProjectile>("GoldenBlast").Type || projectile.type == Mod.Find<ModProjectile>("HealingBlast").Type || projectile.type == Mod.Find<ModProjectile>("ManaBlast").Type || projectile.type == Mod.Find<ModProjectile>("MoonBlast").Type || projectile.type == Mod.Find<ModProjectile>("PlagueBlast").Type || projectile.type == Mod.Find<ModProjectile>("PoisonBlast").Type || projectile.type == Mod.Find<ModProjectile>("PurpleBlast").Type || projectile.type == Mod.Find<ModProjectile>("ShadowBlast").Type || projectile.type == Mod.Find<ModProjectile>("SparkingBlast").Type || projectile.type == Mod.Find<ModProjectile>("SparkingBallz").Type) && Main.player[Main.myPlayer].active && Main.player[Main.myPlayer].FindBuffIndex(Mod.Find<ModBuff>("CursedCloudBuff").Type) != -1)
			{
				target.AddBuff(31, 360, false);
			}
		}
		public override bool? CanHitNPC(Projectile projectile, NPC target)
		{
			if (projectile.aiStyle == 88 && ((projectile.knockBack == .5f || projectile.knockBack == .4f) || (projectile.knockBack >= .4f && projectile.knockBack < .5f)) && target.immune[projectile.owner] > 0)
			{
				return false;
			}
			return null;
		}

	}
}

