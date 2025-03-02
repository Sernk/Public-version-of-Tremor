using System.Linq;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;
using TremorMod.Content.Items.Materials.OreAndBar;

namespace TremorMod.Content.Items.Armor.Chaos
{
	[AutoloadEquip(EquipType.Wings)]
	public class ChaosWings : ModItem
	{

		public override void SetDefaults()
		{
			Item.width = 28;
			Item.height = 30;
			Item.value = 80000;
			Item.rare = 5;
			Item.accessory = true;
		}

		public override void SetStaticDefaults()
		{
            //DisplayName.SetDefault("Chaos Wings");
            //Tooltip.SetDefault("Allows flight and slow fall");
            ArmorIDs.Wing.Sets.Stats[Item.wingSlot] = new WingStats(127, 9f, 1f);
        }

		//these wings use the same values as the solar wings

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.wingTimeMax = 127;
		}

		public override void VerticalWingSpeeds(Player player, ref float ascentWhenFalling, ref float ascentWhenRising,
			ref float maxCanAscendMultiplier, ref float maxAscentMultiplier, ref float constantAscend)
		{
			ascentWhenFalling = 0.85f;
			ascentWhenRising = 0.15f;
			maxCanAscendMultiplier = 1f;
			maxAscentMultiplier = 3f;
			constantAscend = 0.135f;
		}

		public override void HorizontalWingSpeeds(Player player, ref float speed, ref float acceleration)
		{
			speed = 9f;
			acceleration *= 2.5f;
		}

		public override void AddRecipes()
		{
			Recipe recipe =	CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<ChaosBar>(), 15);
			recipe.AddIngredient(ItemID.SoulofFlight, 20);
			recipe.AddIngredient(ItemID.CrystalShard, 25);
			recipe.AddTile(134);
			//recipe.SetResult(this);
			recipe.Register();
		}
	}
}
