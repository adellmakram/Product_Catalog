namespace ProductCatalog.DAL;

public class CategorySeeding
{
    public static List<Category> categoryList = new List<Category>
        {
            new Category{CategoryId=1,CategoryName="Home and Garden"},
            new Category{CategoryId=2,CategoryName="Kitchen Appliances"},
            new Category{CategoryId=3,CategoryName="Books and Magazines"},
            new Category{CategoryId=4,CategoryName="Health and Beauty"},
            new Category{CategoryId=5,CategoryName="Fashion Accessories"},
            new Category{CategoryId=6,CategoryName="Sports Gear"},
            new Category{CategoryId=7,CategoryName="Furniture"},
            new Category{CategoryId=8,CategoryName="Electronics"},
            new Category{CategoryId=9,CategoryName="Apparel"},
            new Category{CategoryId=10,CategoryName="Footwear"},
        };
}
