using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.Linq;
using Terraria;
using Microsoft.Xna.Framework;
using Terraria.GameContent.Bestiary;
using Terraria.GameContent.Events;
using Terraria.GameContent.Personalities;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.Utilities;
using Terraria.GameContent;
using Terraria.GameContent.ItemDropRules;
using TremorMod.Content.Items.Armor.Leather;
using TremorMod.Content.Buffs;
using TremorMod.Content.Items.Armor.Zerokk;
using TremorMod.Content.Items.Armor.Hummer;
using TremorMod.Content.Items.Weapons.Alchemical;
using TremorMod.Content.Items.Accessories;
using TremorMod.Content.Items.BossSumonItems;
using TremorMod.Content.Items.CogLordItems;
using TremorMod.Content.Items;
using TremorMod.Content.Items.CraftingStations;
using TremorMod.Content.Items.Crystal;
using TremorMod.Content.Items.CyberKing;
using TremorMod.Content.Items.EvilCornItems;
using TremorMod.Content.Items.Fish;
using TremorMod.Content.Items.Fungus;
using TremorMod.Content.Items.HeaterOfWorldsItems;
using TremorMod.Content.Items.Key;
using TremorMod.Content.Items.Materials;
using TremorMod.Content.Items.NPCsDrop;
using TremorMod.Content.Items.Placeable;
using TremorMod.Content.Items.SpaceWhaleItems;
using TremorMod.Content.Items.Tools;
using TremorMod.Content.Items.Vanity;
using TremorMod.Content.Items.Weapons;
using TremorMod.Content.Items.Weapons.Magic;
using TremorMod.Content.Items.Weapons.Melee;
using TremorMod.Content.Items.Weapons.Ranged;
using TremorMod.Content.Items.Weapons.Summon;
using TremorMod.Content.Items.Weapons.Throwing;
using TremorMod.Content.Items.Wood;
using TremorMod.Content.Projectiles;
using TremorMod.Utilities;
using TremorMod;

namespace TremorMod.Content.NPCs.TownNPCs
{
	[AutoloadHead]
	public class ForgeMaster : ModNPC
	{
		public override string Texture => $"{typeof(ForgeMaster).NamespaceToPath()}/ForgeMaster";

        public override bool IsLoadingEnabled(Mod mod) => true;

        public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Forge Master");
			Main.npcFrameCount[NPC.type] = 25;
			NPCID.Sets.ExtraFramesCount[NPC.type] = 5;
			NPCID.Sets.AttackFrameCount[NPC.type] = 4;
			NPCID.Sets.DangerDetectRange[NPC.type] = 1000;
			NPCID.Sets.AttackType[NPC.type] = 0;
			NPCID.Sets.AttackTime[NPC.type] = 30;
			NPCID.Sets.AttackAverageChance[NPC.type] = 30;
		}

		public override void SetDefaults()
		{
			NPC.townNPC = true;
			NPC.friendly = true;
			NPC.width = 28;
			NPC.height = 48;
			NPC.aiStyle = 7;
			NPC.damage = 10;
			NPC.defense = 15;
			NPC.lifeMax = 250;
			NPC.HitSound = SoundID.NPCHit1;
			NPC.DeathSound = SoundID.NPCDeath1;
			NPC.knockBackResist = 0.5f;
			AnimationType = NPCID.Guide;
		}
		
		public override bool CanTownNPCSpawn(int numTownNPCs)/* tModPorter Suggestion: Copy the implementation of NPC.SpawnAllowed_Merchant in vanilla if you to count money, and be sure to set a flag when unlocked, so you don't count every tick. */
		   => Main.player.Any(player => !player.dead && player.inventory.Any(item => item != null && item.type == ModContent.ItemType<JungleAlloy>()));

		private readonly WeightedRandom<string> _names = new[]
		{
			"Gefest:2",
			"Aule",
			"Agarorn:2",
			"Treak",
			"Haymer",
			"Golan"
		}.ToWeightedCollectionWithWeight();

        public override List<string> SetNPCNameList() => new List<string> { _names.Get() };

        private readonly WeightedRandom<string> _chats = new[]
		{
			"You can't lift my hammer? Not surprising! That's because you are not worthy!",
			"Strangely but nobody uses hammers for making bars. How do you just put ore into furnaces and get bars!? That is insane!",
			"Valar Morghulis! Oh wait, that's not the Braavos! Forget what I've said.",
			"What? You ask me who am I?! I am the son of the Vulcan and the Vulcan is the mighty anvilborn!",
			"My bars are better because I make them with my hammer. If you won't buy my bars I will make a bar from you.",
			"You wonder why people call me Forge Master!? What means you don't believe I'm the real Master of Forges!?",
			"Be careful when working with forges. I got burnt once when I was taking off a bar from it. That's why I'm wearing such armor!"
		}.ToWeightedCollection();

		public override string GetChat()
			=> _chats.Get();

		public override void SetChatButtons(ref string button, ref string button2)
		{
			button = Lang.inter[28].Value;
		}

        public override void OnChatButtonClicked(bool firstButton, ref string shopName)
        {
            if (firstButton)
                shopName = "ForgeMaster";
        }

        public override void AddShops()
        {
            NPCShop shop = new(Type, "ForgeMaster");
			shop.Add(ModContent.ItemType<GreatAnvil>());

            if (Main.dayTime)
			{
				shop.Add(ItemID.CopperBar)
				.Add(ItemID.IronBar)
				.Add(ItemID.SilverBar);

				if (NPC.downedBoss2)
				{
					shop.Add(ItemID.GoldBar);
				}

				if (NPC.downedBoss3)
				{
					shop.Add(ItemID.DemoniteBar);
				}

				if (NPC.downedMechBossAny)
				{
					shop.Add(ItemID.CobaltBar)
					.Add(ItemID.MythrilBar)
					.Add(ItemID.AdamantiteBar);
				}
			}
			else
			{

				shop.Add(ItemID.TinBar)
				.Add(ItemID.LeadBar)
				.Add(ItemID.TungstenBar);

				if (NPC.downedBoss2)
				{
					shop.Add(ItemID.PlatinumBar);
				}

				if (NPC.downedBoss3)
				{
					shop.Add(ItemID.CrimtaneBar);
				}

				if (NPC.downedMechBossAny)
				{
					shop.Add(ItemID.PalladiumBar)
					.Add(ItemID.OrichalcumBar)
					.Add(ItemID.TitaniumBar);
				}
			}
            if (NPC.downedBoss2)
			{
				shop.Add(ModContent.ItemType<PoisonRod>());
            }
            if (NPC.downedBoss3)
			{
				shop.Add(ModContent.ItemType<BurningHammer>())
				.Add(ModContent.ItemType<PerfectBehemoth>());
            }
			if (NPC.downedPlantBoss) 
			{
				shop.Add(ItemID.HallowedBar);
            }
			if (NPC.downedGolemBoss) 
			{
				shop.Add(ItemID.ChlorophyteBar);
            }
			if (NPC.downedAncientCultist)
			{
				shop.Add(ItemID.SpectreBar);
            }
            if (Main.hardMode)
			{
				shop.Add(ModContent.ItemType<GoldenMace>())
			   .Add(ItemID.HellstoneBar);

            }
            shop.Register();
        }

		public override void TownNPCAttackStrength(ref int damage, ref float knockback)
		{
			damage = 22;
			knockback = 3f;
		}

		public override void TownNPCAttackCooldown(ref int cooldown, ref int randExtraCooldown)
		{
			cooldown = 10;
			randExtraCooldown = 10;
		}

		public override void TownNPCAttackProj(ref int projType, ref int attackDelay)
		{
			projType = ModContent.ProjectileType<BurningHammerPro>();
			attackDelay = 4;
		}

		public override void TownNPCAttackProjSpeed(ref float multiplier, ref float gravityCorrection, ref float randomOffset)
		{
			multiplier = 12f;
			randomOffset = 2f;
		}

		public override void HitEffect(NPC.HitInfo hit)
		{
            int hitDirection = hit.HitDirection;

            if (NPC.life <= 0)
			{
				for (int k = 0; k < 20; k++)
					Dust.NewDust(NPC.position, NPC.width, NPC.height, 151, 2.5f * hitDirection, -2.5f, 0, default(Color), 0.7f);

				for (int i = 0; i < 4; ++i)
                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("FarmerGore1").Type, 1f);
            }
		}
	}
}