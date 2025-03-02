using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TremorMod.Content.Items.Crystal
{
    class UnstableCrystal : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 44;
            Item.height = 48;
            Item.useTime = 30;
            Item.useAnimation = 30;
            Item.useStyle = ItemUseStyleID.HoldUp;
            Item.knockBack = 0;
            Item.shoot = ProjectileID.None;
            Item.value = 10000;
            Item.rare = ItemRarityID.Blue;
            Item.consumable = true;
            Item.maxStack = 999;
            Item.UseSound = SoundID.Item6;
        }

        /*public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Unstable Crystal");
            Tooltip.SetDefault("Teleports you to a random location\n" +
            "'Be careful! It can take you to a very dangerous place!'");
        }*/

        public override bool? UseItem(Player player)
        {
            player.TeleportationPotion(); // “елепортирует игрока в случайное место
            return true; // ¬озвращает true, чтобы показать успешное использование
        }

    }
}
