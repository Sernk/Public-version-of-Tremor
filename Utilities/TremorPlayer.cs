using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.Graphics.Shaders;
using Terraria.ModLoader;
using Terraria.ID;
using TremorMod.Content.Items;
using TremorMod.Content.NPCs;
using Terraria.GameContent.Generation;
using Terraria.ModLoader.IO;
using Terraria.DataStructures;
using static Terraria.ModLoader.ModContent;
using Terraria.GameInput;
using Terraria.GameContent.Events;
using Terraria.GameContent;
using Terraria.Audio;
using Terraria.Graphics.Effects;
using TremorMod;
using TremorMod.Content.Items.Materials;
using TremorMod.Content.Projectiles;
using TremorMod.Content.Items.Key;
using TremorMod.Content.NPCs.Bosses.NovaPillar;
using TremorMod.Content.NPCs.Bosses.CogLord;
using TremorMod.Utilities;

namespace TremorMod
{
	public class TremorPlayer : ModPlayer
	{
        public bool core;
        public bool heartAmulet;
		public bool ZoneRuins;
		public int healHurt;
		public bool dFear;
		public bool creeperMinion;
		public bool corruptorMinion;
		public bool hungryMinion;
		public bool meteorMinion;
		public bool jellyfishMinion;
		public bool cyberMinion;
		public bool blueSakuraMinion;
		public bool goblinMinion;
		public bool shadowMinion;
		public bool AnnoyingDog;
		public bool vultureMinion;
		public bool skeletonMinion;
		public bool goldenWhale;
		public bool vortexBee;
		public bool nebulaJellyfish;
		public bool solarMeteor;
		public bool stardustSquid;
		public bool mudDoll;
		public bool Irradiated;
		public bool Brutty;
		public bool quetzalcoatlMinion;
		public bool northWind;
		public bool summonerPower;
		public bool gurdPet;
		public bool ancientVision;
		public bool ZoneGranite;
		public bool ZoneComet;
		public bool whiteSakura;
		public bool petZootaloo;
		public bool onHitShadaggers = false;
		public bool LivingTombstone;
		public bool miniCyber;
		public bool cluster;
		public bool ZoneIce;
		public bool ancientPredator;
		public bool starfishMinion;
		public bool hauntpet;
		public bool crabStaff;
		public bool zombatMinion;
		public bool huskyStaff;
		public bool ruinAltar;
		public bool emeraldy;
		public bool hunterMinion;
		public bool birbStaff;
		public bool warkee;
		public bool shadowArmSF;

		public bool zellariumHead;
		public bool zellariumBody;

		public bool ZoneTowerNova;
		public bool NovaMonolith = false;

		public int LastChest;

		public override void UpdateDead()
		{
			zellariumBody = false;
			zellariumHead = false;
		}

