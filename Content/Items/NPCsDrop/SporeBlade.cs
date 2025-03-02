using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TremorMod.Content.Items.NPCsDrop
{
	public class SporeBlade : ModItem
	{
		public override void SetDefaults()
		{
			Item.damage = 82;
			Item.DamageType = DamageClass.Melee;
			Item.width = 50;
			Item.height = 55;
			Item.useTime = 35;
			Item.useAnimation = 25;
			Item.useStyle = 1;
			Item.shoot = 228;
			Item.shootSpeed = 20f;
			Item.knockBack = 4;
			Item.value = 50000;
			Item.rare = 6;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = false;
		}

		/*public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Spore Blade");
			Tooltip.SetDefault("");
		}*/

	}
}
