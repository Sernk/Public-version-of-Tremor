using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TremorMod.Content.Items.NPCsDrop
{
	public class Hurricane : ModItem
	{
		public override void SetDefaults()
		{
			Item.damage = 38;
			Item.DamageType = DamageClass.Magic;
			Item.width = 28;
			Item.height = 30;
			Item.useTime = 36;
			Item.useAnimation = 36;
			Item.shoot = 704;
			Item.shootSpeed = 11f;
			Item.mana = 14;
			Item.useStyle = 5;
			Item.knockBack = 3;
			Item.value = 40000;
			Item.rare = 5;
			Item.UseSound = SoundID.Item20;
			Item.autoReuse = true;
		}

		/*public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("The Hurricane");
			Tooltip.SetDefault("Summons a sand whirlwing which moves only on ground");
		}*/
	}
}
