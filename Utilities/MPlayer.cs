using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Terraria;
using Terraria.ID;
using Terraria.DataStructures;
using Terraria.ModLoader;
using TremorMod;
using TremorMod.Content.Items;
using TremorMod.Content.Items.Armor.Afterlife;
using TremorMod.Content.Items.Armor.Argite;
using TremorMod.Content.Items.Armor.Berserker;
using TremorMod.Content.Items.Armor.Brass;
using TremorMod.Content.Items.Armor.Chaos;
using TremorMod.Content.Items.Armor.Crystal;
using TremorMod.Content.Items.Armor.Flesh;
using TremorMod.Content.Items.Armor.Fungus;
using TremorMod.Content.Items.Armor.Harpy;
using TremorMod.Content.Items.Armor.Invar;
using TremorMod.Content.Items.Armor.Magmonium;
using TremorMod.Content.Items.Armor.Nano;
using TremorMod.Content.Items.Armor.Nightingale;
using TremorMod.Content.Items.Armor.Orcish;
using TremorMod.Content.Items.Armor.Sandstone;
using TremorMod.Content.Items.Armor.Nova;
using Microsoft.Xna.Framework;
using TremorMod.Content.Projectiles;

namespace TremorMod.Utilities
{
    public class MPlayer : ModPlayer
    {
        public static MPlayer GetModPlayer(Player player)
            => player.GetModPlayer<MPlayer>();

        public float damageReduction;
        public bool novaChestplate { get; set; }
        public bool novaLeggings { get; set; }
        public bool novaHelmet { get; set; }
        public bool novaAura { get; set; }
        public bool core { get; set; }
        public bool novaSet { get; set; }
        public bool nitro { get; set; }
        public bool pyro { get; set; }
        public bool glove { get; set; }
        public bool enchanted { get; set; }

        float meleeMultiplier = 0.4f; // Множитель для Melee
        float magicMultiplier = 0.6f; // Множитель для Magic
        public bool paraxydeSetBonusActive;
        private int tickCounter; 
        private const int CooldownTicks = 5;
        private const int MaxProjectiles = 50; 
        public bool fragileCondition = false;
        public float alchemicalDamage;
        public float alchemicalKbAddition;
        public float alchemicalKbMult;
        public int alchemicalCrit;

        public override void ResetEffects()
        {
            damageReduction = 0f;
            paraxydeSetBonusActive = false;
            novaLeggings = false;
            novaChestplate = false;
            glove = false;
            core = false;
            novaSet = false;
            novaAura = false;
            nitro = false;
            pyro = false;
            enchanted = false;
            fragileCondition = false;
            alchemicalDamage = 1f;
            alchemicalKbAddition = 0f;
            alchemicalKbMult = 1f;
            alchemicalCrit = 0;
        }

        public override void PostUpdate()
        {
            if (tickCounter > 0)
                tickCounter--;
        }

        public override void ModifyHurt(ref Player.HurtModifiers modifiers)
        {
            modifiers.FinalDamage *= (1f - damageReduction);
        }

        #region paraxydeSetBonusActive
        public override void ModifyHitNPCWithProj(Projectile proj, NPC target, ref NPC.HitModifiers modifiers) // paraxydeSetBonusActive
        {
            if (paraxydeSetBonusActive && tickCounter <= 0)
            {
                int projectileCount = CountProjectilesOnScreen();
                if (projectileCount >= MaxProjectiles)
                    return;

                Vector2 spawnPosition = target.Center + new Vector2(Main.rand.Next(-500, 501), Main.rand.Next(-500, 501));
                Vector2 direction = (target.Center - spawnPosition).SafeNormalize(Vector2.Zero);
                float speed = 20f;
                Vector2 velocity = direction * speed;

                int meleeDamage = (int)(Player.GetTotalDamage(DamageClass.Melee).ApplyTo(50 * meleeMultiplier));
                int magicDamage = (int)(Player.GetTotalDamage(DamageClass.Magic).ApplyTo(50 * magicMultiplier));
                int totalDamage = meleeDamage + magicDamage;

                Projectile.NewProjectile(
                    Player.GetSource_FromThis(),
                    spawnPosition,
                    velocity,
                    ModContent.ProjectileType<ParaxydeKnifePro>(),
                    totalDamage,
                    1f,
                    Player.whoAmI
                );

                tickCounter = CooldownTicks;
            }
        }

        private int CountProjectilesOnScreen()
        {
            int count = 0;
            for (int i = 0; i < Main.maxProjectiles; i++)
            {
                Projectile projectile = Main.projectile[i];
                if (projectile.active && projectile.type == ModContent.ProjectileType<ParaxydeKnifePro>() && projectile.owner == Player.whoAmI)
                {
                    count++;
                }
            }
            return count;
        } // paraxydeSetBonusActive

        #endregion 

        public override void UpdateBadLifeRegen()
        {
            if (fragileCondition)
            {
                Player.statDefense -= 1000000;
            }
        }

        #region Alchemical
        public override void ModifyWeaponDamage(Item item, ref StatModifier damage)
        {
            if (item.DamageType == TremorMod.alchemicalDamage)
            {
                damage *= alchemicalDamage;
            }
        }

        public override void ModifyWeaponCrit(Item item, ref float crit)
        {
            if (item.DamageType == TremorMod.alchemicalDamage)
            {
                crit += alchemicalCrit;
            }
        }
        #endregion

        private const bool EnableLogging = true; // Set to true for demonstration

