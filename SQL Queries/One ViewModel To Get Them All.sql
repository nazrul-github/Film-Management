SELECT * FROM tbl_actor;
SELECT * FROM tbl_Category;
SELECT * FROM tbl_Film;
SELECT * FROM tbl_filmCategory;
SELECT * FROM tbl_filmActor;

CREATE PROCEDURE sp_GetAllFilmCategoryActor
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
ORDER BY title,release_year
END