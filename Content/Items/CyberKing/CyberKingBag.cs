using TremorMod.Content.Items.CyberKing;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.ID;
using Terraria;
using Terraria.GameContent.ItemDropRules;

namespace TremorMod.Content.Items.CyberKing
{
	public class CyberKingBag : ModItem
	{
		/*public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Treasure Bag");
            Tooltip.SetDefault("{$CommonItemTooltip.RightClickToOpen}");
        }*/

		public override void SetDefaults()
		{
			Item.maxStack = 999;
			Item.consumable = true;
			Item.width = 24;
			Item.height = 24;
			Item.rare = ItemRarityID.Cyan;
			Item.expert = true;
		}

		public override bool CanRightClick()
		{
			return true;
		}


		public override void ModifyItemLoot(ItemLoot itemLoot)
		{
			// Гарантированное выпадение одного из трёх предметов.
			itemLoot.Add(ItemDropRule.OneFromOptions(1,
				ModContent.ItemType<RedStorm>(),
				ModContent.ItemType<CyberCutter>(),
				ModContent.ItemType<ShockwaveClaymore>()));

			itemLoot.Add(ItemDropRule.ByCondition(new Conditions.IsExpert(), ModContent.ItemType<CyberStaff>()));

            // Пример добавления других предметов.
            itemLoot.Add(ItemDropRule.Common(ModContent.ItemType<CyberKingMask>(), 7)); // Маска с шансом 1/7.

			//public override int BossBagNPC => NPCType<NPCs.Abomination>();
		}
	}
}