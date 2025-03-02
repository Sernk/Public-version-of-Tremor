using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using TremorMod.Utilities;

namespace TremorMod.Content.Items.Armor.Hallowed
{
	[AutoloadEquip(EquipType.Head)]
	public class HallowedVisage : ModItem
	{
		public static LocalizedText SetBonusText { get; private set; }

        public override void SetDefaults()
		{
			Item.width = 26;
			Item.height = 20;
			Item.value = 50000;
			Item.rare = 5;
			Item.defense = 10;
		}

		public override void SetStaticDefaults()
		{
            //DisplayName.SetDefault("Hallowed Visage");
            //Tooltip.SetDefault("27% increased alchemical damage");
            SetBonusText = this.GetLocalization("SetBonus").WithFormatArgs("23% increased alchemical critical strike chance");
        }

		public override void UpdateEquip(Player player)
		{
			player.GetModPlayer<MPlayer>().alchemicalDamage += 0.27f;
		}

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == 551 && legs.type == 552;
		}

		public override void UpdateArmorSet(Player player)
		{
            player.setBonus = SetBonusText.Value;
            player.setBonus = "23% increased alchemical critical strike chance";
			player.GetModPlayer<MPlayer>().alchemicalCrit += 23;
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