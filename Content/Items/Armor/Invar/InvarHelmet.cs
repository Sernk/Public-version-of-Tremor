using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;
using TremorMod.Content.Items.Materials.OreAndBar;
using Terraria.Localization;


namespace TremorMod.Content.Items.Armor.Invar
{
    [AutoloadEquip(EquipType.Head)]
    internal class InvarHelmet : ModItem
    {
        public static LocalizedText SetBonusText { get; private set; }

        public override void SetStaticDefaults()
        {
            /*DisplayName.SetDefault("Invar Helmet");
			Tooltip.SetDefault("+1 defense");*/
            SetBonusText = this.GetLocalization("SetBonus").WithFormatArgs("2 defense");
        }

        public override void SetDefaults()
        {
            Item.width = 32;
            Item.height = 26;
            Item.value = Item.sellPrice(silver: 9);
            Item.rare = 1;
            Item.defense = 3;
        }

        public override void UpdateEquip(Player player)
        {
            player.GetDamage(DamageClass.Melee) += 0.06f;
        }

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == ModContent.ItemType<InvarBreastPlate>() && legs.type == ModContent.ItemType<InvarGreaves>();
        }

        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = SetBonusText.Value;
            player.statDefense += 2;
        }

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<InvarBar>(), 8);
            //recipe.SetResult(this);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
        }
	}
}
