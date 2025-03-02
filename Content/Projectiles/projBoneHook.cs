using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.GameContent;
using Terraria.ModLoader;
using TremorMod.Utilities;

namespace TremorMod.Content.Projectiles
{
	public class projBoneHook : ModProjectile
	{

		const int HookTime = 50; // "Длина" хука
		const float BackSpeedMulti = 0.75f; // Множитель скорости возвращения хука
		int TimeToHook = HookTime;
		int NPC = -1;

		public override void SetDefaults()
		{
			Projectile.width = 42;
			Projectile.height = 38;
			Projectile.timeLeft = 36000;
			Projectile.DamageType = DamageClass.Melee;
			Projectile.aiStyle = 13;
			Projectile.penetrate = -1;
		}

		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Bone Hook");
		}

		public override void AI()
		{
			if (--TimeToHook <= 0)
			{
				Projectile.ai[0] = 1;
				Projectile.velocity *= BackSpeedMulti;
			}
			else
				Projectile.ai[0] = 0;
			Projectile.rotation = Helper.rotateBetween2Points(Projectile.position, Main.player[Projectile.owner].position) + MathHelper.ToRadians(45);
			if (NPC != -1 && Projectile.Distance(Main.player[Projectile.owner].position) > 64)
			{
				Main.npc[NPC].Center = Projectile.position;
				if (!Main.npc[NPC].active)
					NPC = -1;
			}
		}

		public override bool PreDraw(ref Color lightColor)
		{
            SpriteBatch spriteBatch = Main.spriteBatch;
            spriteBatch.Draw(TextureAssets.Projectile[Projectile.type].Value, new Rectangle((int)(Projectile.position - Main.screenPosition).X, (int)(Projectile.position - Main.screenPosition).Y, Projectile.width, Projectile.height), null, lightColor, Projectile.rotation, new Vector2(Projectile.width / 2, Projectile.height / 2), SpriteEffects.None, 0);
			return false;
		}

		public override bool? CanHitNPC(NPC target)
		{
			return true;
		}

        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            if (NPC == -1 && !target.boss && !target.friendly && target.lifeMax > 5 && target.aiStyle != 6)
                NPC = target.whoAmI;
            TimeToHook = 1;
        }


        public override bool OnTileCollide(Vector2 oldVelocity)
		{
			TimeToHook = 1;
			return base.OnTileCollide(oldVelocity);
		}
    }
}