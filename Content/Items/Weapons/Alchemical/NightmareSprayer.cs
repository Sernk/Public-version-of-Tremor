using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using TremorMod.Content.Items.Materials;
using TremorMod.Content.Items.Accessories;
using TremorMod.Content.Buffs;
using TremorMod.Utilities;
using TremorMod;

namespace TremorMod.Content.Items.Weapons.Alchemical
{
	public class NightmareSprayer : ModItem
    {
		public override void SetDefaults()
		{
            Item.DamageType = TremorMod.alchemicalDamage ?? DamageClass.Generic;
            Item.damage = 120;
			Item.width = 80;
			Item.height = 36;
			Item.useTime = 14;
			Item.useAnimation = 14;
			Item.useStyle = 5;
			Item.noMelee = true;
			Item.knockBack = 4;
			Item.value = 10000;
			Item.rare = 11;
			Item.UseSound = SoundID.Item20;
			Item.autoReuse = false;
			Item.shoot = 10;
			Item.shootSpeed = 6f;
			Item.crit = 4;
			Item.useAmmo = ModContent.ItemType<BoomFlask>();

		}

		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("Nightmare Sprayer");
			//Tooltip.SetDefault("Uses flasks as ammo\n" +
			//"Sprays alchemical clouds");
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<BasicSprayer>(), 1);
			recipe.AddIngredient(ModContent.ItemType<BasicFlask>(), 8);
			recipe.AddIngredient(ModContent.ItemType<NightmareBar>(), 25);
			recipe.AddIngredient(ModContent.ItemType<SteelBar>(), 14);
			recipe.AddIngredient(ItemID.Wire, 15);
			recipe.AddIngredient(3467, 8);
			recipe.AddIngredient(ModContent.ItemType<VoidBar>(), 5);
			//recipe.SetResult(this);
			recipe.AddTile(412);
			recipe.Register();
		}

        public override bool CanConsumeAmmo(Item ammo, Player player)
        {
            if (player.FindBuffIndex(ModContent.BuffType<EnchantmentSolutionBuffs>()) != -1)
            {
                if (Main.rand.Next(0, 100) <= 50)
                    return false;
            }
            if (player.FindBuffIndex(ModContent.BuffType<AmplifiedEnchantmentSolutionBuffs>()) != -1)
            {
                if (Main.rand.Next(0, 100) <= 70)
                    return false;
            }
            return true;
        }

        public override Vector2? HoldoutOffset()
		{
			return new Vector2(-12, -4);
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
            if (player.FindBuffIndex(ModContent.BuffType<LongFuseBuff>()) != -1)
            {
                Item.shootSpeed = 14f;
            }
            if (player.FindBuffIndex(ModContent.BuffType<LongFuseBuff>()) < 1)
            {
                Item.shootSpeed = 6f;
            }
        }

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            MPlayer modPlayer = MPlayer.GetModPlayer(player);
            if (modPlayer.glove)
            {
                for (int i = 0; i < 1; ++i)
                {
                    if (player.FindBuffIndex(ModContent.BuffType<BottledSpiritBuffs>()) != -1)
                    {
                        Projectile.NewProjectile(source, position, velocity + new Vector2(2, 2), 297, damage, knockback, Main.myPlayer);
                    }
                    if (player.FindBuffIndex(ModContent.BuffType<BigBottledSpiritBuffs>()) != -1)
                    {
                        Projectile.NewProjectile(source, position, velocity + new Vector2(3, 3), 297, damage, knockback, Main.myPlayer);
                        Projectile.NewProjectile(source, position, velocity + new Vector2(2, 2), 297, damage, knockback, Main.myPlayer);
                    }
                    Projectile.NewProjectile(source, position, velocity + new Vector2(1, 1), type, damage, knockback, Main.myPlayer);
                    Projectile.NewProjectile(source, position, velocity + new Vector2(1, 1), type, damage, knockback, Main.myPlayer);
                    int k = Projectile.NewProjectile(source, position, velocity, type, damage, knockback, Main.myPlayer);
                    Main.projectile[k].friendly = true;
                }
                return false;
            }
            if (player.FindBuffIndex(ModContent.BuffType<BottledSpiritBuffs>()) != -1 && !modPlayer.glove)
            {
                for (int i = 0; i < 1; ++i)
                {
                    Projectile.NewProjectile(source, position, velocity + new Vector2(1, 1), 297, damage, knockback, Main.myPlayer);
                    int k = Projectile.NewProjectile(source, position, velocity, type, damage, knockback, Main.myPlayer);
                    Main.projectile[k].friendly = true;
                }
                return false;
            }
            if (player.FindBuffIndex(ModContent.BuffType<BigBottledSpiritBuffs>()) != -1 && !modPlayer.glove)
            {
                for (int i = 0; i < 1; ++i)
                {
                    Projectile.NewProjectile(source, position, velocity + new Vector2(2, 2), 297, damage, knockback, Main.myPlayer);
                    Projectile.NewProjectile(source, position, velocity + new Vector2(1, 1), 297, damage, knockback, Main.myPlayer);
                    int k = Projectile.NewProjectile(source, position, velocity, type, damage, knockback, Main.myPlayer);
                    Main.projectile[k].friendly = true;
                }
                return false;
            }
            return true;
        }
    }
}