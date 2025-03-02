using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TremorMod.Content.Projectiles;

namespace TremorMod.Content.Items.SpaceWhaleItems
{
    public class HornedWarHammer : ModItem
    {
        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.Arkhalis);
            Item.damage = 350;
            Item.knockBack = 4f;
            Item.rare = ItemRarityID.Purple;
        }

        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Horned War Hammer");
            // Tooltip.SetDefault("Forged from lightning");
        }

        public override bool Shoot(Player player, Terraria.DataStructures.EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            Projectile.NewProjectile(source, position, velocity, ModContent.ProjectileType<HornedWarhammerPro>(), damage, knockback, player.whoAmI);
            return false; // ¬озвращаем false, чтобы предотвратить стандартное поведение стрельбы.
        }
    }
}
