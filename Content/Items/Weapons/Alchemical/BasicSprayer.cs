using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using TremorMod.Content;
using TremorMod;
using TremorMod.Utilities;
using TremorMod.Content.Buffs;
using TremorMod.Content.Projectiles;

namespace TremorMod.Content.Items.Weapons.Alchemical
{
    public class BasicSprayer : ModItem
    {
        public override void SetDefaults()
        {
            Item.DamageType = TremorMod.alchemicalDamage ?? DamageClass.Generic;
            Item.damage = 16;
            Item.width = 68;
            Item.height = 30;
            Item.useTime = 18;
            Item.useAnimation = 18;
            Item.useStyle = ItemUseStyleID.Shoot; // Измените на правильный стиль использования
            Item.noMelee = true;
            Item.knockBack = 4;
            Item.value = 10000;
            Item.rare = 2;
            Item.UseSound = SoundID.Item20;
            Item.autoReuse = false;
            Item.shoot = 10;
            Item.shootSpeed = 6f;
            Item.crit = 4;
            Item.useAmmo = ModContent.ItemType<BoomFlask>(); // Убедитесь, что оружие использует правильный тип боеприпасов
        }

        public override void AddRecipes()
        {
            Recipe recipe1 = CreateRecipe();
            recipe1.AddIngredient(ItemID.Wood, 45);
            recipe1.AddIngredient(ModContent.ItemType<BasicFlask>(), 8);
            recipe1.AddIngredient(ItemID.ShadowScale, 15);
            recipe1.AddIngredient(ItemID.IronBar, 18);
            recipe1.AddTile(TileID.Anvils);
            recipe1.Register();

            Recipe recipe2 = CreateRecipe();
            recipe2.AddIngredient(ItemID.Wood, 45);
            recipe2.AddIngredient(ModContent.ItemType<BasicFlask>(), 8);
            recipe2.AddIngredient(ItemID.TissueSample, 15);
            recipe2.AddIngredient(ItemID.IronBar, 18);
            recipe2.AddTile(TileID.Anvils);
            recipe2.Register();

            Recipe recipe3 = CreateRecipe();
            recipe3.AddIngredient(ItemID.Wood, 45);
            recipe3.AddIngredient(ModContent.ItemType<BasicFlask>(), 8);
            recipe3.AddIngredient(ItemID.ShadowScale, 15);
            recipe3.AddIngredient(ItemID.LeadBar, 18);
            recipe3.AddTile(TileID.Anvils);
            recipe3.Register();

            Recipe recipe4 = CreateRecipe();
            recipe4.AddIngredient(ItemID.Wood, 45);
            recipe4.AddIngredient(ModContent.ItemType<BasicFlask>(), 8);
            recipe4.AddIngredient(ItemID.TissueSample, 15);
            recipe4.AddIngredient(ItemID.LeadBar, 18);
            recipe4.AddTile(TileID.Anvils);
            recipe4.Register();
        }

        public override bool CanConsumeAmmo(Item ammo, Player player)
        {
            if (player.FindBuffIndex(ModContent.BuffType<EnchantmentSolutionBuffs>()) != -1)
            {
                if (Main.rand.Next(0, 100) <= 50)
                    return false;
            }
            if (player.FindBuffIndex(ModContent.BuffType<EnchantmentSolutionBuffs>()) != -1)
            {
                if (Main.rand.Next(0, 100) <= 70)
                    return false;
            }
            return true;
        }

        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-18, -4);
        }

        public override void UpdateInventory(Player player)
        {
            MPlayer modPlayer = MPlayer.GetModPlayer(player);
            if (modPlayer.core)
            {
                Item.autoReuse = true;
            }
            if (!modPlayer.core)
            {
                Item.autoReuse = false;
            }
            if (player.FindBuffIndex(Mod.Find<ModBuff>("LongFuseBuff").Type) != -1)
            {
                Item.shootSpeed = 14f;
            }
            if (player.FindBuffIndex(Mod.Find<ModBuff>("LongFuseBuff").Type) < 1)
            {
                Item.shootSpeed = 6f;
            }
        }

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            MPlayer modPlayer = MPlayer.GetModPlayer(player);
            float speedX = velocity.X;
            float speedY = velocity.Y;

            if (modPlayer.glove)
            {
                for (int i = 0; i < 1; ++i)
                {
                    if (player.FindBuffIndex(Mod.Find<ModBuff>("BottledSpiritBuffs").Type) != -1)
                    {
                        Projectile.NewProjectile(source, position.X, position.Y, speedX + 2, speedY + 2, 297, damage, knockback, Main.myPlayer);
                    }
                    if (player.FindBuffIndex(Mod.Find<ModBuff>("BigBottledSpiritBuffs").Type) != -1)
                    {
                        Projectile.NewProjectile(source, position.X, position.Y, speedX + 3, speedY + 3, 297, damage, knockback, Main.myPlayer);
                        Projectile.NewProjectile(source, position.X, position.Y, speedX + 2, speedY + 2, 297, damage, knockback, Main.myPlayer);
                    }
                    Projectile.NewProjectile(source, position.X, position.Y, speedX + 1, speedY + 1, type, damage, knockback, Main.myPlayer);
                    Projectile.NewProjectile(source, position.X, position.Y, speedX + 1, speedY + 1, type, damage, knockback, Main.myPlayer);
                    int k = Projectile.NewProjectile(source, position.X, position.Y, speedX, speedY, type, damage, knockback, Main.myPlayer);
                    Main.projectile[k].friendly = true;
                }
                return false;
            }
            if (player.FindBuffIndex(Mod.Find<ModBuff>("BottledSpiritBuffs").Type) != -1 && !modPlayer.glove)
            {
                for (int i = 0; i < 1; ++i)
                {
                    Projectile.NewProjectile(source, position.X, position.Y, speedX + 1, speedY + 1, 297, damage, knockback, Main.myPlayer);
                    int k = Projectile.NewProjectile(source, position.X, position.Y, speedX, speedY, type, damage, knockback, Main.myPlayer);
                    Main.projectile[k].friendly = true;
                }
                return false;
            }
            if (player.FindBuffIndex(Mod.Find<ModBuff>("BigBottledSpiritBuffs").Type) != -1 && !modPlayer.glove)
            {
                for (int i = 0; i < 1; ++i)
                {
                    Projectile.NewProjectile(source, position.X, position.Y, speedX + 2, speedY + 2, 297, damage, knockback, Main.myPlayer);
                    Projectile.NewProjectile(source, position.X, position.Y, speedX + 1, speedY + 1, 297, damage, knockback, Main.myPlayer);
                    int k = Projectile.NewProjectile(source, position.X, position.Y, speedX, speedY, type, damage, knockback, Main.myPlayer);
                    Main.projectile[k].friendly = true;
                }
                return false;
            }
            return true;
        }
    }
}