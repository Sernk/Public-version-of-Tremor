using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TremorMod.Content.Items.Materials;

namespace TremorMod.Content.Items.Armor.Raven
{
	[AutoloadEquip(EquipType.Body)]
	public class RavenBreastplate : ModItem
	{
		public override void SetDefaults()
		{
			Item.width = 18;
			Item.height = 18;
			Item.value = 10000;
			Item.rare = 4;
			Item.defense = 10;
		}

		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("Raven Breastplate");
			//Tooltip.SetDefault("8% increased melee damage\n" +
			//"Increases melee critical strike chance by 5");
		}

		public override void UpdateEquip(Player player)
		{
			player.GetDamage(DamageClass.Melee) += 0.08f;
			player.GetCritChance(DamageClass.Melee) += 5;
        }

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.MoltenBreastplate);
			recipe.AddIngredient(ItemID.IronBar, 8);
			recipe.AddIngredient(ModContent.ItemType<RavenFeather>(), 12);
			//recipe.SetResult(this);
			recipe.AddTile(16);
			recipe.Register();

            Recipe recipe1 = CreateRecipe();
            recipe1.AddIngredient(ItemID.MoltenBreastplate);
			recipe1.AddIngredient(ItemID.LeadBar, 8);
            recipe1.AddIngredient(ModContent.ItemType<RavenFeather>(), 12);
            //recipe1.SetResult(this);
			recipe1.AddTile(16);
            recipe1.Register();
        }
	}
}
