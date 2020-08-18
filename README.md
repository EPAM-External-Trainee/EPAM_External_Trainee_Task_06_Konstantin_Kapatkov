# .NET Summer 2020 (external)
## Task 06. Database_development
### Task
* Develop a normalized database for storing information about results of passing the session by students, if you know:
1. full name, gender, date of birth, student's group;
2. names and dates are known for each group;
3. exams and credits in each specific session;
4. the results of the session are known for each student.
* Implement a class hierarchy and ORM for this database.
* Implement CRUD using ADO and reflection.
* Provide for saving the session results for each session to an xlsx file group as a table.
* For each session, output an xlsx pivot table with average/minimum / maximum score for each group.
* Create a list of students to be expelled, grouped by group.
* When generating reports, consider the possibility of various sorts.
* Develop unit tests for testing the generated classes.
* Develop SQL scripts for rapid deployment and filling in DBMS data.
### Comments
*  Use LINQ to Objects to process data in collections.
* Ensure that code injection is not possible.
* The database must be normalized.
* SOLID (SPR is must have).
* When implementing a DAO (ORM), use a singleton and a factory (factory method).
