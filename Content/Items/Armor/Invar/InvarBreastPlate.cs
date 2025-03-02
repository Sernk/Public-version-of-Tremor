using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TremorMod.Content.Items.Materials.OreAndBar;
using TremorMod.Utilities;

namespace TremorMod.Content.Items.Armor.Invar
{
    [AutoloadEquip(EquipType.Body)]
    internal class InvarBreastPlate : ModItem
    {

        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
            // Указываем текстуры тела и рук
            ArmorIDs.Body.Sets.HidesArms[Item.bodySlot] = false; // Показываем текстуру рук
            ArmorIDs.Body.Sets.HidesTopSkin[Item.bodySlot] = false; // Показываем верхнюю часть кожи
        }


        public override void SetDefaults()
        {
			Item.width = 26;
			Item.height = 18;
			Item.value = Item.sellPrice(silver: 19);
			Item.rare = 1;
			Item.defense = 3;
		}

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetModPlayer<MPlayer>().damageReduction += 0.03f; 
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<InvarBar>(), 18);
            //recipe.SetResult(this);
            recipe.AddTile((TileID.Anvils));
            recipe.Register();
        }

        /*public sealed override void SafeStaticDefaults()
		{
			DisplayName.SetDefault("Reinforced Invar Breastplate");
			Tooltip.SetDefault("Reinforced to grant +1 defense");
		}*/
    }
}
