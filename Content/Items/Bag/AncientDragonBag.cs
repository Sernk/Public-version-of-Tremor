using Terraria;
using Terraria.ModLoader;
using Terraria.GameContent.ItemDropRules;
using TremorMod.Content.Items.Vanity;
using TremorMod.Content.Items.Placeable;
using TremorMod.Content.Items.Weapons.Melee;
using TremorMod.Content.Items.Weapons.Magic;
using TremorMod.Content.Items.Accessories;

namespace TremorMod.Content.Items.Bag
{
	public class AncientDragonBag : ModItem
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

            itemLoot.Add(ItemDropRule.ByCondition(new Conditions.NotExpert(), ModContent.ItemType<AncientDragonMask>(), 7));

            itemLoot.Add(ItemDropRule.OneFromOptions(1,
                ModContent.ItemType<Swordstorm>(),
                ModContent.ItemType<DragonHead>(),
                ModContent.ItemType<AncientTimesEdge>()));

            itemLoot.Add(ItemDropRule.Common(ModContent.ItemType<AncientSoul>(), 1));
        }      
	}
}