		public int zellariumHit;
		public int zellariumDash;
		public int zellariumCooldown;
		public override void PreUpdateBuffs()
		{
			if (Main.netMode != 1)
			{
				if (Player.chest == -1 && LastChest >= 0 && Main.chest[LastChest] != null)
				{
					int x2 = Main.chest[LastChest].x;
					int y2 = Main.chest[LastChest].y;
					ChestItemSummonCheck(x2, y2, Mod);
				}
				LastChest = Player.chest;
			}
		}
		public override void PostUpdateEquips()
		{
			if (zellariumHead)
			{
				if (zellariumDash > 0)
					zellariumDash--;
				else
					zellariumHit = -1;

				if (zellariumDash > 0 && zellariumHit < 0)
				{
					Rectangle rectangle = new Rectangle((int)(Player.position.X + Player.velocity.X * 0.5 - 4.0), (int)(Player.position.Y + Player.velocity.Y * 0.5 - 4.0), Player.width + 8, Player.height + 8);
					for (int i = 0; i < 200; i++)
					{
						if (Main.npc[i].active && !Main.npc[i].dontTakeDamage && !Main.npc[i].friendly)
						{
							NPC npc = Main.npc[i];
							Rectangle rect = npc.getRect();
							if (rectangle.Intersects(rect) && (npc.noTileCollide || Collision.CanHit(Player.position, Player.width, Player.height, npc.position, npc.width, npc.height)))
							{
								float damage = 2f * Player.GetModPlayer<MPlayer>().alchemicalDamage;
								float knockback = 3f;
								//bool crit = false;

								if (Player.kbGlove)
									knockback *= 0f;
								if (Player.kbBuff)
									knockback *= 1f;

								//if (Main.rand.Next(100) < Player.GetCritChance(DamageClass.Melee))
									//crit = true;

								int hitDirection = Player.direction;
								if (Player.velocity.X < 0f)
								{
									hitDirection = -1;
								}
								if (Player.velocity.X > 0f)
								{
									hitDirection = 1;
								}
								/*if (Player.whoAmI == Main.myPlayer)
								{
									npc.StrikeNPC((int)damage, knockback, hitDirection, crit, false, false);
									if (Main.netMode != 0)
									{
									}
								}*/

								zellariumDash = 10;
								Player.dashDelay = 0;
								Player.velocity.X = -(float)hitDirection * 2f;
								Player.velocity.Y = -2f;
								Player.immune = true;
								Player.immuneTime = 7;
								zellariumHit = i;
							}
						}
					}
				}

				if (Player.dash <= 0 && Player.dashDelay == 0 && !Player.mount.Active)
				{
					int num21 = 0;
					bool flag2 = false;
					if (Player.dashTime > 0)
						Player.dashTime--;
					if (Player.dashTime < 0)
						Player.dashTime++;

					if (Player.controlRight && Player.releaseRight)
					{
						if (Player.dashTime > 0)
						{
							num21 = 1;
							flag2 = true;
							Player.dashTime = 0;
						}
						else
						{
							Player.dashTime = 15;
						}
					}
					else if (Player.controlLeft && Player.releaseLeft)
					{
						if (Player.dashTime < 0)
						{
							num21 = -1;
							flag2 = true;
							Player.dashTime = 0;
						}
						else
						{
							Player.dashTime = -15;
						}
					}

					if (flag2)
					{
						Player.velocity.X = 25f * num21;
						Point point3 = (Player.Center + new Vector2(num21 * Player.width / 2 + 2, Player.gravDir * -(float)Player.height / 2f + Player.gravDir * 2f)).ToTileCoordinates();
						Point point4 = (Player.Center + new Vector2(num21 * Player.width / 2 + 2, 0f)).ToTileCoordinates();
						if (WorldGen.SolidOrSlopedTile(point3.X, point3.Y) || WorldGen.SolidOrSlopedTile(point4.X, point4.Y))
						{
							Player.velocity.X = Player.velocity.X / 2f;
						}
						Player.dashDelay = -1;
						zellariumDash = 15;
						for (int num22 = 0; num22 < 100; num22++)
						{
							int num23 = Dust.NewDust(new Vector2(Player.position.X, Player.position.Y), Player.width, Player.height, 59, 0f, 0f, 100, default(Color), 2f);
							Dust dust3 = Main.dust[num23];
							dust3.position.X = dust3.position.X + Main.rand.Next(-5, 6);
							Dust dust4 = Main.dust[num23];
							dust4.position.Y = dust4.position.Y + Main.rand.Next(-5, 6);
							Main.dust[num23].velocity *= 0.2f;
							Main.dust[num23].scale *= 1f + Main.rand.Next(20) * 0.01f;
							Main.dust[num23].shader = GameShaders.Armor.GetSecondaryShader(Player.shield, Player);
						}
					}
				}
			}
			if (zellariumDash > 0)
				zellariumDash--;
			if (Player.dashDelay < 0)
			{
				for (int l = 0; l < 0; l++)
				{
					int num14;
					if (Player.velocity.Y == 0f)
					{
						num14 = Dust.NewDust(new Vector2(Player.position.X, Player.position.Y + Player.height - 4f), Player.width, 8, 59, 0f, 0f, 100, default(Color), 1.4f);
					}
					else
					{
						num14 = Dust.NewDust(new Vector2(Player.position.X, Player.position.Y + (Player.height / 2) - 8f), Player.width, 16, 59, 0f, 0f, 100, default(Color), 1.4f);
					}
					Main.dust[num14].velocity *= 0.1f;
					Main.dust[num14].scale *= 1f + Main.rand.Next(20) * 0.01f;
					Main.dust[num14].shader = GameShaders.Armor.GetSecondaryShader(Player.shoe, Player);
				}

				float maxSpeed = Math.Max(Player.accRunSpeed, Player.maxRunSpeed);

				Player.vortexStealthActive = false;
				if (Player.velocity.X > 12f || Player.velocity.X < -12f)
				{
					Player.velocity.X = Player.velocity.X * 0.985f;
					return;
				}
				if (Player.velocity.X > maxSpeed || Player.velocity.X < -maxSpeed)
				{
					Player.velocity.X = Player.velocity.X * 0.94f;
					return;
				}
				Player.dashDelay = 30;
				if (Player.velocity.X < 0f)
				{
					Player.velocity.X = -maxSpeed;
					return;
				}
				if (Player.velocity.X > 0f)
				{
					Player.velocity.X = maxSpeed;
				}
			}
		}
        public override void ModifyHurt(ref Player.HurtModifiers modifiers)
        {
            if (zellariumBody && Main.rand.Next(10) == 0)
            {
                // Если zellariumBody активен, то просто завершаем метод без изменений
                return;
            }

            // Предполагается, что модификации повреждений выполняются в базовом методе
            base.ModifyHurt(ref modifiers); // Применяем изменения через базовый метод
        }

