using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.ItemDropRules;
using TremorMod.Content.NPCs.Bosses.CogLord;
using static Terraria.ModLoader.ModContent;
using TremorMod.Content.Items.CogLordItems;

namespace TremorMod.Content.Items.CogLordItems
{
	public class CogLordBag : ModItem
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

		/*public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Treasure Bag");
			Tooltip.SetDefault("{$CommonItemTooltip.RightClickToOpen}");
		}*/

		public override bool CanRightClick()
		{
			return true;
		}

        public override void ModifyItemLoot(ItemLoot itemLoot)
        {
            // Guarantee one item from the following three
            itemLoot.Add(ItemDropRule.OneFromOptions(1,
                ModContent.ItemType<BrassStave>(),
                ModContent.ItemType<BrassChainRepeater>(),
                ModContent.ItemType<BrassRapier>()
            ));

            // Add CyberStaff drop only in Expert mode
            itemLoot.Add(ItemDropRule.ByCondition(new Conditions.IsExpert(), ModContent.ItemType<HeatCore>()));

			// Add CyberKingMask with a 1/7 chance
			itemLoot.Add(ItemDropRule.Common(ModContent.ItemType<CogLordMask>(), 7));
            itemLoot.Add(ItemDropRule.Common(ModContent.ItemType<BrassChip>(), 10));

            // Add other drops as necessary
            itemLoot.Add(ItemDropRule.Common(ModContent.ItemType<BrassNugget>(),1, 18, 34));
        }
    }
}
