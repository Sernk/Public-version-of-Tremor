using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TremorMod.Utilities;
using Terraria.DataStructures;
using Microsoft.Xna.Framework;
using Terraria.GameContent.ItemDropRules;
using TremorMod.Content.Items.Materials;
using TremorMod.Content.Items.Placeable.Banners;
using TremorMod.Content.Items.Vanity;

namespace TremorMod.Content.NPCs.ZombieEvent
{

	public class Bonecing : ModNPC
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Bonecing");
			Main.npcFrameCount[NPC.type] = 3;
		}

		public override void SetDefaults()
		{
			NPC.lifeMax = 160;
			NPC.damage = 80;
			NPC.defense = 20;
			NPC.knockBackResist = 0.5f;
			NPC.width = 58;
			NPC.height = 44;
			AnimationType = 177;
			AIType = 177;
			NPC.aiStyle = 41;
			NPC.npcSlots = 0.2f;
			NPC.HitSound = SoundID.NPCHit2;
			NPC.DeathSound = SoundID.NPCDeath2;
			NPC.value = Item.buyPrice(0, 0, 9, 9);
			// banner = npc.type;
			// Todo: bannerItem = mod.ItemType("BigCorpseBanner");
		}

        public override void ModifyNPCLoot(NPCLoot npcLoot)
        {
            if (NPC.AnyNPCs(ModContent.NPCType<Cryptomage>()))
            {
                NPC.Transform(ModContent.NPCType<SuperBonecing>());
            }
        }
    }
}