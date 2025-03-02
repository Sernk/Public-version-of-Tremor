using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TremorMod.Content.Items.NPCsDrop
{
	public class SharkRage : ModItem
	{
		public override void SetDefaults()
		{
			Item.damage = 46;
			Item.DamageType = DamageClass.Magic;
			Item.mana = 10;
			Item.width = 54;
			Item.height = 54;
			Item.useTime = 26;
			Item.useAnimation = 26;
			Item.useStyle = 5;
			Item.noMelee = true;
			Item.knockBack = 3;
			Item.value = 40000;
			Item.rare = 5;
			Item.UseSound = SoundID.Item43;
			Item.autoReuse = true;
			Item.staff[Item.type] = true; //this makes the useStyle animate as a staff instead of as a gun
			Item.shoot = 408;
			Item.shootSpeed = 15f;
		}

		/*public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Shark Rage");
			Tooltip.SetDefault("");
		}*/	

	}
}
