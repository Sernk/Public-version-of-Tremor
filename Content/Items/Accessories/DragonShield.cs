using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TremorMod.Utilities;

namespace TremorMod.Content.Items.Accessories
{
    [AutoloadEquip(EquipType.Shield)]
    public class DragonShield : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 34;
            Item.height = 36;
            Item.value = 32000;
            Item.rare = 11;
            Item.accessory = true;
            Item.defense = 24;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetModPlayer<DragonShieldPlayer>().DashAccessoryEquipped = true;
            player.moveSpeed += 0.6f;
        }
    }
}