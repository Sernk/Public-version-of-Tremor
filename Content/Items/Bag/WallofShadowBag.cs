using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.ItemDropRules;
using TremorMod.Content.Items.Weapons.Magic;
using TremorMod.Content.Items.Weapons.Ranged;
using TremorMod.Content.Items.Weapons.Melee;
using TremorMod.Content.Items.Vanity;
using TremorMod.Content.Items.Placeable;
using TremorMod.Content.Items.Materials;
using TremorMod.Content.Tiles;
using TremorMod.Content.Items.Weapons.Alchemical;

namespace TremorMod.Content.Items.Bag
{
	public class WallofShadowBag : ModItem
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
            itemLoot.Add(ItemDropRule.Common(ModContent.ItemType<WallofShadowTrophy>(), 10));
            itemLoot.Add(ItemDropRule.Common(ItemID.GreaterHealingPotion, 1, 5, 15));
            itemLoot.Add(ItemDropRule.Common(ModContent.ItemType<WallofShadowMask>(), 7));
            itemLoot.Add(ItemDropRule.Common(ModContent.ItemType<WallOfShadowsFlask>(), 1));
            itemLoot.Add(ItemDropRule.Common(ModContent.ItemType<DarknessCloth>(), 1, 8, 15));

            itemLoot.Add(ItemDropRule.OneFromOptions(1,
                ModContent.ItemType<HeavyBeamCannon>(),
                ModContent.ItemType<Bolter>(),
                ModContent.ItemType<StrikerBlade>()));
        }

    }
}