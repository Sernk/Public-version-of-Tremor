using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;

namespace TremorMod.Content.Items.Armor.Palladium
{
	[AutoloadEquip(EquipType.Head)]
	public class PalladiumHeader : ModItem
	{
        public static LocalizedText SetBonusText { get; private set; }

        public override void SetDefaults()
		{
			Item.width = 20;
			Item.height = 24;
			Item.value = 400;
			Item.rare = 4;
			Item.defense = 4;
		}

		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("Palladium Header");
			//Tooltip.SetDefault("18% increased thrown damage");
            SetBonusText = this.GetLocalization("SetBonus").WithFormatArgs("Increases thrown weapon velocity and greatly increases life regeneration after striking an enemy");
        }

		public override void UpdateEquip(Player player)
		{
			player.GetDamage(DamageClass.Throwing) += 0.18f;
		}

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == 1208 && legs.type == 1209;
		}

		public override void UpdateArmorSet(Player player)
		{
            player.setBonus = SetBonusText.Value;
            player.setBonus = "Increases thrown weapon velocity and greatly increases life regeneration after striking an enemy";
			player.GetAttackSpeed(DamageClass.Throwing) += 0.25f;
			player.onHitRegen = true;
		}

		public override void ArmorSetShadows(Player player)
		{
			player.armorEffectDrawShadow = true;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.PalladiumBar, 12);
			//recipe.SetResult(this);
			recipe.AddTile(16);
			recipe.Register();
		}
	}
}
