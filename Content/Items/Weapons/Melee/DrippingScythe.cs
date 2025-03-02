using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TremorMod.Content.Items.Weapons.Melee
{
	public class DrippingScythe : ModItem
	{
		public override void SetDefaults()
		{
			Item.autoReuse = true;
			Item.useStyle = 1;
			Item.useAnimation = 20;
			Item.useTime = 20;
			Item.knockBack = 7f;
			Item.width = 24;
			Item.height = 28;
			Item.damage = 297;
			Item.UseSound = SoundID.Item71;
			Item.rare = 11;
			Item.shootSpeed = 15f;
			Item.value = 450000;
			Item.DamageType = DamageClass.Melee;
		}

		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("Dripping Sickle");
			//Tooltip.SetDefault("");
		}
	}
}