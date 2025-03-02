using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using TremorMod.Content.Items.Materials.OreAndBar;

namespace TremorMod.Content.Items.Armor.Chain
{
	[AutoloadEquip(EquipType.Head)]
	public class ChainCoif : ModItem
	{
        public static LocalizedText SetBonusText { get; private set; }

        public override void SetDefaults()
		{
			Item.width = 18;
			Item.height = 24;
			Item.value = Item.sellPrice(silver: 10);
			Item.rare = 1;
			Item.defense = 2;
		}

		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Chain Coif");
			// Tooltip.SetDefault("");
            SetBonusText = this.GetLocalization("SetBonus").WithFormatArgs("+1 defense");
        }

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == ModContent.ItemType<Chainmail>() && legs.type == ModContent.ItemType<ChainGreaves>();
		}

		public override void UpdateArmorSet(Player player)
		{
            player.setBonus = SetBonusText.Value;
            player.setBonus = "+1 defense";
			player.statDefense += 1;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.IronBar, 15);
			recipe.AddIngredient(ModContent.ItemType<InvarBar>());
			recipe.AddIngredient(ItemID.Chain);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();

            Recipe recipe1 = CreateRecipe();
            recipe1.AddIngredient(ItemID.LeadBar, 15);
            recipe1.AddIngredient(ModContent.ItemType<InvarBar>());
            recipe1.AddIngredient(ItemID.Chain);
            recipe1.AddTile(TileID.Anvils);
            recipe1.Register();
        }
	}
}