        public virtual void OnEnterWorld(Player player)
        {
            if (EnableLogging)
            {
                var armors = new[]
                {
                    new[]
                    {
                        ModContent.ItemType<InvarHat>(),
                        ModContent.ItemType<InvarBreastPlate>(),
                        ModContent.ItemType<InvarGreaves>(),
                    },
                    new[]
                    {
                        ModContent.ItemType<HarpyHelmet>(),
                        ModContent.ItemType<HarpyChestplate>(),
                        ModContent.ItemType<HarpyLeggings>(),
                    },
                    new[]
                    {
                        ModContent.ItemType<ArgiteHelmet>(),
                        ModContent.ItemType<ArgiteBreastplate>(),
                        ModContent.ItemType<ArgiteGreaves>(),
                    },
                    new[]
                    {
                        ModContent.ItemType<NightingaleHood>(),
                        ModContent.ItemType<NightingaleChestplate>(),
                        ModContent.ItemType<NightingaleGreaves>(),
                    },
                    new[]
                    {
                        ModContent.ItemType<OrcishHelmet>(),
                        ModContent.ItemType<OrcishBreastplate>(),
                        ModContent.ItemType<OrcishGreaves>(),
                    },
                    new[]
                    {
                        ModContent.ItemType<FungusHelmet>(),
                        ModContent.ItemType<FungusBreastplate>(),
                        ModContent.ItemType<FungusGreaves>(),
                    },
                    new[]
                    {
                        ModContent.ItemType<FleshHelmet>(),
                        ModContent.ItemType<FleshBreastplate>(),
                        ModContent.ItemType<FleshGreaves>(),
                    },
                    new[]
                    {
                        ModContent.ItemType<CrystalHelmet>(),
                        ModContent.ItemType<CrystalChestplate>(),
                        ModContent.ItemType<CrystalGreaves>(),
                    },
                    new[]
                    {
                        ModContent.ItemType<AfterlifeHood>(),
                        ModContent.ItemType<AfterlifeBreastplate>(),
                        ModContent.ItemType<AfterlifeLeggings>(),
                    },
                    new[]
                    {
                        ModContent.ItemType<NanoHelmet>(),
                        ModContent.ItemType<NanoBreastplate>(),
                        ModContent.ItemType<NanoGreaves>(),
                    },
                    new[]
                    {
                        ModContent.ItemType<MagmoniumHelmet>(),
                        ModContent.ItemType<MagmoniumBreastplate>(),
                        ModContent.ItemType<MagmoniumGreaves>(),
                    },
                    new[]
                    {
                        ModContent.ItemType<SandStoneHelmet>(),
                        ModContent.ItemType<SandStoneBreastplate>(),
                        ModContent.ItemType<SandStoneGreaves>(),
                    },
                    new[]
                    {
                        ModContent.ItemType<ChaosHelmet>(),
                        ModContent.ItemType<ChaosBreastplate>(),
                        ModContent.ItemType<ChaosGreaves>(),
                    },
                    new[]
                    {
                        ModContent.ItemType<BrassHelmet>(),
                        ModContent.ItemType<BrassHeadgear>(),
                        ModContent.ItemType<BrassMask>(),
                    },
                    new[]
                    {
                        ModContent.ItemType<BerserkerHelmet>(),
                        ModContent.ItemType<BerserkerChestplate>(),
                        ModContent.ItemType<BerserkerGreaves>(),
                    },
                    new[]
                    {
                        ModContent.ItemType<NovaHelmet>(),
                        ModContent.ItemType<NovaBreastplate>(),
                        ModContent.ItemType<NovaLeggings>(),
                    },
                };

                var armor = armors[0]; // Example: select the first armor set

                var reqItems = new List<Item>();
                var reqTiles = new List<int>();
                var reqTileNames = new List<string>();

                // loop pieces
                foreach (int piece in armor)
                {
                    var recipes = Main.recipe.Where(x => x.createItem.type == piece);
                    foreach (Recipe recipe in recipes)
                    {
                        reqItems = reqItems.Concat(recipe.requiredItem).ToList();
                        reqTiles = reqTiles.Concat(recipe.requiredTile).ToList();
                    }
                }

                // combine stacks
                var duplicateItems = reqItems.GroupBy(x => x.type).Where(x => x.Count() > 1).Select(x => x);
                var combItems = TremorUtilities.DistinctBy(reqItems, x => x.type).ToList();
                foreach (var grouping in duplicateItems)
                {
                    var reqItem = combItems.FirstOrDefault(x => x.type == grouping.Key);
                    if (reqItem != null)
                    {
                        reqItem.stack = reqItems.Where(x => x.type == grouping.Key).Sum(x => x.stack);
                    }
                }
                reqItems = new List<Item>(combItems);
                reqTiles = reqTiles.Distinct().ToList();

                // get non empty entries
                reqItems = reqItems.Where(x => !x.IsAir).ToList();
                reqTileNames = reqTiles.Where(x => x > 0).Select(x => typeof(TileID).FindNameByConstant((ushort)x)).ToList();
                int i = reqTileNames.IndexOf("Anvils");
                if (i != -1)
                {
                    reqTileNames.RemoveAt(i);
                    reqTileNames.Add("Iron Anvil");
                    reqTileNames.Add("Lead Anvil");
                }
                i = reqTileNames.IndexOf("WorkBenches");
                if (i != -1)
                {
                    reqTileNames.RemoveAt(i);
                    reqTileNames.Add("Work Bench");
                }
                i = reqTileNames.IndexOf("OrichalcumAnvil");
                if (i != -1)
                {
                    reqTileNames.RemoveAt(i);
                    reqTileNames.Add("Orichalcum Anvil");
                }
                i = reqTileNames.IndexOf("MythrilAnvil");
                if (i != -1)
                {
                    reqTileNames.RemoveAt(i);
                    reqTileNames.Add("Mythril Anvil");
                    reqTileNames.Add("Orichalcum Anvil");
                }
            }
        }
    }
}