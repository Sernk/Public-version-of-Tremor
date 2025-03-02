using Terraria;
using Terraria.ModLoader;
using Terraria.GameContent.ItemDropRules;
using TremorMod.Content.Items.Weapons.Summon;
using TremorMod.Content.Items.Weapons.Ranged;
using TremorMod.Content.Items.Weapons.Magic;
using TremorMod.Content.Items.Weapons.Melee;
using TremorMod.Content.Items.Placeable;
using TremorMod.Content.Items.Vanity;
using TremorMod.Content.Items.Buffs;

namespace TremorMod.Content.Items.Bag
{
    public class StormJellyfishBag : ModItem
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
            itemLoot.Add(ItemDropRule.Common(ModContent.ItemType<StormJellyfishMask>(), 7));
            itemLoot.Add(ItemDropRule.Common(ModContent.ItemType<StormBlade>(), 4));
            itemLoot.Add(ItemDropRule.Common(ModContent.ItemType<Poseidon>(), 3));
            itemLoot.Add(ItemDropRule.Common(ModContent.ItemType<JellyfishStaff>(), 3));
            itemLoot.Add(ItemDropRule.Common(ModContent.ItemType<BoltTome>(), 3));
            itemLoot.Add(ItemDropRule.Common(ModContent.ItemType<StickyFlail>(), 3));
            itemLoot.Add(ItemDropRule.Common(ModContent.ItemType<StormJellyfishTrophy>(), 10));
            itemLoot.Add(ItemDropRule.ByCondition(new Conditions.IsExpert(), ModContent.ItemType<EnchantedHourglass>(), 1));
        }
    }
}