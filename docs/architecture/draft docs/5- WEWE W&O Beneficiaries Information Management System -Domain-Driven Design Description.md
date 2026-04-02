
// WEWE W&O Beneficiaries Information Management System

//Domain-Driven Design Description

Translating a DDD model into a SQL ERD require s turning your Aggregate Roots into primary tables and your Entities/Value Objects into related tables or columns. 

In this schema, the `Widow` table acts as the sun in this data solar system—everything else orbits around her unique ID.

---

 Technical ERD: WEWE Widows Database



# 1. The Registration Core
* Table: `Widows` (Aggregate Root)
    * `WidowID` (PK, UUID)
    * `FullName` (String)
    * `NationalID` (String, Unique)
    * `DOB` (Date)
    * `VulnerabilityScore` (Decimal - *Value Object*)
    * `Latitude` / `Longitude` (Decimal - *Location Value Object*)
    * `CreatedAt` (Timestamp)

* Table: `Orphans` (Entity)
    * `OrphanID` (PK, UUID)
    * `WidowID` (FK) — *Links to the Household*
    * `FullName` (String)
    * `Gender` (String)
    * `SchoolStatus` (Boolean)
    * `PhotoURL` (String - *Points to Azure Blob Storage*)

---

# 2. The Support & Activity Tracker
To satisfy your requirement for a "History of Activities," we use a ledger-style table for benefits.

* Table: `Benefits`
    * `BenefitID` (PK, UUID)
    * `RecipientType` (Enum: 'Widow' or 'Orphan')
    * `RecipientID` (UUID - *Can point to WidowID or OrphanID*)
    * `BenefitType` (String: 'Food', 'Cash', 'Healthcare')
    * `Quantity` (Decimal)
    * `DateDelivered` (Timestamp)
    * `OfficerID` (FK - *The staff member who gave the benefit*)

---

# 3. The Case Management (Complaints/Remarks)
* Table: `Cases`
    * `CaseID` (PK, UUID)
    * `WidowID` (FK)
    * `Subject` (String)
    * `Description` (Text)
    * `Status` (Enum: 'Open', 'In-Progress', 'Resolved')
    * `Priority` (Enum: 'Low', 'Medium', 'High')

* Table: `CaseLogs` (History of Remarks)
    * `LogID` (PK)
    * `CaseID` (FK)
    * `StaffRemark` (Text)
    * `Timestamp` (Timestamp)

---

 How this maps to your Technology Stack

| Layer 							| Technical Implementation |

| Mobile (.NET MAUI) 						| Uses SQLite with an identical schema to allow for seamless "Offine -> Cloud" data mapping. |
| Backend (Azure Functions) 					| Receives the ODK XML, iterates through the `<orphan_repeat>` tags, and performs multiple `INSERT` statements into the `Widows` and `Orphans` tables within a single transaction.	|
| Reporting (Power BI) 						| Connects to the `Benefits` and `CaseLogs` tables to generate the "History of Activities" visualization. |

---

 Implementation Tip for the Team
Since you are using Python Azure Functions, I recommend using an ORM (Object-Relational Mapper) like SQLAlchemy. This allows your "Track A" developer to define these tables as Python classes, which makes it much easier to handle the complex logic of nested ODK data.





