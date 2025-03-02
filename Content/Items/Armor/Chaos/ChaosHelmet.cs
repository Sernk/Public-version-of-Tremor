using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TremorMod.Content.Items.Materials.OreAndBar;
using Terraria.Localization;

namespace TremorMod.Content.Items.Armor.Chaos
{
	[AutoloadEquip(EquipType.Head)]
	public class ChaosHelmet : ModItem
	{
        public static LocalizedText SetBonusText { get; private set; }

        public override void SetDefaults()
		{
			Item.width = 32;
			Item.height = 26;
			Item.value = 6000;
			Item.rare = 5;
			Item.defense = 8;
		}

        public override void SetStaticDefaults()
		{
			/*DisplayName.SetDefault("Chaos Helmet");
			Tooltip.SetDefault("Increases maximum life by 25\n" +
			"Immune to most debuffs!");*/
			 SetBonusText = this.GetLocalization("SetBonus").WithFormatArgs("Increases life regeneration");
		}

        public override void UpdateEquip(Player player)
		{
			player.statLifeMax2 += 25;
            player.buffImmune[44] = true;
            player.buffImmune[46] = true;
            player.buffImmune[47] = true;
            player.buffImmune[20] = true;
            player.buffImmune[22] = true;
            player.buffImmune[24] = true;
            player.buffImmune[23] = true;
            player.buffImmune[30] = true;
            player.buffImmune[31] = true;
            player.buffImmune[32] = true;
            player.buffImmune[33] = true;
            player.buffImmune[35] = true;
            player.buffImmune[36] = true;
            player.buffImmune[69] = true;
            player.buffImmune[70] = true;
            player.buffImmune[80] = true;
		}

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == ModContent.ItemType<ChaosBreastplate>() && legs.type == ModContent.ItemType<ChaosGreaves>();
		}

		public override void UpdateArmorSet(Player player)
		{
            player.setBonus = SetBonusText.Value;
            SetBonusText = this.GetLocalization("SetBonus").WithFormatArgs("Increases life regeneration");
			player.lifeRegen += 2;
		}

		public override void ArmorSetShadows(Player player)
		{
			player.armorEffectDrawShadowLokis = true;
		}

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<ChaosBar>(), 14);
            //recipe.SetResult(this);
            recipe.AddTile(134);
            recipe.Register();
        }
	}
}
