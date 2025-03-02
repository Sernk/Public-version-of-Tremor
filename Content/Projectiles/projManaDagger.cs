using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace TremorMod.Content.Projectiles
{
	public class projManaDagger : ModProjectile
	{
		const int ManaPerHit = 2; // Маны за удар по мобу
		int Mana; // Сколько маны уже собрано
		int Hits = 3; // Лимит ударов с кражей маны
		bool NeedAddMana = true; // Системная переменная

		public override void SetDefaults()
		{

			Projectile.width = 14;
			Projectile.height = 28;
			Projectile.aiStyle = 1;
			Projectile.friendly = true;
			Projectile.DamageType = DamageClass.Magic;
			Projectile.penetrate = -1;
			Projectile.timeLeft = 3600;
		}

		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Mana Dagger");

		}

		public override void AI()
		{
			float Light = 0.635f * (3 - (Hits - 1));
			Lighting.AddLight(Projectile.Center, new Vector3(0.0f, Light, Light));
			if (Projectile.Distance(Main.player[Projectile.owner].Center) > 1000f)
				ReturnToPlayer();
			if (Projectile.Distance(Main.player[Projectile.owner].Center) < 25f && NeedAddMana && Projectile.aiStyle == 3)
			{
				NeedAddMana = false;
				Main.player[Projectile.owner].statMana += Mana;
				if (Mana > 0)
					Main.player[Projectile.owner].ManaEffect(Mana);
			}
		}

		public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
		{
			if (Hits > 0)
			{
				Mana += ManaPerHit;
				--Hits;
			}
			else
				ReturnToPlayer();
		}

		public override void OnHitPlayer(Player target, Player.HurtInfo info)
		{
			if (Hits > 0)
			{
				Mana += ManaPerHit;
				--Hits;
			}
			else
				ReturnToPlayer();
		}

		public override bool OnTileCollide(Vector2 oldVelocity)
		{
			ReturnToPlayer();
			return false;
		}

		void ReturnToPlayer()
		{
			Projectile.tileCollide = false;
			Projectile.damage /= 2;
			Projectile.aiStyle = 3;
		}
	}
}
