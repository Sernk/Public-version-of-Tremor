using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TremorMod.Content.Items.Materials;
using Terraria.Localization;

namespace TremorMod.Content.Items.Armor.Nightingale
{
	[AutoloadEquip(EquipType.Head)]
	public class NightingaleHood : ModItem
	{
        public static LocalizedText SetBonusText { get; private set; }

        public override void SetDefaults()
		{
			Item.defense = 5;
			Item.width = 26;
			Item.height = 32;
			Item.value = 2000;
			Item.rare = 2;
		}

		public override void SetStaticDefaults()
		{
			/*DisplayName.SetDefault("Nightingale Hood");
			Tooltip.SetDefault("Increases life regeneration");*/
			SetBonusText = this.GetLocalization("SetBonus").WithFormatArgs("Reduced enemy aggression");
		}

		public override void UpdateEquip(Player player)
		{
			player.lifeRegen += 1;
		}

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == ModContent.ItemType<NightingaleChestplate>() && legs.type == ModContent.ItemType<NightingaleGreaves>();
		}

		public override void UpdateArmorSet(Player player)
		{
            player.setBonus = SetBonusText.Value;
			player.AddBuff(106, 300, true);
		}

		public override void ArmorSetShadows(Player player)
		{
			player.armorEffectDrawShadowLokis = true;
		}

		public override void AddRecipes()
		{
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<SteelBar>(), 5);
            recipe.AddIngredient(ModContent.ItemType<PhantomSoul>(), 3);
            //recipe.SetResult(this);
            recipe.AddTile(16);
            recipe.Register();
        }
	}
}
