
WEWE Widows Database App - Modular Multi-Tier" architecture Description
//WEWE Widows Database App requires a "Modular Multi-Tier" architecture

//Modular Multi-Tier" architecture Description

Designing the WEWE Widows Database App requires a "Modular Multi-Tier" architecture. 

- One of the component of the architecture is the ODK protocol for field data collection and 
- Microsoft 365 (Teams) for the back-office,
- Note, our design must prioritize Data Synchronization and Security.

To distribute this among ourselvies effectively, I will divide the project into Functional Tracks. 

Architectural design
The sprint distribution strategy

1. Solution Architecture Schematic

The system flows from the field to the dashboard:

* Planning Tier:
		1.  Define the Excel Sheet (XLSForm): Finalize exactly which columns are needed for Widows vs. Orphans.
		2.  Azure Setup: Create the Resource Group and the Entra ID (Azure AD) App Registrations.

* Field Tier: 	.NET MAUI app (or any mobile dev framework) captures data (Widow + Orphan loops) using ODK-logic and saves locally to SQLite.

* Logic Tier: Azure Functions (Python) receives ODK XML, parses the hierarchy, and saves it to a central database.

* Management Tier: A Web App (React/Blazor) embedded in Microsoft Teams for case management (complaints/remarks).

* Intelligence Tier: Power BI pulls from the database for historical reporting.



2. Development Tracks & Sprint Distribution

Break the team into three specialized tracks. This allows parallel development without "stepping on toes."

	Track A: The Data & Logic Architect (Backend)

		*Focus: Azure Functions, SQL Database, ODK Parsing.

		* Sprint 1: Design the SQL Schema (Tables for Widows, Orphans, Benefits, and Case Logs).

		* Sprint 2: Build the Python Azure Function to receive and parse the ODK XML submission.

		* Sprint 3: Develop the "History" API that aggregates all activities (benefits + cases) for a specific beneficiary.

	Track B: The Mobile Developer (Frontend - Field)

		*Focus: .NET MAUI, ODK Protocol, Offline Storage.

		* Sprint 1: Build the UI for Widow/Orphan registration with the "Repeat Group" logic.

		* Sprint 2: Implement SQLite local storage and the "Pending Sync" queue.
	
		* Sprint 3: Integrate MSAL (Microsoft Login) and the multipart-upload service to the Azure Function.

	Track C: The Management & BI Developer (Admin)

		*Focus: Web App, Teams Integration, Power BI.
		
		* Sprint 1: Build the Case Management Web App (listing complaints/remarks).
		
		* Sprint 2: Embed the Web App as a Tab in Microsoft Teams and set up Teams Notifications for new registrations.
		
		* Sprint 3: Design the Power BI Dashboard for historical trends and benefit distribution.



 3. Data Object Relationship

	To manage the "History of Activities" (Item 5 in our list), our database should follow this structure:

Entity			Primary Key			Foreign Key			Purpose 

Widow 			Widow_ID`			None				Personal & Status data. 

Orphan 			Orphan_ID`			'Widow_ID`			Dependent data tied to a Widow.

Benefit			`Benefit_ID`			`Widow_ID`/`Orphan_ID`		Records cash, food, or health aid given.



Case			`Case_ID`			`Widow_ID`			Complaints, remarks, or follow-ups. 



