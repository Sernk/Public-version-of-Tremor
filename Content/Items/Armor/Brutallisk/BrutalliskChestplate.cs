using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TremorMod.Content.Items.Materials.OreAndBar;
using TremorMod.Content.Items.Materials;
using TremorMod.Utilities;

namespace TremorMod.Content.Items.Armor.Brutallisk
{
	[AutoloadEquip(EquipType.Body)]
	public class BrutalliskChestplate : ModItem
	{

		public override void SetDefaults()
		{
			Item.width = 38;
			Item.height = 22;
			Item.value = 150000;
			Item.rare = 11;
			Item.defense = 32;
		}

		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Brutallisk Chestplate");
			/* Tooltip.SetDefault("Increases maximum life by 40\n" +
"15% increased melee speed\n" +
"25% increased damage"); */
		}

		public override void UpdateEquip(Player player)
		{
			player.statLifeMax2 += 40;
			player.GetAttackSpeed(DamageClass.Melee) += 0.15f;
			player.GetDamage(DamageClass.Melee) += 0.25f;
			player.GetDamage(DamageClass.Summon) += 0.25f;
			player.GetDamage(DamageClass.Ranged) += 0.25f;
			player.GetDamage(DamageClass.Magic) += 0.25f;
			player.GetDamage(DamageClass.Throwing) += 0.25f;
			player.GetModPlayer<MPlayer>().alchemicalDamage += 0.25f;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<Aquamarine>(), 10);
			recipe.AddIngredient(ModContent.ItemType<NightmareBar>(), 6);
			recipe.AddIngredient(ModContent.ItemType<EvershinyBar>(), 8);
			recipe.AddIngredient(ModContent.ItemType<SteelBar>(), 2);
			recipe.AddIngredient(ModContent.ItemType<Phantaplasm>(), 4);
			recipe.AddTile(134);
			recipe.Register();
		}
	}
}
