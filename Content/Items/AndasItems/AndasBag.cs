using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.ID;
using Terraria;
using Terraria.GameContent.ItemDropRules;

namespace TremorMod.Content.Items.AndasItems
{
	public class AndasBag : ModItem
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
			itemLoot.Add(ItemDropRule.OneFromOptions(1,
				ModContent.ItemType<GehennaStaff>(),
				ModContent.ItemType<VulcanBlade>(),
				ModContent.ItemType<HellStorm>(),
				ModContent.ItemType<Inferno>(),
				ModContent.ItemType<Pandemonium>()));

			itemLoot.Add(ItemDropRule.ByCondition(new Conditions.IsExpert(), ModContent.ItemType<AndasCore>()));
			itemLoot.Add(ItemDropRule.Common(ModContent.ItemType<AndasMask>(), 7)); // Маска с шансом 1/7.
            itemLoot.Add(ItemDropRule.Common(ModContent.ItemType<InfernoSoul>(), 1, 8, 15)); // Маска с шансом 1/7.
            itemLoot.Add(ItemDropRule.Common(ItemID.SuperHealingPotion, 1, 10, 25));
        }
	}
}
