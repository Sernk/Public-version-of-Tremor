using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;
using Terraria;
using Terraria.ModLoader;
using TremorMod.Content.Buffs;
using TremorMod.Content.Items.Weapons.Alchemical;

namespace TremorMod.Utilities
{
	public class AlchemistGlobalItem : GlobalItem
	{
        public override bool ConsumeItem(Item item, Player player)
        {
            MPlayer modPlayer = MPlayer.GetModPlayer(player);
            if (modPlayer.novaChestplate)
            {
                if (player.FindBuffIndex(ModContent.BuffType<BottledSpiritBuffs>()) != -1)
                {
                    if ((item.type == ModContent.ItemType<LesserManaFlask>() || item.type == ModContent.ItemType<BurningFlask>() || item.type == ModContent.ItemType<BoomFlask>() || item.type == ModContent.ItemType<BigVenomFlask>() || item.type == ModContent.ItemType<BigPoisonFlask>() || item.type == ModContent.ItemType<BigManaFlask>() ||
                                item.type == ModContent.ItemType<BigHealingFlack>() || item.type == ModContent.ItemType<BasicFlask>() || item.type == ModContent.ItemType<FreezeFlask>() ||
                                /*item.type == ModContent.ItemType<DepressionFlask>() ||*/ item.type == ModContent.ItemType<CrystalFlask>() || item.type == ModContent.ItemType<ClusterFlask>() ||
                                item.type == ModContent.ItemType<GoldFlask>() || item.type == ModContent.ItemType<ExtendedFreezeFlask>() || item.type == ModContent.ItemType<ExtendedBurningFlask>() ||
                                item.type == ModContent.ItemType<ExtendedBoomFlask>() || item.type == ModContent.ItemType<HealthSupportFlask>() || item.type == ModContent.ItemType<ManaSupportFlask>() ||
                                item.type == ModContent.ItemType<LesserVenomFlask>() || item.type == ModContent.ItemType<LesserPoisonFlask>() || item.type == ModContent.ItemType<LesserHealingFlack>() ||
                                item.type == ModContent.ItemType<PlagueFlask>() || item.type == ModContent.ItemType<PhantomFlask>() || item.type == ModContent.ItemType<MoonDustFlask>() ||
                                item.type == ModContent.ItemType<SparkingFlask>() || item.type == ModContent.ItemType<SuperManaFlask>() || item.type == ModContent.ItemType<SuperHealingFlask>() || item.type == ModContent.ItemType<NovaFlask>()) && Main.rand.NextFloat() < 0.65f)
                    {
                        return false;
                    }
                }
                if (player.FindBuffIndex(ModContent.BuffType<BigBottledSpiritBuffs>()) != -1)
                {
                    if ((item.type == ModContent.ItemType<LesserManaFlask>() || item.type == ModContent.ItemType<BurningFlask>() || item.type == ModContent.ItemType<BoomFlask>() || item.type == ModContent.ItemType<BigVenomFlask>() || item.type == ModContent.ItemType<BigPoisonFlask>() || item.type == ModContent.ItemType<BigManaFlask>() ||
                                item.type == ModContent.ItemType<BigHealingFlack>() || item.type == ModContent.ItemType<BasicFlask>() || item.type == ModContent.ItemType<FreezeFlask>() ||
                               /*item.type == ModContent.ItemType<DepressionFlask>() ||*/ item.type == ModContent.ItemType<CrystalFlask>() || item.type == ModContent.ItemType<ClusterFlask>() ||
                                item.type == ModContent.ItemType<GoldFlask>() || item.type == ModContent.ItemType<ExtendedFreezeFlask>() || item.type == ModContent.ItemType<ExtendedBurningFlask>() ||
                                item.type == ModContent.ItemType<ExtendedBoomFlask>() || item.type == ModContent.ItemType<HealthSupportFlask>() || item.type == ModContent.ItemType<ManaSupportFlask>() ||
                                item.type == ModContent.ItemType<LesserVenomFlask>() || item.type == ModContent.ItemType<LesserPoisonFlask>() || item.type == ModContent.ItemType<LesserHealingFlack>() ||
                                item.type == ModContent.ItemType<PlagueFlask>() || item.type == ModContent.ItemType<PhantomFlask>() || item.type == ModContent.ItemType<MoonDustFlask>() ||
                                item.type == ModContent.ItemType<SparkingFlask>() || item.type == ModContent.ItemType<SuperManaFlask>() || item.type == ModContent.ItemType<SuperHealingFlask>() || item.type == ModContent.ItemType<NovaFlask>()) && Main.rand.NextFloat() < 0.85f)
                    {
                        return false;
                    }
                }
                if (player.FindBuffIndex(ModContent.BuffType<BigBottledSpiritBuffs>()) < 1 && player.FindBuffIndex(ModContent.BuffType<BottledSpiritBuffs>()) < 1)
                {
                    if ((item.type == ModContent.ItemType<LesserManaFlask>() || item.type == ModContent.ItemType<BurningFlask>() || item.type == ModContent.ItemType<BoomFlask>() || item.type == ModContent.ItemType<BigVenomFlask>() || item.type == ModContent.ItemType<BigPoisonFlask>() || item.type == ModContent.ItemType<BigManaFlask>() ||
                                item.type == ModContent.ItemType<BigHealingFlack>() || item.type == ModContent.ItemType<BasicFlask>() || item.type == ModContent.ItemType<FreezeFlask>() ||
                                /*item.type == ModContent.ItemType<DepressionFlask>() ||*/ item.type == ModContent.ItemType<CrystalFlask>() || item.type == ModContent.ItemType<ClusterFlask>() ||
                                item.type == ModContent.ItemType<GoldFlask>() || item.type == ModContent.ItemType<ExtendedFreezeFlask>() || item.type == ModContent.ItemType<ExtendedBurningFlask>() ||
                                item.type == ModContent.ItemType<ExtendedBoomFlask>() || item.type == ModContent.ItemType<HealthSupportFlask>() || item.type == ModContent.ItemType<ManaSupportFlask>() ||
                                item.type == ModContent.ItemType<LesserVenomFlask>() || item.type == ModContent.ItemType<LesserPoisonFlask>() || item.type == ModContent.ItemType<LesserHealingFlack>() ||
                                item.type == ModContent.ItemType<PlagueFlask>() || item.type == ModContent.ItemType<PhantomFlask>() || item.type == ModContent.ItemType<MoonDustFlask>() ||
                                item.type == ModContent.ItemType<SparkingFlask>() || item.type == ModContent.ItemType<SuperManaFlask>() || item.type == ModContent.ItemType<SuperHealingFlask>() || item.type == ModContent.ItemType<NovaFlask>()) && Main.rand.NextFloat() < 0.4f)
                    {
                        return false;
                    }
                }
            }
            if (player.FindBuffIndex(ModContent.BuffType<BottledSpiritBuffs>()) != -1)
            {
                if ((item.type == ModContent.ItemType<LesserManaFlask>() || item.type == ModContent.ItemType<BurningFlask>() || item.type == ModContent.ItemType<BoomFlask>() || item.type == ModContent.ItemType<BigVenomFlask>() || item.type == ModContent.ItemType<BigPoisonFlask>() || item.type == ModContent.ItemType<BigManaFlask>() ||
                            item.type == ModContent.ItemType<BigHealingFlack>() || item.type == ModContent.ItemType<BasicFlask>() || item.type == ModContent.ItemType<FreezeFlask>() ||
                            /*item.type == ModContent.ItemType<DepressionFlask>() ||*/ item.type == ModContent.ItemType<CrystalFlask>() || item.type == ModContent.ItemType<ClusterFlask>() ||
                            item.type == ModContent.ItemType<GoldFlask>() || item.type == ModContent.ItemType<ExtendedFreezeFlask>() || item.type == ModContent.ItemType<ExtendedBurningFlask>() ||
                            item.type == ModContent.ItemType<ExtendedBoomFlask>() || item.type == ModContent.ItemType<HealthSupportFlask>() || item.type == ModContent.ItemType<ManaSupportFlask>() ||
                            item.type == ModContent.ItemType<LesserVenomFlask>() || item.type == ModContent.ItemType<LesserPoisonFlask>() || item.type == ModContent.ItemType<LesserHealingFlack>() ||
                            item.type == ModContent.ItemType<PlagueFlask>() || item.type == ModContent.ItemType<PhantomFlask>() || item.type == ModContent.ItemType<MoonDustFlask>() ||
                            item.type == ModContent.ItemType<SparkingFlask>() || item.type == ModContent.ItemType<SuperManaFlask>() || item.type == ModContent.ItemType<SuperHealingFlask>() || item.type == ModContent.ItemType<NovaFlask>()) && Main.rand.NextFloat() < 0.25f)
                {
                    return false;
                }
            }
            if (player.FindBuffIndex(ModContent.BuffType<BigBottledSpiritBuffs>()) != -1 && modPlayer.novaAura)
            {
                if ((item.type == ModContent.ItemType<LesserManaFlask>() || item.type == ModContent.ItemType<BurningFlask>() || item.type == ModContent.ItemType<BoomFlask>() || item.type == ModContent.ItemType<BigVenomFlask>() || item.type == ModContent.ItemType<BigPoisonFlask>() || item.type == ModContent.ItemType<BigManaFlask>() ||
                            item.type == ModContent.ItemType<BigHealingFlack>() || item.type == ModContent.ItemType<BasicFlask>() || item.type == ModContent.ItemType<FreezeFlask>() ||
                            /*item.type == ModContent.ItemType<DepressionFlask>() ||*/ item.type == ModContent.ItemType<CrystalFlask>() || item.type == ModContent.ItemType<ClusterFlask>() ||
                            item.type == ModContent.ItemType<GoldFlask>() || item.type == ModContent.ItemType<ExtendedFreezeFlask>() || item.type == ModContent.ItemType<ExtendedBurningFlask>() ||
                            item.type == ModContent.ItemType<ExtendedBoomFlask>() || item.type == ModContent.ItemType<HealthSupportFlask>() || item.type == ModContent.ItemType<ManaSupportFlask>() ||
                            item.type == ModContent.ItemType<LesserVenomFlask>() || item.type == ModContent.ItemType<LesserPoisonFlask>() || item.type == ModContent.ItemType<LesserHealingFlack>() ||
                            item.type == ModContent.ItemType<PlagueFlask>() || item.type == ModContent.ItemType<PhantomFlask>() || item.type == ModContent.ItemType<MoonDustFlask>() ||
                            item.type == ModContent.ItemType<SparkingFlask>() || item.type == ModContent.ItemType<SuperManaFlask>() || item.type == ModContent.ItemType<SuperHealingFlask>() || item.type == ModContent.ItemType<NovaFlask>()) && Main.rand.NextFloat() < 0.45f)
                {
                    return false;
                }
            }
            return base.ConsumeItem(item, player);
        }

