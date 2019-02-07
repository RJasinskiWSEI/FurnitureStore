namespace FurnitureStore.Models
{
    public class FurnitureItem
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public string ImageUrl { get; set; }

        public FurnitureCategory Category { get; set; }

        #region Object(s) Overrides

        public override bool Equals(object obj)
        {
            if (obj is FurnitureItem furnitureItem)
            {
                return furnitureItem.Id == this.Id;
            }

            return false;
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        #endregion
    }
}
