using Terraria;
using Terraria.ID; 
using Terraria.ModLoader;
using TremorMod.Content.Items.Materials;
using Terraria.GameContent.Creative;
using Terraria.Localization;

namespace TremorMod.Content.Items.Armor.Afterlife
{
	[AutoloadEquip(EquipType.Body)]
	public class AfterlifeBreastplate : ModItem
	{

		public override void SetDefaults()
		{
			Item.width = 18;
			Item.height = 18;
			Item.value = 10000;
			Item.rare = 6;
			Item.defense = 11;
		}

        /*public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Afterlife Breastplate");
			Tooltip.SetDefault("9% increased damage\n" +
			"Increases your max number of minions");
		}*/

        public override void UpdateEquip(Player player)
        {
            player.GetDamage(DamageClass.Summon) += 0.12f; // Увеличение урона на 12% для Summon
            player.GetDamage(DamageClass.Magic) += 0.09f;  // Увеличение урона на 9% для Magic
            player.GetDamage(DamageClass.Ranged) += 0.09f; // Увеличение урона на 9% для Ranged
            player.GetDamage(DamageClass.Melee) += 0.09f;  // Увеличение урона на 9% для Melee
            player.maxMinions += 2;                        // Увеличение максимального количества миньонов
        }



        public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<SkullTeeth>(), 3);
            recipe.AddIngredient(ModContent.ItemType<SteelBar>(), 20);
			recipe.AddTile(134);
			recipe.Register();
		}
	}
}
