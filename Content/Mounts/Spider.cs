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
	public class Spider : ModMount
	{
		public override void SetStaticDefaults()
		{
			MountData.buff = ModContent.BuffType<FatSpider>();
			MountData.heightBoost = 15;
			MountData.fallDamage = 0.5f;
			MountData.runSpeed = 5f;
			MountData.dashSpeed = 8f;
			MountData.flightTimeMax = 0;
			MountData.fatigueMax = 0;
			MountData.jumpHeight = 50;
			MountData.acceleration = 0.19f;
			MountData.jumpSpeed = 4f;
			MountData.blockExtraJumps = false;
			MountData.totalFrames = 6;
			MountData.constantJump = true;
			int[] array = new int[MountData.totalFrames];
			for (int l = 0; l < array.Length; l++)
			{
				array[l] = 20;
			}
			MountData.playerYOffsets = array;
			MountData.xOffset = 13;
			MountData.bodyFrame = 3;
			MountData.yOffset = -9;
			MountData.playerHeadOffset = 28;
			MountData.standingFrameCount = 1;
			MountData.standingFrameDelay = 12;
			MountData.standingFrameStart = 0;
			MountData.runningFrameCount = 6;
			MountData.runningFrameDelay = 36;
			MountData.runningFrameStart = 0;
			MountData.flyingFrameCount = 0;
			MountData.flyingFrameDelay = 0;
			MountData.flyingFrameStart = 0;
			MountData.inAirFrameCount = 1;
			MountData.inAirFrameDelay = 12;
			MountData.inAirFrameStart = 0;
			MountData.idleFrameCount = 6;
			MountData.idleFrameDelay = 12;
			MountData.idleFrameStart = 0;
			MountData.idleFrameLoop = true;
			MountData.swimFrameCount = MountData.inAirFrameCount;
			MountData.swimFrameDelay = MountData.inAirFrameDelay;
			MountData.swimFrameStart = MountData.inAirFrameStart;
            if (Main.netMode != 2)
            {
                MountData.textureWidth = MountData.backTexture.Value.Width;
                MountData.textureHeight = MountData.backTexture.Value.Height;
            }
        }
	}
}