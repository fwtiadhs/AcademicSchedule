/* ===============================================================
					Example table
					
   =============================================================== */
create table X_EXAMPLE
(
	 ID							int	identity			not null
	,CODE						nvarchar(64)			not null
	,DESCR						nvarchar(128)			null
	,ENTRY_TIME					datetime				null
	,AMOUNT						float					null
	,VALUE_INT					int						null
	,IS_ACTIVE					tinyint 				not null default 0
	,constraint PK_X_EXAMPLE primary key (ID)
);

insert into X_EXAMPLE (CODE, DESCR, ENTRY_TIME, AMOUNT, VALUE_INT, IS_ACTIVE)
		values ('Α', 'Άλφα', '2021-10-31', 39.99, 1000, 1);
		
		
insert into X_EXAMPLE (CODE, DESCR, ENTRY_TIME, AMOUNT, VALUE_INT, IS_ACTIVE)
		values ('Β', 'Βήτα', '2021-10-31', 19.99, 1001, 1);

insert into X_EXAMPLE (CODE, DESCR, ENTRY_TIME, AMOUNT, VALUE_INT, IS_ACTIVE)
		values ('Γ', 'Γάμμα', '2021-10-31', 29.99, 1002, 1);		
		
/*
-- Delete cloned records and reset autoincrement to 3
delete from X_EXAMPLE where ID > 3;
DBCC CHECKIDENT (X_EXAMPLE, RESEED, 3);
*/

/* ===============================================================
					Dimitris table
					
   =============================================================== */
   
   create table X_DIMITRIS
(
	 ID							int	identity			not null
	,CODE						nvarchar(64)			not null
	,MOVIE						nvarchar(128)			null
	,constraint PK_X_DIMITRIS primary key (ID)
);
   
   insert into X_DIMITRIS (CODE, MOVIE)
		values ('Α', 'Interstellar');
		
		
   insert into X_DIMITRIS (CODE, MOVIE)
		values ('B', 'The Martian');
		
		
		
		
/* ===============================================================
					Eleni's table
					
   =============================================================== */
    create table X_ELENI (
   ID							int	identity			not null
  ,CODE						    nvarchar(64)          not null
  ,LESSON                       nvarchar(128)         null
  ,constraint PK_X_ELENI primary key(ID)
  );

  insert into X_ELENI(CODE,LESSON)
		values ('1625-1744','Προηγμένες Αρχιτεκτονικές Υπολογιστών και Προγραμματισμός Παράλληλων Συστημάτων');
  
  
  insert into X_ELENI(CODE,LESSON)
		values ('1625-1771','Τεχνολογίες Ήχου και Εικόνας');

  insert into X_ELENI(CODE,LESSON)
		values ('1625-1950','Σημασιολογικός Ιστός');
   
   
   
   
   
   
   
   
   
   