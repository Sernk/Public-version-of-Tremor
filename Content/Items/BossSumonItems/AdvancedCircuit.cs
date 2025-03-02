using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Audio;
using TremorMod.Content.NPCs.Bosses;
using TremorMod.Content.Items.Materials;

namespace TremorMod.Content.Items.BossSumonItems
{
    public class AdvancedCircuit : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 38;
            Item.height = 38;
            Item.maxStack = 20;
            Item.rare = 7;
            Item.value = 30000;
            Item.useAnimation = 45;
            Item.useTime = 45;
            Item.useStyle = ItemUseStyleID.HoldUp;
            Item.consumable = true;
        }

        public override bool CanUseItem(Player player)
        {
            return !NPC.AnyNPCs(ModContent.NPCType<Mothership>()) && NPC.downedPlantBoss && !Main.dayTime;
        }

        public override bool? UseItem(Player player)
        {
            NPC.SpawnOnPlayer(player.whoAmI, ModContent.NPCType<Mothership>());
            SoundEngine.PlaySound(SoundID.Roar, player.position);
            return true;
        }

        public override void AddRecipes()
        {
            Recipe recipe1 = CreateRecipe();
            recipe1.AddIngredient(ModContent.ItemType<GolemCore>(), 1);
            recipe1.AddIngredient(ItemID.HallowedBar, 25);
            recipe1.AddIngredient(ItemID.SoulofSight, 12);
            recipe1.AddIngredient(ItemID.SoulofMight, 12);
            recipe1.AddIngredient(ItemID.SoulofFright, 12);
            recipe1.AddIngredient(ItemID.Wire, 30);
            recipe1.AddTile(TileID.MythrilAnvil);
            recipe1.Register();

            Recipe recipe2 = CreateRecipe();
            recipe2.AddIngredient(ModContent.ItemType<GolemCore>(), 1);
            recipe2.AddIngredient(ItemID.HallowedBar, 25);
            recipe2.AddIngredient(ItemID.SoulofSight, 12);
            recipe2.AddIngredient(ModContent.ItemType<SoulofMind>(), 12);
            recipe2.AddIngredient(ItemID.SoulofFright, 12);
            recipe2.AddIngredient(ItemID.Wire, 30);
            recipe2.AddTile(TileID.MythrilAnvil);
            recipe2.Register();
        }
    }
}