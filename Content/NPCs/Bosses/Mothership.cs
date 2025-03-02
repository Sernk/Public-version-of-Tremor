using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;
using TremorMod.Content.Projectiles;
using TremorMod.Content.NPCs.Bosses;
using Terraria.Audio;

namespace TremorMod.Content.NPCs.Bosses
{
    [AutoloadBossHead]
    public class Mothership : ModNPC
    {
        private const int NormalFrameCount = 4;
        private const int RageFrameOffset = 4;
        private const float FrameDuration = 0.1f;
        private const float LightIntensity = 0.3f;

        private int currentFrame;
        private float frameTimer;
        private float shootTimer;
        private float elapsedTime;
        private bool isRaging;

        public override void SetStaticDefaults()
        {
            NPCID.Sets.MPAllowedEnemies[Type] = true;
            NPCID.Sets.BossBestiaryPriority.Add(Type);
            NPCID.Sets.SpecificDebuffImmunity[Type][BuffID.Poisoned] = true;
            NPCID.Sets.SpecificDebuffImmunity[Type][BuffID.Confused] = true;

            Main.npcFrameCount[NPC.type] = 8; // Frames for animation
        }

        public override void SetDefaults()
        {
            NPC.aiStyle = -1;
            NPC.lifeMax = 45000;
            NPC.damage = 125;
            NPC.defense = 55;
            NPC.knockBackResist = 0f;
            NPC.width = 162;
            NPC.height = 122;
            NPC.value = Item.buyPrice(0, 0, 0, 0);
            NPC.npcSlots = 1;
            NPC.boss = true;
            NPC.lavaImmune = true;
            NPC.noGravity = true;
            NPC.noTileCollide = true;
            NPC.HitSound = SoundID.NPCHit4;
            NPC.DeathSound = SoundID.NPCDeath6;
            Music = MusicID.Boss2;
        }

        public override void ApplyDifficultyAndPlayerScaling(int numPlayers, float bossLifeScale, float balance)
        {
            NPC.lifeMax = (int)(NPC.lifeMax * 0.625f * bossLifeScale);
            NPC.damage = (int)(NPC.damage * 0.6f);
        }

        public override void FindFrame(int frameHeight)
        {
            int frameOffset = isRaging ? RageFrameOffset : 0;
            NPC.frame.Y = frameHeight * (currentFrame + frameOffset);
        }

