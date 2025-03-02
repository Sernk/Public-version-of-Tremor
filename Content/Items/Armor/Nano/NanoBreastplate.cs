using Terraria;
using Terraria.ModLoader;
using TremorMod.Content.Items.Materials.OreAndBar;

namespace TremorMod.Content.Items.Armor.Nano
{
	[AutoloadEquip(EquipType.Body)]
	public class NanoBreastplate : ModItem
	{

		public override void SetDefaults()
		{
			Item.width = 26;
			Item.height = 18;
			Item.value = 60000;
			Item.rare = 6;
			Item.defense = 17;
		}

		/*public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Nano Breastplate");
			Tooltip.SetDefault("8% increased damage\n" +
			"10% increased melee speed");
		}*/

		public override void UpdateEquip(Player player)
		{
			player.GetDamage(DamageClass.Melee) += 0.08f;   // +8% к ближнему урону
			player.GetDamage(DamageClass.Magic) += 0.08f;   // +8% к магическому урону
			player.GetDamage(DamageClass.Ranged) += 0.08f;  // +8% к дальнему урону
			player.GetDamage(DamageClass.Throwing) += 0.08f; // +8% к урону бросков
			player.GetDamage(DamageClass.Summon) += 0.08f;  // +8% к урону прислужников
			player.GetAttackSpeed(DamageClass.Melee) += 0.10f;
		}

		public override void AddRecipes()
		{
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<NanoBar>(), 20);
            //recipe.SetResult(this);
			recipe.AddTile(134);
            recipe.Register();
        }
	}
}
