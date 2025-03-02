using System.Linq;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;
using TremorMod.Content.Items.Accessories;

namespace TremorMod.Content.Items
{
	[AutoloadEquip(EquipType.Wings)]
	public class VultureWings : ModItem
	{

		public override void SetDefaults()
		{

			Item.width = 22;
			Item.height = 20;
			Item.value = 10000;
			Item.rare = 5;
			Item.accessory = true;
		}

		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Vulture Wings");
			// Tooltip.SetDefault("");
            ArmorIDs.Wing.Sets.Stats[Item.wingSlot] = new WingStats(100, 8f, 1f);
        }

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.wingTimeMax = 100;
		}

		public override void VerticalWingSpeeds(Player player, ref float ascentWhenFalling, ref float ascentWhenRising,
			ref float maxCanAscendMultiplier, ref float maxAscentMultiplier, ref float constantAscend)
		{
			ascentWhenFalling = 0.75f;
			ascentWhenRising = 0.15f;
			maxCanAscendMultiplier = 1f;
			maxAscentMultiplier = 3f;
			constantAscend = 0.125f;
		}

		public override void HorizontalWingSpeeds(Player player, ref float speed, ref float acceleration)
		{
			speed = 8f;
			acceleration *= 2.5f;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<VultureFeather>(), 1);
			recipe.AddIngredient(ItemID.SoulofFlight, 20);
			recipe.AddTile(134);
			//recipe.SetResult(this);
			recipe.Register();
		}
	}
}
