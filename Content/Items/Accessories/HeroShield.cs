using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TremorMod.Content.Items.Accessories
{
	[AutoloadEquip(EquipType.Shield)]
	public class HeroShield : ModItem
	{
		public override void SetDefaults()
		{
			Item.width = 26;
			Item.height = 26;
			Item.value = 15000;
			Item.rare = 8;
			Item.accessory = true;
			Item.defense = 8;
		}

		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("Hero Shield");
			//Tooltip.SetDefault("Grants immunity to most debuffs\n" +
			//"Grants immunity to knockback and fire blocks\n" +
			//"Prolonged after hit invicibility");
		}

		public override void UpdateEquip(Player player)
		{
            player.noKnockback = true;
            //p.paladinBuff = true;
            player.fireWalk = true;
            player.longInvince = true;
            player.buffImmune[44] = true; //Frostburn
            player.buffImmune[46] = true; //Chilled
            player.buffImmune[47] = true; //Frozen
            player.buffImmune[20] = true; //Poisoned
            player.buffImmune[22] = true; //Darkness
            player.buffImmune[24] = true; //Fire
            player.buffImmune[23] = true; //Cursed
            player.buffImmune[30] = true; //Bleeding
            player.buffImmune[31] = true; //Confused
            player.buffImmune[32] = true; //Slowed
            player.buffImmune[33] = true; //Weak
            player.buffImmune[35] = true; //Silenced
            player.buffImmune[36] = true; //Broken Armor
            player.buffImmune[69] = true; //Ichor
            player.buffImmune[70] = true; //Venom
            player.buffImmune[80] = true; //Black Out
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<HolyShield>(), 1);
			recipe.AddIngredient(ItemID.AnkhShield, 1);
			//recipe.SetResult(this);
			recipe.AddTile(114);
			recipe.Register();
		}
	}
}