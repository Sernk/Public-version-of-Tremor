using Terraria;
using System.Linq;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;

namespace TremorMod.Content.Items.AndasItems
{
	[AutoloadEquip(EquipType.Wings)]
	public class AndasCore : ModItem
	{
		public override void SetDefaults()
		{
			Item.width = 22;
			Item.height = 20;
			Item.value = 500000;
			Item.rare = 10;
			Item.expert = true;
			Item.accessory = true;
		}

		public override void SetStaticDefaults()
		{
            //DisplayName.SetDefault("Andas Core");
            //Tooltip.SetDefault("Allows flight\n" +
            //"Has infinite flight time\n" +
            //"Has big flight speed");
            ArmorIDs.Wing.Sets.Stats[Item.wingSlot] = new WingStats(9999999, 40f, 3f);
        }

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.wingTimeMax = 9999999;
		}

		public override void ArmorSetShadows(Player player)
		{
			player.armorEffectDrawOutlines = true; //�।��� ����஢����
			player.armorEffectDrawShadowLokis = true; //�����쪨� ⥭�
		}

		public override void VerticalWingSpeeds(Player player, ref float ascentWhenFalling, ref float ascentWhenRising,
			ref float maxCanAscendMultiplier, ref float maxAscentMultiplier, ref float constantAscend)
		{
			ascentWhenFalling = 3f;
			ascentWhenRising = 2f;
			maxCanAscendMultiplier = 3f;
			maxAscentMultiplier = 3f;
			constantAscend = 0.135f;
		}

		public override void HorizontalWingSpeeds(Player player, ref float speed, ref float acceleration)
		{
			speed = 40f;
			acceleration *= 4f;
		}
	}
}
