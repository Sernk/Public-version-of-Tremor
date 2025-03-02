using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TremorMod.Content.Items.BossLoot.TikiTotem
{
	public class PickaxeofBloom : ModItem
	{
		public override void SetDefaults()
		{
			Item.damage = 9;
			Item.DamageType = DamageClass.Melee;
			Item.width = 42;
			Item.height = 42;
			Item.useTime = 15;
			Item.useAnimation = 20;
			Item.pick = 68;
			Item.useStyle = 1;
			Item.knockBack = 5;
			Item.value = 600;
			Item.rare = 3;
			Item.UseSound = SoundID.Item1;
			Item.useTurn = true;
			Item.autoReuse = true;
		}

		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("Pickaxe of Bloom");
			//Tooltip.SetDefault("");
		}
	}
}