using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TremorMod.Content.Items.Materials;
using TremorMod.Content.Buffs;

namespace TremorMod.Content.Items.Weapons.Magic
{
	public class BookofRevelations : ModItem
	{
		public override void SetDefaults()
		{
			Item.DamageType = DamageClass.Magic;
			Item.width = 50;
			Item.height = 55;
			Item.useTime = 30;
			Item.useAnimation = 30;
			Item.useStyle = 5;
			Item.knockBack = 3;
			Item.value = 2000;
			Item.rare = 2;
			Item.UseSound = SoundID.Item4;
			Item.autoReuse = false;
			Item.noMelee = true;

		}

		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Book of Revelations");
			/* Tooltip.SetDefault("Drops 4 hearts and 4 mana stars\n" +
"Has 20 seconds cooldown"); */
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<Rupicide>(), 2);
			recipe.AddIngredient(ModContent.ItemType<TornPapyrus>(), 5);
			//recipe.SetResult(this);
			recipe.Register();
		}

		public override bool? UseItem(Player player)/* tModPorter Suggestion: Return null instead of false */
		{
			if (player.FindBuffIndex(ModContent.BuffType<TomeRechargeBuff1>()) < 1)
			{
				player.AddBuff(ModContent.BuffType<TomeRechargeBuff1>(), 1200, true);
				Item.NewItem(Item.GetSource_FromThis(), (int)player.position.X - 25, (int)player.position.Y, player.width, player.height, 58, 1);
				Item.NewItem(Item.GetSource_FromThis(), (int)player.position.X - 50, (int)player.position.Y, player.width, player.height, 58, 1);
				Item.NewItem(Item.GetSource_FromThis(), (int)player.position.X - 75, (int)player.position.Y, player.width, player.height, 58, 1);
				Item.NewItem(Item.GetSource_FromThis(), (int)player.position.X - 100, (int)player.position.Y, player.width, player.height, 58, 1);
				Item.NewItem(Item.GetSource_FromThis(), (int)player.position.X + 25, (int)player.position.Y, player.width, player.height, 184, 1);
				Item.NewItem(Item.GetSource_FromThis(), (int)player.position.X + 50, (int)player.position.Y, player.width, player.height, 184, 1);
				Item.NewItem(Item.GetSource_FromThis(), (int)player.position.X + 75, (int)player.position.Y, player.width, player.height, 184, 1);
				Item.NewItem(Item.GetSource_FromThis(), (int)player.position.X + 100, (int)player.position.Y, player.width, player.height, 184, 1);
			}
			return false;
		}

	}
}
