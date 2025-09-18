namespace Domain.Entities
{
    public class DetailFavorite
    {
        public int Id { get; set; }
        public int FavoriteId { get; set; }
        public int ProductId { get; set; }

        public Favorite Favorite { get; set; } = null!;
        public Product Product { get; set; } = null!;
    }
}