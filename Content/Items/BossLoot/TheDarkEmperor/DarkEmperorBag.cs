using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.ID;
using Terraria;
using Terraria.GameContent.ItemDropRules;
using TremorMod.Content.Items.Weapons.Melee;

namespace TremorMod.Content.Items.BossLoot.TheDarkEmperor
{
	public class DarkEmperorBag : ModItem
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

            // Выпадение маски с шансом 1/4 (25%) вне экспертного режима
            itemLoot.Add(ItemDropRule.ByCondition(new Conditions.IsExpert(), ModContent.ItemType<DarkEmperorMask>(), 4));

            itemLoot.Add(ItemDropRule.ByCondition(new Conditions.IsExpert(), ModContent.ItemType<DarkEmperorTrophy>(), 4));

            itemLoot.Add(ItemDropRule.ByCondition(new Conditions.IsExpert(), ModContent.ItemType<DrippingScythe>(), 10));

            itemLoot.Add(ItemDropRule.ByCondition(new Conditions.IsExpert(), ModContent.ItemType<DelightfulClump>(), 4));

            itemLoot.Add(ItemDropRule.ByCondition(new Conditions.IsExpert(), ModContent.ItemType<NastyJavelin>(), 1, 30, 50));

            itemLoot.Add(ItemDropRule.ByCondition(new Conditions.IsExpert(), ModContent.ItemType<DarkGel>(), 1, 50, 100));

            itemLoot.Add(ItemDropRule.ByCondition(new Conditions.IsExpert(), ModContent.ItemType<SoulofFight>(), 1, 20, 30));

            itemLoot.Add(ItemDropRule.ByCondition(new Conditions.IsExpert(), ModContent.ItemType<SuperBigCannon>()));

            itemLoot.Add(ItemDropRule.ByCondition(new Conditions.IsExpert(), ModContent.ItemType<SBCCannonballAmmo>(), 1, 50, 150));
        }
    }
}
