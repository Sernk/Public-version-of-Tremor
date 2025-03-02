using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using TremorMod.Content.Items.Armor.Heaven;
using TremorMod.Content.Items.Buffs;
using TremorMod.Content.Items.Armor.Paladin;
using Terraria.ModLoader;
using TremorMod.Content.Items.Bag;
using TremorMod.Content.Items.BossLoot.TikiTotem;
using TremorMod.Content.Items.Armor.Meteor;
using Terraria.GameContent.ItemDropRules;
using TremorMod.Content.Buffs;
using TremorMod.Content.Items.Armor.Zerokk;
using TremorMod.Content.Items.Armor.Hummer;
using TremorMod.Content.Items.Weapons.Alchemical;
using TremorMod.Content.Items.Accessories;
using TremorMod.Content.Items.BossSumonItems;
using TremorMod.Content.Items.CogLordItems;
using TremorMod.Content.Items;
using TremorMod.Content.Items.CraftingStations;
using TremorMod.Content.Items.Crystal;
using TremorMod.Content.Items.CyberKing;
using TremorMod.Content.Items.EvilCornItems;
using TremorMod.Content.Items.Fish;
using TremorMod.Content.Items.Fungus;
using TremorMod.Content.Items.HeaterOfWorldsItems;
using TremorMod.Content.Items.Key;
using TremorMod.Content.Items.Materials;
using TremorMod.Content.Items.NPCsDrop;
using TremorMod.Content.Items.Placeable;
using TremorMod.Content.Items.SpaceWhaleItems;
using TremorMod.Content.Items.Tools;
using TremorMod.Content.Items.Vanity;
using TremorMod.Content.Items.Weapons;
using TremorMod.Content.Items.Weapons.Magic;
using TremorMod.Content.Items.Weapons.Melee;
using TremorMod.Content.Items.Weapons.Ranged;
using TremorMod.Content.Items.Weapons.Summon;
using TremorMod.Content.Items.Weapons.Throwing;
using TremorMod.Content.Items.Wood;
using TremorMod;

namespace TremorMod.Utilities
{
    public class TremorNPC : GlobalNPC
    {
        public override void ModifyNPCLoot(NPC npc, NPCLoot npcLoot)
        {
            if (NPC.downedMoonlord)
            {
                int[] moonlordNpcTypes = { 147, 150, 154, 155, 161, 167, 168, 169, 184, 185, 197, 206, 431 };

                if (moonlordNpcTypes.Contains(npc.type))
                {
                    npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<IceSoul>(), 7));
                }
            }

            int[] ribNpcTypes = { 77, 110 };

