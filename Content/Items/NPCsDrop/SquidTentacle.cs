using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;

namespace TremorMod.Content.Items.NPCsDrop
{
	class SquidTentacle : ModItem
	{
		public override void SetDefaults()
		{
			Item.CloneDefaults(ItemID.WormHook);

			Item.shootSpeed = 18f; // how quickly the hook is shot.
			Item.shoot = ModContent.ProjectileType<SquidTentacleProjectile>();
		}

		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Squid Tentacle");
			// Tooltip.SetDefault("");
		}

	}

	class SquidTentacleProjectile : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Squid Tentacle Projectile");
		}

		public override void SetDefaults()
		{
			Projectile.CloneDefaults(ProjectileID.GemHookAmethyst);
		}

		// Use this hook for hooks that can have multiple hooks midflight: Dual Hook, Web Slinger, Fish Hook, Static Hook, Lunar Hook
		/*
				public override bool? CanUseGrapple(Player player)
				{
					int hooksOut = 0;
					for (int l = 0; l < 1000; l++)
					{
						if (Main.projectile[l].active && Main.projectile[l].owner == Main.myPlayer && Main.projectile[l].type == projectile.type)
						{
							hooksOut++;
						}
					}
					if (hooksOut > 2) // This hook can have 3 hooks out.
					{
						return false;
					}
					return true;
				}
		*/

		// Return true if it is like: Hook, CandyCaneHook, BatHook, GemHooks
		//public override bool? SingleGrappleHook(Player player)
		//{
		//	return true;
		//}

		// Use this to kill oldest hook. For hooks that kill the oldest when shot, not when the newest latches on: Like SkeletronHand
		// You can also change the projectile likr: Dual Hook, Lunar Hook
		//public override void UseGrapple(Player player, ref int type)
		//{
		//	int hooksOut = 0;
		//	int oldestHookIndex = -1;
		//	int oldestHookTimeLeft = 100000;
		//	for (int i = 0; i < 1000; i++)
		//	{
		//		if (Main.projectile[i].active && Main.projectile[i].owner == projectile.whoAmI && Main.projectile[i].type == projectile.type)
		//		{
		//			hooksOut++;
		//			if (Main.projectile[i].timeLeft < oldestHookTimeLeft)
		//			{
		//				oldestHookIndex = i;
		//				oldestHookTimeLeft = Main.projectile[i].timeLeft;
		//			}
		//		}
		//	}
		//	if (hooksOut > 1)
		//	{
		//		Main.projectile[oldestHookIndex].Kill();
		//	}
		//}

		// Amethyst Hook is 300, Static Hook is 600
		public override float GrappleRange()
		{
			return 500f;
		}

		public override void NumGrappleHooks(Player player, ref int numHooks)
		{
			numHooks = 3;
		}

		// default is 11, Lunar is 24
		public override void GrappleRetreatSpeed(Player player, ref float speed)
		{
			speed = 11f;
		}

		public override void GrapplePullSpeed(Player player, ref float speed)
		{
			speed = 10;
		}

        public override bool PreDraw(ref Color lightColor)
        {
            Vector2 playerCenter = Main.player[Projectile.owner].MountedCenter;
            Vector2 center = Projectile.Center;
            Vector2 distToProj = playerCenter - Projectile.Center;
            float projRotation = distToProj.ToRotation() - 1.57f;
            float distance = distToProj.Length();

			// ��������� �������� ���� ���, ����� �������� ���������� �������.
			var texture = ModContent.Request<Texture2D>("TremorMod/Content/Items/NPCsDrop/SquidTentacleChain").Value;

            while (distance > 30f && !float.IsNaN(distance))
            {
                distToProj.Normalize();                 // �������� ��������� ������.
                distToProj *= 24f;                      // �������� ����.
                center += distToProj;                   // ��������� ������� ��� ���������.
                distToProj = playerCenter - center;     // ��������� ����������.
                distance = distToProj.Length();
                Color drawColor = lightColor;

                // ���������� ��� ���������.
                Vector2 position = new Vector2(center.X - Main.screenPosition.X, center.Y - Main.screenPosition.Y);
                Rectangle sourceRectangle = new Rectangle(0, 0, texture.Width, texture.Height);
                Vector2 origin = new Vector2(texture.Width * 0.5f, texture.Height * 0.5f);

                // ������ ����.
                Main.spriteBatch.Draw(
                    texture,
                    position,
                    sourceRectangle,
                    drawColor,
                    projRotation,
                    origin,
                    1f, // �������.
                    SpriteEffects.None,
                    0f
                );
            }

            // ���������� ��������, ����� ��������� ������.
            return true;
        }


        // Animated hook example
        // Multiple, 
        // only 1 connected, spawn mult
        // Light the path
        // Gem Hooks: 1 spawn only
        // Thorn: 4 spawns, 3 connected
        // Dual: 2/1 
        // Lunar: 5/4 -- Cycle hooks, more than 1 at once
        // AntiGravity -- Push player to position
        // Static -- move player with keys, don't pull to wall
        // Christmas -- light ends
        // Web slinger -- 9/8, can shoot more than 1 at once
        // Bat hook -- Fast reeling

    }
}