using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TremorMod.Content.Items.BossLoot.TheDarkEmperor;
using TremorMod.Content.Items.Armor.Nova;
using TremorMod.Content.Items.Materials;
using TremorMod.Utilities;
using TremorMod;

namespace TremorMod.Content.Items.Armor.WhiteMaster
{
	[AutoloadEquip(EquipType.Body)]
	public class WhiteMasterChestplate : ModItem
	{
		public override void SetDefaults()
		{
			Item.width = 34;
			Item.height = 20;
			Item.value = 50000;
			Item.rare = 11;
			Item.defense = 33;
		}

		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("White Master Chestplate");
			/* Tooltip.SetDefault("Massively increases alchemical damage as health lowers\n" +
			"30% increased alchemical damage\n" +
			"Enemy attacks have 10% chance to do no damage to you\n" +
			"Immune to cursed inferno, lava, and can move through liquids"); */
		}

		public override void UpdateEquip(Player player)
		{
            TremorPlayer modPlayer = player.GetModPlayer<TremorPlayer>();
            modPlayer.zellariumBody = true;
            player.lavaImmune = true;
			player.ignoreWater = true;
			player.GetModPlayer<MPlayer>().alchemicalDamage += 0.3f;
			player.buffImmune[BuffID.CursedInferno] = true;
			if (player.statLife <= player.statLifeMax2)
			{
				player.GetModPlayer<MPlayer>().alchemicalDamage += 0.3f;
			}
			if (player.statLife <= 400)
			{
				player.GetModPlayer<MPlayer>().alchemicalDamage += 0.4f;
			}
			if (player.statLife <= 300)
			{
				player.GetModPlayer<MPlayer>().alchemicalDamage += 0.5f;
			}
			if (player.statLife <= 200)
			{
				player.GetModPlayer<MPlayer>().alchemicalDamage += 0.6f;
			}
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<BrokenHeroArmorplate>(), 1);
			recipe.AddIngredient(ModContent.ItemType<NovaBreastplate>(), 1);
			recipe.AddIngredient(ModContent.ItemType<Aquamarine>(), 8);
			recipe.AddIngredient(ModContent.ItemType<SoulofFight>(), 14);
			recipe.AddIngredient(ModContent.ItemType<Phantaplasm>(), 8);
			//recipe.SetResult(this);
			recipe.AddTile(412);
			recipe.Register();
		}
	}
}
