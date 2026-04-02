//PLEASE READ PROBLEM STATEMENT FIRST BEFORE PROCEEDING TO READ THIS.

// XLSFORM for the excel sheet is descrbed below


The XLSForm is the critical first step because it defines the data structure that both our mobile app and our database will follow. 

Below is a sample XLSForm structure for our WEWE Widows Database App. See folder - odk - widow_registration_v1.xlsx

The design will allow us to capture widows and their dependent orphans. 

This structure directly mirrors the DDD model and ERD schema I will discuss with you guys later.

1. The `survey` or emuneration Sheet

This sheet defines the fields and logic for the data capture. 

Note how the `begin_repeat` block handles the "One-to-Many" relationship between a widow and her orphans.


type			name		label				hint				constraint			required

start 			start_time
deviceid		device_id
geopoint 		location	Capture GPS Location		Ensure you are outdoors.					yes
text			widow_name	Full Name of Widow										yes
date			widow_dob 	Date of Birth			. < today()							yes 
select_one status	marital_status	Marital Status											yes
integer			orphan_count	How many orphans(household?)	Enter 0 if none.		. >= 0 				yes
begin_repeat		orphan_repeat	Orphan Details											
text			orphan_name	Full Name of Child										yes
select_one gender	orphan_gender	Gender												yes
integer			orphan_age	Age of Child							. < 18 				yes 
select_one school	in_school	Currently in school?										yes
image			orphan_photo	Take a photo of the child									no
end_repeat		
acknowledge		confirm_data	I certify this data is correct.									 yes
	



2. The `choices` Sheet

This defines the dropdown options (Value Objects in DDD).

list_name		name		label

status			widowed		Widowed
status			divorced	Divorced/Separated
gender			male		Male
gender			female		Female 
school			yes 		Yes
school			no		No



3. How it Maps to our ERD and DDD (I will share with you the document for them)

This Excel sheet acts as a blueprint for the developers:

* For the Database (ERD): 

Every `name` in the Excel sheet (e.g., `widow_name`, `orphan_age`) becomes a column in your SQL tables. 

The `orphan_repeat` block tells the backend developer to create a separate table for `Orphans` linked by a `WidowID`.


* For the Mobile App (.NET MAUI) or any other Mobile app framework: 

The app uses this form to generate the UI. (Whatever you design in the excel becomes the form the Mobile app will display to capture input, even though the excel can also be allow to use for data input)

In the field, officers will see a dynamic list of questions that match these columns exactly.


* For the DDD Model: (PLEASE DO A SELF STUDY TO UNDERSTAND DOMAIN-DRIVEN DESIGN MODELLING WORKS)

The top-level questions belong to the WIDOW AGGREGATE ROOT, while the repeat group represents the ORPHAN ENTITY.


4. Why this sequence works for our Sprints

* Sprint 1 Start: 

Once our team agrees on this Excel sheet, the Backend Developer can build the SQL tables, and 

the Mobile Developer can start building the .NET MAUI (ANY OTHER MOBILE DEV FRAMEWORK) "Interpreter" to load this form.


* Integration: 

Since we are using Azure Functions and Microsoft Teams, we will use Power BI to report on those specific columns (e.g., "Total Orphans in School").


5. Settings" sheet for this XLSForm:



