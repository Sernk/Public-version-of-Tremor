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
using TremorMod.Content.Items.BossLoot.TheDarkEmperor;
using TremorMod.Content.Items.Armor.Sniper;
using TremorMod.Content.Items.Armor.Chain;
using Terraria.GameContent.ItemDropRules;
using TremorMod.Content.Items.Armor.Golden;
using TremorMod.Content.Items.Armor.Leather;
using TremorMod.Content.Items.Buffs;
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
	public class Startrooper : ModNPC
	{
		public override string Texture => $"{typeof(Startrooper).NamespaceToPath()}/Startrooper";

        public override bool IsLoadingEnabled(Mod mod) => true;

        public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Startrooper");
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
			NPC.width = 30;
			NPC.height = 44;
			NPC.aiStyle = 7;
			NPC.damage = 10;
			NPC.defense = 15;
			NPC.lifeMax = 250;
			NPC.HitSound = SoundID.NPCHit1;
			NPC.DeathSound = SoundID.NPCDeath1;
			NPC.knockBackResist = 0.5f;
			AnimationType = NPCID.GoblinTinkerer;
		}

		public override bool CanTownNPCSpawn(int numTownNPCs)/* tModPorter Suggestion: Copy the implementation of NPC.SpawnAllowed_Merchant in vanilla if you to count money, and be sure to set a flag when unlocked, so you don't count every tick. */
			=> !TremorSpawnEnemys.downedSpaceWhale && Main.player.Any(player => !player.dead);

		private readonly WeightedRandom<string> _names = new[]
		{
			"Ripley:2",
			"Dallas",
			"Brett",
			"Kane:2",
			"Ash",
			"Parker",
			"Lambert"
		}.ToWeightedCollectionWithWeight();

        public override List<string> SetNPCNameList() => new List<string> { _names.Get() };

        private readonly WeightedRandom<string> _chats = new[]
		{
			"There is an explanation for anything, you know.",
			"If you get into a trouble remember that somebody will surely save your skin.",
			"My friend always liked to tell me the odds but now he is dead. You should know: Never tell me the odds.",
			"That giant flying fish that you've defeated was making plans to destroy my home-planet. Glad you've killed him.",
			"I suggest you carrying at least small blaster - nobody knows what's on mind of this creatures in this world.",
			"Have you ever heard a tale of a giant three eyed creature with eyes in it hands and tentacles on head? I'm very glad that it is just a stupid story.",
			"There were some cult of men calling themselve knights and fighting with some kind of light swords on a planet I was travelling once to. As for me, a gun is better than a useless sword."
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
                shopName = "Startrooper";
        }

        public override void AddShops()
        {
            NPCShop shop = new(Type, "Startrooper");
                shop.Add(ModContent.ItemType<Starmine>())
                .Add(ModContent.ItemType<ChainBow>())
                .Add(ModContent.ItemType<EnforcerShield>());

			if (!Main.dayTime)
			{
				shop.Add(ModContent.ItemType<SniperHelmet>());
				shop.Add(ModContent.ItemType<SniperBreastplate>());
				shop.Add(ModContent.ItemType<SniperBoots>());
			}
			else
			{
				shop.Add(ModContent.ItemType<ParatrooperLens>());
				shop.Add(ModContent.ItemType<StartrooperFlameburstPistol>());
			}
			if (!TremorSpawnEnemys.downedTrinity)
			{
				if (!Main.dayTime)
				{
					shop.Add(ModContent.ItemType<CosmicAssaultRifle>());
				}
				shop.Add(ModContent.ItemType<WartimeRocketLauncher>());
			}
			if (Main.bloodMoon)
			{
				shop.Add(ModContent.ItemType<ParatrooperShotgun>());
			}
			if (Main.LocalPlayer.HasItem(ModContent.ItemType<SuperBigCannon>()))
			{
				shop.Add(ModContent.ItemType<SBCCannonballAmmo>());
			}
			shop.Register();
        }

        public override void TownNPCAttackStrength(ref int damage, ref float knockback)
		{
			damage = 310;
			knockback = 4f;
		}

		public override void TownNPCAttackCooldown(ref int cooldown, ref int randExtraCooldown)
		{
			cooldown = 15;
			randExtraCooldown = 15;
		}

		public override void TownNPCAttackProj(ref int projType, ref int attackDelay)
		{
			projType = ModContent.ProjectileType<StarminePro>();
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

				for (int i = 0; i < 3; i++)
                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("StartrooperNGore").Type, 1f);
            }
		}
	}
}