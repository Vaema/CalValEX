using Terraria;
using Terraria.ModLoader;

namespace CalValEX.Items.Equips.Wings
{
    [AutoloadEquip(EquipType.Wings)]
    public class PlaguePack : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Beelzebooster");
            Tooltip.SetDefault("And they wonder how bees can get themselves off the ground\n" + "Horizontal speed: 9\n" + "Acceleration multiplier: 2.5\n" + "Flight time: 170");
        }

        public override void SetDefaults()
        {
            item.width = 40;
            item.height = 34;
            item.value = Item.buyPrice(0, 2, 0, 0);
            item.rare = 8;
            item.accessory = true;
        }

        //these wings use the same values as the solar wings
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.wingTimeMax = 170;
        }

        public override void VerticalWingSpeeds(Player player, ref float ascentWhenFalling, ref float ascentWhenRising,
            ref float maxCanAscendMultiplier, ref float maxAscentMultiplier, ref float constantAscend)
        {
            ascentWhenFalling = 0.85f;
            ascentWhenRising = 0.15f;
            maxCanAscendMultiplier = 1f;
            maxAscentMultiplier = 3f;
            constantAscend = 0.135f;
        }

        public override void HorizontalWingSpeeds(Player player, ref float speed, ref float acceleration)
        {
            speed = 9f;
            acceleration *= 2.5f;
        }
    }
}