using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TremorMod.Content.Items.Weapons.Melee
{
	public class AngelFlameSword : ModItem
	{
		public override void SetDefaults()
		{

			Item.damage = 59;
			Item.DamageType = DamageClass.Melee;
			Item.width = 35;
			Item.height = 20;
			Item.useTime = 20;
			Item.useAnimation = 30;
			Item.useStyle = 1;
			Item.knockBack = 10;
			Item.value = 1002;
			Item.rare = 5;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
		}

		/*public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Angel Flame Sword");
			Tooltip.SetDefault("Ignites your enemies");
		}*/

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.Excalibur, 1);
			recipe.AddIngredient(ItemID.FieryGreatsword, 1);
			recipe.AddTile(TileID.MythrilAnvil);
			//recipe.SetResult(this);
			recipe.Register();

		}

        public override void OnHitNPC(Player player, NPC target, NPC.HitInfo hit, int damageDone)
        {
            // Inflict the OnFire debuff for 1 second onto any NPC/Monster that this hits.
            // 60 frames = 1 second
            target.AddBuff(BuffID.OnFire, 140);
        }
    }
}
