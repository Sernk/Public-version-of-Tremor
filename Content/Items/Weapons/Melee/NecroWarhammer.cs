using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TremorMod.Content.Items.Weapons.Melee
{
	public class NecroWarhammer : ModItem
	{
		public override void SetDefaults()
		{
			Item.damage = 73;
			Item.DamageType = DamageClass.Melee;
			Item.width = 38;
			Item.height = 20;
			Item.useTime = 26;
			Item.useAnimation = 26;
			Item.useStyle = 1;
			Item.knockBack = 10;
			Item.value = 150000;
			Item.rare = 6;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
			Item.shoot = 270;
			Item.shootSpeed = 12f;
		}

		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("Necro War Hammer");
			//Tooltip.SetDefault("");
		}
	}
}