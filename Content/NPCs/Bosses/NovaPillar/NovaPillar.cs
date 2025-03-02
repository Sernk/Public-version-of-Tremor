using System;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.GameContent;
using Terraria.Graphics;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using TremorMod;
using TremorMod.Content;
using TremorMod.Content.NPCs.Bosses.NovaPillar.NPCs;
using TremorMod.Content.NPCs.Bosses.NovaPillar.Projectiles;
using TremorMod.Content.NPCs.Bosses.NovaPillar.Items;
using ReLogic.Content; // Для использования ModContent.Request

namespace TremorMod.Content.NPCs.Bosses.NovaPillar
{
    [AutoloadBossHead]
    public class NovaPillar : ModNPC
    {
        private const int ShieldThreshold = 20; // Количество врагов для снятия щита
        private int enemiesKilled = 0;          // Счетчик уничтоженных врагов
        private bool shieldActive = true;       // Состояние щита
        private float shieldProgress = 0f;  // Прогресс в убийстве врагов
        private bool Active = true; // Если вы хотите контролировать активность NPC
        private float Intensity = 0f; // Для хранения уровня интенсивности



        public override void SetDefaults()
        {
            NPC.aiStyle = 94;
            NPC.lifeMax = 20000;
            NPC.damage = 0;
            NPC.defense = 20;
            NPC.knockBackResist = 0f;
            NPC.width = 170;
            NPC.height = 359;
            NPC.HitSound = SoundID.NPCHit1;
            NPC.DeathSound = SoundID.NPCDeath1;
            NPC.noGravity = true;
            NPC.npcSlots = 0;
            NPC.noTileCollide = true;
            NPC.alpha = 0;
            NPCID.Sets.MustAlwaysDraw[NPC.type] = true;
            Music = MusicID.TheTowers;
        }

        public override void Load()
        {
            Filters.Scene["MoonLordShield"] = new Filter(new ScreenShaderData("FilterMoonLord"), EffectPriority.High);
            Filters.Scene["MoonLordShield"].Load();
            Filters.Scene["NovaBossFilter"] = new Filter(new ScreenShaderData("FilterTower").UseColor(0.8f, 0.8f, 0.2f), EffectPriority.High);
            Filters.Scene["NovaBossFilter"].Load();
            SkyManager.Instance["NovaSky"] = new NovaSky();
        }

        int Timer;

