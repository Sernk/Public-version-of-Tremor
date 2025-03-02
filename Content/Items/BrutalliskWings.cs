using System.Linq;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;
using TremorMod.Content.Items.Materials.OreAndBar;
using TremorMod.Content.Items.Materials;

namespace TremorMod.Content.Items
{
	[AutoloadEquip(EquipType.Wings)]
	public class BrutalliskWings : ModItem
	{

		public override void SetDefaults()
		{

			Item.width = 22;
			Item.height = 20;

			Item.value = 100000;
			Item.rare = 11;
			Item.accessory = true;
		}

		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Brutallisk Wings");
			// Tooltip.SetDefault("Allows flight and slow fall");
            ArmorIDs.Wing.Sets.Stats[Item.wingSlot] = new WingStats(290, 10f, 1f);
        }

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.wingTimeMax = 290;
		}

		public override void VerticalWingSpeeds(Player player, ref float ascentWhenFalling, ref float ascentWhenRising,
			ref float maxCanAscendMultiplier, ref float maxAscentMultiplier, ref float constantAscend)
		{
			ascentWhenFalling = 0.85f;
			ascentWhenRising = 0.45f;
			maxCanAscendMultiplier = 1f;
			maxAscentMultiplier = 3f;
			constantAscend = 0.135f;
		}

		public override void HorizontalWingSpeeds(Player player, ref float speed, ref float acceleration)
		{
			speed = 10f;
			acceleration *= 4.5f;
		}
	}
}