        public override void ResetEffects()
		{
			heartAmulet = false;
			dFear = false;
			healHurt = 0;
			creeperMinion = false;
			corruptorMinion = false;
			hungryMinion = false;
			jellyfishMinion = false;
			meteorMinion = false;
			cyberMinion = false;
			blueSakuraMinion = false;
			goblinMinion = false;
			shadowMinion = false;
			AnnoyingDog = false;
			vultureMinion = false;
			skeletonMinion = false;
			goldenWhale = false;
			vortexBee = false;
			nebulaJellyfish = false;
			solarMeteor = false;
			stardustSquid = false;
			Irradiated = false;
			mudDoll = false;
			Brutty = false;
			quetzalcoatlMinion = false;
			northWind = false;
			summonerPower = false;
			gurdPet = false;
			ancientVision = false;
			whiteSakura = false;
			petZootaloo = false;
			LivingTombstone = false;
			miniCyber = false;
			cluster = false;
			ancientPredator = false;
			starfishMinion = false;
			hauntpet = false;
			crabStaff = false;
			zombatMinion = false;
			huskyStaff = false;
			ruinAltar = false;
			emeraldy = false;
			hunterMinion = false;
			birbStaff = false;
			warkee = false;
			shadowArmSF = false;
		}

		//private float _fadeOpacity;
		//private float maxDepth;
		//private float minDepth;

		public override void OnRespawn()
		{
			if (heartAmulet)
			{
				Player.statLife = (Player.statLifeMax2 / 100) * 80;
			}
		}

		private struct LightPillar
		{
			//public Vector2 Position;
			//public float Depth;
		}
		//private LightPillar[] _pillars;

		public static int[] iceWidth = new int[3];
		public static int[] iceHeight = new int[3];
		public static Texture2D[] backgroundTexture = new Texture2D[3];

