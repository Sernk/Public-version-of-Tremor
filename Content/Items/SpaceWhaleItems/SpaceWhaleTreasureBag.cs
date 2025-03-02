using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.ItemDropRules;

namespace TremorMod.Content.Items.SpaceWhaleItems
{
	public class SpaceWhaleTreasureBag : ModItem
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
            // Выпадение обычных предметов
            itemLoot.Add(ItemDropRule.Common(ItemID.PlatinumCoin, 1, 1, 7)); 
            itemLoot.Add(ItemDropRule.Common(ItemID.GoldCoin, 1, 25, 60)); 

            // Выпадение трофея с шансом 10%
            itemLoot.Add(ItemDropRule.Common(ModContent.ItemType<SpaceWhaleTrophy>(), 10));

			// Выпадение маски с шансом 1/7 (14.29%) вне экспертного режима
			itemLoot.Add(ItemDropRule.ByCondition(new Conditions.NotExpert(), ModContent.ItemType<SpaceWhaleMask>(), 7));
            itemLoot.Add(ItemDropRule.Common(ModContent.ItemType<CosmicFuel>(), 1));
            itemLoot.Add(ItemDropRule.Common(ModContent.ItemType<StarLantern>(), 4));

			// Гарантированное выпадение одного из трёх предметов.
			itemLoot.Add(ItemDropRule.OneFromOptions(1,
				ModContent.ItemType<BlackHoleCannon>(),
				ModContent.ItemType<HornedWarHammer>(),
				ModContent.ItemType<SDL>(),
				ModContent.ItemType<WhaleFlippers>()));

            itemLoot.Add(ItemDropRule.ByCondition(new Conditions.IsExpert(), ModContent.ItemType<LasCannon>(), 1));    
        }
	}
}
