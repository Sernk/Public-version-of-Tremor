using Terraria.ModLoader;
using Terraria.ModLoader.Config;
using System.ComponentModel;

namespace TremorMod
{
    public class TremorConfig : ModConfig
    {
        public override ConfigScope Mode => ConfigScope.ServerSide; // Доступно для сервера и одиночной игры

        [Header("$Mods.TremorMod.Config.BuffSettings")] // Локализованный заголовок

        [DefaultValue(false)] // По умолчанию НЕ совместимы
        [LabelKey("$Mods.TremorMod.Config.AllowHealthBuffsTogether")]
        [TooltipKey("$Mods.TremorMod.Config.AllowHealthBuffsTogetherTooltip")]
        public bool AllowHealthBuffsTogether;

        [DefaultValue(false)] // По умолчанию НЕ совместимы
        [LabelKey("$Mods.TremorMod.Config.AllowManaBuffsTogether")]
        [TooltipKey("$Mods.TremorMod.Config.AllowManaBuffsTogetherTooltip")]
        public bool AllowManaBuffsTogether;

        [Header("$Mods.TremorMod.Config.CreateSettings")] 

        [DefaultValue(true)] // новый рецепт Зенита включен по умолчанию
        [LabelKey("$Mods.TremorMod.Config.AllowZenithRecipeChange")]
        [TooltipKey("$Mods.TremorMod.Config.AllowZenithRecipeChangeTooltip")]
        public bool AllowZenithRecipeChange;
    }
}