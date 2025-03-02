using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TremorMod.Content.Items.Weapons.Magic
{
    public class ThunderRay : ModItem
    {
        public override void SetDefaults()
        {
            Item.damage = 24;
            Item.width = 14;
            Item.height = 84;
            Item.DamageType = DamageClass.Magic;  
            Item.mana = 9;
            Item.useTime = 26;
            Item.shoot = 255;
            Item.shootSpeed = 8f;
            Item.useAnimation = 26;
            Item.useStyle = 5;
            Item.knockBack = 0;
            Item.value = 2100;
            Item.rare = 2;
            Item.UseSound = SoundID.Item114;
            Item.autoReuse = true;
        }

        /*public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Thunder Ray");
			Tooltip.SetDefault("");
		}*/
    }
}
