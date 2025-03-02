using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TremorMod.Content.Items.Materials.OreAndBar;
using TremorMod.Utilities;

namespace TremorMod.Content.Items.Armor.Invar
{
    [AutoloadEquip(EquipType.Legs)]
    internal class InvarGreaves : ModItem
	{

        public override void SetDefaults()
		{
			Item.width = 22;
			Item.height = 18;
			Item.value = Item.sellPrice(silver: 13);
			Item.rare = 1;
			Item.defense = 2;
		}

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetModPlayer<MPlayer>().damageReduction += 0.03f;
        }

        /*public override void SafeStaticDefaults()
		{
			DisplayName.SetDefault("Reinforced Invar Greaves");
			Tooltip.SetDefault("Reinforced to grant +1 defense");
		}*/

        public override void AddRecipes()
		{
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<InvarBar>(), 12);
            //recipe.SetResult(this);
            recipe.AddTile((TileID.Anvils));
            recipe.Register();
        }
	}
}
