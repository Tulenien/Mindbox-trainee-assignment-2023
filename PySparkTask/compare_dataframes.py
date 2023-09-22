def compareDF(df1, df2):
    return df1.subtract(df2).count() == 0 and df2.subtract(df1).count() == 0
