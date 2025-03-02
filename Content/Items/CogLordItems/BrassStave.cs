using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TremorMod.Content.Buffs;

namespace TremorMod.Content.Items.CogLordItems
{
	public class BrassStave : ModItem
	{
		public override void SetDefaults()
		{

			Item.damage = 80;
            Item.DamageType = DamageClass.Magic;
            Item.mana = 60;
			Item.width = 40;
			Item.height = 40;
			Item.useTime = 45;
			Item.useAnimation = 45;
			Item.useStyle = 5;
			Item.value = 12500;
			Item.rare = 5;
			Item.UseSound = SoundID.Item43;
			Item.autoReuse = false;
			Item.shoot = 443;
			Item.shootSpeed = 12f;
            Item.staff[Type] = true; //this makes the useStyle animate as a staff instead of as a gun
        }

		/*public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Brass Stave");
			Tooltip.SetDefault("Shoots fast thin bolts\n" +
			"Press RMB for powerful attack");
		}*/

		public override bool AltFunctionUse(Player player)
		{
			return true;
		}

		public override bool CanUseItem(Player player)
		{
			if (player.altFunctionUse == 2)
			{
				Item.damage = 80;
                Item.DamageType = DamageClass.Magic;
                Item.mana = 60;
				Item.width = 40;
				Item.height = 40;
				Item.useTime = 45;
				Item.useAnimation = 45;
				Item.useStyle = 5;
				Item.rare = 5;
				Item.UseSound = SoundID.Item43;
				Item.autoReuse = false;
				Item.shoot = 443;
				Item.shootSpeed = 12f;
                //item.toolTip = "Shoots fast thin bolts";
                //item.toolTip2 = "Press RMB for powerful attack";
                Item.staff[Type] = true; //this makes the useStyle animate as a staff instead of as a gun
			}
			else
			{
				Item.damage = 65;
                Item.DamageType = DamageClass.Magic;
                Item.mana = 10;
				Item.width = 40;
				Item.height = 40;
				Item.useTime = 22;
				Item.useAnimation = 22;
				Item.useStyle = 5;
				Item.rare = 5;
				Item.UseSound = SoundID.Item43;
				Item.autoReuse = true;
				Item.shoot = 459;
				Item.shootSpeed = 15f;
                //item.toolTip = "Shoots fast thin bolts";
                //item.toolTip2 = "Press RMB for powerful attack";
                Item.staff[Type] = true; //this makes the useStyle animate as a staff instead of as a gun
			}
			return base.CanUseItem(player);
		}

		public override void UpdateInventory(Player player)
		{
			if (player.altFunctionUse == 2)
			{
				if (player.HasBuff(ModContent.BuffType<SteamMageBuff>()))
				{
					Item.damage = 100;
				}
				else
				{
					Item.damage = 80;
				}
			}
			else
			{
				if (player.HasBuff(ModContent.BuffType<SteamMageBuff>()))
				{
					Item.damage = 80;
				}
				else
				{
					Item.damage = 65;
				}
			}
		}
	}
}