        public void UpdateBiomes()
        {
            ZoneRuins = (TremorWorld.RuinsTiles > 50);
            ZoneGranite = (TremorWorld.GraniteTiles > 100);
            ZoneIce = (TremorWorld.IceTiles > 100);
            ZoneComet = (TremorWorld.CometTiles > 30);

            ZoneTowerNova = false;
            if (!Player.ZoneTowerSolar && !Player.ZoneTowerVortex && !Player.ZoneTowerNebula && !Player.ZoneTowerStardust)
            {
                for (int i = 0; i < Main.maxNPCs; i++)
                {
                    var npc = Main.npc[i];
                    if (npc != null && npc.active && npc.type == ModContent.NPCType<NovaPillar>() && Player.Distance(npc.Center) <= 4000f)
                    {
                        ZoneTowerNova = true;
                    }
                }
            }
        }

        const int XOffset = 400;
		const int YOffset = 400;
		public override void PostUpdate()
		{
			//bool First = true;
			const int XOffset = 400;
			const int YOffset = 400;

			// CyberWrathInvasion modPlayer = Main.player[Main.myPlayer].GetModPlayer<CyberWrathInvasion>(mod);
			if (ZoneIce)
			{
				Player.ZoneSnow = true;
			}
			if (ZoneComet)
			{
				Player player = Main.player[Main.myPlayer]; // Получаем текущего игрока
				IEntitySource source = player.GetSource_FromThis(); // Источник появления NPC

				if (Main.rand.Next(310) == 0)
				{
					switch (Main.rand.Next(0, 4))
					{
						case 0:
							NPC.NewNPC(source, (int)player.Center.X + XOffset, (int)player.Center.Y + YOffset, ModContent.NPCType<CometHead>()); break;
						case 1:
							NPC.NewNPC(source, (int)player.Center.X + XOffset, (int)player.Center.Y - YOffset, ModContent.NPCType<CometHead>()); break;
						case 2:
							NPC.NewNPC(source, (int)player.Center.X - XOffset, (int)player.Center.Y + YOffset, ModContent.NPCType<CometHead>()); break;
						case 3:
							NPC.NewNPC(source, (int)player.Center.X - XOffset, (int)player.Center.Y - YOffset, ModContent.NPCType<CometHead>()); break;
					}
				}

				if (Main.rand.Next(700) == 0)
				{
					switch (Main.rand.Next(0, 4))
					{
						case 0:
							NPC.NewNPC(source, (int)player.Center.X + XOffset, (int)player.Center.Y + YOffset, ModContent.NPCType<Galasquid>()); break;
						case 1:
							NPC.NewNPC(source, (int)player.Center.X + XOffset, (int)player.Center.Y - YOffset, ModContent.NPCType<Galasquid>()); break;
						case 2:
							NPC.NewNPC(source, (int)player.Center.X - XOffset, (int)player.Center.Y + YOffset, ModContent.NPCType<Galasquid>()); break;
						case 3:
							NPC.NewNPC(source, (int)player.Center.X - XOffset, (int)player.Center.Y - YOffset, ModContent.NPCType<Galasquid>()); break;
					}
				}

				if (Main.rand.Next(860) == 0)
				{
					switch (Main.rand.Next(0, 4))
					{
						case 0:
							NPC.NewNPC(source, (int)player.Center.X + XOffset, (int)player.Center.Y + YOffset, ModContent.NPCType<Astrofly>()); break;
						case 1:
							NPC.NewNPC(source, (int)player.Center.X + XOffset, (int)player.Center.Y - YOffset, ModContent.NPCType<Astrofly>()); break;
						case 2:
							NPC.NewNPC(source, (int)player.Center.X - XOffset, (int)player.Center.Y + YOffset, ModContent.NPCType<Astrofly>()); break;
						case 3:
							NPC.NewNPC(source, (int)player.Center.X - XOffset, (int)player.Center.Y - YOffset, ModContent.NPCType<Astrofly>()); break;
					}
				}
			}
		}

		public override IEnumerable<Item> AddStartingItems(bool mediumCoreDeath)
		{
			if (!mediumCoreDeath)
			{
				yield return new Item(ModContent.ItemType<AdventurerSpark>());
			}
		}

		public bool CustomBiomesMatch(Player other)
        {
            var modOther = other.GetModPlayer<TremorPlayer>();
            return modOther.ZoneTowerNova == this.ZoneTowerNova;
        }

