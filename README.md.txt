# Gaia Project - פלטפורמה אפליקטיבית לביצוע פעולות מסוגים שונים

## תיאור

פרויקט זה מהווה פלטפורמה גנרית לביצוע פעולות שונות, החל מחישובים מתמטיים פשוטים ועד לעיבוד מידע מורכב. הפרויקט מורכב משני חלקים עיקריים:

*   **API (שרת):** מספק את הפונקציונליות לביצוע הפעולות.
*   **WinForms Client (לקוח):** ממשק משתמש גרפי המאפשר אינטרקציה עם ה-API.

## טכנולוגיות

*   C#
*   .NET
*   Entity Framework Core
*   WinForms

## הוראות התקנה והפעלה

1.  **שינוי מחרוזת החיבור למסד הנתונים:**
    *   בקובץ `appsettings.json` (או במקום בו מוגדרת מחרוזת החיבור), יש לשנות את ערך ה-`ConnectionString` למסד הנתונים שלכם.
    *   ודאו ששם השרת, שם מסד הנתונים והרשאות הגישה תואמים את ההגדרות שלכם.

2.  **יצירת מסד הנתונים:**
    *   הפעילו את SQL Server Management Studio (SSMS) או כלי ניהול מסדי נתונים אחר.
    *   צרו מסד נתונים חדש בשם `GaiaCalculator` (או שם אחר שתבחרו).
    *   הרצו את שאילתות ה-SQL הבאות כדי ליצור את הטבלאות ולאכלס אותן בנתונים ראשוניים:

```sql
CREATE TABLE Operations (
    OperationId INT PRIMARY KEY IDENTITY(1,1),
    Name VARCHAR(50) NOT NULL,
    Description VARCHAR(255),
    ParameterAType VARCHAR(20) NOT NULL,
    ParameterBType VARCHAR(20) NOT NULL
);

CREATE TABLE OperationHistory (
    HistoryId INT PRIMARY KEY IDENTITY(1,1),
    OperationId int FOREIGN KEY REFERENCES Operations(OperationId),
    FieldA NVARCHAR(MAX),
    FieldB NVARCHAR(MAX),
    Result NVARCHAR(MAX),
    CalculationTime DATETIME DEFAULT GETDATE()
);

INSERT INTO Operations (Name, Description, ParameterAType, ParameterBType) VALUES
('Add', 'Adds two numbers', 'NUMBER', 'NUMBER'),
('Concat', 'Concatenates strings', 'STRING', 'STRING'),
('Divide', 'Divide two numbers', 'NUMBER', 'NUMBER'),
('Subtract', 'Subtract two numbers', 'NUMBER', 'NUMBER'),
('Multiply', 'Multiply two numbers', 'NUMBER', 'NUMBER');