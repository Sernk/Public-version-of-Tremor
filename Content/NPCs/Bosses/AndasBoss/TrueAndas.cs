using System;
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
using TremorMod.Content.Items.AndasItems;

namespace TremorMod.Content.NPCs.Bosses.AndasBoss
{
	[AutoloadBossHead]
	public class TrueAndas : ModNPC
	{
		public static Asset<Texture2D> GlowTexture;

		/*public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("True Andas");
		}*/

		public override void SetDefaults()
		{
			NPC.aiStyle = -1;
            NPC.width = 142;
            NPC.height = 164;
            NPC.damage = 67;
            NPC.defense = 200;
            NPC.lifeMax = 145000;
            NPC.HitSound = SoundID.NPCHit1;
            NPC.DeathSound = SoundID.NPCDeath10;
            NPC.value = 60000f;
            NPC.knockBackResist = 0f;
            NPC.noTileCollide = true;
            NPC.noGravity = true;
            NPC.boss = true;
            if (ModLoader.HasMod("TremorModMusic"))
            {
                Mod musicMod = ModLoader.GetMod("TremorModMusic");
                if (musicMod != null)
                {
                    Music = MusicLoader.GetMusicSlot(musicMod, "Assets/Music/TrueAndas");
                }
            }
            else
            {
                Music = MusicID.Boss1; 
            }
            NPC.buffImmune[24] = true;
            NPC.buffImmune[67] = true;
            NPC.lavaImmune = true;
		}

		#region Settings AI
		const int ShootType = 467;
		const int ShootDamage = 50;
		const float ShootKnockback = 2f;
		const int ShootCount = 5;
		const int ShootSpeed = 5;
		const int ShootDirection = 7;
		const float Speed = 18f;
		const float Acceleration = 0.15f;
		int Timer;
		#endregion

		//@todo
		public override void AI()
		{
			NPC.TargetClosest(true);
			NPC.spriteDirection = NPC.direction;
			Player player = Main.player[NPC.target];
			if (player.dead || !player.active || !Main.dayTime)
			{
				NPC.TargetClosest(false);
				NPC.active = false;
			}
			Timer++;
			if (Timer >= 0 && Timer <= 1000) //flight
			{
				Vector2 StartPosition = new Vector2(NPC.position.X + NPC.width * 0.5f, NPC.position.Y + NPC.height * 0.5f);
				float DirectionX = Main.player[NPC.target].position.X + Main.player[NPC.target].width / 2 - StartPosition.X;
				float DirectionY = Main.player[NPC.target].position.Y + (Main.player[NPC.target].height / 2) - 120 - StartPosition.Y;
				float Length = (float)Math.Sqrt(DirectionX * DirectionX + DirectionY * DirectionY);
				float Num = Speed / Length;
				DirectionX = DirectionX * Num;
				DirectionY = DirectionY * Num;
				if (NPC.velocity.X < DirectionX)
				{
					NPC.velocity.X = NPC.velocity.X + Acceleration;
					if (NPC.velocity.X < 0 && DirectionX > 0)
						NPC.velocity.X = NPC.velocity.X + Acceleration;
				}
				else if (NPC.velocity.X > DirectionX)
				{
					NPC.velocity.X = NPC.velocity.X - Acceleration;
					if (NPC.velocity.X > 0 && DirectionX < 0)
						NPC.velocity.X = NPC.velocity.X - Acceleration;
				}
				if (NPC.velocity.Y < DirectionY)
				{
					NPC.velocity.Y = NPC.velocity.Y + Acceleration;
					if (NPC.velocity.Y < 0 && DirectionY > 0)
						NPC.velocity.Y = NPC.velocity.Y + Acceleration;
				}
				else if (NPC.velocity.Y > DirectionY)
				{
					NPC.velocity.Y = NPC.velocity.Y - Acceleration;
					if (NPC.velocity.Y > 0 && DirectionY < 0)
						NPC.velocity.Y = NPC.velocity.Y - Acceleration;
				}
				if (Main.rand.Next(36) == 1)
				{
					Vector2 StartPosition2 = new Vector2(NPC.position.X + (NPC.width * 0.5f), NPC.position.Y + (NPC.height / 2));
					float AndasRotation = (float)Math.Atan2(StartPosition2.Y - (Main.player[NPC.target].position.Y + (Main.player[NPC.target].height * 0.5f)), StartPosition2.X - (Main.player[NPC.target].position.X + (Main.player[NPC.target].width * 0.5f)));
					NPC.velocity.X = (float)(Math.Cos(AndasRotation) * 18) * -1;
					NPC.velocity.Y = (float)(Math.Sin(AndasRotation) * 18) * -1;
					NPC.netUpdate = true;
				}
			}

			if (Timer == 700)
			{
				for (int i = 0; i < 50; i++)
				{
					int dust = Dust.NewDust(NPC.position, NPC.width, NPC.height, 57);
					Main.dust[dust].scale = 1.5f;
				}
				DoAndasShoot();
				NPC.position.X = (Main.player[NPC.target].position.X - 500) + Main.rand.Next(1000);
				NPC.position.Y = (Main.player[NPC.target].position.Y - 500) + Main.rand.Next(1000);
			}

			if (Timer == 850)
			{
				for (int i = 0; i < 50; i++)
				{
					int dust = Dust.NewDust(NPC.position, NPC.width, NPC.height, 57);
					Main.dust[dust].scale = 1.5f;
				}
				DoAndasShoot();
				NPC.position.X = (Main.player[NPC.target].position.X - 500) + Main.rand.Next(1000);
				NPC.position.Y = (Main.player[NPC.target].position.Y - 500) + Main.rand.Next(1000);
			}

			if (Timer == 1000)
			{
				for (int i = 0; i < 50; i++)
				{
					int dust = Dust.NewDust(NPC.position, NPC.width, NPC.height, 57);
					Main.dust[dust].scale = 1.5f;
				}

				IEntitySource source = NPC.GetSource_FromAI();  // Создаем источник для NPC
				NPC.NewNPC(source, (int)NPC.position.X, (int)NPC.position.Y, ModContent.NPCType<MoltenSpirit>());
				DoAndasShoot();
				NPC.position.X = (Main.player[NPC.target].position.X - 500) + Main.rand.Next(1000);
				NPC.position.Y = (Main.player[NPC.target].position.Y - 500) + Main.rand.Next(1000);
			}

			if (Timer == 1150)
			{
				for (int i = 0; i < 50; i++)
				{
					int dust = Dust.NewDust(NPC.position, NPC.width, NPC.height, 57);
					Main.dust[dust].scale = 1.5f;
				}
				DoAndasShoot();
				NPC.position.X = (Main.player[NPC.target].position.X - 500) + Main.rand.Next(1000);
				NPC.position.Y = (Main.player[NPC.target].position.Y - 500) + Main.rand.Next(1000);
			}

			if (Timer == 1300)
			{
				for (int i = 0; i < 50; i++)
				{
					int dust = Dust.NewDust(NPC.position, NPC.width, NPC.height, 57);
					Main.dust[dust].scale = 1.5f;
				}

				IEntitySource source = NPC.GetSource_FromAI();  // Создаем источник для NPC
				NPC.NewNPC(source, (int)NPC.position.X, (int)NPC.position.Y, ModContent.NPCType<UndeadWyrmHead>());
				NPC.position.X = (Main.player[NPC.target].position.X - 500) + Main.rand.Next(1000);
				NPC.position.Y = (Main.player[NPC.target].position.Y - 500) + Main.rand.Next(1000);
			}

			if (Timer > 1300)
			{
				Timer = 0;
			}

		}
        void DoAndasShoot()
        {
            // Создаем источник для снаряда
            IEntitySource source = NPC.GetSource_FromAI(); // Создание источника для снаряда

            // Создаем проектиль в разных направлениях
            Projectile.NewProjectile(source, NPC.position.X + 40, NPC.position.Y + 40, -ShootDirection, 0, ModContent.ProjectileType<InfernoSkull>(), ShootDamage, ShootKnockback, Main.myPlayer, 0f, 0f);
            Projectile.NewProjectile(source, NPC.position.X + 40, NPC.position.Y + 40, ShootDirection, 0, ModContent.ProjectileType<InfernoSkull>(), ShootDamage, ShootKnockback, Main.myPlayer, 0f, 0f);
            Projectile.NewProjectile(source, NPC.position.X + 40, NPC.position.Y + 40, 0, ShootDirection, ModContent.ProjectileType<InfernoSkull>(), ShootDamage, ShootKnockback, Main.myPlayer, 0f, 0f);
            Projectile.NewProjectile(source, NPC.position.X + 40, NPC.position.Y + 40, 0, -ShootDirection, ModContent.ProjectileType<InfernoSkull>(), ShootDamage, ShootKnockback, Main.myPlayer, 0f, 0f);
        }


