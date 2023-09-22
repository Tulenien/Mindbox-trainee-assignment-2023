import unittest
from compare_dataframes import *
from solution import *
from pyspark.sql import SparkSession
from pyspark.sql.types import StructType, StructField, StringType, ArrayType
import os
import sys

def createProductsWithEmptyCategoriesDataframes(spark):
        products_data = [("Product1", ""),
                         ("Product2", "")]
        products_schema = ["Product", "Category"]
        products_df = spark.createDataFrame(products_data, products_schema)

        categories_data = [("Category1", "Description1"),
                           ("Category2", "Description2")]
        categories_schema = ["Category", "Description"]
        categories_df = spark.createDataFrame(categories_data, categories_schema)
        return products_df, categories_df

def createProductsWithOneCategory(spark):
        products_data = [("Product1", "Category1"),
                         ("Product2", "Category2")]
        products_schema = ["Product", "Category"]
        products_df = spark.createDataFrame(products_data, products_schema)

        categories_data = [("Category1", "Description1"),
                           ("Category2", "Description2")]
        categories_schema = ["Category", "Description"]
        categories_df = spark.createDataFrame(categories_data, categories_schema)
        return products_df, categories_df

def createProductsWithMultipleCategories(spark):
        products_data = [("Product1", "Category1"),
                         ("Product1", "Category2"),
                         ("Product2", "Category1"),
                         ("Product2", "Category3"),]
        products_schema = ["Product", "Category"]
        products_df = spark.createDataFrame(products_data, products_schema)

        categories_data = [("Category1", "Description1"),
                           ("Category2", "Description2"),
                           ("Category3", "Description3")]
        categories_schema = ["Category", "Description"]
        categories_df = spark.createDataFrame(categories_data, categories_schema)
        return products_df, categories_df

def createDataframeWithNoProducts(spark):
        products_data = spark.sparkContext.emptyRDD()
        products_schema = StructType([
            StructField('Product', StringType(), True),
            StructField('Category', StringType(), True)
        ])
        products_df = products_data.toDF(products_schema)

        categories_data = [("Category1", "Description1"),
                           ("Category2", "Description2")]
        categories_schema = ["Category", "Description"]
        categories_df = spark.createDataFrame(categories_data, categories_schema)
        return products_df, categories_df

def createProductsWithEmptyAndOneCategoryDataframes(spark):
        products_data = [("Product1", ""),
                         ("Product2", "Category1")]
        products_schema = ["Product", "Category"]
        products_df = spark.createDataFrame(products_data, products_schema)

        categories_data = [("Category1", "Description1"),
                           ("Category2", "Description2")]
        categories_schema = ["Category", "Description"]
        categories_df = spark.createDataFrame(categories_data, categories_schema)
        return products_df, categories_df

class Testing(unittest.TestCase):
    os.environ['PYSPARK_PYTHON'] = sys.executable
    os.environ['PYSPARK_DRIVER_PYTHON'] = sys.executable
    spark = SparkSession.builder.getOrCreate()
    combinator = ProductCombinator(spark)

    def test_productsHaveEmptyCategory(self):
        products_df, categories_df = createProductsWithEmptyCategoriesDataframes(self.spark)
        expectedData = [("Product1", ['']), 
                        ("Product2", [''])]
        expectedSchema = ["Product", "Categories"]
        expected = self.spark.createDataFrame(expectedData, expectedSchema)
        actual = self.combinator.getAllProductsAndCategories(products_df, categories_df)
        self.assertTrue(compareDF(actual, expected))

    def test_productsHaveOneCategory(self):
        products_df, categories_df = createProductsWithOneCategory(self.spark)
        expectedData = [("Product1", ["Category1"]), 
                        ("Product2", ["Category2"])]
        expectedSchema = ["Product", "Categories"]
        expected = self.spark.createDataFrame(expectedData, expectedSchema)
        actual = self.combinator.getAllProductsAndCategories(products_df, categories_df)
        self.assertTrue(compareDF(actual, expected))

    def test_productsHaveMultipleCategories(self):
        products_df, categories_df = createProductsWithMultipleCategories(self.spark)
        expectedData = [("Product1", ["Category1", "Category2"]), 
                        ("Product2", ["Category1", "Category3"])]
        expectedSchema = ["Product", "Categories"]
        expected = self.spark.createDataFrame(expectedData, expectedSchema)
        actual = self.combinator.getAllProductsAndCategories(products_df, categories_df)
        self.assertTrue(compareDF(actual, expected))

    def test_noProducts(self):
        products_df, categories_df = createDataframeWithNoProducts(self.spark)
        expectedData = self.spark.sparkContext.emptyRDD()
        expectedSchema = StructType([
            StructField('Product', StringType(), True),
            StructField('Categories', ArrayType(StringType()), True)
        ])
        expected = expectedData.toDF(expectedSchema)
        actual = self.combinator.getAllProductsAndCategories(products_df, categories_df)
        self.assertTrue(compareDF(actual, expected))

    def test_emptyCategoryAndCategoryOnOneProduct(self):
        products_df, categories_df = createProductsWithEmptyAndOneCategoryDataframes(self.spark)
        expectedData = [("Product1", ['']), 
                        ("Product2", ["Category1"])]
        expectedSchema = ["Product", "Categories"]
        expected = self.spark.createDataFrame(expectedData, expectedSchema)
        actual = self.combinator.getAllProductsAndCategories(products_df, categories_df)
        self.assertTrue(compareDF(actual, expected))

if __name__ == '__main__':
    unittest.main()