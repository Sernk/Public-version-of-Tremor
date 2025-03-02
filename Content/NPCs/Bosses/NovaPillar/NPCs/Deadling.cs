using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TremorMod.Content.Projectiles;
using TremorMod.Content.NPCs.Bosses.NovaPillar.Projectiles;


namespace TremorMod.Content.NPCs.Bosses.NovaPillar.NPCs
{
    public class Deadling : ModNPC
    {
        public override void SetStaticDefaults()
        {
            Main.npcFrameCount[NPC.type] = 2;
        }

        public override void SetDefaults()
        {
            NPC.aiStyle = 87;
            NPC.damage = 60;
            NPC.width = 24;
            NPC.height = 26;
            NPC.defense = 50;
            NPC.lifeMax = 1000;
            NPC.knockBackResist = 0f;
            AnimationType = 81;
            NPC.noGravity = false;
            NPC.noTileCollide = false;
            NPC.HitSound = SoundID.NPCHit55;
            NPC.DeathSound = SoundID.NPCDeath51;
        }

        public override void ApplyDifficultyAndPlayerScaling(int numPlayers, float balance, float bossAdjustment)
        {
            NPC.lifeMax = NPC.lifeMax * 1;
            NPC.damage = NPC.damage * 1;
        }

        /*public override void PostDraw(SpriteBatch spriteBatch, Vector2 screenPos, Color drawColor)
        {
            var texture = ModContent.Request<Texture2D>("NPCs/Bosses/NovaPillar/NPCs/Deadling_GlowMask").Value;
        }*/

        public override void OnHitPlayer(Player target, Player.HurtInfo hurtInfo)
        {
            NPC.life = -1;
            NPC.active = false;
            NPC.checkDead();
            if (NovaHandler.ShieldStrength > 0)
            {
                NPC parent = Main.npc[NPC.FindFirstNPC(ModContent.NPCType<NovaPillar>())];
                Vector2 Velocity = Helper.VelocityToPoint(NPC.Center, parent.Center, 20);
                var source = NPC.GetSource_FromThis();
                Projectile.NewProjectile(source, NPC.Center, Velocity, ModContent.ProjectileType<CogLordLaser>(), 1, 1f);
            }
            for (int i = 0; i < 5; i++)
            {
                Dust.NewDust(NPC.position, NPC.width, NPC.height, 57, Main.rand.NextFloat(-3f, 3f), Main.rand.NextFloat(-3f, 3f));
            }
            for (int k = 0; k < 30; k++)
            {
                Vector2 vector = new Vector2(Main.rand.Next(-100, 101), Main.rand.Next(-100, 101));
                vector.Normalize();
                vector *= Main.rand.Next(10, 201) * 0.01f;
                var source = NPC.GetSource_FromThis();
                int proj = Projectile.NewProjectile(source, NPC.position, vector, ModContent.ProjectileType<NovaAlchemistCloud>(), 20, 1f);
                Main.projectile[proj].friendly = false;
            }
        }
        public override void OnKill()
        {
            base.OnKill();
            // Уведомляем столб о смерти врага
            int pillarIndex = NPC.FindFirstNPC(ModContent.NPCType<NovaPillar>());
            if (pillarIndex != -1)
            {
                NPC pillar = Main.npc[pillarIndex];
                if (pillar.ModNPC is NovaPillar novaPillar)
                {
                    novaPillar.OnEnemyKilled();
                }
            }
        }
        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            if (spawnInfo.Player.GetModPlayer<TremorPlayer>().ZoneTowerNova)
                return 1f; // 100% шанс спавна в зоне башни Nova
            return 0;
        }
    }
}
