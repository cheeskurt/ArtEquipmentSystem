SELECT i.ItemName, COUNT(s.StockID) as Stock
FROM Item as i
LEFT JOIN Stock as s
ON i.ItemID = s.ItemID
GROUP BY i.ItemName