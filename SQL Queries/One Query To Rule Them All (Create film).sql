CREATE PROCEDURE sp_CreateFilms
@Title NVARCHAR(100),
@Description NVARCHAR(500),
@ReleaseYear NVARCHAR(20),
@RentalDuration INT,
@RentalRate INT,
@Rating VARCHAR(10),
@ActorFirstName NVARCHAR(50),
@ActorLastName NVARCHAR(50),
@CategoryId INT,
@FilmId INT OUT,
@ActorId INT OUT
AS 
BEGIN
 INSERT INTO tbl_Film 
 VALUES(
	@Title,
	@Description,
	@ReleaseYear,
	@RentalDuration,
	@RentalRate,
	@Rating)
SELECT @FilmId = SCOPE_IDENTITY()
INSERT INTO tbl_actor
VALUES
(@ActorFirstName,@ActorLastName,GETDATE())
SELECT @ActorId = SCOPE_IDENTITY()
INSERT INTO tbl_filmCategory
VALUES
(@FilmId,@CategoryId,GETDATE())
INSERT INTO tbl_filmActor
VALUES
(@ActorId,@FilmId,GETDATE())
END