USE [My_Database]
GO
/****** Object:  StoredProcedure [dbo].[sp_GetAllFilmCategoryActor]    Script Date: 01-Dec-19 11:49:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[sp_GetAllFilmCategoryActor]
AS
BEGIN
SELECT F.film_id,F.title,F.description,F.release_year,F.rating, C.name AS CategoryName,
A.first_name AS FirstName, A.last_name AS LastName
FROM tbl_Film AS F
JOIN tbl_filmCategory AS FC ON
F.film_id = FC.film_id
JOIN tbl_Category AS C
ON C.category_id = FC.category_id
JOIN tbl_filmActor AS FA
ON FA.film_id = F.film_id
JOIN tbl_actor AS A
ON A.actor_id = FA.actor_id
ORDER BY F.film_id DESC
END