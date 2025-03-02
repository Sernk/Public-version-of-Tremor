using Terraria;
using Terraria.ModLoader;
using Terraria.GameContent.ItemDropRules;
using TremorMod.Content.Items.Weapons.Melee;
using TremorMod.Content.Items.Materials;
using TremorMod.Content.Items.Vanity;
using TremorMod.Content.Items.Placeable;

namespace TremorMod.Content.Items.Bag
{
	public class FrostKingBag : ModItem
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
            itemLoot.Add(ItemDropRule.Common(ModContent.ItemType<AncientDragonTrophy>(), 10));

            itemLoot.Add(ItemDropRule.Common(ModContent.ItemType<EdgeofFrostKing>(), 1));

            itemLoot.Add(ItemDropRule.ByCondition(new Conditions.NotExpert(), ModContent.ItemType<FrostKingMask>(), 7));

            itemLoot.Add(ItemDropRule.Common(ModContent.ItemType<FrostoneOre>(), 1, 24, 42));
        }
    }
}