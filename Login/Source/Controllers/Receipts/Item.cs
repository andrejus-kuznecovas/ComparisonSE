namespace Login
{
    public enum Category
    {
        UNKNOWN_CATEGORY,
        DAIRY_PRODUCTS,
        BREAD_PRODUCTS,
        DRINKS,
        HOUSEHOLD_GOODS,
        PET_PRODUCTS,
        MEAT_AND_FISH,
        FRUITS_AND_VEGETABLES,
        SWEETS,
        HOUSEHOLD_CHEMICALS,
        HYGIENE_PRODUCTS,
        OTHER_GOODS
    };


    public class Item
    {
        public float price { get; set; }
        public string name { get; set; }
        public Category category { get; set; }

        // Required for XML serialization
        public Item()
        {

        }

        public Item(string name, float price)
        {
            this.price = price;
            this.name = name.ToLower();
        }

        public float getPrice()
        {
            return price;
        }

        public string GetName()
        {
            return this.name;

        }

        ~Item()
        {

        }
    }
}