        public void CopyCustomBiomesTo(Player other)
        {
            var modOther = other.GetModPlayer<TremorPlayer>();
            modOther.ZoneTowerNova = this.ZoneTowerNova;
        }

        public void SendCustomBiomes(BinaryWriter writer)
        {
            byte flags = 0;
            if (ZoneGranite)
            {
                flags |= 1;
            }
            if (ZoneTowerNova)
            {
                flags |= 2;
            }
            writer.Write(flags);
        }

        public void ReceiveCustomBiomes(BinaryReader reader)
        {
            byte flags = reader.ReadByte();
            ZoneGranite = (flags & 1) != 0;
            ZoneTowerNova = (flags & 2) != 0;
        }


        public void OnHit(float x, float y, Entity victim)
        {
            if (onHitShadaggers && Main.rand.NextBool(4))
            {
                Player.petalTimer = 20;

                int direction = Player.direction;
                float num = Main.screenPosition.X;
                if (direction < 0)
                {
                    num += Main.screenWidth;
                }
                float num2 = Main.screenPosition.Y;
                num2 += Main.rand.Next(Main.screenHeight);

                Vector2 spawnPosition = new Vector2(num, num2);
                Vector2 targetPosition = new Vector2(x, y);

                Vector2 velocity = targetPosition - spawnPosition;
                velocity.X += Main.rand.Next(-50, 51) * 0.1f;
                velocity.Y += Main.rand.Next(-50, 51) * 0.1f;

                float speed = 24f;
                velocity.Normalize();
                velocity *= speed;

                // Используем IEntitySource для указания источника создания снаряда
                IEntitySource source = victim.GetSource_FromAI();

                Projectile.NewProjectile(
                    source,
                    spawnPosition.X,
                    spawnPosition.Y,
                    velocity.X,
                    velocity.Y,
                    ModContent.ProjectileType<ParaxydeKnifePro>(),
                    46,
                    0f,
                    Player.whoAmI,
                    0f,
                    0f
                );
            }
        }


        public override void UpdateBadLifeRegen()
		{
			ResetRegen(dFear || healHurt > 0, Player);

			Player.lifeRegen -= dFear
				? 10 : healHurt > 0
				? 120 * healHurt : 0;
		}

		private void ResetRegen(bool condition, Player player)
		{
			if (condition)
			{
				if (player.lifeRegen > 0)
				{
					player.lifeRegen = 0;
				}
				player.lifeRegenTime = 0;
			}
		}

        public void UpdateCustomBiomeVisuals()
        {
            var modPlayer = Player.GetModPlayer<TremorPlayer>();

            // Обновление визуальных эффектов биомов
            bool useIceEffects = modPlayer.ZoneIce;
            Player.ManageSpecialBiomeVisuals("Tremor:Ice", useIceEffects);

            bool useCogLordEffects = NPC.AnyNPCs(Mod.Find<ModNPC>("CogLord").Type);
            Player.ManageSpecialBiomeVisuals("Tremor:CogLord", useCogLordEffects);

            bool useNovaEffects = modPlayer.ZoneTowerNova || NovaMonolith;
            Player.ManageSpecialBiomeVisuals("Tremor:Nova", useNovaEffects);
		}

