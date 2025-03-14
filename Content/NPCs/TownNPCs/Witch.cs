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
using TremorMod.Content.Items.Armor.Vicious;
using TremorMod.Content.Items.Armor.Vile;
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
	public class Witch : ModNPC
	{
		public override string Texture => $"{typeof(Witch).NamespaceToPath()}/Witch";

		public override bool IsLoadingEnabled(Mod mod) => true;

		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Witch");
			Main.npcFrameCount[NPC.type] = 26;
			NPCID.Sets.ExtraFramesCount[NPC.type] = 5;
			NPCID.Sets.AttackFrameCount[NPC.type] = 5;
			NPCID.Sets.DangerDetectRange[NPC.type] = 1000;
			NPCID.Sets.AttackType[NPC.type] = 0;
			NPCID.Sets.AttackTime[NPC.type] = 30;
			NPCID.Sets.AttackAverageChance[NPC.type] = 30;
		}

		public override void SetDefaults()
		{
			NPC.townNPC = true;
			NPC.friendly = true;
			NPC.width = 32;
			NPC.height = 54;
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
			=> Main.player.Any(player => !player.dead && player.inventory.Any(item => item != null && item.type == ItemID.GoodieBag));

		private readonly WeightedRandom<string> _names = new[]
		{
			"Circe",
			"Kikimora:2",
			"Morgana",
			"Hecate"
		}.ToWeightedCollectionWithWeight();

		public override List<string> SetNPCNameList() => new List<string> { _names.Get() };

		private readonly WeightedRandom<string> _chats = new[]
		{
			"<cackle> Welcome dearies! I hope you don't mind the body parts. I was just cleaning up.",
			"Eye of a newt! Tongue of a cat! Blood of a dryad... a little more blood.",
			"Don't pull my nose! It's not a mask!",
			"The moon has a secret dearies! One that you'll know soon enough!",
			"This is halloween! Or is it?",
			"Blood for the blood moon! Skulls for the skull cap... Or was it something else?"
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
				shopName = "Witch";
		}

		public override void AddShops()
		{
			NPCShop shop = new(Type, "Witch");
			shop.Add(ModContent.ItemType<PlagueMask>());
			shop.Add(ModContent.ItemType<PlagueRobe>());
			shop.Add(ModContent.ItemType<SacrificalScythe>());
			shop.Add(ModContent.ItemType<Scarecrow>());

			if (NPC.downedBoss1)
			{
				shop.Add(ModContent.ItemType<BoomSpear>());
			}

			if (NPC.downedBoss2)
			{
				shop.Add(ModContent.ItemType<BlackRose>());
			}

			if (NPC.downedBoss3)
			{
				shop.Add(ModContent.ItemType<Pumpspell>());
			}
			shop.Register();
		}

		public override void TownNPCAttackStrength(ref int damage, ref float knockback)
		{
			damage = 25;
			knockback = 4f;
		}

		public override void TownNPCAttackCooldown(ref int cooldown, ref int randExtraCooldown)
		{
			cooldown = 10;
			randExtraCooldown = 10;
		}

		public override void TownNPCAttackProj(ref int projType, ref int attackDelay)
		{
			projType = ModContent.ProjectileType<PumpkinPro>();
			attackDelay = 2;
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
				Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("WitchGore1").Type, 1f);
			}
		}
	}
}