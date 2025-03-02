using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Audio;
using System.Collections.Generic;
using Terraria.DataStructures;
using TremorMod.Content.NPCs.Bosses.CogLord;
using TremorMod.Content.Items.Materials;
using TremorMod.Content.NPCs.Bosses.AndasBoss;

namespace TremorMod.Content.Items.BossSumonItems
{
    public class ArtifactEngine : ModItem
    {
        const int XOffset = -400;
        const int YOffset = -400;

        public override void SetDefaults()
        {
            Item.width = 40;
            Item.height = 28;
            Item.maxStack = 20;
            Item.value = 100;
            Item.rare = 5;
            Item.useAnimation = 15;
            Item.useTime = 15;
            Item.useStyle = 4;
            Item.consumable = true;
        }

        /*public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Artifact Engine");
            Tooltip.SetDefault("Summons Cog Lord\n" +
            "Requires any mech. boss to have been slain, hardmode and night time");
        }*/

        public override bool CanUseItem(Player player)
        {
            return !Main.dayTime && Main.hardMode && NPC.downedMechBossAny && !NPC.AnyNPCs(ModContent.NPCType<CogLord> ());
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(575, 30);
            recipe.AddIngredient(ItemID.HallowedBar, 6);
            recipe.AddIngredient(ItemID.Cog, 25);
            recipe.AddIngredient(ItemID.Wire, 20);
            recipe.AddIngredient(ModContent.ItemType<GolemCore>(), 1);
            //recipe.SetResult(this);
            recipe.AddTile(134);
            recipe.Register();
        }

        public override bool? UseItem(Player player)
        {
            Main.NewText("Cog Lord has awoken!", 175, 75, 255);

            // Replace Main.PlaySound with SoundEngine.PlaySound
            SoundEngine.PlaySound(SoundID.Item15, player.position); // Play a sound at the player's position

            if (Main.netMode != NetmodeID.Server)
            {
                // Use EntitySource_ItemUse to create the NPC spawn source
                IEntitySource source = player.GetSource_ItemUse(Item);
                // Use ModContent to correctly reference the NPC type
                NPC.NewNPC(source, (int)player.Center.X + XOffset, (int)player.Center.Y + YOffset, ModContent.NPCType<CogLord>());
            }

            return true; // Return true to indicate the item was successfully used
        }
    }
}
