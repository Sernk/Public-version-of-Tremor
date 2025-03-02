using Terraria;
using Terraria.ModLoader;
using Terraria.GameContent.ItemDropRules;
using TremorMod.Content.Items.Materials.OreAndBar;
using TremorMod.Content.Items.Materials;

namespace TremorMod.Content.Items.Bag
{
    public class SuspiciousBag : ModItem
    {
        public override void SetDefaults()
        {
            Item.maxStack = 999;
            Item.consumable = true;
            Item.width = 24;
            Item.height = 24;
            Item.rare = 11;
        }

        public override bool CanRightClick()
        {
            return true;
        }

        public override void ModifyItemLoot(ItemLoot itemLoot)
        {
            itemLoot.Add(ItemDropRule.Common(ModContent.ItemType<Doomstone>(), 3, 2, 5));
            itemLoot.Add(ItemDropRule.Common(ModContent.ItemType<ConcentratedEther>(), 3, 3, 10));
            itemLoot.Add(ItemDropRule.Common(ModContent.ItemType<CandyBar>(), 3, 2, 6));
            itemLoot.Add(ItemDropRule.Common(ModContent.ItemType<VoidBar>(), 3, 2, 7));
            itemLoot.Add(ItemDropRule.Common(ModContent.ItemType<NightmareBar>(), 3, 2, 6));
            itemLoot.Add(ItemDropRule.Common(ModContent.ItemType<Phantaplasm>(), 5, 3, 6));
            itemLoot.Add(ItemDropRule.Common(ModContent.ItemType<CarbonSteel>(), 3, 1, 3));
            itemLoot.Add(ItemDropRule.Common(ModContent.ItemType<ClusterShard>(), 3, 3, 36));
            itemLoot.Add(ItemDropRule.Common(ModContent.ItemType<DeadTissue>(), 8));
            itemLoot.Add(ItemDropRule.Common(ModContent.ItemType<ToothofAbraxas>(), 4, 2, 4));
            //itemLoot.Add(ItemDropRule.Common(ModContent.ItemType<Burner>(), 30)); The Burner is an unimplemented and incomplete item. All that exists of it is an image. No stats, behaviors or associated projectiles exist for this item, making it impossible to know what it would have done had it been finished. 
            //https://tremormod.fandom.com/wiki/Burner
        }
    }
}