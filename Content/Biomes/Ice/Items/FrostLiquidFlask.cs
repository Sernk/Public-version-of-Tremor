using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TremorMod.Content.Biomes.Ice.Items
{
	public class FrostLiquidFlask : ModItem
	{
		public override void SetDefaults()
		{
			Item.damage = 10;
			//item.thrown = true;
			Item.width = 26;
			Item.noUseGraphic = true;
			Item.maxStack = 999;
			Item.consumable = true;
			Item.height = 30;
			Item.useTime = 20;
			Item.useAnimation = 20;
			Item.shoot = ModContent.ProjectileType<FrostLiquidFlaskPro>();
			Item.shootSpeed = 8f;
			Item.useStyle = 1;
			Item.knockBack = 1;
			Item.UseSound = SoundID.Item106;
			Item.value = 30;
			Item.rare = 1;
			Item.autoReuse = false;
			Item.crit = 4;
		}

		/*public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Frost Liquid Flask");
			Tooltip.SetDefault("Throws a flask that explodes into frost bolts");
		}*/
	}
}