		public override void CatchFish(FishingAttempt attempt, ref int itemDrop, ref int npcSpawn, ref AdvancedPopupRequest sonar, ref Vector2 sonarPosition)
		{
			// Проверяем, является ли это мусором
			if (itemDrop == ItemID.OldShoe || itemDrop == ItemID.FishingSeaweed || itemDrop == ItemID.TinCan)
			{
				return;
			}

			// Список квестовых рыб
			string[] questFishes =
			{
				"CornFish",
				"SunflowerFish",
				"PumpfishFish",
				"ParrotFish",
				"CrateFish",
				"ForkFish",
				"GlassFish",
				"JawFish",
				"CoalFish",
				"CultistFish",
				"AlienFish",
				"LunarSquid"
			};

			// Проверяем, совпадает ли текущая рыба с квестовой
			string qFish = questFishes.FirstOrDefault(fish => Mod.Find<ModItem>(fish).Type == attempt.questFish);

			if (qFish != null && Main.rand.NextBool(10))
			{
				itemDrop = Mod.Find<ModItem>(qFish).Type;
			}
			else
			{
				// Список рыб, зависящих от зоны
				string[] zoneFish =
				{
					"WoodenPiranha",
					"KeyFish"
				};

                // Условия для зон
                bool[] zoneCond =
				{
					Player.ZoneJungle, 
					Player.ZoneDungeon 
				};

                // Проверяем рыбу зоны
                qFish = zoneFish.FirstOrDefault(fish => zoneCond[zoneFish.ToList().IndexOf(fish)]);

				if (qFish != null && Main.rand.NextBool(10))
				{
					itemDrop = Mod.Find<ModItem>(qFish).Type;
				}
				else
				{
					// Редкая рыба в хардмоде
					if (Main.hardMode && Main.rand.Next(20) == 0)
					{
						itemDrop = ModContent.ItemType<GreenPuzzleFragment>(); // Исправлено здесь
					}
				}
			}
		}

