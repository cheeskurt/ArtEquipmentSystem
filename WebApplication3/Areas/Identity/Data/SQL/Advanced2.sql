SELECT ItemIssueID, IssueID, StockTag, Note, DateReturned  
FROM ItemIssue as iti, Stock as st
WHERE iti.StockID = st.StockID
 