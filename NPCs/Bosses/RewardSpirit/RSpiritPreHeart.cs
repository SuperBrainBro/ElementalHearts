using ElementalHearts.Items.Consumables.Special;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace ElementalHearts.NPCs.Bosses.RewardSpirit
{
    public class RSpiritPreHeart : ModProjectile
    {
        public override string Texture => "ElementalHearts/Items/Consumables/Special/HeartofSlaughter";

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Heart");
        }

        public override void SetDefaults()
        {
            projectile.width = mod.GetTexture(Texture.Replace("ElementalHearts/", "")).Width;
            projectile.height = mod.GetTexture(Texture.Replace("ElementalHearts/", "")).Height;
            projectile.hostile = true;
            projectile.friendly = false;
            projectile.damage = 1;
            projectile.tileCollide = false;
        }

        public override void AI()
        {
            projectile.ai[1]++;
            if (projectile.ai[1] > 500)
            {
                projectile.Kill();
            }
            projectile.rotation += 0.01f;
        }

        public override void ModifyHitPlayer(Player target, ref int damage, ref bool crit)
        {
            damage = 1;
            if (!target.HasItem(ItemType<HeartofSlaughter>()))
            {
                target.QuickSpawnItem(ItemType<HeartofSlaughter>());
            }
            target.GetModPlayer<ElementalHeartsPlayerSpecial>().heartCatched = true;
        }
    }
}
