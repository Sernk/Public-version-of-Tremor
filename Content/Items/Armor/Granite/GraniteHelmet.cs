using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using TremorMod.Content.Items.Materials;

namespace TremorMod.Content.Items.Armor.Granite
{
	[AutoloadEquip(EquipType.Head)]
	public class GraniteHelmet : ModItem
	{
        public static LocalizedText SetBonusText { get; private set; }

        public override void SetDefaults()
		{

			Item.width = 18;
			Item.height = 18;
			Item.value = 2500;
			Item.rare = 1;
			Item.defense = 2;
		}

		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Granite Helmet");
			// Tooltip.SetDefault("");
            SetBonusText = this.GetLocalization("SetBonus").WithFormatArgs("Increases maximum defense by 3");
        }

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == ModContent.ItemType<GraniteChestplate>() && legs.type == ModContent.ItemType<GraniteGreaves>();
		}

		public override void UpdateArmorSet(Player player)
		{
            player.setBonus = SetBonusText.Value;
            player.setBonus = "Increases maximum defense by 3";
			player.statDefense += 3;
			player.moveSpeed -= 0.20f;
		}

		public override void ArmorSetShadows(Player player)
		{
			player.armorEffectDrawShadowSubtle = true;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.GraniteBlock, 30);
			recipe.AddIngredient(ModContent.ItemType<StoneofLife>(), 1);
			recipe.AddTile(16);
			recipe.Register();
		}
	}
}
