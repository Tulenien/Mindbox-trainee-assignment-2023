import os
import sys
from solution import *
from pyspark.sql import SparkSession

if __name__ == '__main__':
    os.environ['PYSPARK_PYTHON'] = sys.executable
    os.environ['PYSPARK_DRIVER_PYTHON'] = sys.executable

    spark = SparkSession.builder.getOrCreate()

    combinator = ProductCombinator(spark)
    
    products_data = [("Product1", "Category1"),
                    ("Product2", "Category2"),
                    ("Product3", "Category1"),
                    ("Product4", "Category3"),
                    ("Product4", "Category2"),
                    ("Product5", None)]
    products_schema = ["Product", "Category"]
    products_df = spark.createDataFrame(products_data, products_schema)

    # Создаем DataFrame для категорий (опционально)
    categories_data = [("Category1", "Description1"),
                    ("Category2", "Description2"),
                    ("Category3", "Description3")]
    categories_schema = ["Category", "Description"]
    categories_df = spark.createDataFrame(categories_data, categories_schema)

    result_df = combinator.getAllProductsAndCategories(products_df, categories_df)

    result_df.show(truncate=False)
    print("The end")