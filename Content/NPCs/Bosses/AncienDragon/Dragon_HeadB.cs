using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.GameContent.ItemDropRules;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;
using TremorMod.Content.Items.Bag;
using TremorMod.Content.Items.Vanity;
using TremorMod.Content.Items.Placeable;
using TremorMod.Content.Items.Weapons.Melee;
using TremorMod.Content.Items.Weapons.Magic;

namespace TremorMod.Content.NPCs.Bosses.AncienDragon
{
	//todo: refactor, comparable to HoW
	[AutoloadBossHead]
	public class Dragon_HeadB : ModNPC
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Ancient Dragon");
		}

		private bool _tailSpawned;
		public static int ShootRate = 20;

		public override void SetDefaults()
		{
			NPC.damage = 28;
			NPC.npcSlots = 5f;
			NPC.width = 78;
			NPC.height = 132;
			NPC.defense = 12;
			NPC.lifeMax = 3100;
			NPC.aiStyle = 6;
			NPC.npcSlots = 1f;
			NPC.knockBackResist = 0f;

			NPC.noTileCollide = true;
			NPC.behindTiles = true;
			NPC.friendly = false;
			NPC.dontTakeDamage = false;
			NPC.noGravity = true;
			NPC.boss = true;
			NPC.lavaImmune = true;

			NPC.buffImmune[BuffID.OnFire] = true;
			NPC.buffImmune[BuffID.Burning] = true;
			
			Music = MusicID.Boss2;
			NPC.HitSound = SoundID.NPCHit1;
			NPC.DeathSound = SoundID.NPCDeath1;
			//bossBag/* tModPorter Note: Removed. Spawn the treasure bag alongside other loot via npcLoot.Add(ItemDropRule.BossBag(type)) */ = Mod.ItemType<AncientDragonBag>();
		}

        /*public override void NPCLoot()
		{
			if (Main.expertMode)
			{
				npc.DropBossBags();
			}
			else
			{
				if (Main.rand.NextBool(7))
				{
					Item.NewItem(npc.position, npc.Size, mod.ItemType<AncientDragonMask>());
				}

				if (Main.rand.NextBool())
				{
					Item.NewItem(npc.position, npc.Size, mod.ItemType<AncientTimesEdge>());
					Item.NewItem(npc.position, npc.Size, mod.ItemType<DragonHead>());
					Item.NewItem(npc.position, npc.Size, mod.ItemType<Swordstorm>());
				}
			}

			if (Main.rand.NextBool(10))
			{
				Item.NewItem(npc.position, npc.Size, mod.ItemType<AncientDragonTrophy>());
			}

			TremorWorld.Boss.AncientDragon.Downed();
		}*/
        public override void ModifyNPCLoot(NPCLoot npcLoot)
        {

            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<AncientDragonTrophy>(), 10));

            npcLoot.Add(ItemDropRule.ByCondition(new Conditions.NotExpert(), ModContent.ItemType<AncientDragonMask>(), 7));

            npcLoot.Add(ItemDropRule.OneFromOptions(1,
                ModContent.ItemType<Swordstorm>(),
                ModContent.ItemType<DragonHead>(),
                ModContent.ItemType<AncientTimesEdge>()));

            // Альтернативное использование условия:
            npcLoot.Add(ItemDropRule.ByCondition(new Conditions.IsExpert(), ModContent.ItemType<AncientDragonBag>(), 1));
        }

        public override void AI()
        {
            NPC.position += NPC.velocity * (2 - 1);

            if (!_tailSpawned)
            {
                int previous = NPC.whoAmI;
                for (int num36 = 0; num36 < 19; num36++)
                {
                    int newNPC;
                    if (num36 < 18)
                    {
                        newNPC = NPC.NewNPC(NPC.GetSource_FromAI(), (int)NPC.position.X + (NPC.width / 2), (int)NPC.position.Y + (NPC.width / 2), ModContent.NPCType<Dragon_BodyB>(), NPC.whoAmI);
                    }
                    else
                    {
                        newNPC = NPC.NewNPC(NPC.GetSource_FromAI(), (int)NPC.position.X + (NPC.width / 2), (int)NPC.position.Y + (NPC.width / 2), ModContent.NPCType<Dragon_LegB>(), NPC.whoAmI);
                    }

                    Main.npc[newNPC].realLife = NPC.whoAmI;
                    Main.npc[newNPC].ai[2] = NPC.whoAmI;
                    Main.npc[newNPC].ai[1] = previous;
                    Main.npc[previous].ai[0] = newNPC;

                    previous = newNPC;
                }
                _tailSpawned = true;
            }

            if ((int)(Main.time % 180) == 0)
            {
                Vector2 vector = new Vector2(NPC.position.X + (NPC.width * 0.5f), NPC.position.Y + (NPC.height / 2));
                float birdRotation = (float)Math.Atan2(vector.Y - (Main.player[NPC.target].position.Y + (Main.player[NPC.target].height * 0.5f)), vector.X - (Main.player[NPC.target].position.X + (Main.player[NPC.target].width * 0.5f)));
                NPC.velocity.X = (float)(Math.Cos(birdRotation) * 7) * -1;
                NPC.velocity.Y = (float)(Math.Sin(birdRotation) * 7) * -1;
                NPC.netUpdate = true;
            }
        }

        public override bool PreDraw(SpriteBatch spriteBatch, Vector2 screenPos, Color drawColor)
        {
            Texture2D drawTexture = TextureAssets.Npc[NPC.type].Value;
            Vector2 origin = new Vector2((drawTexture.Width / 2) * 0.5F, (drawTexture.Height / Main.npcFrameCount[NPC.type]) * 0.5F);

            Vector2 drawPos = new Vector2(
                NPC.position.X - Main.screenPosition.X + (NPC.width / 2) - (TextureAssets.Npc[NPC.type].Value.Width / 2) * NPC.scale / 2f + origin.X * NPC.scale,
                NPC.position.Y - Main.screenPosition.Y + NPC.height - TextureAssets.Npc[NPC.type].Value.Height * NPC.scale / Main.npcFrameCount[NPC.type] + 4f + origin.Y * NPC.scale + NPC.gfxOffY);

            SpriteEffects effects = NPC.spriteDirection == -1 ? SpriteEffects.None : SpriteEffects.FlipHorizontally;

            spriteBatch.Draw(drawTexture, drawPos, NPC.frame, drawColor, NPC.rotation, origin, NPC.scale, effects, 0);

            return false;
        }
    }
}