using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using TremorMod.Utilities;

namespace TremorMod.Content.Items.Armor.Hallowed
{
	[AutoloadEquip(EquipType.Head)]
	public class HallowedHat : ModItem
	{
		public static LocalizedText SetBonusText { get; private set; }

        public override void SetDefaults()
		{
			Item.width = 24;
			Item.height = 24;
			Item.value = 400;
			Item.rare = 4;
			Item.defense = 9;
		}

		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("Hallowed Hat");
			//Tooltip.SetDefault("25% increased minion damage");
			SetBonusText = this.GetLocalization("SetBonus").WithFormatArgs("Increases your max number of minions");
		}

		public override void UpdateEquip(Player player)
		{
			player.GetDamage(DamageClass.Summon) += 0.25f; // 25% возможно надо будет изменить на 15%
        }

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == 551 && legs.type == 552;
		}

		public override void UpdateArmorSet(Player player)
		{
			player.setBonus = SetBonusText.Value;
            player.setBonus = "Increases your max number of minions";
			player.maxMinions += 3;
		}

		public override void ArmorSetShadows(Player player)
		{
			player.armorEffectDrawOutlines = true;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.HallowedBar, 12);
			//recipe.SetResult(this);
			recipe.AddTile(134);
			recipe.Register();
		}
	}
}