using Terraria;
using Terraria.ModLoader;
using Terraria.GameContent.ItemDropRules;
using TremorMod.Content.Items.Vanity;
using TremorMod.Content.Items.Placeable;
using TremorMod.Content.Items.Weapons.Alchemical;
using TremorMod.Content.Items.Weapons.Melee;
using TremorMod.Content.Items.Accessories;
using TremorMod.Content.Items.Bag;
using TremorMod.Content.Items;

namespace TremorMod.Content.Items.Bag
{
	public class AlchemasterTreasureBag : ModItem
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
			// DisplayName.SetDefault("Treasure Bag");
			// Tooltip.SetDefault("{$CommonItemTooltip.RightClickToOpen}");
		}

		public override bool CanRightClick()
		{
			return true;
		}

        public override void ModifyItemLoot(ItemLoot itemLoot)
        {
            itemLoot.Add(ItemDropRule.Common(ModContent.ItemType<AlchemasterMask>(), 7));
            itemLoot.Add(ItemDropRule.Common(ModContent.ItemType<PlagueFlask>(), 1, 60, 160));
            itemLoot.Add(ItemDropRule.Common(ModContent.ItemType<SparkingFlask>(), 1, 60, 160));
            itemLoot.Add(ItemDropRule.Common(ModContent.ItemType<LongFuse>(), 1));
            itemLoot.Add(ItemDropRule.Common(ModContent.ItemType<TheGlorch>(), 3));
            itemLoot.Add(ItemDropRule.Common(ModContent.ItemType<BadApple>(), 3));
            itemLoot.Add(ItemDropRule.Common(ModContent.ItemType<GoldenStar>(), 1));
            itemLoot.Add(ItemDropRule.Common(ModContent.ItemType<AlchemasterTrophy>(), 10));
        }
	}
}
