using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TremorMod.Content.Biomes.Ruins.Items
{
	public class FirebenderTome : ModItem
	{
		public override void SetDefaults()
		{
			Item.damage = 18;
			Item.DamageType = DamageClass.Magic;
			Item.width = 28;
			Item.height = 30;
			Item.useTime = 36;
			Item.useAnimation = 36;
			Item.shoot = 706;
			Item.shootSpeed = 7f;
			Item.mana = 10;
			Item.useStyle = 5;
			Item.knockBack = 3;
			Item.value = 10000;
			Item.rare = 2;
			Item.UseSound = SoundID.Item20;
			Item.autoReuse = true;
		}

		/*public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Firebender Tome");
			Tooltip.SetDefault("");
		}*/
	}
}