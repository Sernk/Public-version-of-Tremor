using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using TremorMod.Content.Items.Materials;
using TremorMod.Content.Tiles;
using TremorMod.Utilities;
using TremorMod;

namespace TremorMod.Content.Items.Armor.Paraxyde
{
	[AutoloadEquip(EquipType.Head)]
	public class ParaxydeHelmet : ModItem
	{
        public static LocalizedText SetBonusText { get; private set; }

        public override void SetDefaults()
		{
			Item.width = 38;
			Item.height = 22;
			Item.value = 10000;
			Item.rare = 5;
			Item.defense = 15;
		}

		public override void SetStaticDefaults()
		{
            //DisplayName.SetDefault("Paraxyde Helmet");
            //Tooltip.SetDefault("12% increased magic damage\n" +
            //"16% increased melee damage");
            SetBonusText = this.GetLocalization("SetBonus").WithFormatArgs("Shadow knives will fall on your target for extra damage");
        }

		public override void UpdateEquip(Player player)
		{
			player.GetDamage(DamageClass.Magic) += 0.12f;
			player.GetDamage(DamageClass.Melee) += 0.16f;
		}

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == ModContent.ItemType<ParaxydeBreastplate>() && legs.type == ModContent.ItemType<ParaxydeGreaves>();
		}

		public override void UpdateArmorSet(Player player)
		{
            player.setBonus = SetBonusText.Value;
            player.setBonus = "Shadow knives will fall on your target for extra damage";
            player.GetModPlayer<MPlayer>().paraxydeSetBonusActive = true; 
        }

        public override void ArmorSetShadows(Player player)
		{
			player.armorEffectDrawOutlines = true; //�।��� ����஢����
			player.armorEffectDrawShadow = true;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<ParaxydeShard>(), 12);
			//recipe.SetResult(this);
			recipe.AddTile(ModContent.TileType<AlchematorTile>());
			recipe.Register();
		}
	}
}
