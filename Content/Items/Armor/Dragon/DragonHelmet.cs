using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using TremorMod.Content.Items.Materials;

namespace TremorMod.Content.Items.Armor.Dragon
{
	[AutoloadEquip(EquipType.Head)]
	public class DragonHelmet : ModItem
	{
        public static LocalizedText SetBonusText { get; private set; }

        public override void SetDefaults()
		{
			Item.width = 32;
			Item.height = 22;
			Item.value = 38000;
			Item.rare = 11;
			Item.defense = 31;
		}

		public override void SetStaticDefaults()
		{
            //DisplayName.SetDefault("Dragon Helmet");
            //Tooltip.SetDefault("Increases arrow speed and damage");
            SetBonusText = this.GetLocalization("SetBonus").WithFormatArgs("Allows you to detect enemies and increases ranged critical strike chance by 25");
		}

		public override void UpdateEquip(Player player)
		{
			player.archery = true;
		}

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == ModContent.ItemType<DragonBreastplate>() && legs.type == ModContent.ItemType<DragonGreaves>();
		}

		public override void UpdateArmorSet(Player player)
		{
            player.setBonus = SetBonusText.Value;        
			player.GetCritChance(DamageClass.Ranged) += 25;
            player.detectCreature = true;
		}

		public override void ArmorSetShadows(Player player)
		{
			player.armorEffectDrawOutlines = true;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<DragonCapsule>(), 14);
			recipe.AddIngredient(ModContent.ItemType<EarthFragment>(), 10);
			recipe.AddTile(412);
			//recipe.SetResult(this);
			recipe.Register();
		}
	}
}
