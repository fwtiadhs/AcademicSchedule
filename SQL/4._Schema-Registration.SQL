/* ===============================================================
					Student Registration
		
   =============================================================== */
create table X_STUDENT_REG
(
	 
	 ID					int				identity not null
	,STUDENT_CID	    bigint 			not null
	,LESSON_CID 		int 			not null
	,CLASS_NUMBER		tinyint			not null default 0
	,SEMESTER_CODE		nvarchar(4)		not null default 'SP21'
	,REG_DATETIME		datetime		not null
	,REG_RECEIPT		nvarchar(36)	not null
	,IS_ACTIVE			tinyint			not null default 1
	,IS_FINALIZED	 	tinyint 		not null default 0
	,constraint PK_X_STUDENT_REG primary key (ID)
	,constraint FK_X_STUDENT_REG_01 foreign key (STUDENT_CID) references X_STUDENT(CID)
	,constraint FK_X_STUDENT_REG_02 foreign key (LESSON_CID) references X_LESSON(CID)
);