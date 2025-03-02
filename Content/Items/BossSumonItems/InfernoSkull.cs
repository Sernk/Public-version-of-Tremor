using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Audio;
using Terraria.ModLoader;
using Terraria.DataStructures;
using TremorMod.Content.Tiles;
using TremorMod.Content.NPCs.Bosses.AndasBoss;
using TremorMod.Content.Items.Materials;	

namespace TremorMod.Content.Items.BossSumonItems
{
	public class InfernoSkull : ModItem
	{
		public override void SetDefaults()
		{
			Item.width = 26;
			Item.height = 28;
			Item.maxStack = 20;
			Item.value = 100;
			Item.rare = 0;
			Item.useAnimation = 15;
			Item.useTime = 15;
			Item.useStyle = 4;
			Item.consumable = true;
		}

		/*public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Inferno Skull");
			Tooltip.SetDefault("Summons the Andas\n" +
			"Requires the hell biome and The Trinity to have been downed");
		}*/

		public override bool CanUseItem(Player player)
		{
			//return player.position.Y / 16f > Main.maxTilesY - 200 && TremorWorld.Boss.Trinity.IsDowned() && !NPC.AnyNPCs(ModContent.NPCType<Andas>());
            return player.position.Y / 16f > Main.maxTilesY - 200 && NPC.downedBoss2 && !NPC.AnyNPCs(ModContent.NPCType<Andas>());
        }

		public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            foreach (var tooltip in tooltips)
            {
                // Меняем цвет текста для названия предмета
                if (tooltip.Mod == "Terraria" && tooltip.Name == "ItemName")
                {
                    tooltip.OverrideColor = new Color(238, 194, 73); // Цвет золота
                }
            }
        }

        public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<AngeliteBar>(), 10);
			recipe.AddIngredient(ModContent.ItemType<CollapsiumBar>(), 10);
			recipe.AddIngredient(ModContent.ItemType<FireFragment>(), 12);
			recipe.AddIngredient(ItemID.HellstoneBar, 6);
			recipe.AddIngredient(ItemID.Bone, 25);
			recipe.AddIngredient(ItemID.SoulofNight, 8);
			//recipe.SetResult(this);
			recipe.AddTile(ModContent.TileType<StarvilTile>());
			recipe.Register();
		}

        public override bool? UseItem(Player player)
        {
			NPC.SpawnOnPlayer(player.whoAmI, ModContent.NPCType<Andas>());
            SoundEngine.PlaySound(SoundID.Roar, player.position);
            return true;
		}
	}
}
