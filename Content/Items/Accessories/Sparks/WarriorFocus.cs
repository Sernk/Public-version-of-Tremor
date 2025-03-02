using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using TremorMod.Content.Items.Materials;
using TremorMod.Content.Tiles;

namespace TremorMod.Content.Items.Accessories.Sparks
{
	public class WarriorFocus : ModItem
	{

		public override void SetDefaults()
		{

			Item.width = 22;
			Item.height = 22;

			Item.accessory = true;
			Item.defense = 3;
			Item.rare = 2;
			Item.value = 50000;
		}

		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Warrior Focus");
			/* Tooltip.SetDefault("6% increased melee damage\n" +
"Increases melee critical strike chance by 11"); */
			Main.RegisterItemAnimation(Item.type, new DrawAnimationVertical(6, 4));
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.GetDamage(DamageClass.Melee) += 0.06f;
			player.GetCritChance(DamageClass.Melee) += 11;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<WarriorSpark>());
			recipe.AddIngredient(ModContent.ItemType<AirFragment>(), 1);
			recipe.AddIngredient(ItemID.Ruby, 16);
			//recipe.SetResult(this);
			recipe.AddTile(ModContent.TileType<AltarofEnchantmentsTile>());
			recipe.Register();
		}
	}
}
