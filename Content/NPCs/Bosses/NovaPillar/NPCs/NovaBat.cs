using Microsoft.Xna.Framework.Graphics;
using System;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;
using Terraria;
using Terraria.ID;
using TremorMod.Content.Projectiles;
using Terraria.DataStructures;
using TremorMod.Content.NPCs.Bosses.NovaPillar.Projectiles;

namespace TremorMod.Content.NPCs.Bosses.NovaPillar.NPCs
{
	public class NovaBat : ModNPC
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Nova Bat");
			Main.npcFrameCount[NPC.type] = 4;
		}

		public override void SetDefaults()
		{
			NPC.lifeMax = 2250;
			NPC.damage = 100;
			NPC.defense = 45;
			NPC.knockBackResist = 0.3f;
			NPC.width = 40;
			NPC.height = 20;
			AnimationType = 75;
			NPC.aiStyle = 14;
			NPC.npcSlots = 0.5f;
			NPC.noGravity = true;
		}

        /*public override float SpawnChance(NPCSpawnInfo spawnInfo)
		{
			if (spawnInfo.Player.GetModPlayer<TremorPlayer>(Mod).ZoneTowerNova)
				return 1f;
			return 0;
		}*/

        /*public override void PostDraw(SpriteBatch spriteBatch, Vector2 screenPos, Color drawColor)
        {
            Texture2D glowMask = ModContent.Request<Texture2D>("NPCs/Bosses/NovaPillar/NPCs/NovaBat_GlowMask").Value;
            TremorUtils.DrawNPCGlowMask(spriteBatch, NPC, glowMask);
        }*/

        public override void HitEffect(NPC.HitInfo hitInfo)
        {
            int hitDirection = hitInfo.Knockback > 0 ? 1 : -1; // Измените hit на hitInfo

            if (NPC.life <= 0)
            {
                if (NovaHandler.ShieldStrength > 0)
                {
                    int parentIndex = NPC.FindFirstNPC(ModContent.NPCType<NovaPillar>());
                    if (parentIndex != -1)
                    {
                        NPC parent = Main.npc[parentIndex];
                        Vector2 velocity = Helper.VelocityToPoint(NPC.Center, parent.Center, 20);
                        Projectile.NewProjectile(NPC.GetSource_FromAI(), NPC.Center, velocity, ModContent.ProjectileType<CogLordLaser>(), 1, 1f);
                    }
                }

                for (int k = 0; k < 19; k++)
                {
                    Vector2 vector = new Vector2(Main.rand.Next(-100, 101), Main.rand.Next(-100, 101));
                    vector.Normalize();
                    vector *= Main.rand.Next(10, 201) * 0.01f;
                    int i = Projectile.NewProjectile(NPC.GetSource_FromAI(), NPC.position, vector, ModContent.ProjectileType<NovaAlchemistCloud>(), 20, 1);
                    Main.projectile[i].friendly = false;
                }

                for (int i = 0; i < 5; i++)
                {
                    Dust.NewDust(NPC.position, NPC.width, NPC.height, 57, Main.rand.NextFloat(-3f, 3f), Main.rand.NextFloat(-3f, 3f));
                }

                for (int i = 0; i < 2; i++)
                {
                    Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("NovaBatGore2").Type, 1f);
                    Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("NovaBatGore2").Type, 1f);
                }
                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("NovaBatGore3").Type, 1f);
                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("NovaBatGore1").Type, 1f);
            }
        }

        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            if (spawnInfo.Player.GetModPlayer<TremorPlayer>().ZoneTowerNova)
                return 1f; // 100% шанс спавна в зоне башни Nova
            return 0;
        }

        public override void AI()
        {
            NPC.position += NPC.velocity * 1.33f;
            if (Main.time % 120 == 0)
            {
                for (int k = 0; k < 19; k++)
                {
                    Vector2 Vector = new Vector2(Main.rand.Next(-100, 101), Main.rand.Next(-100, 101));
                    Vector.Normalize();
                    Vector *= Main.rand.Next(10, 201) * 0.01f;

                    // Использование правильного источника для снарядов и передача корректных типов
                    int i = Projectile.NewProjectile(NPC.GetSource_FromThis(), NPC.position, Vector, ModContent.ProjectileType<NovaAlchemistCloud>(), 20, 1);

                    // Установка параметров снаряда
                    Main.projectile[i].friendly = false;
                }
            }
        }

    }
}