using Terraria;
using Terraria.ModLoader;
using Terraria.GameContent.ItemDropRules;
using TremorMod.Content.Items.Placeable;
using TremorMod.Content.Items.Materials.OreAndBar;
using TremorMod.Content.Items.Accessories;
using TremorMod.Content.Items.Weapons.Melee;
using TremorMod.Content.Items.Weapons.Ranged;
using TremorMod.Content.Items.Weapons.Magic;
using TremorMod.Content.Items.Weapons.Throwing;
using TremorMod.Content.Items.Vanity;
using TremorMod.Content.Items.Materials;

namespace TremorMod.Content.Items.Bag
{
	public class VultureKingBag : ModItem
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
            itemLoot.Add(ItemDropRule.Common(ModContent.ItemType<VultureKingMask>(), 7));
            itemLoot.Add(ItemDropRule.Common(ModContent.ItemType<VultureFeather>(), 4));
            itemLoot.Add(ItemDropRule.Common(ModContent.ItemType<CactusBow>(), 3));
            itemLoot.Add(ItemDropRule.Common(ModContent.ItemType<SandKnife>(), 3));
            itemLoot.Add(ItemDropRule.Common(ModContent.ItemType<SandstoneBar>(), 1, 10, 18));
            itemLoot.Add(ItemDropRule.Common(ModContent.ItemType<VultureKingTrophy>(), 10));
            itemLoot.Add(ItemDropRule.ByCondition(new Conditions.IsExpert(), ModContent.ItemType<DesertClaymore>(), 1));
        }
    }
}
