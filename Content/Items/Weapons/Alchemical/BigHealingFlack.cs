using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TremorMod.Content.Items.Materials;
using TremorMod.Content.Projectiles;
using TremorMod.Content.Buffs;
using TremorMod.Utilities;

namespace TremorMod.Content.Items.Weapons.Alchemical
{
    public class BigHealingFlack : ModItem
    {
        public override void SetDefaults()
        {
            Item.DamageType = TremorMod.alchemicalDamage ?? DamageClass.Generic;
            Item.crit = 4;
            Item.damage = 22;
            Item.width = 26;
            Item.noUseGraphic = true;
            Item.maxStack = 999;
            Item.consumable = true;
            Item.height = 30;
            Item.useTime = 20;
            Item.useAnimation = 20;
            Item.shoot = ModContent.ProjectileType<BigHealingFlackPro>();
            Item.shootSpeed = 8f;
            Item.useStyle = 1;
            Item.knockBack = 1;
            Item.UseSound = SoundID.Item106;
            Item.value = 200;
            Item.rare = 4;
            Item.autoReuse = false;
            //Item.useAmmo = ModContent.ItemType<BoomFlask>();
        }

        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Big Healing Flask");
            // Tooltip.SetDefault("Throws a flask that explodes into clouds\n" +
            // "Clouds deal damage to enemies and heal player if hit enemy");
        }

        // Remove or rename this method if not valid for overriding
        // public override bool PickAmmo(Item ammo, Player player, ref int type, ref float speed, ref int damage, ref float knockback)
        // {
        //     type = ModContent.ProjectileType<HealingCloudPro>();
        //     return true; 
        // }

        public override void UpdateInventory(Player player)
        {
            MPlayer modPlayer = MPlayer.GetModPlayer(player);
            if (modPlayer.novaHelmet)
            {
                Item.autoReuse = true;
            }
            if (!modPlayer.novaHelmet)
            {
                Item.autoReuse = false;
            }

            if (player.FindBuffIndex(ModContent.BuffType<LongFuseBuff>()) != -1)
            {
                Item.shootSpeed = 11f;
            }
            if (player.FindBuffIndex(ModContent.BuffType<LongFuseBuff>()) < 1)
            {
                Item.shootSpeed = 8f;
            }
            if (modPlayer.core)
            {
                Item.autoReuse = true;
            }
            if (!modPlayer.core)
            {
                Item.autoReuse = false;
            }
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<LesserHealingFlack>(), 25);
            recipe.AddIngredient(ModContent.ItemType<StoneofLife>(), 1);
            recipe.AddIngredient(ItemID.PixieDust, 3);
            // recipe.SetResult(this, 20);
            recipe.Register();
        }
    }
}