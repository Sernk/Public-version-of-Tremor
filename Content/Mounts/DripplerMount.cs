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
	public class DripplerMount : ModMount
	{
		public override void SetStaticDefaults()
		{
			MountData.spawnDust = 5;
			MountData.buff = Mod.Find<ModBuff>("DripplerBuff").Type;
			MountData.heightBoost = 20;
			MountData.flightTimeMax = 30;
			MountData.fatigueMax = 10;
			MountData.acceleration = 1f;
			MountData.jumpSpeed = 6f;
			MountData.fallDamage = 1f;
			MountData.runSpeed = 2f;
			MountData.blockExtraJumps = true;
			MountData.totalFrames = 8;
			MountData.constantJump = true;
			MountData.jumpHeight = 100;
			int[] array = new int[MountData.totalFrames];
			for (int l = 0; l < array.Length; l++)
			{
				array[l] = 12;
			}
			MountData.playerYOffsets = array;
			MountData.xOffset = 10;
			MountData.bodyFrame = 3;
			MountData.yOffset = 19;
			MountData.inAirFrameStart = 0;
			MountData.idleFrameCount = 8;
			MountData.idleFrameDelay = 12;
			MountData.idleFrameStart = 0;
			MountData.runningFrameStart = 0;
			MountData.flyingFrameCount = 8;
			MountData.flyingFrameDelay = 10;
			MountData.flyingFrameStart = 0;
			MountData.playerHeadOffset = 22;
			MountData.standingFrameStart = 0;
			MountData.runningFrameCount = 8;
			MountData.swimFrameCount = MountData.inAirFrameCount;
			MountData.swimFrameDelay = MountData.inAirFrameDelay;
			MountData.swimFrameStart = MountData.inAirFrameStart;
			MountData.standingFrameCount = 8;
			MountData.runningFrameDelay = 8;
			MountData.inAirFrameCount = 8;
			MountData.inAirFrameDelay = 10;
			MountData.idleFrameLoop = true;
			MountData.standingFrameDelay = 8;

            if (Main.netMode != 2)
            {
                MountData.textureWidth = MountData.backTexture.Value.Width;
                MountData.textureHeight = MountData.backTexture.Value.Height;
            }
        }

	}
}