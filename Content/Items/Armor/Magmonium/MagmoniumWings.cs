using Terraria;
using System.Linq;
using Terraria.ID;
using TremorMod.Content.Items.Materials.OreAndBar;
using Terraria.ModLoader;
using Terraria.DataStructures;

namespace TremorMod.Content.Items.Armor.Magmonium
{
	[AutoloadEquip(EquipType.Wings)]
	public class MagmoniumWings : ModItem
	{

		public override void SetDefaults()
		{
			Item.width = 22;
			Item.height = 20;
			Item.value = 80000;
			Item.rare = 8;
			Item.accessory = true;
		}

        public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("Magmonium Wings");
			//Tooltip.SetDefault("Allows flight and slow fall");
			ArmorIDs.Wing.Sets.Stats[Item.wingSlot] = new WingStats(163, 9f, 1f);
		}

        //these wings use the same values as the solar wings

        public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.wingTimeMax = 163;
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
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<MagmoniumBar>(), 20);
			recipe.AddIngredient(ItemID.SoulofFlight, 20);
			recipe.AddTile(134);
			//recipe.SetResult(this);
			recipe.Register();
		}
	}
}
