using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TremorMod.Content.Items.Weapons.Magic
{
	public class Blizzard : ModItem
	{
		public override void SetDefaults()
		{
			Item.damage = 35;
			Item.DamageType = DamageClass.Magic;
			Item.width = 50;
			Item.height = 55;
			Item.useTime = 12;
			Item.useAnimation = 12;
			Item.mana = 8;
			Item.useStyle = 5;
			Item.shoot = 337;
			Item.shootSpeed = 26f;
			Item.knockBack = 4;
			Item.value = 100000;
			Item.rare = 5;
			Item.UseSound = SoundID.Item20;
			Item.autoReuse = true;
		}

		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("Blizzard");
			//Tooltip.SetDefault("");
		}

	}
}
