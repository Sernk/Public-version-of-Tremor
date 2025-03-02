using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.ItemDropRules;
using TremorMod.Content.Items.Weapons.Ranged;
using TremorMod.Content.Items;

namespace TremorMod.Content.Items.Bag
{
	public class PirateChest : ModItem
	{
		public override void SetDefaults()
		{
			Item.maxStack = 999;
			Item.consumable = true;
			Item.width = 34;
			Item.height = 34;
			Item.value = 20000;
			Item.rare = 5;
		}

		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("Pirate Chest");
			//Tooltip.SetDefault("Right click to open\n" +
			//"'Contains precious things'");
		}

		public override bool CanRightClick()
		{
			return true;
		}

        public override void ModifyItemLoot(ItemLoot itemLoot)
        {
			itemLoot.Add(ItemDropRule.Common(ItemID.GoldBar, 1, 9, 18)); //19
			itemLoot.Add(ItemDropRule.Common(ItemID.GoldCoin, 2, 14, 19)); //73
            itemLoot.Add(ItemDropRule.Common(ItemID.Cutlass, 25)); //672
			itemLoot.Add(ItemDropRule.Common(ItemID.PlatinumBar, 2, 14, 19)); //706
            itemLoot.Add(ItemDropRule.Common(ItemID.DiscountCard, 15)); //854
            itemLoot.Add(ItemDropRule.Common(ItemID.LuckyCoin, 10)); //855
            itemLoot.Add(ItemDropRule.Common(ItemID.CoinGun, 25)); //905 
            itemLoot.Add(ItemDropRule.Common(ItemID.CactusSink, 10)); //2854
            itemLoot.Add(ItemDropRule.Common(ItemID.GoldRing, 6)); //3033

            itemLoot.Add(ItemDropRule.Common(ModContent.ItemType<HandCannon>(), 6));                                  
            itemLoot.Add(ItemDropRule.Common(ModContent.ItemType<PirateFlag>(), 6));                                
        }
    }
}