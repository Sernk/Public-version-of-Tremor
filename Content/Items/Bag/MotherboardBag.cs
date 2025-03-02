using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.ItemDropRules;
using TremorMod.Content.Items.Accessories;
using TremorMod.Content.Items.Materials;
using TremorMod.Content.Items.Placeable;
using TremorMod.Content.Items.Vanity;

namespace TremorMod.Content.Items.Bag
{
	public class MotherboardBag : ModItem
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
			// DisplayName.SetDefault("Motherboard Treasure Bag");
			// Tooltip.SetDefault("{$CommonItemTooltip.RightClickToOpen}");
		}
		
		public override bool CanRightClick()
		{
			return true;
		}

        public override void ModifyItemLoot(ItemLoot itemLoot)
        {
            itemLoot.Add(ItemDropRule.Common(ModContent.ItemType<SoulofMind>(), 1, 20, 40));
            itemLoot.Add(ItemDropRule.Common(ItemID.MechanicalWagonPiece, 1));
            itemLoot.Add(ItemDropRule.Common(ItemID.GreaterHealingPotion, 1, 5, 16));
            itemLoot.Add(ItemDropRule.Common(ItemID.HallowedBar, 1, 15, 35));
        }

    }
}
