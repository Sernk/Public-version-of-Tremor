using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using TremorMod.Content.Items.Materials;

namespace TremorMod.Content.Items.Accessories.Sparks
{
	public class WarriorSpark : ModItem
	{
		public override void SetStaticDefaults()
		{
			Main.RegisterItemAnimation(Item.type, new DrawAnimationVertical(6, 4));
			// DisplayName.SetDefault("Warrior Spark");
			/* Tooltip.SetDefault("3% increased melee damage\n" +
			                   "8% increased melee critical strike chance"); */
		}

		public override void SetDefaults()
		{
			Item.width = 22;
			Item.height = 22;
			Item.accessory = true;
			Item.defense = 2;
			Item.rare = 1;
			Item.value = Item.buyPrice(silver: 1);
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.GetDamage(DamageClass.Melee) += 0.03f;
			player.GetCritChance(DamageClass.Melee) += 8;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<AdventurerSpark>());
			//recipe.SetResult(this);
			recipe.Register();
		}
	}
}
