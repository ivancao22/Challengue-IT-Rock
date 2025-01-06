--creo tabla Tasks con id autoincremental y PK, title obligatorio(podria ser una unique key pero no se especifico se debe ser unico o no en la documentacion), 
--isCompletes con default en 0 y el resto no tienen un valor requerido

CREATE TABLE Tasks
(
ID INT PRIMARY KEY IDENTITY(1,1),
Title varchar(150) not null,
Description varchar(MAX) null,       
IsCompleted BIT DEFAULT 0,    
DueDate DATETIME null  
)