        public override void AI()
        {
            base.AI(); // Вызов базовой логики AI, если необходимо

            Player player = Main.player[NPC.target];
            float distanceToPlayer = Vector2.Distance(NPC.Center, player.Center);

            // Отключение эффектов, если игрок слишком далеко
            if (distanceToPlayer > 200 * 16) // 200 плиток * 16 пикселей на плитку
            {
                if (Filters.Scene["NovaBossFilter"].IsActive())
                {
                    Filters.Scene.Deactivate("NovaBossFilter");
                }
                if (SkyManager.Instance["NovaSky"].IsActive())
                {
                    SkyManager.Instance.Deactivate("NovaSky");
                }
            }
            else
            {
                // Активация эффектов, если игрок в пределах 200 плиток
                if (!Filters.Scene["NovaBossFilter"].IsActive())
                {
                    Filters.Scene.Activate("NovaBossFilter");
                }
                if (!SkyManager.Instance["NovaSky"].IsActive())
                {
                    SkyManager.Instance.Activate("NovaSky");
                }
            }

            // Остальная логика AI
            if (Active)
            {
                var boss = Main.npc.FirstOrDefault(n => n.active && n.type == ModContent.NPCType<NovaPillar>());
                if (boss != null)
                {
                    Intensity = MathHelper.Clamp(1f - (boss.life / (float)boss.lifeMax), 0f, 1f);
                }
                else
                {
                    Intensity = Math.Max(0f, Intensity - 0.01f);
                }
            }

            if (shieldActive)
            {
                NPC.dontTakeDamage = true;
                CreateShieldEffect();
            }
            else
            {
                NPC.dontTakeDamage = false;
            }


            if (NPC.ai[0] % 300 == 0) // Каждые 5 секунд
            {
                SpawnEnemies(ModContent.NPCType<NovaAlchemist>(), 2);
                SpawnEnemies(ModContent.NPCType<NovaFlier>(), 4);
            }

            if (NPC.ai[0] % 120 == 0) // Каждые 2 секунды
            {
                SpawnEnemies(ModContent.NPCType<NovaBat>(), 3);
                SpawnEnemies(ModContent.NPCType<Youwarkee>(), 1);
                SpawnEnemies(ModContent.NPCType<Deadling>(), 2);
            }

            if (NPC.ai[0] % 180 == 0) // Каждые 3 секунды
            {
                SpawnEnemies(ModContent.NPCType<Varki>(), 1);
            }

            Timer++;
            if (Timer % 150 == 0)
            {
                if (Main.player[NPC.target].GetModPlayer<TremorPlayer>().ZoneTowerNova)
                {
                    var ShootPos = Main.player[NPC.target].position + new Vector2(Main.rand.Next(-1000, 1000), -1000);
                    var ShootVel = new Vector2(Main.rand.NextFloat(-3f, 3f), Main.rand.NextFloat(15f, 20f));

                    // Создаем источник события
                    IEntitySource source = NPC.GetSource_FromAI();

                    // Добавляем недостающие аргументы
                    int i = Projectile.NewProjectile(
                        source,
                        ShootPos,
                        ShootVel,
                        ModContent.ProjectileType<NovaBottle>(), // Тип снаряда
                        34,                                     // Урон
                        1f,                                     // Отбрасывание
                        Main.myPlayer                           // Владелец
                    );

                    Main.projectile[i].friendly = false;
                }
            }
        }
        private void CreateShieldEffect()
        {
            for (int i = 0; i < 10; i++)
            {
                Dust.NewDust(NPC.position, NPC.width, NPC.height, DustID.BlueTorch, 0f, 0f, 150, Color.Cyan, 1.5f);
            }
        }
        private void SpawnEnemies(int npcType, int count)
        {
            for (int i = 0; i < count; i++)
            {
                Vector2 spawnPosition = NPC.Center + new Vector2(Main.rand.Next(-200, 200), Main.rand.Next(-200, 200));
                if (Collision.CanHit(NPC.Center, 1, 1, spawnPosition, 1, 1))
                {
                    var source = NPC.GetSource_FromAI();
                    int newNPC = NPC.NewNPC(source, (int)spawnPosition.X, (int)spawnPosition.Y, npcType);
                }
            }
        }
        public void OnEnemyKilled()
        {
            enemiesKilled++;
            shieldProgress = (float)enemiesKilled / ShieldThreshold;  // Прогресс от 0 до 1

            if (enemiesKilled >= ShieldThreshold)
            {
                shieldActive = false;
                // Эффект исчезновения щита
                for (int i = 0; i < 20; i++)
                {
                    Dust.NewDust(NPC.position, NPC.width, NPC.height, DustID.Smoke, 0f, 0f, 150, Color.Gray, 2f);
                }
            }
        }

        public override void SaveData(TagCompound tag)
        {   
            tag["shieldActive"] = shieldActive;
            tag["enemiesKilled"] = enemiesKilled;
            tag["shieldProgress"] = shieldProgress;
        }

        public override void LoadData(TagCompound tag)
        {
            shieldActive = tag.GetBool("shieldActive");
            enemiesKilled = tag.GetInt("enemiesKilled");
            shieldProgress = tag.GetFloat("shieldProgress");
            if (shieldActive)
            {
                NPC.life = NPC.lifeMax; // Полное восстановление здоровья, если щит активен
            }
        }

        public override bool CheckActive()
        {
            return false;
        }

        public override bool CheckDead()
        {
            // Если NPC должен пережить смерть один раз
            if (NPC.ai[2] != 1)
            {
                NPC.ai[2] = 1; // Помечаем, что он пережил смерть
                NPC.ai[1] = 0; // Сброс таймера
                NPC.life = NPC.lifeMax; // Полное восстановление здоровья
                NPC.dontTakeDamage = true; // Защита от урона
                NPC.netUpdate = true; // Синхронизация состояния с клиентами
                return false; // Отмена смерти
            }

            int stacks = Main.rand.Next(25, 41) / 2;
            if (Main.expertMode)
            {
                stacks = (int)(stacks * 1.5f);
            }

            return true;
        }

