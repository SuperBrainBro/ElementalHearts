using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ElementalHearts.Items.Consumables
{
    internal class TooLongForRealNameID : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Permanently increases maximum life by 69");
            DisplayName.SetDefault("Adamantite Amber Amethyst Boreal Wood Bubble Cactus Candy Cane Chlorophyte Cloud Cobalt Cog" +
                " Copper Coralstone Crimsand Crimstone Crimtane Crystal Cursed Flame Demon Demonite Diamond Dirt Dynasty Ebonsand" +
                " Ebonstone Ebonwood Ectoplasm Emerald Empty Enchanted Flesh Fossil Glass Gold Granite Hay Hellstone Honey Ice" +
                " Ichor Iron Lead Lesion Luminite Marble Mechanical Meteorite Mushroom Mythril Obsidian Orichalcum Palladium Palm" +
                " Wood Pearlsand Pearlstone Pearlwood Platinum Pumpkin Rainbow Rain Cloud Rich Mahogany Ruby Sand Sapphire" +
                " Shadewood Silver Slime Snow Cloud Soul of Blight Soul of Flight Soul of Fright Soul of Light Soul of Might Soul" +
                " of Night Soul of Sight Spooky Stone Sunplate Tin Titanium Topaz Tungsten Wood Zenith Abyss Gravel Aerialite" +
                " Astral Clay Astral Dirt Astral Astral Ice Astral Monolith Astral Sand Astral Sandstone Astral Snow Astral Stone" +
                " Auric Brimstone Slag Celestial Remains Cinderplate Cryonic Eutrophic Sand Exodium Cluster Hardened Astral Sand" +
                " Hardened Sulphurous Sandstone Navystone Novae Slug Perennial Planty Mush Scoria Sea Prism Sulphurous Sand" +
                " Sulphurous Sandstone Tenebris Uelibloom Voidstone Voidite Soul of Fraught Soul of Thought Soul of Wrought Aquaite" +
                " Brackish Clump Depth's Rock Illumite Life Quartz Lodestone Magma Mossy Gold Mossy Marine Rock Mossy Platinum Onyx" +
                " Opal Pearl Permafrost Smooth Coal Thorium Valadium Yew Wood Ancient Betsy's Brain Blizzard Bone Celestial Dark" +
                " Dutchman Elf Eye Hive Horseman's Lihzhardian Menacing Morning Bulb Razorpine Royal Slime Snot Soaring Truffle" +
                " Volatile Xeno Worm Abominable Abyssal Afflicted Anderite Aquatic Aqueous Armored Astral Beholder Blazing Bloody" +
                " Worm Calamitous Champion's Charred Corpus Crystalline Crystallized Toxic Cursed Dark Plasmic Sparkling Dormant" +
                " Draconic Drakonian Dynamo Stem Easter Etheria Fiery Fungal Gehenna Gravistarthema Ice Bound Strider Inferno Lich's" +
                " Molten Phantasmal Mutated Nebulous Ocean Omega Polarized Pyraprofaned Rotten Sacred Scourge Sea Breeze Twisting" +
                " Vampire's Venom Void of Zephyr's Heart MK2 Ambergris of Cryogen of Despair of Hope of the Frost of the Infection" +
                " of the Storm o' Plenty");
        }

        public override void SetDefaults()
        {
            item.CloneDefaults(ItemID.LifeFruit);
            item.rare = ItemRarityID.Quest;
            item.value = 0;
            item.color = Main.DiscoColor;
        }

        public override bool CanUseItem(Player player)
        {
            return player.statLifeMax >= 100 && player.GetModPlayer<ElementalHeartsPlayer>().TooLongForRealNameID <
                   ModContent.GetInstance<ElementalHeartsConfig>().MaxElementalHeartConfig;
        }

        public override bool UseItem(Player player)
        {
            player.statLifeMax2 += 69;
            player.statLife += 69;
            if (Main.myPlayer == player.whoAmI)
            {
                player.HealEffect(69, true);
            }
            player.GetModPlayer<ElementalHeartsPlayer>().TooLongForRealNameID += 1;
            return true;
        }
    }
}
