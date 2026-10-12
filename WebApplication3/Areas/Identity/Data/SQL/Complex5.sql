SELECT i.ItemName, COUNT(iti.ItemIssueID) as "Times Lent"
FROM Item as i
JOIN Stock as s ON i.ItemID = s.ItemID
JOIN ItemIssue as iti ON s.StockID = iti.StockID
GROUP BY i.ItemName
HAVING COUNT(iti.ItemIssueID) >= 5