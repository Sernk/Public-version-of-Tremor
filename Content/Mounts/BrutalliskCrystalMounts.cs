using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TremorMod.Content.Buffs;

namespace TremorMod.Content.Mounts
{
    public class BrutalliskCrystalMounts : ModMount
    {
        public override void SetStaticDefaults()
        {
            MountData.spawnDust = 226;
            MountData.spawnDustNoGravity = true;
            MountData.buff = ModContent.BuffType<BrutalliskCrystal>();
            MountData.heightBoost = 24;
            MountData.flightTimeMax = 999999999;
            MountData.fatigueMax = 999999999;
            MountData.fallDamage = 0f;
            MountData.usesHover = true;
            MountData.runSpeed = 14f;
            MountData.dashSpeed = 14f;
            MountData.acceleration = 1f;
            MountData.jumpHeight = 10;
            MountData.jumpSpeed = 8f;
            MountData.blockExtraJumps = true;
            MountData.totalFrames = 2;

            int[] array = new int[MountData.totalFrames];
            for (int num2 = 0; num2 < array.Length; num2++)
            {
                array[num2] = 16;
            }
            MountData.playerYOffsets = array;
            MountData.xOffset = 10;
            MountData.bodyFrame = 3;
            MountData.yOffset = 25;
            MountData.playerHeadOffset = 22;
            MountData.standingFrameCount = 2;
            MountData.standingFrameDelay = 8;
            MountData.standingFrameStart = 0;
            MountData.runningFrameCount = 2;
            MountData.runningFrameDelay = 8;
            MountData.runningFrameStart = 0;
            MountData.flyingFrameCount = 2;
            MountData.flyingFrameDelay = 10;
            MountData.flyingFrameStart = 0;
            MountData.inAirFrameCount = 2;
            MountData.inAirFrameDelay = 10;
            MountData.inAirFrameStart = 0;
            MountData.idleFrameCount = 2;
            MountData.idleFrameDelay = 12;
            MountData.idleFrameStart = 0;
            MountData.idleFrameLoop = true;
            MountData.swimFrameCount = MountData.inAirFrameCount;
            MountData.swimFrameDelay = MountData.inAirFrameDelay;
            MountData.swimFrameStart = MountData.inAirFrameStart;

            if (Main.netMode != 2)
            {
                MountData.textureWidth = MountData.backTexture.Value.Width + 20;
                MountData.textureHeight = MountData.backTexture.Value.Height;
            }
        }
    }
}
