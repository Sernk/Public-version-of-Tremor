using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TremorMod;
using TremorMod.Content.Buffs;
using TremorMod.Content.Items.Weapons.Alchemical;
using TremorMod.Utilities;

namespace TremorMod.Content.Items.Accessories
{
    public class EnchantmentSolution : ModItem
    {
        /*public override bool CanEquipAccessory(Player player, int slot)
        {
            for (int i = 0; i < player.armor.Length; i++)
            {
                MPlayer modPlayer = player.GetModPlayer<MPlayer>();
                if (modPlayer.enchanted)
                {
                    return false;
                }
            }
            return true;
        }*/

        public override void SetDefaults()
        {
            Item.width = 26;
            Item.height = 30;
            Item.value = 250000;
            Item.rare = 5;
            Item.accessory = true;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.Bottle, 5);
            recipe.AddIngredient(ItemID.SoulofLight, 12);
            recipe.AddIngredient(ItemID.BottledWater, 1);
            recipe.AddIngredient(ItemID.ManaCrystal, 1);
            recipe.AddIngredient(ItemID.LifeCrystal, 1);
            recipe.AddIngredient(ModContent.ItemType<BasicFlask>(), 15);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            MPlayer modPlayer = player.GetModPlayer<MPlayer>();
            player.AddBuff(ModContent.BuffType<EnchantmentSolutionBuffs>(), 2);
            modPlayer.enchanted = true;
        }
    }
}