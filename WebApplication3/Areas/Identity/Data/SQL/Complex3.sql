SELECT s.FirstName, s.LastName, COUNT(i.IssueID) as "Issue History"
FROM Student as s
LEFT JOIN Issue as i
ON s.StudentID = i.StudentID
GROUP BY s.FirstName, s.LastName
ORDER BY "Issue History" DESC