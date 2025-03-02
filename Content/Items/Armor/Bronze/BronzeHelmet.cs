using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using TremorMod.Content.Items.Materials;

namespace TremorMod.Content.Items.Armor.Bronze
{
	[AutoloadEquip(EquipType.Head)]
	public class BronzeHelmet : ModItem
	{
        public static LocalizedText SetBonusText { get; private set; }

        public override void SetDefaults()
		{

			Item.width = 32;
			Item.height = 26;

			Item.value = 400;
			Item.rare = 1;
			Item.defense = 4;
		}

		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Bronze Helmet");
			// Tooltip.SetDefault("6% increased melee critical strike chance");
            SetBonusText = this.GetLocalization("SetBonus").WithFormatArgs("Summons a Rotating Sword to fight for you");
        }

		public override void UpdateEquip(Player player)
		{
			player.GetCritChance(DamageClass.Melee) += 6;
		}

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == Mod.Find<ModItem>("BronzeChestplate").Type && legs.type == Mod.Find<ModItem>("BronzeGreaves").Type;
		}

		public override void UpdateArmorSet(Player player)
		{
            player.setBonus = SetBonusText.Value;
            player.setBonus = "8% increased damage";
			player.GetDamage(DamageClass.Melee) += 0.08f;
			player.GetDamage(DamageClass.Magic) += 0.08f;
			player.GetDamage(DamageClass.Ranged) += 0.08f;
		}

		public override void ArmorSetShadows(Player player)
		{
			player.armorEffectDrawShadowSubtle = true;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<BronzeBar>(), 13);
			recipe.AddTile(16);
			recipe.Register();
		}
	}
}
