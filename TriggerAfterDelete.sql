CREATE TABLE ArchiveTeacher(Id BIGINT IDENTITY(1,1) PRIMARY KEY,TeacherId BIGINT,FirstName nchar(255),LastName nchar(255),Email nchar(255),PhoneNumber nchar(255),Password nchar(255),DeletedAt DATETIME DEFAULT GETDATE());
CREATE TABLE ArchiveAdmins(Id BIGINT IDENTITY(1,1) PRIMARY KEY,AdminId BIGINT,FirstName nchar(255),LastName nchar(255),Email nchar(255),PhoneNumber nchar(255),Password nchar(255),DeletedAt DATETIME DEFAULT GETDATE());
CREATE TABLE ArchiveStudents(Id BIGINT IDENTITY(1,1) PRIMARY KEY,StudentId BIGINT,FirstName nchar(255),UserName nchar(255),LastName nchar(255),Email nchar(255),PhoneNumber nchar(255),Password nchar(255),DeletedAt DATETIME DEFAULT GETDATE());
CREATE TABLE ArchivePaymentDetails(Id BIGINT PRIMARY KEY IDENTITY(1,1),StudentId BIGINT,CourseId BIGINT);
GO
CREATE TRIGGER AfterDeleteTeacher
on Teachers
AFTER DELETE
AS
BEGIN
DECLARE
@Id BIGINT,
@FirstName nchar(255),
@LastName nchar(255),
@Email nchar(255),
@PhoneNumber nchar(255),
@Password nchar(255)
set NOCOUNT ON;
select @Id = deleted.Id, @FirstName = deleted.FirstName,@LastName = deleted.LastName,@Email = deleted.Email,@PhoneNumber = deleted.PhoneNumber,
@Password = deleted.Password from deleted
INSERT INTO ArchiveTeacher(TeacherId,FirstName,LastName,Email,PhoneNumber,Password) VALUES(@Id,@FirstName,@LastName,@Email,@PhoneNumber,@Password)
END

GO
CREATE TRIGGER AfterDeleteAdmins
on Admins
AFTER DELETE
AS
BEGIN
DECLARE
@Id BIGINT,
@FirstName nchar(255),
@LastName nchar(255),
@Email nchar(255),
@PhoneNumber nchar(255),
@Password nchar(255)
set NOCOUNT ON;
select @Id = deleted.Id, @FirstName = deleted.FirstName,@LastName = deleted.LastName,@Email = deleted.Email,@PhoneNumber = deleted.PhoneNumber,
@Password = deleted.Password from deleted
INSERT INTO ArchiveAdmins(AdminId,FirstName,LastName,Email,PhoneNumber,Password) VALUES(@Id,@FirstName,@LastName,@Email,@PhoneNumber,@Password)
END

GO

CREATE TRIGGER AfterDeleteStudents
on Students
AFTER DELETE
AS
BEGIN
DECLARE
@Id BIGINT,
@FirstName nchar(255),
@LastName nchar(255),
@Email nchar(255),
@PhoneNumber nchar(255),
@Password nchar(255),
@UserName NCHAR(255)
set NOCOUNT ON;
select @Id = deleted.Id, @FirstName = deleted.FirstName,@LastName = deleted.LastName,@Email = deleted.Email,@PhoneNumber = deleted.PhoneNumber,
@Password = deleted.Password,@UserName = deleted.UserName from deleted
INSERT INTO ArchiveStudents(StudentId,FirstName,LastName,Email,PhoneNumber,Password,UserName) VALUES(@Id,@FirstName,@LastName,@Email,@PhoneNumber,@Password,@UserName)
END

GO
CREATE TRIGGER AfterDeletePaymentDetails
on PaymentDetails
AFTER DELETE
AS
BEGIN
DECLARE
@StudentId BIGINT,
@CourseId BIGINT
set NOCOUNT ON;
select @StudentId = deleted.StudentId,@CourseId = deleted.CourseId from deleted
INSERT INTO ArchivePaymentDetails(StudentId,CourseId) VALUES(@StudentId,@CourseId)
END