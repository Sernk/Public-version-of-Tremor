using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using TremorMod.Content.NPCs.Bosses.EvilCorn;

namespace TremorMod.Content.Items.BossSumonItems
{
	public class CursedPopcorn : ModItem
	{
		public override void SetDefaults()
		{
			Item.width = 26;
			Item.height = 34;
			Item.maxStack = 20;
			Item.rare = 2;
			Item.value = 50000;
			Item.useAnimation = 45;
			Item.useTime = 45;
			Item.useStyle = 4;
			Item.consumable = true;
		}

		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("Cursed Popcorn");
			//Tooltip.SetDefault("Summons the Evil Corn\n" +
			//"Requires night time");
		}

		public override bool CanUseItem(Player player)
		{
            return !NPC.AnyNPCs(ModContent.NPCType<EvilCorn>()) && !Main.dayTime;
        }

		public override bool? UseItem(Player player)/* tModPorter Suggestion: Return null instead of false */
		{
			NPC.SpawnOnPlayer(player.whoAmI, ModContent.NPCType<EvilCorn>());
            SoundEngine.PlaySound(SoundID.Roar, player.position);
            return true;
		}
    }
}