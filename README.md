# 📚 Project — Library Management System

A console-based C# application .

---
## 🎒 Class Structure 

| Class | Type | Responsibility |
| ----------- | ----------- | ----------- |
|  `LibraryItem` | Abstract Base Class | Shared properties: `Id`, `Title`, `AddedDate`. Abstract method: `GetInfo()` | 
| `Book` | Inherits `LibraryItem` + `ISearchable` | Adds `Author`, `Year`, `Genre`, `IsAvailable`. Overrides `GetInfo()`, implements `MatchesQuery()` | 
| `Member` | Implements `ISearchable` | Properties: `Id`, `Name`, `Email`, `JoinDate`, `Book[] BorrowedBooks`. Implements `MatchesQuery()` | 
| `PremiumMember` | Inherits `Member` | Adds `MaxBorrowLimit` (10), `LoanDays` (30). Overrides `GetInfo()` | 
| `BorrowRecord` | Data Class | Properties: `Id`, `Book`, `Member`, `BorrowDate`,`DateTime? ReturnDate`. Method: `IsLate()` | 
| `Library` | Service Class | Holds all data arrays. Contains all business logic methods |
| `ISearchable` | Interface | Contract: `bool MatchesQuery(string query)` |
---


## 🎁 Application Features
| # | Feature | Description |
| ----------- | ----------- | ----------- |
| 1 | Add a Book | Prompt for title, author, year, genre. Auto-assign Id. Validate no empty fields. |
| 2 | Register a Member | Prompt for name and email. Auto-set `JoinDate` to `DateTime.Now`. Support Regular and Premium types. |
| 3 | Borrow a Book | Input book Id + member Id. Check `IsAvailable`. Create `BorrowRecord`. Throw exception if unavailable. |
| 4 | Return a Book | Input book Id. Find open `BorrowRecord`, set `ReturnDate`, flip `IsAvailable` to true. |
| 5 | Search the Catalog | Input any string. Call `MatchesQuery()` on all books and members. Case-insensitive. Print results labeled by type. |
| 6 | View Available Books | Filter books where `IsAvailable == true`. Print via `GetInfo()`. Show message if none available. |
| 7 | Member Borrowing History | Input member Id. Print all their `BorrowRecord`s with book title, borrow date, and return status. |
| 8 | Late Return Report | Call `IsLate()` on all open records. Print member name, book title, borrow date, days overdue. |
---
## 📂 Folder Structure

```
LibraryManagementSystem/
├── Models/
│   ├── LibraryItem.cs       ← abstract base class
│   ├── Book.cs              ← inherits LibraryItem, implements ISearchable
│   ├── Member.cs            ← implements ISearchable
│   ├── PremiumMember.cs     ← inherits Member
│   └── BorrowRecord.cs      ← transaction record
├── Interfaces/
│   └── ISearchable.cs
├── Services/
│   └── Library.cs           ← all business logic
└── Program.cs               ← menu loop + user I/O
```
### ☺️ Implementation Steps

1. **ISearchable interface** — define `bool MatchesQuery(string query)`
2. **LibraryItem** — abstract class with `Id`, `Title`, `AddedDate`, and abstract `GetInfo()`
3. **Book** — extend `LibraryItem`, add properties, implement `GetInfo()` and `MatchesQuery()`
4. **Member + PremiumMember** — build `Member` with `BorrowedBooks[]`, then extend with `PremiumMember`
5. **BorrowRecord** — properties + `IsLate()` using `(DateTime.Now - BorrowDate).TotalDays > 14`
6. **Library** — three arrays + three counters, implement all 8 methods one at a time
7. **Program.cs** — `do-while` menu loop, parse input, call Library methods, wrap in `try/catch`
8. **Seed Data + Test** — add `SeedData()`, test every feature with valid and invalid input
