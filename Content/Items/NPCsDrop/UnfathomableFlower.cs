using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TremorMod.Content.Items.NPCsDrop
{
	public class UnfathomableFlower : ModItem
	{
		public override void SetDefaults()
		{

			Item.damage = 42;
			Item.DamageType = DamageClass.Magic;
			Item.width = 40;
			Item.mana = 11;
			Item.height = 20;
			Item.useTime = 12;
			Item.useAnimation = 12;
			Item.useStyle = 5;
			Item.noMelee = true;
			Item.knockBack = 6;
			Item.value = 60000;
			Item.rare = 6;
			Item.autoReuse = true;
			Item.shoot = 248;
			Item.shootSpeed = 12f;
		}

		/*public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Unfathomable Flower");
			Tooltip.SetDefault("");
		}*/

	}
}
