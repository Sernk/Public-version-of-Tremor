using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TremorMod.Content.Items.Materials;
using TremorMod.Content.Buffs;

namespace TremorMod.Content.Items.Accessories
{
    public class BouncingCasing : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 22;
            Item.height = 44;
            Item.value = 25000;
            Item.rare = 5;
            Item.accessory = true;
            Item.defense = 1;
        }

        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Bouncing Casing");
            //Tooltip.SetDefault("Alchemical flasks bounce off blocks");
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.AddBuff(ModContent.BuffType<BouncingCasingBuff>(), 2);
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.Bottle, 1);
            recipe.AddIngredient(ModContent.ItemType<PinkGelCube>(), 5);
            recipe.AddIngredient(ItemID.SoulofLight, 9);
            recipe.AddIngredient(ItemID.SoulofNight, 9);
            //recipe.SetResult(this);
            recipe.AddTile(16);
            recipe.Register();
        }
    }
}
