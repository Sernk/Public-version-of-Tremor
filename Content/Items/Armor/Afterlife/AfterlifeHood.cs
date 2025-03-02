using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TremorMod.Content.Items.Materials;
using Terraria.Localization;
using Terraria.GameContent.Creative;

namespace TremorMod.Content.Items.Armor.Afterlife
{
	[AutoloadEquip(EquipType.Head)]
	public class AfterlifeHood : ModItem
	{
        public static LocalizedText SetBonusText { get; private set; }

        public override void SetDefaults()
		{
			Item.width = 38;
			Item.height = 22;
			Item.value = 10000;
			Item.rare = 6;
			Item.defense = 7;
		}

        public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("Afterlife Hood");
			//Tooltip.SetDefault("Increases life regeneration");
			SetBonusText = this.GetLocalization("SetBonus").WithFormatArgs("Quickly recovers you if you have low health.But at what cost...");
		}

        public override void UpdateEquip(Player player)
		{
			player.crimsonRegen = true;
		}

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == ModContent.ItemType<AfterlifeBreastplate>() && legs.type == ModContent.ItemType<AfterlifeLeggings>();
		}

		public override void UpdateArmorSet(Player player)
		{
            player.setBonus = SetBonusText.Value;
            SetBonusText = this.GetLocalization("SetBonus").WithFormatArgs("Quickly recovers you if you have low health.But at what cost...");
			if (player.statLife < 25)
			{
				player.lifeRegen += 40;
			}
		}

		public override void ArmorSetShadows(Player player)
		{
			player.armorEffectDrawShadowLokis = true;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<SkullTeeth>(), 2);
            recipe.AddIngredient(ModContent.ItemType<SteelBar>(), 12);
			recipe.AddTile(134);
			recipe.Register();
		}
	}
}