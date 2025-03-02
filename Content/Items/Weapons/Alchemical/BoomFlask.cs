using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;
using Microsoft.Xna.Framework;
using TremorMod;
using TremorMod.Content.Projectiles;
using TremorMod.Content.Buffs;

namespace TremorMod.Content.Items.Weapons.Alchemical
{
    public class BoomFlask : ModItem
    {
        public override void SetDefaults()
        {
            Item.DamageType = TremorMod.alchemicalDamage ?? DamageClass.Generic;
            Item.crit = 4;
            Item.damage = 18;
            Item.width = 26;
            Item.noUseGraphic = true;
            Item.maxStack = 999;
            Item.consumable = true;
            Item.height = 30;
            Item.useTime = 40;
            Item.useAnimation = 40;
            Item.shoot = ModContent.ProjectileType<BoomFlaskPro>();
            Item.shootSpeed = 10f;
            Item.useStyle = ItemUseStyleID.Swing; // Измените на правильный стиль использования
            Item.knockBack = 1;
            Item.UseSound = SoundID.Item106;
            Item.value = 145;
            Item.rare = 2;
            Item.autoReuse = false;
            Item.ammo = Item.type; // Убедитесь, что предмет настроен как боеприпас
        }

        public override void UpdateInventory(Player player)
        {
            TremorPlayer modPlayer = player.GetModPlayer<TremorPlayer>();

            if (player.FindBuffIndex(ModContent.BuffType<LongFuseBuff>()) != -1)
            {
                Item.shootSpeed = 11f;
            }
            else
            {
                Item.shootSpeed = 8f;
            }

            if (modPlayer != null && modPlayer.core)
            {
                Item.autoReuse = true;
            }
            else
            {
                Item.autoReuse = false;
            }
        }
    }
}