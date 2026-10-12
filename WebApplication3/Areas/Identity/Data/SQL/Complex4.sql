SELECT s.SubjectName, COUNT(i.IssueID) as "Issue History"
FROM Subject as s
LEFT JOIN Issue as i
ON  s.SubjectID = i.SubjectID
GROUP BY s.SubjectName