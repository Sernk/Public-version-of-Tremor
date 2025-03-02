using System;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using TremorMod.Utilities;
using Terraria.DataStructures;
using Microsoft.Xna.Framework;
using Terraria.GameContent.ItemDropRules;
using TremorMod.Content.Items.Materials.OreAndBar;
using TremorMod.Content.Projectiles;
using TremorMod.Content.Items.Materials;
using TremorMod.Content.Items.Weapons.Magic;
using TremorMod.Content.Items.Placeable.Banners;
using TremorMod.Content.Items.Vanity;

namespace TremorMod.Content.NPCs
{
	/*
	 * AI could still use some cleaning up.
	 */
	public class SnowEater : ModNPC
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Snow Eater");
			Main.npcFrameCount[NPC.type] = 5;
		}

		public override void SetDefaults()
		{
			NPC.lifeMax = 70;
			NPC.damage = 13;
			NPC.defense = 7;
			NPC.knockBackResist = 0.0f;
			NPC.width = 24;
			NPC.height = 24;
			AnimationType = 69;
			NPC.aiStyle = -1;
			NPC.behindTiles = true;
			NPC.npcSlots = 0.1f;
			NPC.HitSound = SoundID.NPCHit31;
			NPC.DeathSound = SoundID.NPCDeath34;
			NPC.value = Item.buyPrice(0, 0, 12, 0);
			// banner = npc.type;
			// Todo: bannerItem = mod.ItemType("SnowEaterBanner");
		}

		public override void AI()
		{
			NPC.TargetClosest(true);
			float num679 = 12f;
			Vector2 vector67 = new Vector2(NPC.position.X + NPC.width * 0.5f, NPC.position.Y + NPC.height * 0.5f);
			float num680 = Main.player[NPC.target].position.X + Main.player[NPC.target].width / 2 - vector67.X;
			float num681 = Main.player[NPC.target].position.Y - vector67.Y;
			float num682 = (float)Math.Sqrt(num680 * num680 + num681 * num681);
			num682 = num679 / num682;
			num680 *= num682;
			num681 *= num682;
			bool flag74 = false;
			if (NPC.directionY < 0)
			{
				NPC.rotation = (float)(Math.Atan2(num681, num680) + 1.57);
				flag74 = (NPC.rotation >= -1.2 && NPC.rotation <= 1.2);
				if (NPC.rotation < -0.8)
				{
					NPC.rotation = -0.8f;
				}
				else if (NPC.rotation > 0.8)
				{
					NPC.rotation = 0.8f;
				}
				if (NPC.velocity.X != 0f)
				{
					NPC.velocity.X = NPC.velocity.X * 0.9f;
					if (NPC.velocity.X > -0.1 || NPC.velocity.X < 0.1)
					{
						NPC.netUpdate = true;
						NPC.velocity.X = 0f;
					}
				}
			}
			if (NPC.ai[0] > 0f)
			{
				if (NPC.ai[0] == 200f)
				{
					SoundEngine.PlaySound(SoundID.Item5, NPC.position);
				}
				NPC.ai[0] -= 1f;
			}
			if (Main.netMode != 1 && flag74 && NPC.ai[0] == 0f && Collision.CanHit(NPC.position, NPC.width, NPC.height, Main.player[NPC.target].position, Main.player[NPC.target].width, Main.player[NPC.target].height))
			{
				NPC.ai[0] = 200f;
				int num683 = 10;
				int num684 = 109;
				int num685 = Projectile.NewProjectile(NPC.GetSource_FromThis(), vector67.X, vector67.Y, num680, num681, num684, num683, 0f, Main.myPlayer, 0f, 0f);
				Main.projectile[num685].ai[0] = 2f;
				Main.projectile[num685].timeLeft = 300;
				Main.projectile[num685].friendly = false;
				//NetMessage.SendData(27, -1, -1, "", num685, 0f, 0f, 0f, 0, 0, 0);
				NPC.netUpdate = true;
			}
			try
			{
				int num686 = (int)NPC.position.X / 16;
				int num687 = (int)(NPC.position.X + NPC.width / 2) / 16;
				int num688 = (int)(NPC.position.X + NPC.width) / 16;
				int num689 = (int)(NPC.position.Y + NPC.height) / 16;
				bool flag75 = false;
				if (Main.tile[num686, num689] == null)
				{
					//Main.tile[num686, num689] = new Tile();
				}
				if (Main.tile[num687, num689] == null)
				{
					//Main.tile[num686, num689] = new Tile();
				}
				if (Main.tile[num688, num689] == null)
				{
					//Main.tile[num686, num689] = new Tile();
				}
				if ((Main.tile[num686, num689].HasUnactuatedTile && Main.tileSolid[Main.tile[num686, num689].TileType]) || (Main.tile[num687, num689].HasUnactuatedTile && Main.tileSolid[Main.tile[num687, num689].TileType]) || (Main.tile[num688, num689].HasUnactuatedTile && Main.tileSolid[Main.tile[num688, num689].TileType]))
				{
					flag75 = true;
				}
				if (flag75)
				{
					NPC.noGravity = true;
					NPC.noTileCollide = true;
					NPC.velocity.Y = -0.2f;
				}
				else
				{
					NPC.noGravity = false;
					NPC.noTileCollide = false;
					if (Main.rand.NextBool(2))
					{
						int num690 = Dust.NewDust(new Vector2(NPC.position.X - 4f, NPC.position.Y + NPC.height - 8f), NPC.width + 8, 24, 80, 0f, NPC.velocity.Y / 2f, 0, default(Color), 1f);
						Dust expr_28A1C_cp_0 = Main.dust[num690];
						expr_28A1C_cp_0.velocity.X = expr_28A1C_cp_0.velocity.X * 0.4f;
						Dust expr_28A3C_cp_0 = Main.dust[num690];
						expr_28A3C_cp_0.velocity.Y = expr_28A3C_cp_0.velocity.Y * -1f;
						if (Main.rand.NextBool(2))
						{
							Main.dust[num690].noGravity = true;
							Main.dust[num690].scale += 0.2f;
						}
					}
				}
			}
			catch
			{
			}
		}

        public override void ModifyNPCLoot(NPCLoot npcLoot)
        {
            npcLoot.Add(ItemDropRule.ByCondition(new Conditions.NotExpert(), ModContent.ItemType<FrostCore>(), 2));
            if (NPC.downedMoonlord)
			{
				npcLoot.Add(ItemDropRule.ByCondition(new Conditions.NotExpert(), ModContent.ItemType<IceSoul>(), 5));
			}          
        }

        public override void HitEffect(NPC.HitInfo hit)
		{
            int hitDirection = hit.HitDirection;

            if (NPC.life <= 0)
			{
				Dust.NewDust(NPC.position, NPC.width, NPC.height, 80, 2.5f * hitDirection, -2.5f, 0, default(Color), 1.7f);
				Dust.NewDust(NPC.position, NPC.width, NPC.height, 80, 2.5f * hitDirection, -2.5f, 0, default(Color), 2.7f);
				Dust.NewDust(NPC.position, NPC.width, NPC.height, 80, 2.5f * hitDirection, -2.5f, 0, default(Color), 0.7f);

                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("SEGore1").Type, 1f);
                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("SEGore1").Type, 1f);
                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("SEGore2").Type, 1f);


				for (int k = 0; k < 20; k++)
				{
					Dust.NewDust(NPC.position, NPC.width, NPC.height, 80, 2.5f * hitDirection, -2.5f, 0, default(Color), 1.7f);
					Dust.NewDust(NPC.position, NPC.width, NPC.height, 80, 2.5f * hitDirection, -2.5f, 0, default(Color), 0.6f);
				}
			}
		}

		public override float SpawnChance(NPCSpawnInfo spawnInfo)
			=> spawnInfo.Player.ZoneSnow && spawnInfo.SpawnTileY > Main.rockLayer ? 0.01f : 0f;
	}
}