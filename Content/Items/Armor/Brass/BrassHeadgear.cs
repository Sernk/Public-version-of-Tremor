using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TremorMod.Content.Items.Materials.OreAndBar;
using Terraria.Localization;
using TremorMod.Content.Buffs;

namespace TremorMod.Content.Items.Armor.Brass
{
	[AutoloadEquip(EquipType.Head)]
	public class BrassHeadgear : ModItem
	{
        public static LocalizedText SetBonusText { get; private set; }

        public override void SetDefaults()
		{
			Item.width = 20;
			Item.height = 20;
			Item.value = 400;
			Item.rare = 5;
			Item.defense = 8;
		}

		public override void SetStaticDefaults()
		{
            /*DisplayName.SetDefault("Brass Headgear");
			Tooltip.SetDefault("10% increased magical damage\n" +
			"Increases magical critical strike chance by 8");*/
            SetBonusText = this.GetLocalization("SetBonus").WithFormatArgs("Summons a Steampunk Drone to fight for you and increases damage of Brass Chain Repeater");
        }

		public override void UpdateEquip(Player player)
		{
            player.GetCritChance(DamageClass.Magic) += 8;
			player.GetDamage(DamageClass.Magic) += 0.1f;
		}

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == ModContent.ItemType<BrassChestplate>() && legs.type == ModContent.ItemType<BrassGreaves>();
		}

		public override void UpdateArmorSet(Player player)
		{
			player.setBonus = SetBonusText.Value;
			SetBonusText = this.GetLocalization("SetBonus").WithFormatArgs("Summons a Steampunk Drone to fight for you and increases damage of Brass Chain Repeater");
            player.AddBuff(ModContent.BuffType<buffSteampunkProbe>(), 4);
			player.AddBuff(ModContent.BuffType<SteamMageBuff>(), 4);
		}

		public override void ArmorSetShadows(Player player)
		{
			player.armorEffectDrawOutlines = true;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<BrassBar>(), 13);
			recipe.AddIngredient(ItemID.Cog, 12);
			recipe.AddIngredient(ItemID.Glass, 6);
			//recipe.SetResult(this);
			recipe.AddTile(134);
			recipe.Register();
		}
	}
}
