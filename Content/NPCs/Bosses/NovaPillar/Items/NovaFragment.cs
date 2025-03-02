using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics; // Add this directive for Texture2D
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TremorMod.Content.NPCs.Bosses.NovaPillar.Items
{
    public class NovaFragment : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 48;
            Item.height = 48;
            Item.value = 2000;
            Item.rare = 9;
            Item.maxStack = 999;
            ItemID.Sets.ItemIconPulse[Item.type] = true;
            ItemID.Sets.ItemNoGravity[Item.type] = true;
        }

        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Nova Fragment");
            // Tooltip.SetDefault("'The constituents of stars are contained in this fragment'");
            AddGlowMask(Item.type, "TremorMod/Content/NPCs/Bosses/NovaPillar/Items/NovaFragment_Glow");
        }

        public override void PostUpdate()
        {
            Lighting.AddLight(Item.Center, new Vector3(0.8f, 0.7f, 0.3f) * Main.essScale);
        }

        public override Color? GetAlpha(Color lightColor)
        {
            return Color.White;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(3456, 1);
            recipe.AddIngredient(3457, 1);
            recipe.AddIngredient(3458, 1);
            recipe.AddIngredient(3459, 1);
            // recipe.SetResult(this);
            recipe.AddTile(412);
            recipe.Register();
        }

        private void AddGlowMask(int itemType, string texturePath)
        {
            // Implement the logic to add a glow mask to the item
            // Use ModContent.Request to load the texture
            Texture2D texture = ModContent.Request<Texture2D>(texturePath).Value;
            // Assuming you have a way to apply this texture as a glow mask
            // This implementation depends on your modding framework
        }
    }
}