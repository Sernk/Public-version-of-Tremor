using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.ItemDropRules;
using TremorMod.Content.Items.Vanity;
using TremorMod.Content.Items.Materials;
using TremorMod.Content.Items.Weapons.Melee;
using TremorMod.Content.Items.Weapons.Magic;
using TremorMod.Content.Items.Weapons.Ranged;
using TremorMod.Content.Items.Weapons.Throwing;
using TremorMod.Content.Items.Bag;
using TremorMod.Content.Items;
using TremorMod.Content.Items.Placeable;

namespace TremorMod.Content.Items.Bag
{
	public class ParadoxTitanBag : ModItem
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

			itemLoot.Add(ItemDropRule.Common(ModContent.ItemType<ParadoxTitanMask>(), 7));
			itemLoot.Add(ItemDropRule.Common(ModContent.ItemType<TimeTissue>(), 1, 20, 32));
			itemLoot.Add(ItemDropRule.OneFromOptions(1, ModContent.ItemType<RocketWand>(), ModContent.ItemType<TheEtherealm>(), ModContent.ItemType<SoulFlames>()));
			itemLoot.Add(ItemDropRule.Common(ModContent.ItemType<ParadoxTitanTrophy>(), 10));
			itemLoot.Add(ItemDropRule.Common(ModContent.ItemType<VioleumWings>(), 20));
			itemLoot.Add(ItemDropRule.ByCondition(new Conditions.IsExpert(), ModContent.ItemType<ClockofTime>(), 1));
		}
	}
}
