using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using TremorMod.Content.Items.Materials;

namespace TremorMod.Content.Items.Armor.Raven
{
	[AutoloadEquip(EquipType.Head)]
	public class RavenHeadgear : ModItem
	{
        public static LocalizedText SetBonusText { get; private set; }

        public override void SetDefaults()
		{
			Item.width = 18;
			Item.height = 18;
			Item.value = 10000;
			Item.rare = 4;
			Item.defense = 9;
		}

		public override void SetStaticDefaults()
		{
            //DisplayName.SetDefault("Raven Headgear");
            //Tooltip.SetDefault("5% increased melee damage\n" +
            //"Increases melee critical strike chance by 5");
            SetBonusText = this.GetLocalization("SetBonus").WithFormatArgs("Increases player defense by 3, 8% increased melee speed, increases melee critical strike chance by 6");
        }

		public override void UpdateEquip(Player player)
		{
            player.GetDamage(DamageClass.Melee) += 0.05f;
            player.GetCritChance(DamageClass.Melee) += 5;
		}

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == ModContent.ItemType<RavenBreastplate>() && legs.type == ModContent.ItemType<RavenGreaves>();
		}

		public override void UpdateArmorSet(Player player)
		{
            player.setBonus = SetBonusText.Value;
            player.setBonus = "Increases player defense by 3, 8% increased melee speed, increases melee critical strike chance by 6";
            player.statDefense += 3;
            player.GetDamage(DamageClass.Melee) += 0.8f;
            player.GetCritChance(DamageClass.Melee) += 6;
        }

		public override void AddRecipes()
		{
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.MoltenHelmet);
            recipe.AddIngredient(ItemID.IronBar, 7);
            recipe.AddIngredient(ModContent.ItemType<RavenFeather>(), 11);
            //recipe.SetResult(this);
            recipe.AddTile(16);
            recipe.Register();

            Recipe recipe1 = CreateRecipe();
            recipe1.AddIngredient(ItemID.MoltenHelmet);
            recipe1.AddIngredient(ItemID.LeadBar, 7);
            recipe1.AddIngredient(ModContent.ItemType<RavenFeather>(), 11);
            //recipe.SetResult(this);
            recipe1.AddTile(16);
            recipe1.Register();
		}
	}
}