        /*public override bool PreDraw(SpriteBatch spriteBatch, Vector2 screenPos, Color drawColor)
		{
			Texture2D drawTexture = Main.npcTexture[NPC.type];
			Vector2 origin = new Vector2((drawTexture.Width / 2) * 0.5F, (drawTexture.Height / Main.npcFrameCount[NPC.type]) * 0.5F);

			Vector2 drawPos = new Vector2(
                NPC.position.X - Main.screenPosition.X + (NPC.width / 2) - (Main.npcTexture[NPC.type].Width / 2) * NPC.scale / 2f + origin.X * NPC.scale,
                NPC.position.Y - Main.screenPosition.Y + NPC.height - Main.npcTexture[NPC.type].Height * NPC.scale / Main.npcFrameCount[NPC.type] + 4f + origin.Y * NPC.scale + NPC.gfxOffY);

			SpriteEffects effects = NPC.spriteDirection == -1 ? SpriteEffects.None : SpriteEffects.FlipHorizontally;
			spriteBatch.Draw(drawTexture, drawPos, NPC.frame, Color.White, NPC.rotation, origin, NPC.scale, effects, 0);

			return false;
		}*/

        public override void ModifyNPCLoot(NPCLoot npcLoot)
        {
            // Выпадение обычных предметов
            npcLoot.Add(ItemDropRule.Common(ItemID.GoldCoin, 1, 6, 25)); // 6-25 золотых монет
            npcLoot.Add(ItemDropRule.Common(ItemID.SilverCoin, 1, 6, 25)); // 6-25 серебряных монет

            // Выпадение трофея с шансом 10%
            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<AndasTrophy>(), 10));

            // Выпадение маски с шансом 1/7 (14.29%) вне экспертного режима
            npcLoot.Add(ItemDropRule.ByCondition(new Conditions.NotExpert(), ModContent.ItemType<AndasMask>(), 7));

            // Гарантированное выпадение одного из трёх предметов.
            npcLoot.Add(ItemDropRule.OneFromOptions(1,
                ModContent.ItemType<GehennaStaff>(),
                ModContent.ItemType<VulcanBlade>(),
                ModContent.ItemType<HellStorm>(),
                ModContent.ItemType<Inferno>(),
                ModContent.ItemType<Pandemonium>()));

            // Альтернативное использование условия:
            npcLoot.Add(ItemDropRule.ByCondition(new Conditions.IsExpert(), ModContent.ItemType<AndasBag>(), 1));
        }
    }
}