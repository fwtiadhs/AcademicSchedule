/* ===============================================================
					Student registered for lesson
		
   =============================================================== */
create table X_STUDENT
(
	 CID 						bigint					not null
	,SURNAME					nvarchar(128)			null
	,FIRSTNAME					nvarchar(128)			null
	
	,REG_LESSON_CLASS			nvarchar(128)			not null
	,REG_POSITION				int						null
	,STUDIES_SEMESTER			nvarchar(128)			null
	,ACADEMIC_CREDITS			int 					not null default 0
	
	,DISCORD_UID				nvarchar(128) 			null
	,DISCORD_USER				nvarchar(128) 			null
	,DISCORD_DISPLAY_NAME		nvarchar(128) 			null
	
	,PRESENCE_COUNT				tinyint 				not null default 0
	,ABSENCE_COUNT				tinyint 				null
	
	,EXAMS_TEAM 				tinyint 				not null default 1	
	,EXAMS_GROUP				tinyint					not null default 1
	,EXAMS_TEAM_PREV			tinyint 				null	
	
	
	,HAS_ID						tinyint 				not null default 0
	,HAS_IDENTITY				tinyint 				not null default 0
	,HAS_IDENTITY_DATE 			datetime 				null
	,HAS_IDENTITY_RECEIPT		nvarchar(32) 			null
	,HAS_CONSENT 				tinyint 				not null default 0
	,HAS_CONSENT_DATE 			datetime 				null
	,HAS_CONSENT_RECEIPT		nvarchar(32) 			null
	,HAS_LEARNING_DIFS			tinyint 				not null default 0 
	,HAS_LEARNING_DIFS_DATE		datetime 				null
	,HAS_LEARNING_DIFS_RECEIPT	nvarchar(32) 			null
	,NEED_EXAMS_CERT			tinyint 				not null default 0
	,NEED_EXAMS_CERT_DATE		datetime 				null
	,NEED_EXAMS_CERT_RECEIPT	nvarchar(32) 			null
	
	,constraint PK_X_STUDENT primary key (CID)
);


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