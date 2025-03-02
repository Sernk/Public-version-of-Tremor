using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
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
	public class GlobalItems : GlobalItem
	{
        public override void ModifyItemLoot(Item item, ItemLoot itemLoot)
        {
            if (item.type == ItemID.DestroyerBossBag)
            {
                itemLoot.Add(ItemDropRule.Common(ModContent.ItemType<Destructor>(), 6));
            }
            if (item.type == ItemID.SkeletronPrimeBossBag && Main.rand.NextBool(6))
            {   
                itemLoot.Add(ItemDropRule.Common(ModContent.ItemType<PrimeBlade>()));
            }              
            if (item.type == ItemID.WallOfFleshBossBag && Main.rand.NextBool())
            {
                itemLoot.Add(ItemDropRule.Common(ModContent.ItemType<PieceofFlesh>(), 1, 8, 17));
            }               
            if (item.type == ItemID.SkeletronBossBag && Main.rand.NextBool())
            {
                itemLoot.Add(ItemDropRule.Common(ModContent.ItemType<CursedSoul>(), 1, 1, 5));
            }             
            if (item.type == ItemID.GolemBossBag && Main.rand.NextBool())
            {
                 itemLoot.Add(ItemDropRule.Common(ModContent.ItemType<GolemCore>()));
            }              
            if (item.type == ItemID.EyeOfCthulhuBossBag)
            {
                if (Main.rand.NextBool(5))
                {
                    itemLoot.Add(ItemDropRule.Common(ModContent.ItemType<EyeMonolith>()));
                }                   
                if (Main.rand.NextBool(4))
                {
                    itemLoot.Add(ItemDropRule.Common(ModContent.ItemType<MonsterTooth>()));
                }                   
            }
            if (item.type == ItemID.PlanteraBossBag && Main.rand.NextBool())
            {
                itemLoot.Add(ItemDropRule.Common(ModContent.ItemType<EssenseofJungle>(), 1, 2, 3));

            }
            //if (item.type == ItemID.FishronBossBag && Main.rand.NextBool(6))
            //{
            //    itemLoot.Add(ItemDropRule.Common(ModContent.ItemType<DukeCannon>()));
            //}              
            if (item.type == ItemID.MoonLordBossBag && Main.rand.NextBool())
            {
                itemLoot.Add(ItemDropRule.Common(ModContent.ItemType<MultidimensionalFragment>(), 1, 6, 12));
            }
            if (item.type == ItemID.WallOfFleshBossBag) 
            {
                itemLoot.Add(ItemDropRule.Common(ModContent.ItemType<AlchemistEmblem>(), 2)); 
                itemLoot.Add(ItemDropRule.Common(ModContent.ItemType<ThrowerEmblem>(), 2)); 
            }
            if (item.type == ItemID.SkeletronBossBag && Main.rand.NextBool())
            {
                itemLoot.Add(ItemDropRule.Common(ModContent.ItemType<TearsofDeath>(), 1, 1, 3));
            }
            if (item.type == ItemID.QueenBeeBossBag && Main.rand.NextBool(3))
            {
                itemLoot.Add(ItemDropRule.Common(ModContent.ItemType<YellowPuzzleFragment>()));
            }
            if (item.type == ItemID.TwinsBossBag && Main.rand.NextBool(6))
            {
                itemLoot.Add(ItemDropRule.Common(ModContent.ItemType<MechaSprayer>()));
            }
            if (Main.hardMode)
            {
                //if (Main.rand.Next(30) == 0)
                //{
                //    itemLoot.Add(ItemDropRule.Common(ModContent.ItemType<Zadum4iviiHelmet>()));
                //    itemLoot.Add(ItemDropRule.Common(ModContent.ItemType<Zadum4iviiCuirass>()));
                //    itemLoot.Add(ItemDropRule.Common(ModContent.ItemType<Zadum4iviiLeggings>()));
                //}

                if (Main.rand.Next(30) == 0)
                {
                    itemLoot.Add(ItemDropRule.Common(ModContent.ItemType<HummerHelmet>()));
                    itemLoot.Add(ItemDropRule.Common(ModContent.ItemType<HummerBreastplate>()));
                    itemLoot.Add(ItemDropRule.Common(ModContent.ItemType<HummerGreaves>()));
                }

                if (Main.rand.Next(30) == 0)
                {
                    itemLoot.Add(ItemDropRule.Common(ModContent.ItemType<ZerokkHead>()));
                    itemLoot.Add(ItemDropRule.Common(ModContent.ItemType<ZerokkBody>()));
                    itemLoot.Add(ItemDropRule.Common(ModContent.ItemType<ZerokkLegs>()));
                }

                if (Main.rand.Next(30) == 0)
                {
                    itemLoot.Add(ItemDropRule.Common(ModContent.ItemType<CursedKnightHelmet>()));
                    itemLoot.Add(ItemDropRule.Common(ModContent.ItemType<CursedKnightBreastplate>()));
                    itemLoot.Add(ItemDropRule.Common(ModContent.ItemType<CursedKnightGreaves>()));
                }

                if (Main.rand.Next(42) == 0)
                {
                    itemLoot.Add(ItemDropRule.Common(ModContent.ItemType<SpinalMask>()));
                }
            }
        }
    }
}