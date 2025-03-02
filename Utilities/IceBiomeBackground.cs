using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace TremorMod.Utilities
{
    public class IceBiomeBackground : ModSurfaceBackgroundStyle
    {
        public override void ModifyFarFades(float[] fades, float transitionSpeed)
        {
            for (int i = 0; i < fades.Length; i++)
            {
                fades[i] = (i == 0) ? MathHelper.Lerp(fades[i], 1f, transitionSpeed) : MathHelper.Lerp(fades[i], 0f, transitionSpeed);
            }
        }

        public override int ChooseFarTexture()
        {
            return BackgroundTextureLoader.GetBackgroundSlot("TremorMod/Assets/Backgrounds/Ice3");
        }
    }
}
