using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.ItemDropRules;
using TremorMod.Utilities;
using TremorMod.Content.Items.Vanity;

namespace TremorMod.Content.Items.EvilCornItems
{
	public class EvilCornBag : ModItem
	{
		public override void SetDefaults()
		{
			Item.maxStack = 999;
			Item.consumable = true;
			Item.width = 24;
			Item.height = 24;
			Item.rare = 9;
			Item.expert = true;
		}

		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("Treasure Bag");
			//Tooltip.SetDefault("{$CommonItemTooltip.RightClickToOpen}");
		}

		public override bool CanRightClick()
		{
			return true;
		}

		public override void ModifyItemLoot(ItemLoot itemLoot)
		{
			itemLoot.Add(ItemDropRule.Common(ItemID.GoldCoin, 1, 1, 4));
			itemLoot.Add(ItemDropRule.Common(ItemID.SilverCoin, 1, 6, 25));
			itemLoot.Add(ItemDropRule.Common(ModContent.ItemType<EvilCornTrophy>(), 10));
			itemLoot.Add(ItemDropRule.Common(ModContent.ItemType<EvilCornMask>(), 7));

			itemLoot.Add(ItemDropRule.Common(ModContent.ItemType<GrayKnightHelmet>(), 5));
			itemLoot.Add(ItemDropRule.Common(ModContent.ItemType<GrayKnightBreastplate>(), 5));
			itemLoot.Add(ItemDropRule.Common(ModContent.ItemType<KnightGreaves>(), 5));

			itemLoot.Add(ItemDropRule.Common(ModContent.ItemType<CornSword>(), 3));
			itemLoot.Add(ItemDropRule.Common(ModContent.ItemType<CornHeater>(), 1));

			itemLoot.Add(ItemDropRule.Common(ModContent.ItemType<Corn>(), 1, 25, 48));
			itemLoot.Add(ItemDropRule.Common(ModContent.ItemType<CornJavelin>(), 1, 15, 45));

			itemLoot.Add(ItemDropRule.ByCondition(new MissingItemCondition(ModContent.ItemType<FarmerShovel>()), ModContent.ItemType<FarmerShovel>(), 1));
		}
	}
}