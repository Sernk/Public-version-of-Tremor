using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;

namespace TremorMod.Content.Items.Armor.Vine
{
	[AutoloadEquip(EquipType.Head)]
	public class VineHood : ModItem
	{
        public static LocalizedText SetBonusText { get; private set; }

        public override void SetDefaults()
		{

			Item.width = 26;
			Item.height = 26;

			Item.value = 100;
			Item.rare = 1;
			Item.defense = 1;
		}

		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Vine Hood");
			// Tooltip.SetDefault("5% increased ranged damage");
            SetBonusText = this.GetLocalization("SetBonus").WithFormatArgs("15% increased movement speed");
        }

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == ModContent.ItemType<VineCape>() && legs.type == ModContent.ItemType<VinePants>();
		}

		public override void UpdateArmorSet(Player player)
		{
            player.setBonus = SetBonusText.Value;
            player.setBonus = "15% increased movement speed";
			player.moveSpeed += 0.15f;
		}
		public override void UpdateEquip(Player player)
		{
			player.GetDamage(DamageClass.Ranged) += 0.05f;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.VineRope, 25);
			recipe.AddIngredient(ItemID.Daybloom, 1);
			//recipe.SetResult(this);
			recipe.AddTile(16);
			recipe.Register();
		}

	}
}