        public override void HitEffect(NPC.HitInfo hitInfo)
        {
            if (NPC.life <= 0)
            {
                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("CKMotherGore1").Type, 1f);
                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("CKMotherGore2").Type, 1f);
                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("CKMotherGore3").Type, 1f);
            }
        }

        private bool isSecondPhase = false; // Проверка на вторую фазу
        private float lightningTimer = 0f;  // Таймер для вызова молний

        public override void AI()
        {
            if (ShouldEscape())
            {
                EscapeBehavior();
                return;
            }

            UpdateTimers();

            // Переход на вторую фазу при снижении здоровья до 50% или меньше
            if (!isSecondPhase && NPC.life <= NPC.lifeMax / 2)
            {
                isSecondPhase = true;
                Main.NewText("The Mothership enters its second phase!", 255, 0, 0); // Уведомление (опционально)
            }

            Player targetPlayer = Main.player[NPC.target];
            UpdatePosition(targetPlayer);
            UpdateAnimation();

            if (isSecondPhase)
            {
                HandleSecondPhase(targetPlayer); // Логика второй фазы
            }
            else
            {
                if (shootTimer <= 0)
                {
                    Shoot(targetPlayer);
                    ResetShootTimer();
                }
            }
        }

        private void HandleSecondPhase(Player targetPlayer)
        {
            lightningTimer += 0.016f; // Увеличиваем таймер (16 мс = 1 кадр)

            if (lightningTimer >= 3f) // Каждые 3 секунды
            {
                SpawnLightning(targetPlayer); // Вызываем снаряд
                lightningTimer = 0f; // Сбрасываем таймер
            }
        }

        private void SpawnLightning(Player targetPlayer)
        {
            Vector2 spawnPosition = NPC.Center + new Vector2(Main.rand.Next(-200, 201), Main.rand.Next(-200, 201));
            Projectile.NewProjectile(
                NPC.GetSource_FromAI(),
                spawnPosition,
                Vector2.Zero, // Скорость задается в снаряде
                ModContent.ProjectileType<LightningOrb>(),
                30, // Урон молнии
                5f, // Отбрасывание
                Main.myPlayer
            );

            Terraria.Audio.SoundEngine.PlaySound(SoundID.Item93, spawnPosition); // Звук молнии
        }


        private bool AreAllPlayersDead()
        {
            foreach (Player player in Main.player)
            {
                if (!player.dead) // Если хотя бы один игрок жив, возвращаем false
                {
                    return false;
                }
            }
            return true; // Все игроки мертвы
        }

        private void UpdateTimers()
        {
            elapsedTime += 0.016f;
            frameTimer -= 0.016f;
            shootTimer -= 0.016f;
        }

        private void UpdatePosition(Player targetPlayer)
        {
            Vector2 targetOffset = new Vector2((float)Math.Sin(elapsedTime) * 200, (float)Math.Cos(elapsedTime) * 50);
            Vector2 targetPosition = targetPlayer.Center - new Vector2(0, 250) + targetOffset;
            NPC.Center = Vector2.Lerp(NPC.Center, targetPosition, 0.01f);
            Lighting.AddLight(NPC.Center, LightIntensity, LightIntensity, 1f);
        }

        private void UpdateAnimation()
        {
            if (frameTimer <= 0)
            {
                frameTimer = FrameDuration;
                currentFrame = (currentFrame + 1) % NormalFrameCount;
            }

            isRaging = NPC.life < NPC.lifeMax / 2;
        }

        private void ResetShootTimer()
        {
            shootTimer = isRaging ? 8 : 1;
        }

        private void Shoot(Player targetPlayer)
        {
            if (isRaging)
            {
                ShootFocused(targetPlayer);
            }
            else
            {
                ShootSpread();
            }
        }

        private void ShootSpread()
        {
            int projectileType = ModContent.ProjectileType<PurplePulsePro>();
            float angleStep = MathHelper.PiOver4;
            for (float angle = 0; angle < MathHelper.TwoPi; angle += angleStep)
            {
                Vector2 velocity = new Vector2((float)Math.Cos(angle), (float)Math.Sin(angle)) * 9; // Уменьшите множитель с 5 на 3

                Projectile.NewProjectile(NPC.GetSource_FromAI(), NPC.Center, velocity, projectileType, 30, 5f);
            }
        }

        private void ShootFocused(Player targetPlayer)
        {
            Vector2 direction = Vector2.Normalize(targetPlayer.Center - NPC.Center);
            int projectileType = ProjectileID.PurpleLaser;
            Projectile.NewProjectile(NPC.GetSource_FromAI(), NPC.Center, direction * 5, projectileType, 25, 5f);
        }

        private bool ShouldEscape()
        {
            bool allPlayersDead = true;
            foreach (Player player in Main.player)
            {
                if (!player.dead)
                {
                    allPlayersDead = false;
                    break;
                }
            }
            return Main.dayTime || allPlayersDead;
        }

        public override void OnKill()
        {
            // Создание нового NPC (CyberKing)
            IEntitySource source = NPC.GetSource_FromAI(); // Источник действия
            Vector2 bossCenter = NPC.Center; // Центр текущего NPC

            // Уточнение пути к классу CyberKing
            int cyberKingID = ModContent.NPCType<CyberKing>();
            NPC.NewNPC(source, (int)bossCenter.X, (int)bossCenter.Y, cyberKingID, 0, 0, 0, 0, 0, NPC.target);


            // Воспроизведение звука
            Player player = Main.player[NPC.target];
            SoundEngine.PlaySound(SoundID.Roar, player.position);
        }




        private void EscapeBehavior()
        {
            NPC.velocity.X += NPC.velocity.X > 0 ? 0.75f : -0.75f;
            NPC.velocity.Y -= 0.1f;
            NPC.rotation = NPC.velocity.X * 0.05f;
        }
    }
}
