using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using TremorMod.Content.Items.Materials;
using TremorMod.Content.Projectiles;
using TremorMod.Utilities;

namespace TremorMod.Content.Items.Weapons.Ranged
{
    public class BoneRepeater : ModItem
    {
        public override void SetDefaults()
        {
            Item.damage = 28;
            Item.width = 18;
            Item.height = 56;
            Item.DamageType = DamageClass.Ranged;
            Item.useTime = 30;
            Item.useAnimation = 30;
            Item.useStyle = 5;
            Item.knockBack = 1.8f;
            Item.value = 2500;
            Item.rare = ItemRarityID.Orange;
            Item.UseSound = SoundID.Item5;
            Item.autoReuse = true;
            Item.shootSpeed = 12f;

            Item.shoot = 1; 
            Item.useAmmo = ItemID.Bone; 
        }

        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Bone Repeater");
            // Tooltip.SetDefault("Uses bones as ammo");
        }

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            if (type == 1) return false; 

            Projectile.NewProjectile(source, position, velocity, ModContent.ProjectileType<BoneBoltPro>(), damage, knockback, player.whoAmI);
            return false; 
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.HellstoneBar, 8);
            recipe.AddIngredient(ModContent.ItemType<PetrifiedSpike>(), 15);
            recipe.AddIngredient(ModContent.ItemType<SharpenedTooth>(), 9);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
        }
    }
}
