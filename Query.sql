select fs.productid, count(1)
  FROM (WITH firstSale AS (SELECT s.salesid,
                                  s.customerid,
                                  s.productid,
                                  s.datetime,
                                  ROW_NUMBER() OVER(PARTITION BY s.customerid ORDER BY s.datetime ASC) AS rk
                             FROM Sales s)
         SELECT s.*
           FROM firstSale s
          WHERE s.rk = 1) fs
          GROUP BY fs.productid
