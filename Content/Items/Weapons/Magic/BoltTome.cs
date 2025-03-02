using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TremorMod.Content.Items.Weapons.Magic
{
	public class BoltTome : ModItem
	{
		public override void SetDefaults()
		{
			Item.damage = 26;
			//item.melee = false;
			Item.DamageType = DamageClass.Magic;
			Item.width = 50;
			Item.height = 55;
			Item.useTime = 30;
			Item.mana = 7;
			Item.useAnimation = 30;
			Item.useStyle = 5;
			Item.shoot = 645;
			Item.shootSpeed = 20f;
			Item.knockBack = 3;
			Item.value = 30000;
			Item.rare = 3;
			Item.UseSound = SoundID.Item4;
			Item.autoReuse = false;
		}

		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("Bolt Tome");
			//Tooltip.SetDefault("");
		}
	}
}