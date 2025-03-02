using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;

namespace TremorMod.Content.Biomes.Ice.Items
{
	[AutoloadEquip(EquipType.Head)]
	public class GlacierWoodHelmet : ModItem
	{
        public static LocalizedText SetBonusText { get; private set; }
        public override void SetDefaults()
		{
			Item.width = 32;
			Item.height = 26;
			Item.value = 400;
			Item.rare = 1;
			Item.defense = 2;
		}

		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("Glacier Wood Helmet");
			//Tooltip.SetDefault("");
		}

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == ModContent.ItemType<GlacierWoodChestplate>() && legs.type == ModContent.ItemType<GlacierWoodLeggings>();
		}

		public override void UpdateArmorSet(Player player)
		{
            SetBonusText = this.GetLocalization("SetBonus").WithFormatArgs("1 defense");
            player.setBonus = Language.GetTextValue("Mods.TremorMod.ArmorSetBonus.Adamantite");
            player.setBonus = "1 defense";
			player.statDefense += 1;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<GlacierWood>(), 20);
			//recipe.SetResult(this);
			recipe.AddTile(18);
			recipe.Register();
		}
	}
}
