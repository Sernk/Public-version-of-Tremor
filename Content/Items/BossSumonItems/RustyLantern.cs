using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TremorMod.Content.NPCs.Bosses.AncienDragon;
using TremorMod.Content.Biomes.Ruins.Tiles;

namespace TremorMod.Content.Items.BossSumonItems
{
    public class RustyLantern : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 14;
            Item.height = 30;
            Item.maxStack = 20;
            Item.value = 3000;
            Item.rare = 2;
            Item.useTime = 40;
            Item.useAnimation = 40;
            Item.useStyle = ItemUseStyleID.HoldUp;
            Item.consumable = true;
        }

        public override bool CanUseItem(Player player)
        {
            int range = 1; 

            Point playerTilePos = player.Center.ToTileCoordinates();

            for (int i = -range; i <= range; i++)
            {
                for (int j = -range; j <= range; j++)
                {
                    int tileX = playerTilePos.X + i;
                    int tileY = playerTilePos.Y + j;

                    if (!WorldGen.InWorld(tileX, tileY)) continue;

                    Tile tile = Main.tile[tileX, tileY];

                    if (tile != null && tile.HasTile && tile.TileType == ModContent.TileType<RuinAltar>())
                    {
                        return !NPC.AnyNPCs(ModContent.NPCType<Dragon_HeadB>()); 
                    }
                }
            }
            return false; 
        }

        public override bool? UseItem(Player player)
        {
            if (Main.netMode != NetmodeID.MultiplayerClient) 
            {
                Vector2 spawnPosition = player.Center + new Vector2(0, -200);
                int bossType = ModContent.NPCType<Dragon_HeadB>(); 

                int npcIndex = NPC.NewNPC(null, (int)spawnPosition.X, (int)spawnPosition.Y, bossType);

                if (npcIndex >= 0)
                {
                    Main.npc[npcIndex].netUpdate = true; 
                }

                Main.NewText("The Ancient Dragon has awakened!", 150, 64, 219);

            }
            return true;
        }
    }
}