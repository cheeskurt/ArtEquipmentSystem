using WebApplication3.Models;
using WebApplication3.Areas.Identity.Data;

namespace WebApplication3.Data
{
    public static class DbInitializer
    {
        public static void Initialize(ArtEquipmentContext context)
        {
            context.Database.EnsureCreated();

            if (!context.Subject.Any())
            {
                var subjects = new Subject[]
                {
                    new Subject { SubjectName = "9APA" },
                    new Subject { SubjectName = "10APA" },
                    new Subject { SubjectName = "11APA" },
                    new Subject { SubjectName = "11APD" },
                    new Subject { SubjectName = "12APA" },
                    new Subject { SubjectName = "12APD" },
                    new Subject { SubjectName = "12PHO" },
                    new Subject { SubjectName = "13APA" },
                    new Subject { SubjectName = "13APD" },
                    new Subject { SubjectName = "13PHO" },
                };
                foreach (var s in subjects) context.Subject.Add(s);
                context.SaveChanges();
            }

            if (!context.Student.Any())
            {
                var students = new Student[]
                {
                    new Student { FirstName = "Alice",   LastName = "Smith",    Year = 13, Email = "ac183742@avcol.school.nz" },
                    new Student { FirstName = "Bob",     LastName = "Johnson",  Year = 12, Email = "ac105619@avcol.school.nz" },
                    new Student { FirstName = "Carol",   LastName = "Williams", Year = 13, Email = "ac192836@avcol.school.nz" },
                    new Student { FirstName = "David",   LastName = "Brown",    Year = 12, Email = "ac147205@avcol.school.nz" },
                    new Student { FirstName = "Eva",     LastName = "Jones",     Year = 13, Email = "ac168391@avcol.school.nz" },
                    new Student { FirstName = "Finn",    LastName = "Taylor",    Year = 9,  Email = "ac124867@avcol.school.nz" },
                    new Student { FirstName = "Grace",   LastName = "Wilson",    Year = 10, Email = "ac150294@avcol.school.nz" },
                    new Student { FirstName = "Henry",   LastName = "Martin",    Year = 11, Email = "ac176413@avcol.school.nz" },
                    new Student { FirstName = "Isla",    LastName = "Lee",       Year = 12, Email = "ac139582@avcol.school.nz" },
                    new Student { FirstName = "Jack",    LastName = "Walker",    Year = 13, Email = "ac114728@avcol.school.nz" },
                    new Student { FirstName = "Katie",   LastName = "Hall",      Year = 9,  Email = "ac195063@avcol.school.nz" },
                    new Student { FirstName = "Liam",    LastName = "Allen",     Year = 10, Email = "ac132841@avcol.school.nz" },
                    new Student { FirstName = "Mia",     LastName = "Young",     Year = 11, Email = "ac160927@avcol.school.nz" },
                    new Student { FirstName = "Noah",    LastName = "King",      Year = 12, Email = "ac108356@avcol.school.nz" },
                    new Student { FirstName = "Olivia",  LastName = "Wright",    Year = 13, Email = "ac184209@avcol.school.nz" },
                    new Student { FirstName = "Parker",  LastName = "Scott",     Year = 9,  Email = "ac127594@avcol.school.nz" },
                    new Student { FirstName = "Quinn",   LastName = "Green",     Year = 10, Email = "ac153718@avcol.school.nz" },
                    new Student { FirstName = "Ruby",    LastName = "Baker",     Year = 11, Email = "ac196402@avcol.school.nz" },
                    new Student { FirstName = "Sam",     LastName = "Adams",     Year = 12, Email = "ac141835@avcol.school.nz" },
                    new Student { FirstName = "Tessa",   LastName = "Nelson",    Year = 13, Email = "ac172069@avcol.school.nz" },
                    new Student { FirstName = "Uma",     LastName = "Carter",    Year = 9,  Email = "ac115384@avcol.school.nz" },
                    new Student { FirstName = "Victor",  LastName = "Mitchell",  Year = 10, Email = "ac188571@avcol.school.nz" },
                    new Student { FirstName = "Willow",  LastName = "Perez",     Year = 11, Email = "ac130946@avcol.school.nz" },
                    new Student { FirstName = "Xavier",  LastName = "Roberts",   Year = 12, Email = "ac164257@avcol.school.nz" },
                    new Student { FirstName = "Yasmin",  LastName = "Turner",    Year = 13, Email = "ac109683@avcol.school.nz" },
                    new Student { FirstName = "Zane",    LastName = "Phillips",  Year = 9,  Email = "ac157420@avcol.school.nz" },
                    new Student { FirstName = "Amelia",  LastName = "Campbell",  Year = 10, Email = "ac193751@avcol.school.nz" },
                    new Student { FirstName = "Blake",   LastName = "Parker",    Year = 11, Email = "ac126308@avcol.school.nz" },
                    new Student { FirstName = "Chloe",   LastName = "Evans",     Year = 12, Email = "ac175942@avcol.school.nz" },
                    new Student { FirstName = "Dylan",   LastName = "Murphy",    Year = 13, Email = "ac142617@avcol.school.nz" },
                };

                foreach (var s in students)
                    context.Student.Add(s);

                context.SaveChanges();
            }

            if (!context.Item.Any())
            {
                var items = new Item[]
                {
                    new Item { ItemName = "Canon EOS R50",              Category = Category.Cameras  },
                    new Item { ItemName = "Canon EOS 6D",               Category = Category.Cameras  },
                    new Item { ItemName = "SD Card 128GB",              Category = Category.Storage  },
                    new Item { ItemName = "Wacom Intuos Pro",           Category = Category.Tablets  },
                    new Item { ItemName = "Holbein Artists Gouache Set", Category = Category.Paints  },
                    new Item { ItemName = "Winsor & Newton Oil Set",    Category = Category.Paints   },
                    new Item { ItemName = "Canon EOS 80D", Category = Category.Cameras },
                    new Item { ItemName = "Canon EF 50mm Lens", Category = Category.Cameras },
                    new Item { ItemName = "Nikon D3500", Category = Category.Cameras },
                    new Item { ItemName = "Sony A6400", Category = Category.Cameras },
                    new Item { ItemName = "Canon Speedlite 430EX III", Category = Category.Cameras },
                    new Item { ItemName = "SD Card 64GB", Category = Category.Storage },
                    new Item { ItemName = "SD Card 256GB", Category = Category.Storage },
                    new Item { ItemName = "Portable SSD 1TB", Category = Category.Storage },
                    new Item { ItemName = "USB Flash Drive 64GB", Category = Category.Storage },
                    new Item { ItemName = "External HDD 2TB", Category = Category.Storage },
                    new Item { ItemName = "Wacom One", Category = Category.Tablets },
                    new Item { ItemName = "Huion Kamvas 13", Category = Category.Tablets },
                    new Item { ItemName = "XP-Pen Deco Pro", Category = Category.Tablets },
                    new Item { ItemName = "Wacom Intuos Small", Category = Category.Tablets },
                    new Item { ItemName = "Huion Inspiroy H950P", Category = Category.Tablets },
                    new Item { ItemName = "Acrylic Paint Set", Category = Category.Paints },
                    new Item { ItemName = "Watercolour Paint Set", Category = Category.Paints },
                    new Item { ItemName = "Oil Paint Brush Kit", Category = Category.Paints },
                    new Item { ItemName = "Canvas Pack A3", Category = Category.Paints },
                    new Item { ItemName = "Palette Knife Set", Category = Category.Paints },
                    new Item { ItemName = "Gesso Primer 1L", Category = Category.Paints },
                    new Item { ItemName = "Acrylic Brush Set", Category = Category.Paints },
                    new Item { ItemName = "Watercolour Brush Set", Category = Category.Paints },
                    new Item { ItemName = "Artist Palette Large", Category = Category.Paints },
                    new Item { ItemName = "Sketching Paint Marker Set", Category = Category.Paints },
                };
                foreach (var i in items) context.Item.Add(i);
                context.SaveChanges();
            }

            if (!context.Stock.Any())
            {
                var stocks = new Stock[]
                {
                    new Stock { ItemID = 1, StockTag = "CAM01" },
                    new Stock { ItemID = 1, StockTag = "CAM02" },
                    new Stock { ItemID = 2, StockTag = "CAM03" },
                    new Stock { ItemID = 3, StockTag = "SD01"  },
                    new Stock { ItemID = 3, StockTag = "SD02"  },
                    new Stock { ItemID = 3, StockTag = "SD03"  },
                    new Stock { ItemID = 4, StockTag = "WAC01" },
                    new Stock { ItemID = 4, StockTag = "WAC02" },
                    new Stock { ItemID = 5, StockTag = "GOU01" },
                    new Stock { ItemID = 5, StockTag = "GOU02" },
                    new Stock { ItemID = 6, StockTag = "OIL01" },
                    new Stock { ItemID = 7,  StockTag = "CAM04" },
                    new Stock { ItemID = 8,  StockTag = "LEN01" },
                    new Stock { ItemID = 9,  StockTag = "CAM05" },
                    new Stock { ItemID = 10, StockTag = "CAM06" },
                    new Stock { ItemID = 11, StockTag = "SD04"  },
                    new Stock { ItemID = 12, StockTag = "SD05"  },
                    new Stock { ItemID = 13, StockTag = "SSD01" },
                    new Stock { ItemID = 14, StockTag = "USB01" },
                    new Stock { ItemID = 15, StockTag = "HDD01" },
                    new Stock { ItemID = 16, StockTag = "TAB01" },
                    new Stock { ItemID = 17, StockTag = "TAB02" },
                    new Stock { ItemID = 18, StockTag = "TAB03" },
                    new Stock { ItemID = 19, StockTag = "TAB04" },
                    new Stock { ItemID = 20, StockTag = "TAB05" },
                    new Stock { ItemID = 21, StockTag = "PNT01" },
                    new Stock { ItemID = 22, StockTag = "PNT02" },
                    new Stock { ItemID = 23, StockTag = "PNT03" },
                    new Stock { ItemID = 24, StockTag = "PNT04" },
                    new Stock { ItemID = 25, StockTag = "PNT05" },
                    new Stock { ItemID = 26, StockTag = "PNT06" },
                    new Stock { ItemID = 27, StockTag = "PNT07" },
                    new Stock { ItemID = 28, StockTag = "PNT08" },
                    new Stock { ItemID = 29, StockTag = "PNT09" },
                    new Stock { ItemID = 30, StockTag = "PNT10" },
                    new Stock { ItemID = 31, StockTag = "PNT11" },
                };
                foreach (var st in stocks) context.Stock.Add(st);
                context.SaveChanges();
            }

            if (!context.Issue.Any())
            {
                var issues = new Issue[]
                {
                    new Issue { StudentID = 1,  SubjectID = 1, Period = 2, Reason = "Photography assignment",     DateIssued = DateTime.Parse("2025-01-15") },
                    new Issue { StudentID = 2,  SubjectID = 2, Period = 4, Reason = "Digital illustration work",  DateIssued = DateTime.Parse("2025-02-01") },
                    new Issue { StudentID = 3,  SubjectID = 3, Period = 1, Reason = "Painting assessment",        DateIssued = DateTime.Parse("2025-03-05") },
                    new Issue { StudentID = 4,  SubjectID = 1, Period = 3, Reason = "Studio shoot",              DateIssued = DateTime.Parse("2025-03-10") },
                    new Issue { StudentID = 5, SubjectID = 3, Period = 2, Reason = "Oil painting project",      DateIssued = DateTime.Parse("2025-03-15") },
                    new Issue { StudentID = 6, SubjectID = 4,  Period = 1, Reason = "Photography coursework", DateIssued = DateTime.Parse("2025-03-20") },
                    new Issue { StudentID = 7, SubjectID = 5,  Period = 2, Reason = "Painting project", DateIssued = DateTime.Parse("2025-03-21") },
                    new Issue { StudentID = 8, SubjectID = 6,  Period = 3, Reason = "Digital design task", DateIssued = DateTime.Parse("2025-03-22") },
                    new Issue { StudentID = 9, SubjectID = 7,  Period = 4, Reason = "Portfolio work", DateIssued = DateTime.Parse("2025-03-24") },
                    new Issue { StudentID = 10, SubjectID = 8,  Period = 5, Reason = "Studio session", DateIssued = DateTime.Parse("2025-03-25") },
                    new Issue { StudentID = 11, SubjectID = 9,  Period = 1, Reason = "Photography shoot", DateIssued = DateTime.Parse("2025-03-27") },
                    new Issue { StudentID = 12, SubjectID = 10, Period = 2, Reason = "Assessment work", DateIssued = DateTime.Parse("2025-03-28") },
                    new Issue { StudentID = 13, SubjectID = 1,  Period = 3, Reason = "Art practice", DateIssued = DateTime.Parse("2025-03-29") },
                    new Issue { StudentID = 14, SubjectID = 2,  Period = 4, Reason = "Digital illustration", DateIssued = DateTime.Parse("2025-03-31") },
                    new Issue { StudentID = 15, SubjectID = 3,  Period = 5, Reason = "Painting assessment", DateIssued = DateTime.Parse("2025-04-01") },
                    new Issue { StudentID = 16, SubjectID = 4,  Period = 1, Reason = "Photography project", DateIssued = DateTime.Parse("2025-04-03") },
                    new Issue { StudentID = 17, SubjectID = 5,  Period = 2, Reason = "Design portfolio", DateIssued = DateTime.Parse("2025-04-04") },
                    new Issue { StudentID = 18, SubjectID = 6,  Period = 3, Reason = "Coursework", DateIssued = DateTime.Parse("2025-04-05") },
                    new Issue { StudentID = 19, SubjectID = 7,  Period = 4, Reason = "Practical work", DateIssued = DateTime.Parse("2025-04-07") },
                    new Issue { StudentID = 20, SubjectID = 8,  Period = 5, Reason = "Research project", DateIssued = DateTime.Parse("2025-04-08") },
                    new Issue { StudentID = 21, SubjectID = 9,  Period = 1, Reason = "Camera loan", DateIssued = DateTime.Parse("2025-04-10") },
                    new Issue { StudentID = 22, SubjectID = 10, Period = 2, Reason = "Artwork development", DateIssued = DateTime.Parse("2025-04-11") },
                    new Issue { StudentID = 23, SubjectID = 1,  Period = 3, Reason = "Digital art project", DateIssued = DateTime.Parse("2025-04-12") },
                    new Issue { StudentID = 24, SubjectID = 2,  Period = 4, Reason = "Portfolio preparation", DateIssued = DateTime.Parse("2025-04-14") },
                    new Issue { StudentID = 25, SubjectID = 3,  Period = 5, Reason = "Painting task", DateIssued = DateTime.Parse("2025-04-15") },
                    new Issue { StudentID = 26, SubjectID = 4,  Period = 1, Reason = "Photography assignment", DateIssued = DateTime.Parse("2025-04-17") },
                    new Issue { StudentID = 27, SubjectID = 5,  Period = 2, Reason = "Creative project", DateIssued = DateTime.Parse("2025-04-18") },
                    new Issue { StudentID = 28, SubjectID = 6,  Period = 3, Reason = "Design work", DateIssued = DateTime.Parse("2025-04-19") },
                    new Issue { StudentID = 29, SubjectID = 7,  Period = 4, Reason = "Assessment preparation", DateIssued = DateTime.Parse("2025-04-21") },
                    new Issue { StudentID = 30, SubjectID = 8,  Period = 5, Reason = "Exhibition preparation", DateIssued = DateTime.Parse("2025-04-22") },
                };
                foreach (var iss in issues) context.Issue.Add(iss);
                context.SaveChanges();
            }

            if (!context.ItemIssue.Any())
            {
                var itemIssues = new ItemIssue[]
                {
                    new ItemIssue { IssueID = 1, StockID = 1                                                                              },
                    new ItemIssue { IssueID = 1, StockID = 4                                                                              },
                    new ItemIssue { IssueID = 2, StockID = 7,  DateReturned = DateTime.Parse("2025-02-08")                               },
                    new ItemIssue { IssueID = 3, StockID = 9,  Note = "Two colours nearly empty.", DateReturned = DateTime.Parse("2025-03-12") },
                    new ItemIssue { IssueID = 4, StockID = 2                                                                              },
                    new ItemIssue { IssueID = 4, StockID = 5                                                                              },
                    new ItemIssue { IssueID = 5, StockID = 11, Note = "Linseed oil lid cracked."                                         },
                    new ItemIssue { IssueID = 6,  StockID = 12, DateReturned = DateTime.Parse("2025-04-03") },
                    new ItemIssue { IssueID = 7,  StockID = 13, DateReturned = DateTime.Parse("2025-04-04") },
                    new ItemIssue { IssueID = 8,  StockID = 14, DateReturned = DateTime.Parse("2025-04-07") },
                    new ItemIssue { IssueID = 9,  StockID = 15, DateReturned = DateTime.Parse("2025-04-08") },
                    new ItemIssue { IssueID = 10, StockID = 16, DateReturned = DateTime.Parse("2025-04-09") },
                    new ItemIssue { IssueID = 11, StockID = 17, DateReturned = DateTime.Parse("2025-04-01") },
                    new ItemIssue { IssueID = 12, StockID = 18 },
                    new ItemIssue { IssueID = 13, StockID = 19 },
                    new ItemIssue { IssueID = 14, StockID = 20, Note = "Pen pressure issue reported" },
                    new ItemIssue { IssueID = 15, StockID = 21, DateReturned = DateTime.Parse("2025-04-18") },
                    new ItemIssue { IssueID = 16, StockID = 22 },
                    new ItemIssue { IssueID = 17, StockID = 23 },
                    new ItemIssue { IssueID = 18, StockID = 24 },
                    new ItemIssue { IssueID = 19, StockID = 25, Note = "Minor paint residue" },
                    new ItemIssue { IssueID = 20, StockID = 26 },
                    new ItemIssue { IssueID = 21, StockID = 27, DateReturned = DateTime.Parse("2025-04-28") },
                    new ItemIssue { IssueID = 22, StockID = 28 },
                    new ItemIssue { IssueID = 23, StockID = 29 },
                    new ItemIssue { IssueID = 24, StockID = 30 },
                    new ItemIssue { IssueID = 25, StockID = 31 },
                    new ItemIssue { IssueID = 26, StockID = 12 },
                    new ItemIssue { IssueID = 27, StockID = 13 },
                    new ItemIssue { IssueID = 28, StockID = 14, DateReturned = DateTime.Parse("2025-05-02") },
                    new ItemIssue { IssueID = 29, StockID = 15 },
                    new ItemIssue { IssueID = 30, StockID = 16 },
                };
                foreach (var ii in itemIssues) context.ItemIssue.Add(ii);
                context.SaveChanges();
            }
        }
    }
}