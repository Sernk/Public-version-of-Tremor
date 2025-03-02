using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using ReLogic.Utilities;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.GameContent;
using Terraria.GameContent.Bestiary;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Filters = Terraria.Graphics.Effects.Filters;
using TremorMod.Content.Tiles;
using TremorMod.Content.Items.Materials;
using TremorMod.Content.Items.NPCsDrop;
using TremorMod.Utilities;

namespace TremorMod.Content.NPCs
{
    public class Galasquid : ModNPC
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Galasquid");
            Main.npcFrameCount[NPC.type] = 5;
        }

        public override void SetDefaults()
        {
            NPC.aiStyle = -1;
            NPC.lifeMax = 4250;
            NPC.damage = 125;
            NPC.defense = 75;
            AnimationType = 82;
            NPC.knockBackResist = 0.03f;
            NPC.width = 40;
            NPC.height = 60;
            NPC.value = Item.buyPrice(0, 2, 0, 0);
            NPC.noGravity = true;
            NPC.noTileCollide = true;
            NPC.HitSound = SoundID.NPCHit1;
            NPC.DeathSound = SoundID.NPCDeath1;
            NPC.buffImmune[20] = true;
            NPC.buffImmune[24] = true;
            NPC.buffImmune[39] = true;
            NPC.npcSlots = 10f;
        }

        public override void ApplyDifficultyAndPlayerScaling(int numPlayers, float balance, float bossAdjustment)
        {
            // Используем параметр balance вместо bossLifeScale
            NPC.lifeMax = (int)(NPC.lifeMax * 0.625f * balance);
            NPC.damage = (int)(NPC.damage * 0.6f);
        }


        public override void AI()
        {
            NPC.TargetClosest(true);

            float moveSpeed = 5f;

            Vector2 targetVelocity = Main.player[NPC.target].Center - NPC.Center;
            float velocityLength = targetVelocity.Length();

            // В зависимости от расстояния между NPC и игроком, корректируем скорость NPC
            if (velocityLength < 20)
                targetVelocity = NPC.velocity;
            else if (velocityLength < 40)
            {
                targetVelocity.Normalize();
                targetVelocity *= moveSpeed * 0.35f;
            }
            else if (velocityLength < 80)
            {
                targetVelocity.Normalize();
                targetVelocity *= moveSpeed * 0.65f;
            }
            else
            {
                targetVelocity.Normalize();
                targetVelocity *= moveSpeed;
            }
            NPC.SimpleFlyMovement(targetVelocity, 0.15f);
            NPC.rotation = NPC.velocity.X * 0.1f;

            if (Main.netMode != 1 && NPC.ai[0]++ >= 70)
            {
                Vector2 projectileVelocity = Vector2.Zero;
                while (Math.Abs(projectileVelocity.X) < 1.5f)
                    projectileVelocity = Vector2.UnitY.RotatedByRandom(Math.PI / 2) * new Vector2(5f, 3f);

                // Создаем источник сущности для NPC
                IEntitySource source = NPC.GetSource_FromAI();

                // Создаем новый снаряд
                Projectile.NewProjectile(source, NPC.Center, projectileVelocity, ProjectileID.MartianTurretBolt, 60, 0f, Main.myPlayer, 0f, NPC.whoAmI);

                NPC.ai[0] = 0f;
            }
        }


        public override void ModifyNPCLoot(NPCLoot npcLoot)
        {
            npcLoot.Add(ItemDropRule.ByCondition(new Conditions.NotExpert(), ModContent.ItemType<Catalyst>(), 1, 5, 12));
        }

        public override void HitEffect(NPC.HitInfo hit)
        {
            if (NPC.life <= 0)
            {
                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("GalasquidGore1").Type, 1f);
                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("GalasquidGore2").Type, 1f);
                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("GalasquidGore2").Type, 1f);
                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("GalasquidGore2").Type, 1f);
            }
        }

        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            // Проверка, находится ли координата в пределах карты
            if (spawnInfo.SpawnTileX < 0 || spawnInfo.SpawnTileX >= Main.maxTilesX ||
                spawnInfo.SpawnTileY < 0 || spawnInfo.SpawnTileY >= Main.maxTilesY)
            {
                return 0f;
            }

            // Список допустимых тайлов
            int[] cometTiles = { ModContent.TileType<CometiteOreTile>(), ModContent.TileType<HardCometiteOreTile>() };

            // Проверяем наличие тайла и дополнительные условия
            if (cometTiles.Contains(Main.tile[spawnInfo.SpawnTileX, spawnInfo.SpawnTileY].TileType) &&
                NPC.downedMoonlord && spawnInfo.SpawnTileY < Main.rockLayer)
            {
                return 15f;
            }

            return 0f;
        }

    }
}