SELECT i.ItemName, s.StockTag, iti.Note
FROM ItemIssue as iti
JOIN Stock as s ON iti.StockID = s.StockID
JOIN Item as i ON s.ItemID = i.ItemID
WHERE iti.DateReturned IS NULL