            if (ribNpcTypes.Contains(npc.type))
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<TheRib>(), 3));
            }

            int[] StoneofLNpcTypes = { 481, 483 };

            if (StoneofLNpcTypes.Contains(npc.type))
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<StoneofLife>(), 4));
            }

            if (npc.type == 140)
            {
                npcLoot.Add(ItemDropRule.OneFromOptions(25, ModContent.ItemType<PossessedHelmet>(), ModContent.ItemType<PossessedChestplate>(), ModContent.ItemType<PossessedGreaves>()));
            }

            if (npc.type == NPCID.WallofFlesh)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<AlchemistEmblem>(), 4));
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<ThrowerEmblem>(), 4));
            }

            if (!Main.expertMode && npc.type == 134)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Destructor>(), 6));
            }

            if (((npc.type == 381) || (npc.type == 382) || (npc.type == 383) || (npc.type == 385) || (npc.type == 386) ||
            (npc.type == 388) || (npc.type == 389) || (npc.type == 390) || (npc.type == 391) || (npc.type == 520)))
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Transistor>(), 500));
            }

            if (!Main.expertMode && npc.type == 113)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<PieceofFlesh>(), 1, 8, 17));
            }

            if (npc.type == 489)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Stigmata>(), 30));
            }

            int[] DemonBNpcTypes = { 66, 62 };

            if (DemonBNpcTypes.Contains(npc.type))
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<DemonBlood>(), 2));
            }

            if (npc.type == 111)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<LongBow>(), 20));
            }

            if (npc.type == 127)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<BenderHead>(), 3));

                if (!Main.expertMode)
                {
                    npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<PrimeBlade>(), 6));
                }
            }

            if (npc.type == 125 || npc.type == 126)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<BenderBody>(), 5));
            }

            if (npc.type == 134)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<BenderLegs>(), 3));
            }

            int[] ToxicHNpcTypes = { 42, 231, 232, 233, 234, 235 };

            if (ToxicHNpcTypes.Contains(npc.type))
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<ToxicHilt>(), 30));
            }

            if (npc.type == 6)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<PiercingQuartz>(), 30));
            }

            if (npc.type == 239)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Vertebrow>(), 28));
            }

            if (npc.type == 166)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<SwampClump>(), 28));
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<FiercePaw>(), 25));
            }

            if (npc.type == 469)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<LeechingSeed>(), 28));
            }

            if (npc.type == 460)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<ButcherMask>(), 20));
            }

            if (npc.type == 175)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<ThornBall>(), 2, 6, 15));
            }

            int[] ArachnophobiaNpcTypes = { 164, 165 };

            if (ArachnophobiaNpcTypes.Contains(npc.type))
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Arachnophobia>(), 40));
            }

            if (!TremorSpawnEnemys.downedMotherboard && Main.hardMode)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<MechanicalBrain>(), 2500));
            }

            if (npc.type == 532)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<PetrifiedSpike>(), 3, 5, 10));
            }

            int[] ScorpionSNpcTypes = { 530, 531 };

            if (ScorpionSNpcTypes.Contains(npc.type))
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<ScorpionStinger>(), 16));
            }

            if (npc.type == 23)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<AncientMeteorHelmet>(), 100));
            }

            if (npc.type == 346)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<SantaNK1Mask>(), 7));
            }

            if (npc.type == 345)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<IceQueenMask>(), 7));
            }

            if (npc.type == 344)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<EverscreamMask>(), 7));
            }

            int[] PumpkingNpcTypes = { 327, 328 };

            if (PumpkingNpcTypes.Contains(npc.type))
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<PumpkingMask>(), 7));
            }

            if (npc.type == 325)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<MourningWoodMask>(), 7));
            }

            if (npc.type == 491)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<PirateChest>(), 3));
            }

            if (!Main.expertMode && npc.type == 245)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<GolemCore>(), 1));
            }

            if (npc.type == 124)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<ThrowingWrench>(), 1, 10, 20));
            }

            if (npc.type == 513)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<IonBlaster>(), 25));
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<PetrifiedSpike>(), 3, 5, 10));
            }

            if ((npc.type == 3 || npc.type == 186 || npc.type == 187 || npc.type == 188 ||
            npc.type == 189 || npc.type == 200 || npc.type == 132 || npc.type == 319 || npc.type == 320 ||
            npc.type == 321 || npc.type == 331 || npc.type == 332 || npc.type == 430 || npc.type == 432 ||
            npc.type == 433 || npc.type == 434 || npc.type == 435 || npc.type == 436))
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<UntreatedFlesh>(), 3));
            }

            if ((npc.type == 48 || npc.type == 75 || npc.type == 87))
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<AirFragment>(), 3));
            }

            if ((npc.type == 58 || npc.type == 65 || npc.type == 63 || npc.type == 64 || npc.type == 102 ||
            npc.type == 103 || npc.type == 157))
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<SeaFragment>(), 2));
            }

            if ((npc.type == 10 || npc.type == 95 || npc.type == 56 || npc.type == 153 || npc.type == 175 ||
            npc.type == 176 || npc.type == 205 || npc.type == 231 || npc.type == 232 || npc.type == 233 ||
            npc.type == 234 || npc.type == 235 || npc.type == 236 || npc.type == 237))
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<EarthFragment>(), 4));
            }

            if ((npc.type == 24 || npc.type == 59 || npc.type == 60 || npc.type == 151 || npc.type == 62 ||
            npc.type == 66))
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<FireFragment>(), 3));
            }

            if ((npc.type == 466 || npc.type == 467 || npc.type == 468 || npc.type == 463 || npc.type == 460))
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<DarkMatter>(), 2));
            }

            if (npc.type == 496)
            {
                //npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<PurpleShellmet>(), 22));
            }

            if (npc.type == 497)
            {
                //npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<OrangeShellmet>(), 22));
            }

            if (npc.lifeMax > 100 && npc.lifeMax < 200)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<TinySai>(), 300));
            }

            if (npc.value > 100f && npc.value < 1000f)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<RoyalClaymore>(), 300));
            }

            if (npc.lifeMax > 200 && npc.lifeMax < 500)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<MassiveHammer>(), 300));
            }

            if (npc.defense > 10 && npc.defense < 30)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Crowbar>(), 300));
            }

            if (npc.damage < 200 && npc.damage > 80)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Narsil>(), 300));
            }

            if (npc.boss && !Main.hardMode)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<HeavenHelmet>(), 5));
            }

            if (npc.boss && !Main.hardMode)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<HeavenBreastplate>(), 5));
            }

            if (npc.boss && !Main.hardMode)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<HeavenLeggings>(), 5));
            }

            if (npc.type == 13)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<CorruptorStaff>(), 20));
            }

            if (npc.type == 266)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<CreeperStaff>(), 20));
            }

            if (Main.xMas && !Main.player[Main.myPlayer].HasItem(ModContent.ItemType<SuspiciousLookingPresent>()))
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<SuspiciousLookingPresent>(), 250));
            }

            if (NPC.downedMoonlord)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<SuspiciousBag>(), 250));
            }

            if (NPC.downedMoonlord && Main.player[Main.myPlayer].ZoneDungeon)
            {
                if (npc.lifeMax > 200 && !Main.expertMode)
                {
                    npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Phantaplasm>(), 4));
                }
                if (npc.lifeMax > 400 && Main.expertMode)
                {
                    npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Phantaplasm>(), 4));
                }
            }

            if (npc.type == 7)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<CorruptorGun>(), 26));
            }

            if ((npc.type == 69 || npc.type == 508))
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<AntlionShell>(), 6));
            }

            if (npc.type == 298)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<RedMask>(), 100));
            }

            if (npc.type == 494)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<RedClaw>(), 29));
            }

            if (npc.type == 495)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<GreenClaw>(), 29));
            }

            if ((npc.type == 498 || npc.type == 499 || npc.type == 500 || npc.type == 501 || npc.type == 502 ||
            npc.type == 503 || npc.type == 504 || npc.type == 505 || npc.type == 506))
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<SalamanderSkin>(), 2));
            }

            if ((npc.type == 173))
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<CrimCudgel>(), 173));
            }

            if ((npc.type == 4))
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<TriangleMask>(), 10));
            }

            if ((npc.type == 35))
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<TheArtifact>(), 6));
            }

            if (Main.eclipse && NPC.downedMoonlord)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<ToothofAbraxas>(), 10));
            }

            if ((npc.type == 125 || npc.type == 126 || npc.type == 127 || npc.type == 134) && NPC.downedMoonlord)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<CarbonSteel>(), 1, 6, 12));
            }

            int[] RedSteelNPCs = { 21, 449, 450, 451, 452, 322, 323, 324, 294, 295, 296, 201, 202, 20 };

            if (WorldGen.shadowOrbSmashed && RedSteelNPCs.Contains(npc.type))
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<RedSteelArmorPiece>(), 8));
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<FaultyRedSteelShield>(), 8));
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<ChippyRedSteelSword>(), 8));
            }

            if ((npc.type == 489))
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<TheBrain>(), 24));
            }

            if ((npc.type == 490))
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<DrippingRoot>(), 4));
            }

            if ((npc.aiStyle == 1) && NPC.downedMoonlord)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<DarkMass>(), 60));
            }

            if ((npc.type == 164 || npc.type == 165))
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<SpiderMeat>(), 5, 1, 3));
            }

            if ((npc.type == 98 || npc.type == 94 || npc.type == 101 || npc.type == 170 || npc.type == 180 ||
            npc.type == 182) && NPC.downedMoonlord)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<ClusterShard>(), 7, 1, 2));
            }

            if ((npc.type == 175 || npc.type == 205 || npc.type == 226) && NPC.downedMoonlord)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<DragonCapsule>(), 4, 1, 2));
            }

            if (npc.type == 290 && NPC.downedMoonlord)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<PaladinHelmet>(), 20));
            }

            if (npc.type == 290 && NPC.downedMoonlord)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<PaladinBreastplate>(), 20));
            }

            if (npc.type == 290 && NPC.downedMoonlord)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<PaladinGreaves>(), 20));
            }

            if (!Main.expertMode && npc.type == 35)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<TearsofDeath>(), 1, 1, 3));
            }

            int[] FrostCoreNpcTypes = { 169, 431, 161 };

            if (FrostCoreNpcTypes.Contains(npc.type))
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<FrostCore>(), 5, 1, 3));
            }

            if (npc.type == 477)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<BrokenHeroAmulet>(), 4));
            }

            int[] WaterStormNpcTypes = { 32, 34 };

            if (WaterStormNpcTypes.Contains(npc.type))
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<WaterStorm>(), 50));
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<KeyKnife>(), 40));
            }

            if (!Main.expertMode && npc.type == 4)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<EyeMonolith>(), 5));
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<MonsterTooth>(), 3, 20, 40));
            }

            if (npc.type == 167)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<NorthAxe>(), 32));
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<NorthHammer>(), 32));
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<NorthCutlass>(), 32));
            }

            if (npc.type == 82)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<WrathofWraith>(), 40));
            }

            if (npc.type == 439)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<AncientTablet>(), 1, 12, 22));
            }

            if (npc.type == 262)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<EssenseofJungle>(), 1, 2, 3));
            }

            if (npc.type == 370 && !Main.expertMode)
            {
                //npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<DukesCannon>(), 1, 2, 3));
            }

            int[] CrystalSpearNpcTypes = { 138, 137 };

            if (CrystalSpearNpcTypes.Contains(npc.type))
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<CrystalSpear>(), 35, 2, 3));
            }

            if (npc.type == 39)
            {
                //npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<GunBlade>(), 1, 2, 3));
            }

            if (npc.type == 346)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<SpiK3Ball>(), 1, 50, 100));
            }

            if (!NPC.downedMoonlord && (npc.type == 75 || npc.type == 86 || npc.type == 244 || npc.type == 122 || npc.type == 80 || npc.type == 527))
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<UnstableCrystal>(), 50));
            }

            if (npc.type == 17)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<MoneySack>(), 2, 2, 4));
            }

            if (npc.type == 398)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<MultidimensionalFragment>(), 1, 2, 4));
            }

            if (!Main.expertMode && npc.type == 222)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<YellowPuzzleFragment>(), 3));
            }

            if ((npc.type == 381 || npc.type == 382 || npc.type == 383 || npc.type == 385 || npc.type == 386 || npc.type == 387 || npc.type == 388 || npc.type == 389 || npc.type == 390))
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<WarpPad>(), 100));
            }

            if ((npc.type == 273 || npc.type == 274 || npc.type == 275 || npc.type == 276 || npc.type == 269 || npc.type == 270 || npc.type == 271 || npc.type == 272 || npc.type == 277 || npc.type == 278 || npc.type == 279 || npc.type == 280 || npc.type == 283 || npc.type == 284 || npc.type == 281 || npc.type == 282 || npc.type == 285 || npc.type == 286))
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<BottledSpirit>(), 25));
            }

            if ((npc.type == 134 || npc.type == 125 || npc.type == 126 || npc.type == 127) && NPC.downedMechBossAny)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<FlaskCore>(), 10));
            }

            if (npc.type == 175)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<RichMahoganySeed>(), 50));
            }

            if (!Main.expertMode && npc.type == 126 && !NPC.AnyNPCs(125))
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<BottledSpirit>(), 25));
            }

            if (!Main.expertMode && Main.rand.NextBool(6))
            {
                if ((npc.type == 126 && !NPC.AnyNPCs(125)) || (npc.type == 125 && !NPC.AnyNPCs(126)))
                {
                    npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<MechaSprayer>(), 1));
                }
            }

            if (npc.type == 395)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<MartianSprayer>(), 20));
            }

            if (npc.type == 370)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<DukeFlask>(), 1, 550, 750));
            }

            if (npc.type == 120)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<ChaosElement>(), 20));
            }

            if ((npc.type == 361 || npc.type == 445))
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<FrogMask>(), 33));
            }

            if (npc.type == 35)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<CursedSoul>(), 1, 1, 5));
            }
        }

        public override void ModifyShop(NPCShop shop)
        {
            if (shop.NpcType == NPCID.Merchant && Main.bloodMoon)
            {
                shop.Add(ModContent.ItemType<RedPuzzleFragment>());
            }
        }
        public override void SetDefaults(NPC npc)
        {
            if (npc.type == 46)
            {
                npc.lifeMax = 10;
            }

            if (npc.type == 140)
            {
                npc.lifeMax = 280;
            }

            if (npc.type == 82)
            {
                npc.lifeMax = 200;
            }

            if (npc.type == 141)
            {
                npc.lifeMax = 175;
            }

            if (npc.type == 45)
            {
                npc.lifeMax = 250;
            }

            if (npc.type == 58)
            {
                npc.lifeMax = 35;
            }

            if (npc.type == 49)
            {
                npc.lifeMax = 22;
            }

            if (npc.type == 93)
            {
                npc.lifeMax = 150;
            }

            if (npc.type == 77)
            {
                npc.lifeMax = 300;
            }

            if (npc.type == 110)
            {
                npc.lifeMax = 250;
            }

            if (npc.type == 63 && Main.hardMode)
            {
                npc.catchItem = 2436;
            }

            if (npc.type == 103 && Main.hardMode)
            {
                npc.catchItem = 2437;
            }

            if (npc.type == 64 && Main.hardMode)
            {
                npc.catchItem = 2438;
            }

            if (NPC.downedMoonlord && npc.boss == false && npc.townNPC == false && npc.type >= 0 && npc.type <= 579)
            {
                npc.lifeMax = npc.lifeMax * 2;
                npc.defense = npc.defense * 2;
            }



        }

    }
}