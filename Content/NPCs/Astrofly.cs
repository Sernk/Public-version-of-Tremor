using System.Linq;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using TremorMod.Content.Items.Materials;
using Terraria.GameContent.ItemDropRules;
using TremorMod.Content.Items.NPCsDrop;
using TremorMod.Content.Items.Crystal;
using TremorMod.Content.Tiles;

namespace TremorMod.Content.NPCs
{

	public class Astrofly : ModNPC
	{
		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("Astrofly");
			Main.npcFrameCount[NPC.type] = 7;
		}

		public override void SetDefaults()
		{
			NPC.lifeMax = 5000;
			NPC.damage = 160;
			NPC.defense = 115;
			NPC.knockBackResist = 0.2f;
			NPC.width = 56;
			NPC.height = 12;
			AnimationType = 156;
			NPC.aiStyle = 22;
			NPC.npcSlots = 15f;
			NPC.noTileCollide = true;
			NPC.noGravity = true;
			NPC.HitSound = SoundID.NPCHit3;
			NPC.noGravity = true;
			NPC.DeathSound = SoundID.NPCDeath5;
			NPC.value = Item.buyPrice(0, 2, 4, 9);
			// banner = npc.type;
			// Todo: bannerItem = mod.ItemType("AstroflyBanner");
		}

        public override void ModifyNPCLoot(NPCLoot npcLoot)
        {
            npcLoot.Add(ItemDropRule.ByCondition(new Conditions.NotExpert(), ModContent.ItemType<CometiteOre>(), 1, 2, 5));
            npcLoot.Add(ItemDropRule.ByCondition(new Conditions.NotExpert(), ModContent.ItemType<ChargedCrystal>(), 1, 1, 3));
        }

        public override void HitEffect(NPC.HitInfo hit)
        {
            if (NPC.life <= 0) // Если NPC умирает
            {
                for (int k = 0; k < 20; k++)
                {
                    Dust.NewDust(NPC.position, NPC.width, NPC.height, 59, 2.5f * hit.HitDirection, -2.5f, 0, default(Color), 0.7f);
                    Dust.NewDust(NPC.position, NPC.width, NPC.height, 27, 2.5f * hit.HitDirection, -2.5f, 0, default(Color), 0.7f);
                }

                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("AstroflyGore1").Type, 1f);
                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("AstroflyGore1").Type, 1f);
                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("AstroflyGore2").Type, 1f);
                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("AstroflyGore2").Type, 1f);
                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("AstroflyGore3").Type, 1f);
            }
            else // Если NPC не умирает
            {
                int dustAmount = (int)(hit.Damage / (float)NPC.lifeMax * 50.0f); // Количество пыли в зависимости от урона
                for (int k = 0; k < dustAmount; k++)
                {
                    Dust.NewDust(NPC.position, NPC.width, NPC.height, 59, hit.HitDirection, -1f, 0, default(Color), 0.7f);
                }
            }
        }

        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            // Проверка, находится ли координата в пределах карты
            if (spawnInfo.SpawnTileX < 0 || spawnInfo.SpawnTileX >= Main.maxTilesX ||
                spawnInfo.SpawnTileY < 0 || spawnInfo.SpawnTileY >= Main.maxTilesY)
            {
                return 0f;
            }

            // Список допустимых тайлов
            int[] cometTiles = { ModContent.TileType<CometiteOreTile>(), ModContent.TileType<HardCometiteOreTile>() };

            // Проверяем наличие тайла и дополнительные условия
            if (cometTiles.Contains(Main.tile[spawnInfo.SpawnTileX, spawnInfo.SpawnTileY].TileType) &&
                NPC.downedMoonlord && spawnInfo.SpawnTileY < Main.rockLayer)
            {
                return 15f;
            }

            return 0f;
        }
    }
}