        public override void OnKill()
         {
             base.OnKill();
             // Деактивация фильтра при смерти врага
             if (Filters.Scene["NovaBossFilter"].IsActive())
             {
                 Filters.Scene.Deactivate("NovaBossFilter");
             }

             // Деактивация эффекта при смерти врага
             if (SkyManager.Instance["NovaSky"].IsActive())
             {
                 SkyManager.Instance.Deactivate("NovaSky");
             }

             int stacks = Main.rand.Next(25, 41) / 2;
             if (Main.expertMode)
             {
                 stacks = (int)(stacks * 1.5f);
             }

             // Используем GetSource_Death для первого аргумента
             IEntitySource source = NPC.GetSource_Death();

             for (int i = 0; i < stacks; i++)
             {
                 // Создаем Vector2 для позиции
                 Vector2 position = NPC.position + new Vector2(Main.rand.Next(NPC.width), Main.rand.Next(NPC.height));

                 // Исправленная передача аргументов
                 Item.NewItem(source, position, 2, 2, ModContent.ItemType<NovaFragment>(), Main.rand.Next(1, 4));
             }
             NovaHandler.TowerX = -1;
             if (NPC.LunarApocalypseIsUp)
             {
                 Main.NewText("Your hands are shaking...", 175, 75, 255);
             }
             else
             {
                 // Передаем необходимый аргумент для countdownTime
                 WorldGen.StartImpendingDoom(10); // Пример значения, измените по необходимости
             }
         }
        public override void OnSpawn(IEntitySource source)
        {
            base.OnSpawn(source);

            if (shieldActive)
            {
                CreateShieldEffect();
            }
            if (!SkyManager.Instance["NovaSky"].IsActive())
            {
                SkyManager.Instance.Activate("NovaSky");
            }
        }

        public override void PostDraw(SpriteBatch spriteBatch, Vector2 screenPos, Color drawColor)
        {
            if (shieldActive) // Отрисовка щита только при его активности
            {
                // Проверка фильтра и текстуры
                var filter = Filters.Scene["MoonLordShield"];
                if (filter == null || filter.GetShader() == null)
                {
                    Mod.Logger.Warn("Filter 'MoonLordShield' is not available.");
                    return;
                }

                Texture2D perlinTexture;
                try
                {
                    perlinTexture = Main.Assets.Request<Texture2D>("Images/Misc/Perlin").Value;
                }
                catch
                {
                    Mod.Logger.Warn("Perlin texture not found in main assets.");
                    return;
                }

                // Вычисление силы щита (если нужно для анимации)
                float shieldStrengthRatio = enemiesKilled / (float)ShieldThreshold;

                // Подготовка к отрисовке шейдера
                Main.spriteBatch.End();
                Main.spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend, SamplerState.PointWrap, DepthStencilState.Default, RasterizerState.CullNone);

                var center = NPC.Center - Main.screenPosition;
                float shaderIntensity = 1f;

                // Рассчитываем расстояние до игрока
                float distanceToPlayer = Vector2.Distance(NPC.Center, Main.player[NPC.target].Center);

                // Изменяем цвет щита на оранжевый, если игрок находится в пределах 4000 единиц
                Color shieldColor = distanceToPlayer <= 4000f ? Color.Orange : Color.White;

                filter.GetShader()
                      .UseIntensity(shaderIntensity)
                      .UseProgress(shieldStrengthRatio);

                DrawData drawData = new DrawData(
                    perlinTexture,
                    center,
                    new Rectangle(0, 0, 600, 600),
                    shieldColor * (shieldStrengthRatio * 0.8f + 0.2f),
                    NPC.rotation,
                    new Vector2(300f, 300f),
                    NPC.scale * 1.2f,
                    SpriteEffects.None,
                    0
                );

                GameShaders.Misc["ForceField"].UseColor(new Vector3(0.5f, 0.8f, 1.2f));
                GameShaders.Misc["ForceField"].Apply(drawData);
                drawData.Draw(Main.spriteBatch);

                Main.spriteBatch.End();
                Main.spriteBatch.Begin();
            }
        }      
    }
}