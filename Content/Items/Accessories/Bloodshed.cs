using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TremorMod.Content.Tiles;
using TremorMod.Content.Items;

namespace TremorMod.Content.Items.Accessories
{
	public class Bloodshed : ModItem
	{
		public override void SetDefaults()
		{
			Item.width = 22;
			Item.height = 44;
			Item.value = 10000;
			Item.rare = 3;
			Item.defense = 6;
			Item.accessory = true;
		}

		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("Bloodshed");
			//Tooltip.SetDefault("8% increased melee, magic and minion damage\n" +
			//"Increases maximum mana and health by 60\n" +
			//"10% increased melee and magic critical strike chance");
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.statManaMax2 += 60;
			player.statLifeMax2 += 60;
            player.GetCritChance(DamageClass.Melee) += 10;
            player.GetCritChance(DamageClass.Magic) += 10;
            player.GetDamage(DamageClass.Summon) += 0.13f;
            player.GetDamage(DamageClass.Magic) += 0.13f;
            player.GetDamage(DamageClass.Melee) += 0.13f;
        }

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<JungleWrath>(), 1);
			recipe.AddIngredient(ModContent.ItemType<CrimtaneProtector>(), 1);
			recipe.AddIngredient(ModContent.ItemType<WaterStorm>(), 1);
			recipe.AddIngredient(ModContent.ItemType<Candent>(), 1);
			//recipe.SetResult(this);
			recipe.AddTile(ModContent.TileType<GreatAnvilTile>());
			recipe.Register();
		}
	}
}
