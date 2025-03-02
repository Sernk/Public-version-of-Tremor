using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TremorMod.Content.Projectiles.Minions;

namespace TremorMod.Content.Items.Weapons.Summon
{
    public class AntiqueStave : ModItem
    {
        public override void SetDefaults()
        {
            Item.damage = 21;
            Item.mana = 10;
            Item.width = 44;
            Item.height = 44;
            Item.useTime = 25;
            Item.useAnimation = 25;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.noMelee = true;
            Item.knockBack = 2.5f;
            Item.value = Item.buyPrice(0, 1, 0, 0);
            Item.rare = ItemRarityID.Green;
            Item.UseSound = SoundID.Item44;
            Item.autoReuse = true;
            Item.shoot = ModContent.ProjectileType<AntiqueStavePro>();
            Item.DamageType = (DamageClass.Summon);
            Item.sentry = true;
        }

        /*public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Antique Stave");
            Tooltip.SetDefault("Summons an antique spirit to shoot bolts at your enemies");
        }*/

        public override bool AltFunctionUse(Player player)
        {
            return true;
        }

        public override bool? UseItem(Player player)
        {
            if (player.altFunctionUse == 2)
            {
                player.MinionNPCTargetAim(true); // Или false, в зависимости от того, что вам нужно
            }
            return base.UseItem(player);
        }


        public override bool Shoot(Player player, Terraria.DataStructures.EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockBack)
        {
            Vector2 SPos = Main.screenPosition + new Vector2(Main.mouseX, Main.mouseY);
            position = SPos;

            // Деактивация старых снарядов того же типа
            for (int l = 0; l < Main.projectile.Length; l++)
            {
                Projectile proj = Main.projectile[l];
                if (proj.active && proj.type == Item.shoot && proj.owner == player.whoAmI)
                {
                    proj.active = false;
                }
            }

            // Выстрел только при основной функции
            return player.altFunctionUse != 2;
        }
    }
}