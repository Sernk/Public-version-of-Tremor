using Terraria;
using Terraria.ModLoader;
using Terraria.GameContent.ItemDropRules;
using TremorMod.Content.Items.Bag;
using TremorMod.Content.Items.Placeable;
using TremorMod.Content.Items.Materials;
using TremorMod.Content.Items.Weapons.Magic;
using TremorMod.Content.Items.Weapons.Melee;
using TremorMod.Content.Items.Weapons.Ranged;
using TremorMod.Content.Items.Weapons.Throwing;
using TremorMod.Content.Items.Weapons.Summon;
using TremorMod.Content.Items.Vanity;
using TremorMod.Content.Items.Crystal;
using TremorMod.Content.Items;
using TremorMod;

namespace TremorMod.Content.Items.Bag
{
	public class BrutalliskBag : ModItem
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
            itemLoot.Add(ItemDropRule.Common(ModContent.ItemType<BrutalliskMask>(), 7));
            itemLoot.Add(ItemDropRule.Common(ModContent.ItemType<LightningStaff>(), 4));
            itemLoot.Add(ItemDropRule.Common(ModContent.ItemType<Awakening>(), 4));
            itemLoot.Add(ItemDropRule.Common(ModContent.ItemType<SnakeDevourer>(), 4));
            itemLoot.Add(ItemDropRule.Common(ModContent.ItemType<QuetzalcoatlStave>(), 4));
            itemLoot.Add(ItemDropRule.Common(ModContent.ItemType<TreasureGlaive>(), 4));
            itemLoot.Add(ItemDropRule.Common(ModContent.ItemType<FallenSnake>(), 4));
            itemLoot.Add(ItemDropRule.Common(ModContent.ItemType<StrangeEgg>(), 5));
            itemLoot.Add(ItemDropRule.Common(ModContent.ItemType<BrutalliskTrophy>(), 10));
            itemLoot.Add(ItemDropRule.Common(ModContent.ItemType<Aquamarine>(), 1, 25, 30));
            itemLoot.Add(ItemDropRule.Common(ModContent.ItemType<BrutalliskCrystal>(), 1));
        }
    }
}
