using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace CalValEX.Items.Equips.Shields {
    [AutoloadEquip(EquipType.Shield)]
    public class EarthShield : ModItem {
        public override void SetStaticDefaults() => SacrificeTotal = 1;

        public override void SetDefaults() {
            Item.width = 24;
            Item.height = 28;
            Item.value = Item.sellPrice(0, 2, 0, 0);
            Item.rare = ItemRarityID.LightRed;
            Item.accessory = true;
            Item.vanity = true;
        }
    }
}