        // Straight up copy from removed `DesertMimicSummon` class.
        public static bool ChestItemSummonCheck(int x, int y, Mod mod)
        {
            if (Main.netMode == 1) return false;

            int num = Chest.FindChest(x, y);
            if (num < 0) return false;

            int numberDesertKey = 0;
            int numberJungleKey = 0;
            int numberOceanKey = 0;
            int numberOtherItems = 0;

            ushort tileType = Main.tile[Main.chest[num].x, Main.chest[num].y].TileType;
            int tileStyle = Main.tile[Main.chest[num].x, Main.chest[num].y].TileFrameX / 36;
            if (TileID.Sets.BasicChest[tileType] && (tileStyle < 5 || tileStyle > 6))
            {
                for (int i = 0; i < 40; i++)
                {
                    if (Main.chest[num].item[i] != null && Main.chest[num].item[i].type > 0)
                    {
                        if (Main.chest[num].item[i].type == ModContent.ItemType<KeyofSands>())
                            numberDesertKey += Main.chest[num].item[i].stack;
                        else if (Main.chest[num].item[i].type == ModContent.ItemType<KeyofTwilight>())
                            numberJungleKey += Main.chest[num].item[i].stack;
                        else if (Main.chest[num].item[i].type == ModContent.ItemType<KeyofOcean>())
                            numberOceanKey += Main.chest[num].item[i].stack;
                        else
                            numberOtherItems++;
                    }
                }
            }

            if (numberOtherItems == 0 && numberDesertKey == 1)
            {
                if (TileID.Sets.BasicChest[Main.tile[x, y].TileType])
                {
                    if (Main.tile[x, y].TileFrameX % 36 != 0)
                        x--;
                    if (Main.tile[x, y].TileFrameY % 36 != 0)
                        y--;
                    int number = Chest.FindChest(x, y);
                    for (int j = x; j <= x + 1; j++)
                    {
                        for (int k = y; k <= y + 1; k++)
                        {
                            Tile tile = Main.tile[j, k];
                            if (tile.TileType == TileID.Containers)
                                tile.HasTile = false;
                        }
                    }
                    for (int l = 0; l < 40; l++)
                        Main.chest[number].item[l] = new Item();
                    Chest.DestroyChest(x, y);
                    NetMessage.SendData(34, -1, -1, null, 1, x, y, 0f, number, 0, 0);
                    NetMessage.SendTileSquare(-1, x, y, 3);
                }
                int npcToSpawn = ModContent.NPCType<DesertMimic>();
                int npcIndex = NPC.NewNPC(
                    new EntitySource_ItemUse(Main.LocalPlayer, Main.LocalPlayer.HeldItem),
                    (int)(x * 16 + 16),
                    (int)(y * 16 + 32),
                    npcToSpawn,
                    0,
                    0f,
                    0f,
                    0f,
                    0f,
                    255
                );
                Main.npc[npcIndex].whoAmI = npcIndex;
                NetMessage.SendData(23, -1, -1, null, npcIndex, 0f, 0f, 0f, 0, 0, 0);
                Main.npc[npcIndex].BigMimicSpawnSmoke();
            }
            else if (numberOtherItems == 0 && numberJungleKey == 1)
            {
                if (TileID.Sets.BasicChest[Main.tile[x, y].TileType])
                {
                    if (Main.tile[x, y].TileFrameX % 36 != 0)
                        x--;
                    if (Main.tile[x, y].TileFrameY % 36 != 0)
                        y--;

                    int number = Chest.FindChest(x, y);

                    for (int j = x; j <= x + 1; j++)
                    {
                        for (int k = y; k <= y + 1; k++)
                        {
                            Tile tile = Main.tile[j, k]; // Получаем объект Tile
                            if (tile.TileType == TileID.Containers)
                                tile.HasTile = false; // Изменяем свойство HasTile
                        }
                    }

                    for (int l = 0; l < 40; l++)
                        Main.chest[number].item[l] = new Item(); // Очищаем сундук

                    Chest.DestroyChest(x, y);
                    NetMessage.SendData(34, -1, -1, null, 1, x, y, 0f, number, 0, 0);
                    NetMessage.SendTileSquare(-1, x, y, 3);
                }

                int npcToSpawn = ModContent.NPCType<JungleMimic>();
                int npcIndex = NPC.NewNPC(
                    new EntitySource_ItemUse(Main.LocalPlayer, Main.LocalPlayer.HeldItem), // Передаем текущий предмет
                    (int)(x * 16 + 16),
                    (int)(y * 16 + 32),
                    npcToSpawn,
                    0,
                    0f,
                    0f,
                    0f,
                    0f,
                    255
                );
                Main.npc[npcIndex].whoAmI = npcIndex;
                NetMessage.SendData(23, -1, -1, null, npcIndex, 0f, 0f, 0f, 0, 0, 0);
                Main.npc[npcIndex].BigMimicSpawnSmoke();
            }
            else if (numberOtherItems == 0 && numberOceanKey == 1)
            {
                if (TileID.Sets.BasicChest[Main.tile[x, y].TileType])
                {
                    if (Main.tile[x, y].TileFrameX % 36 != 0)
                        x--;
                    if (Main.tile[x, y].TileFrameY % 36 != 0)
                        y--;

                    int number = Chest.FindChest(x, y);

                    for (int j = x; j <= x + 1; j++)
                    {
                        for (int k = y; k <= y + 1; k++)
                        {
                            Tile tile = Main.tile[j, k];
                            if (tile.TileType == TileID.Containers)
                                tile.HasTile = false;
                        }
                    }

                    for (int l = 0; l < 40; l++)
                        Main.chest[number].item[l] = new Item();

                    Chest.DestroyChest(x, y);
                    NetMessage.SendData(34, -1, -1, null, 1, x, y, 0f, number, 0, 0);
                    NetMessage.SendTileSquare(-1, x, y, 3);
                }

                int npcToSpawn = ModContent.NPCType<OceanMimic>();
                int npcIndex = NPC.NewNPC(
                    new EntitySource_ItemUse(Main.LocalPlayer, Main.LocalPlayer.HeldItem),
                    (int)(x * 16 + 16),
                    (int)(y * 16 + 32),
                    npcToSpawn,
                    0,
                    0f,
                    0f,
                    0f,
                    0f,
                    255
                );
                Main.npc[npcIndex].whoAmI = npcIndex;
                NetMessage.SendData(23, -1, -1, null, npcIndex, 0f, 0f, 0f, 0, 0, 0);
                Main.npc[npcIndex].BigMimicSpawnSmoke();
            }
            return false;
        }
    }
}