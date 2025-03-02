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
    public class TrinityBag3 : ModItem
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
            itemLoot.Add(ItemDropRule.Common(ModContent.ItemType<HopeMask>(), 7));

            itemLoot.Add(ItemDropRule.Common(ModContent.ItemType<Banhammer>(), 3));

            itemLoot.Add(ItemDropRule.Common(ModContent.ItemType<BestNightmare>(), 3));

            itemLoot.Add(ItemDropRule.Common(ModContent.ItemType<HonestBlade>(), 3));

            itemLoot.Add(ItemDropRule.Common(ModContent.ItemType<Volcannon>(), 3));

            itemLoot.Add(ItemDropRule.Common(ModContent.ItemType<TrebleClef>(), 3));

            itemLoot.Add(ItemDropRule.Common(ModContent.ItemType<Revolwar>(), 3));

            itemLoot.Add(ItemDropRule.Common(ModContent.ItemType<UnpredictableСompass>(), 3));

            itemLoot.Add(ItemDropRule.Common(ModContent.ItemType<OmnikronBar>(), 1, 20, 36));

            itemLoot.Add(ItemDropRule.Common(ModContent.ItemType<TrueEssense>(), 1, 10, 25));
        }
    }
}