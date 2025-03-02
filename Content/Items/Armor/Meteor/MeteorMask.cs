using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;

namespace TremorMod.Content.Items.Armor.Meteor
{
	[AutoloadEquip(EquipType.Head)]
	public class MeteorMask : ModItem
	{
        public static LocalizedText SetBonusText { get; private set; }

        public override void SetDefaults()
		{
			Item.width = 18;
			Item.height = 28;
			Item.value = 9000;
			Item.rare = 1;
			Item.defense = 4;
		}

		public override void SetStaticDefaults()
		{
            //DisplayName.SetDefault("Meteor Mask");
            //Tooltip.SetDefault("Increases magic critical strike chance by 9");
            SetBonusText = this.GetLocalization("SetBonus").WithFormatArgs("Increases magic critical strike chance by 9");
        }

		public override void UpdateEquip(Player player)
		{
			player.GetCritChance(DamageClass.Magic) += 9;
		}

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == 124 && legs.type == 125;
		}

		public override void UpdateArmorSet(Player player)
		{
            player.setBonus = SetBonusText.Value;
            player.setBonus = "Reduces the mana cost of the Space Gun to zero";
			player.spaceGun = true;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(117, 15);
			//recipe.SetResult(this);
			recipe.AddTile(16);
			recipe.Register();
		}
	}
}
