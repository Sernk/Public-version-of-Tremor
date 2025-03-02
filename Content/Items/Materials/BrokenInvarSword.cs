using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TremorMod.Content.Items.Materials
{
    public class BrokenInvarSword : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 28;
            Item.height = 30;
            Item.maxStack = 990;
            Item.value = Item.sellPrice(silver: 1);
            Item.rare = 1;
        }
    }
}