        public override bool Shoot(Item item, Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            MPlayer modPlayer = MPlayer.GetModPlayer(player);
            if (modPlayer.glove)
            {
                for (int i = 0; i < 1; ++i)
                {
                    if (player.FindBuffIndex(ModContent.BuffType<BottledSpiritBuffs>()) != -1)
                    {
                        Projectile.NewProjectile(source, position.X, position.Y, velocity.X + 2, velocity.Y + 2, 297, damage, knockback, Main.myPlayer);
                        Projectile.NewProjectile(source, position.X, position.Y, velocity.X - 1, velocity.Y - 1, 297, damage, knockback, Main.myPlayer);
                    }
                    if (player.FindBuffIndex(ModContent.BuffType<BigBottledSpiritBuffs>()) != -1)
                    {
                        Projectile.NewProjectile(source, position.X, position.Y, velocity.X + 3, velocity.Y + 3, 297, damage, knockback, Main.myPlayer);
                        Projectile.NewProjectile(source, position.X, position.Y, velocity.X + 2, velocity.Y + 2, 297, damage, knockback, Main.myPlayer);
                        Projectile.NewProjectile(source, position.X, position.Y, velocity.X - 1, velocity.Y - 1, 297, damage, knockback, Main.myPlayer);
                        Projectile.NewProjectile(source, position.X, position.Y, velocity.X - 2, velocity.Y - 2, 297, damage, knockback, Main.myPlayer);
                    }
                    Projectile.NewProjectile(source, position.X, position.Y, velocity.X + 1, velocity.Y + 1, type, damage, knockback, Main.myPlayer);
                    int k = Projectile.NewProjectile(source, position.X, position.Y, velocity.X, velocity.Y, type, damage, knockback, Main.myPlayer);
                    Main.projectile[k].friendly = true;
                }
                return false;
            }
            if (player.FindBuffIndex(ModContent.BuffType<BottledSpiritBuffs>()) != -1 && !modPlayer.glove)
            {
                for (int i = 0; i < 1; ++i)
                {
                    Projectile.NewProjectile(source, position.X, position.Y, velocity.X + 1, velocity.Y + 1, 297, damage, knockback, Main.myPlayer);
                    int k = Projectile.NewProjectile(source, position.X, position.Y, velocity.X, velocity.Y, type, damage, knockback, Main.myPlayer);
                    Projectile.NewProjectile(source, position.X, position.Y, velocity.X - 1, velocity.Y - 1, 297, damage, knockback, Main.myPlayer);
                    Main.projectile[k].friendly = true;
                }
                return false;
            }
            if (player.FindBuffIndex(ModContent.BuffType<BigBottledSpiritBuffs>()) != -1 && !modPlayer.glove)
            {
                for (int i = 0; i < 1; ++i)
                {
                    Projectile.NewProjectile(source, position.X, position.Y, velocity.X + 2, velocity.Y + 2, 297, damage, knockback, Main.myPlayer);
                    Projectile.NewProjectile(source, position.X, position.Y, velocity.X + 1, velocity.Y + 1, 297, damage, knockback, Main.myPlayer);
                    int k = Projectile.NewProjectile(source, position.X, position.Y, velocity.X, velocity.Y, type, damage, knockback, Main.myPlayer);
                    Projectile.NewProjectile(source, position.X, position.Y, velocity.X - 1, velocity.Y - 1, 297, damage, knockback, Main.myPlayer);
                    Projectile.NewProjectile(source, position.X, position.Y, velocity.X - 2, velocity.Y - 2, 297, damage, knockback, Main.myPlayer);
                    Main.projectile[k].friendly = true;
                }
                return false;
            }
            return true;
        }
    }
}