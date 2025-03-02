using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;

namespace TremorMod.Content.Items.Armor.Crystal
{
	[AutoloadEquip(EquipType.Head)]
	public class CrystalHelmet : ModItem
	{
		public static LocalizedText SetBonusText { get; private set; }

		public override void SetDefaults()
		{
			Item.defense = 5;
			Item.width = 26;
			Item.height = 22;
			Item.value = 2500;
			Item.rare = 4;
		}

		public override void SetStaticDefaults()
		{
            /*DisplayName.SetDefault("Crystal Helmet");
			Tooltip.SetDefault("20% increased throwing damage");*/
            SetBonusText = this.GetLocalization("SetBonus").WithFormatArgs("Increases movement speed");
        }

		public override void UpdateEquip(Player player)
		{
            player.GetDamage(DamageClass.Throwing) += 0.2f;
        }

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == ModContent.ItemType<CrystalChestplate>() && legs.type == ModContent.ItemType<CrystalGreaves>();
		}

		public override void UpdateArmorSet(Player player)
		{
            player.setBonus = SetBonusText.Value;
            SetBonusText = this.GetLocalization("SetBonus").WithFormatArgs("Increases movement speed");           
			player.moveSpeed += 0.25f;
		}

		public override void ArmorSetShadows(Player player)
		{
			player.armorEffectDrawShadow = true;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.CrystalShard, 30);
			recipe.AddIngredient(ItemID.SoulofLight, 6);
			//recipe.SetResult(this);
			recipe.AddTile(134);
			recipe.Register();
		}
	}
}
