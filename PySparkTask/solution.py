from pyspark.sql.functions import col, collect_list

class ProductCombinator:
    def __init__(self, sparkSession):
        self.sparkSession = sparkSession
    
    def getAllProductsAndCategories(self, productsData, categoriesData):
        result = productsData.join(categoriesData, "Category", "left")\
            .groupby("Product")\
            .agg(collect_list("Category")\
            .alias("Categories"))
        return result