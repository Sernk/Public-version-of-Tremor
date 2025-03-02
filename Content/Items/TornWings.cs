using System.Linq;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;
using TremorMod.Content.Items.Materials;

namespace TremorMod.Content.Items
{
	[AutoloadEquip(EquipType.Wings)]
	public class TornWings : ModItem
	{

		public override void SetDefaults()
		{

			Item.width = 22;
			Item.height = 20;
			Item.value = 10000;
			Item.rare = 3;
			Item.accessory = true;
		}

		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Torn Wings");
			// Tooltip.SetDefault("");
            ArmorIDs.Wing.Sets.Stats[Item.wingSlot] = new WingStats(25, 4f, 1f);
        }

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.wingTimeMax = 25;
		}

		public override void VerticalWingSpeeds(Player player, ref float ascentWhenFalling, ref float ascentWhenRising,
		   ref float maxCanAscendMultiplier, ref float maxAscentMultiplier, ref float constantAscend)
		{
			ascentWhenFalling = 0.35f;
			ascentWhenRising = 0.8f;
			maxCanAscendMultiplier = 1f;
			maxAscentMultiplier = 2f;
			constantAscend = 0.25f;
		}

		public override void HorizontalWingSpeeds(Player player, ref float speed, ref float acceleration)
		{
			speed = 4f;
			acceleration *= 2.5f;
		}
	}
}
