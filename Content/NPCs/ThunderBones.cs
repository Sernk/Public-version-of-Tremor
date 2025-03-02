using System;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using TremorMod.Utilities;
using Terraria.DataStructures;
using Microsoft.Xna.Framework;
using Terraria.GameContent.ItemDropRules;
using TremorMod.Content.Items.Weapons.Throwing;
using TremorMod.Content.Items.Materials.OreAndBar;
using TremorMod.Content.Projectiles;
using TremorMod.Content.Items.Materials;
using TremorMod.Content.Items.Weapons.Magic;
using TremorMod.Content.Items.Placeable.Banners;
using TremorMod.Content.Items.Vanity;

namespace TremorMod.Content.NPCs
{
	public class ThunderBones : ModNPC
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Thunder Bones");
			Main.npcFrameCount[NPC.type] = 20;
		}

		public override void SetDefaults()
		{
			AIType = 77;
			NPC.lifeMax = 500;
			NPC.damage = 30;
			NPC.defense = 10;
			NPC.knockBackResist = 0.3f;
			NPC.width = 36;
			NPC.height = 44;
			AnimationType = 482;
			NPC.aiStyle = 3;
			NPC.npcSlots = 0.6f;
			NPC.HitSound = SoundID.NPCHit2;
			NPC.DeathSound = SoundID.NPCDeath6;
			NPC.value = Item.buyPrice(0, 0, 6, 9);
			// banner = npc.type;
			// Todo: bannerItem = mod.ItemType("ThunderBonesBanner");
		}

		public override void AI()
		{
			if (Main.rand.NextBool(9))
				Main.dust[Dust.NewDust(NPC.position, NPC.width, NPC.height, 180, 0f, 0f, 200, NPC.color)].velocity *= 0.3f;
		}

        public override void ModifyNPCLoot(NPCLoot npcLoot)
        {
            npcLoot.Add(ItemDropRule.ByCondition(new Conditions.NotExpert(), ModContent.ItemType<Bonecrusher>(), 20));
            npcLoot.Add(ItemDropRule.ByCondition(new Conditions.NotExpert(), ModContent.ItemType<TearsofDeath>(), 1, 1, 6));
        }


        public override void HitEffect(NPC.HitInfo hit)
		{
            int hitDirection = hit.HitDirection;

            if (NPC.life <= 0)
			{
                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("TBGore1").Type, 1f);
                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("TBGore2").Type, 1f);
                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("TBGore3").Type, 1f);
                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("TBGore4").Type, 1f);
                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("TBGore4").Type, 1f);
                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("TBGore5").Type, 1f);
                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("TBGore5").Type, 1f);

				if (Main.netMode == 1) return;

				NPC.NewNPC(NPC.GetSource_Death(), (int)NPC.position.X + 32, (int)NPC.position.Y - 48, ModContent.NPCType<BoneFish>());
				NPC.NewNPC(NPC.GetSource_Death(), (int)NPC.position.X + 16, (int)NPC.position.Y - 48, ModContent.NPCType<BoneFish>());
				NPC.NewNPC(NPC.GetSource_Death(), (int)NPC.position.X - 32, (int)NPC.position.Y - 48, ModContent.NPCType<BoneFish>());
				NPC.NewNPC(NPC.GetSource_Death(), (int)NPC.position.X - 16, (int)NPC.position.Y - 48, ModContent.NPCType<BoneFish>());
			}
		}

		public override float SpawnChance(NPCSpawnInfo spawnInfo)
			=> Helper.NoZoneAllowWater(spawnInfo) && NPC.downedBoss3 && Main.bloodMoon && spawnInfo.SpawnTileY < Main.worldSurface ? 0.01f : 0f;
	}
}