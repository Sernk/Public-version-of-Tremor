using Terraria;
using Terraria.ModLoader;
using Terraria.GameContent.ItemDropRules;
using TremorMod.Content.Items.Placeable;
using TremorMod.Content.Items.Materials.OreAndBar;
using TremorMod.Content.Items.Accessories;
using TremorMod.Content.Items.Weapons.Melee;
using TremorMod.Content.Items.Weapons.Magic;
using TremorMod.Content.Items.Vanity;

namespace TremorMod.Content.Items.Bag
{
	public class PixieQueenBag : ModItem
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

		public override bool CanRightClick()
		{
			return true;
		}
		
        public override void ModifyItemLoot(ItemLoot itemLoot)
        {         
            itemLoot.Add(ItemDropRule.Common(ModContent.ItemType<EtherealFeather>(), 6));

            itemLoot.Add(ItemDropRule.Common(ModContent.ItemType<PixiePulse>(), 6));

            itemLoot.Add(ItemDropRule.Common(ModContent.ItemType<HeartMagnet>(), 6));

            itemLoot.Add(ItemDropRule.Common(ModContent.ItemType<DopelgangerCandle>(), 6));

            itemLoot.Add(ItemDropRule.Common(ModContent.ItemType<GlorianaWrath>(), 1));

            itemLoot.Add(ItemDropRule.ByCondition(new Conditions.NotExpert(), ModContent.ItemType<PixieQueenMask>(), 7));

            itemLoot.Add(ItemDropRule.Common(ModContent.ItemType<ChaosBar>(), 1, 15, 25));
        }

    }
}
