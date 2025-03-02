using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using TremorMod.Content.Projectiles.Minions;
using TremorMod.Content.Buffs;
using TremorMod.Content.Items.Materials;

namespace TremorMod.Content.Items.Weapons.Summon
{
    public class ShadowStaff : ModItem
    {
        public override void SetDefaults()
        {
            Item.damage = 38;
            Item.DamageType = DamageClass.Summon;
            Item.mana = 10;
            Item.width = 26;
            Item.height = 28;
            Item.useTime = 36;
            Item.channel = true;
            Item.useAnimation = 36;
            Item.useStyle = 4;
            Item.noMelee = true;
            Item.knockBack = 3;
            Item.value = Item.buyPrice(0, 3, 0, 0);
            Item.rare = 3;
            Item.UseSound = SoundID.Item44;
            Item.shoot = ModContent.ProjectileType<ShadowStaffPro>();
            Item.shootSpeed = 2f;
            Item.buffType = ModContent.BuffType<ShadowArmBuff>();
            Item.buffTime = 3600;
        }

        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Rich Mahogany Seed");
            //Tooltip.SetDefault("Summons a lil' snatcher to fight for you.");
        }

        public override bool AltFunctionUse(Player player)
        {
            return true;
        }

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            return player.altFunctionUse != 2;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.SoulofNight, 8);
            recipe.AddIngredient(ItemID.SpookyWood, 15);
            recipe.AddIngredient(ModContent.ItemType<DarknessCloth>(), 9);
            recipe.AddTile(134);
            //recipe.SetResult(this);
            recipe.Register();
        }
    }
}