using Microsoft.EntityFrameworkCore;
using newsfeed.nicolasbonora.entities;
using newsfeed.nicolasbonora.entities.Relation_entities;

namespace newsfeed.nicolasbonora.repository
{
    public class NewsFeedContext : DbContext
    {
        public NewsFeedContext(DbContextOptions<NewsFeedContext> options)
        : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Feed>()
                .HasMany(f => f.Posts)
                .WithOne(p => p.Feed);

            modelBuilder.Entity<UserFeed>()
                .HasKey(uf => new { uf.UserId, uf.FeedId });
            modelBuilder.Entity<UserFeed>()
                .HasOne(uf => uf.User)
                .WithMany(u => u.FollowingFeeds)
                .HasForeignKey(uf => uf.UserId);
            modelBuilder.Entity<UserFeed>()
                .HasOne(uf => uf.Feed)
                .WithMany(f => f.Subscribers)
                .HasForeignKey(uf => uf.FeedId);

            modelBuilder.Entity<User>()
                .HasOne(u => u.Feed)
                .WithOne(f => f.Owner)
                .HasForeignKey<Feed>(f => f.OwnerId);
        }

        public DbSet<Feed> Feeds { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserFeed> UserFeeds { get; set; }

    }
}
