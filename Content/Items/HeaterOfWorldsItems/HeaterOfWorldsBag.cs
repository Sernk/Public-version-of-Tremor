using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.ID;
using Terraria;
using Terraria.GameContent.ItemDropRules;

namespace TremorMod.Content.Items.HeaterOfWorldsItems
{
	public class HeaterOfWorldsBag : ModItem
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

            // Add CyberStaff drop only in Expert mode
            itemLoot.Add(ItemDropRule.ByCondition(new Conditions.IsExpert(), ModContent.ItemType<InfernalShield>()));

            // Add CyberKingMask with a 1/7 chance
            itemLoot.Add(ItemDropRule.Common(ModContent.ItemType<HeaterOfWorldsMask>(), 7));

            // Add other drops as necessary
            itemLoot.Add(ItemDropRule.Common(ModContent.ItemType<MoltenParts>(), 1, 1));
        }
	}
}
