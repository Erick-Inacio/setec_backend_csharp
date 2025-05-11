UPDATE users SET Role = 1 WHERE Role = 'ADMIN';
UPDATE users SET Role = 2 WHERE Role = 'STUDENT';
UPDATE users SET Role = 3 WHERE Role = 'COMISSION';
UPDATE users SET Role = 4 WHERE Role = 'SPEAKER';

UPDATE users set Relationship = 1 WHERE Relationship = 'EXALUNO';
UPDATE users set Relationship = 2 WHERE Relationship = 'ALUNO';
UPDATE users set Relationship = 3 WHERE Relationship = 'PROFESSOR';
UPDATE users set Relationship = 4 WHERE Relationship = 'COORDENADOR';
UPDATE users set Relationship = 5 WHERE Relationship = 'SEMRELACAO';

ALTER TABLE users MODIFY COLUMN Role INT;
ALTER TABLE users MODIFY COLUMN Relationship INT;