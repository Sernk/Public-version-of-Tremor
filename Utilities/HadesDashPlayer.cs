using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace TremorMod.Utilities
{ 
    public class HadesDashPlayer : ModPlayer
    {
        public const int DashRight = 2;
        public const int DashLeft = 3;

        private const int DashCooldown = 35;
        private const int DashDuration = 20;
        private const float DashVelocity = 15f;

        private int DashDir = -1;
        public bool DashAccessoryEquipped;
        private int DashDelay = 0;
        private int DashTimer = 0;

        public override void ResetEffects()
        {
            DashAccessoryEquipped = false;
            DashDir = -1;

            if (Player.controlRight && Player.releaseRight && Player.doubleTapCardinalTimer[DashRight] < 30)
                DashDir = DashRight;
            else if (Player.controlLeft && Player.releaseLeft && Player.doubleTapCardinalTimer[DashLeft] < 30)
                DashDir = DashLeft;
        }

        public override void PreUpdateMovement()
        {
            if (CanUseDash() && DashDir != -1 && DashDelay == 0)
            {
                float dashDirection = (DashDir == DashRight) ? 1 : -1;
                Player.velocity.X = dashDirection * DashVelocity;

                DashDelay = DashCooldown;
                DashTimer = DashDuration;

                Player.eocDash = DashTimer;
                Player.armorEffectDrawShadowEOCShield = true;
                Player.immune = true;
                Player.immuneTime = 15;
            }

            if (DashDelay > 0)
                DashDelay--;

            if (DashTimer > 0)
            {
                DashTimer--;
            }
        }

        private bool CanUseDash()
        {
            return DashAccessoryEquipped
                && Player.dashType == 0
                && !Player.setSolar
                && !Player.mount.Active;
        }
    }
}
