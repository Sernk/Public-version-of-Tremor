using System.Linq;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.GameContent.ItemDropRules;
using Terraria.GameContent.Bestiary;
using Terraria.ModLoader.Utilities;
using System.IO;
using TremorMod.Content.Items.Materials;
using TremorMod.Content.Items.NPCsDrop;
using TremorMod.Content.Items.Crystal;
using TremorMod.Content.Tiles;
using TremorMod.Content.Items.Placeable.Banners;

namespace TremorMod.Content.NPCs
{
	public class CometHead : ModNPC
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Comet Head");
			Main.npcFrameCount[NPC.type] = 3;
		}

		public override void SetDefaults()
		{
			NPC.lifeMax = 600;
			NPC.damage = 130;
			NPC.defense = 65;
			NPC.knockBackResist = 0.5f;
			NPC.width = 20;
			NPC.height = 20;
			AnimationType = 288;
			AIType = 288;
			NPC.aiStyle = 56;
			NPC.npcSlots = 15f;
			NPC.noTileCollide = true;
			NPC.noGravity = true;
			NPC.HitSound = SoundID.NPCHit3;
			NPC.noGravity = true;
			NPC.DeathSound = SoundID.NPCDeath5;
			NPC.value = Item.buyPrice(0, 0, 4, 9);
		}
        public override void ModifyNPCLoot(NPCLoot npcLoot)
        {
			npcLoot.Add(ItemDropRule.ByCondition(new Conditions.NotExpert(), ModContent.ItemType<CometiteOre>(), 1, 2, 3));
            npcLoot.Add(ItemDropRule.ByCondition(new Conditions.NotExpert(), ModContent.ItemType<ChargedCrystal>(), 1, 5, 6));
        }

        public override void HitEffect(NPC.HitInfo hit)
        {
            if (NPC.life <= 0)
            {
                // Используем NPC.lastInteraction для получения индекса игрока
                int playerID = NPC.lastInteraction;

                // Убеждаемся, что playerID находится в допустимом диапазоне
                if (playerID >= 0 && playerID < Main.maxPlayers)
                {
                    Player player = Main.player[playerID]; // Получаем объект игрока
                    float HitDirection = (player.position.X < NPC.position.X) ? -1f : 1f; // Определяем направление удара

                    Dust.NewDust(NPC.position, NPC.width, NPC.height, 59, 2.5f * HitDirection, -2.5f, 0, default(Color), 1.7f);
                    Dust.NewDust(NPC.position, NPC.width, NPC.height, 59, 2.5f * HitDirection, -2.5f, 0, default(Color), 2.7f);
                    Dust.NewDust(NPC.position, NPC.width, NPC.height, 59, 2.5f * HitDirection, -2.5f, 0, default(Color), 0.7f);
                    Dust.NewDust(NPC.position, NPC.width, NPC.height, 59, 2.5f * HitDirection, -2.5f, 0, default(Color), 2.7f);
                    Dust.NewDust(NPC.position, NPC.width, NPC.height, 59, 2.5f * HitDirection, -2.5f, 0, default(Color), 0.7f);

                    for (int k = 0; k < 20; k++)
                    {
                        Dust.NewDust(NPC.position, NPC.width, NPC.height, 59, 2.5f * HitDirection, -2.5f, 0, default(Color), 1.7f);
                        Dust.NewDust(NPC.position, NPC.width, NPC.height, 59, 2.5f * HitDirection, -2.5f, 0, default(Color), 0.6f);
                        Dust.NewDust(NPC.position, NPC.width, NPC.height, 59, 2.5f * HitDirection, -2.5f, 0, default(Color), 1.7f);
                        Dust.NewDust(NPC.position, NPC.width, NPC.height, 59, 2.5f * HitDirection, -2.5f, 0, default(Color), 0.6f);
                    }
                }
            }
        }

        public override float SpawnChance(NPCSpawnInfo spawnInfo)
		{
			int[] cometTiles = { ModContent.TileType<CometiteOreTile>(), ModContent.TileType<HardCometiteOreTile>()};
			return cometTiles.Contains(Main.tile[spawnInfo.SpawnTileX, spawnInfo.SpawnTileY].TileType) ? 15f : 0f;
		}
    }
}