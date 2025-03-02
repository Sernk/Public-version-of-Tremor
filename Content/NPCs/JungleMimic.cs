using TremorMod.Content.Items.Placeable.Banners;
using Terraria;
using Terraria.GameContent.Bestiary;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.Utilities;
using System.IO;
using Microsoft.Xna.Framework;
using TremorMod.Content.Items.NPCsDrop;
using TremorMod.Utilities;

namespace TremorMod.Content.NPCs
{
	public class JungleMimic : ModNPC
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Jungle Mimic");
			Main.npcFrameCount[NPC.type] = 14;
		}

		public override void SetDefaults()
		{
			NPC.lifeMax = 3500;
			NPC.damage = 90;
			NPC.defense = 34;
			NPC.knockBackResist = 0f;
			NPC.width = 48;
			NPC.height = 40;
			NPC.aiStyle = 87;
			NPC.npcSlots = 0.5f;
			NPC.HitSound = SoundID.NPCHit4;
			NPC.DeathSound = SoundID.NPCDeath6;
			NPC.value = Item.buyPrice(0, 3, 0, 0);
			AnimationType = NPCID.BigMimicHallow;
        }

        public override void OnKill()
        {
            // Выпадение Greater Healing и Mana Potions с шансом 50%
            if (Main.rand.NextBool()) // 50% шанс
            {
                Item.NewItem(NPC.GetSource_Loot(), NPC.position, ItemID.GreaterHealingPotion, Main.rand.Next(1, 10));
                Item.NewItem(NPC.GetSource_Loot(), NPC.position, ItemID.GreaterManaPotion, Main.rand.Next(1, 10));
            }

            // Проверка с шансом 25% на каждый предмет
            if (Main.rand.NextFloat() < 0.25f)
            {
                Item.NewItem(NPC.GetSource_Death(), NPC.getRect(), ModContent.ItemType<SporeBlade>());
            }
            if (Main.rand.NextFloat() < 0.25f)
            {
                Item.NewItem(NPC.GetSource_Death(), NPC.getRect(), ModContent.ItemType<TechnologyofDionysus>());
            }
            if (Main.rand.NextFloat() < 0.25f)
            {
                Item.NewItem(NPC.GetSource_Death(), NPC.getRect(), ModContent.ItemType<LivingWoodThreepeater>());
            }
            if (Main.rand.NextFloat() < 0.25f)
            {
                Item.NewItem(NPC.GetSource_Death(), NPC.getRect(), ModContent.ItemType<UnfathomableFlower>());
            }
        }


        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            // Возвращаем результат тернарного оператора
            return Main.hardMode && spawnInfo.Player.ZoneJungle && spawnInfo.SpawnTileY > Main.rockLayer ? 0.2f : 0f;
        }
    }
}