using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TremorMod.Content.Projectiles;
using TremorMod.Content.Buffs;

namespace TremorMod.Content.Items
{
	public class BadApple : ModItem
	{
		public override void SetDefaults()
		{
			Item.CloneDefaults(ItemID.Carrot);
			Item.useTime = 25;
			Item.useAnimation = 25;
			Item.shoot = ModContent.ProjectileType<GurdPet>();
			Item.buffType = ModContent.BuffType<GurdPetBuff>();
		}

        /*public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Bad Apple");
			Tooltip.SetDefault("Summons a gurd pet");
		}*/

        public override bool? UseItem(Player player)
        {
            // Дополнительное поведение при использовании
            if (player.whoAmI == Main.myPlayer)
            {
                player.AddBuff(Item.buffType, 3600, true); // Добавляем бафф на 60 секунд
            }
            return true; // Указывает, что действие выполнено успешно
        }

    }
}
