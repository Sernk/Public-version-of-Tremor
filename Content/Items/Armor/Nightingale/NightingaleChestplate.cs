using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TremorMod.Content.Items.Materials;

namespace TremorMod.Content.Items.Armor.Nightingale
{
	[AutoloadEquip(EquipType.Body)]
	public class NightingaleChestplate : ModItem
	{
		public override void SetDefaults()
		{
			Item.defense = 7;
			Item.width = 22;
			Item.height = 30;
			Item.value = 3025;
			Item.rare = 2;
		}

		/*public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Nightingale Chestplate");
			Tooltip.SetDefault("5% increased damage");
		}*/

		public override void UpdateEquip(Player player)
		{
            player.GetDamage(DamageClass.Melee) += 0.05f;   
            player.GetDamage(DamageClass.Magic) += 0.05f;  
            player.GetDamage(DamageClass.Ranged) += 0.05f; 
            player.GetDamage(DamageClass.Throwing) += 0.05f; 
            player.GetDamage(DamageClass.Summon) += 0.05f;  
		}

		public override void AddRecipes()
		{
            Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<SteelBar>(), 15);
            recipe.AddIngredient(ModContent.ItemType<PhantomSoul>(), 4);
            //recipe.SetResult(this);
            recipe.AddTile(16);
            recipe.Register();
        }
	}
}
