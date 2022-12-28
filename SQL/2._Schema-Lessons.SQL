/* ===============================================================
					Professors for the lesson
		
   =============================================================== */
create table X_PROFESSOR
(
	 CID 			int 				not null
	,FULL_NAME 		nvarchar(128)		not null
	,constraint PK_X_PROFESSOR primary key (CID)
);

insert into X_PROFESSOR values (1, 'Παντελής Ι. Καπλάνογλου');
insert into X_PROFESSOR values (2, 'Δημήτρης Αμανατιάδης');
insert into X_PROFESSOR values (3, 'Αντώνης Σιδηρόπουλος');
insert into X_PROFESSOR values (4, 'Αδαμίδης Παναγιώτης');
insert into X_PROFESSOR values (5, 'Βίτσας Βασίλης');
insert into X_PROFESSOR values (6, 'Δεληγιάννης Ιγνάτιος');
insert into X_PROFESSOR values (7, 'Δέρβος Δημήτριος');
insert into X_PROFESSOR values (8, 'Διαμαντάρας Κωνσταντίνος');
insert into X_PROFESSOR values (9, 'Ηλιούδης Χρήστος');
insert into X_PROFESSOR values (10, 'Καζακόπουλος Αριστοτέλης');
insert into X_PROFESSOR values (11, 'Κιοσκερίδης Ιορδάνης');
insert into X_PROFESSOR values (12, 'Κώστογλου Βασίλης');
insert into X_PROFESSOR values (13, 'Μαρμόρκος Ιωάννης');
insert into X_PROFESSOR values (14, 'Μπάμνιος Γεώργιος');
insert into X_PROFESSOR values (15, 'Παπακώστας Δημήτριος');
insert into X_PROFESSOR values (16, 'Σαλαμπάσης Μιχάλης');
insert into X_PROFESSOR values (17, 'Σταμάτης Δημοσθένης');
insert into X_PROFESSOR values (18, 'Χατζημίσιος Περικλής');
insert into X_PROFESSOR values (19, 'Αντωνίου Ευστάθιος');
insert into X_PROFESSOR values (20, 'Γουλιάνας Κωνσταντίνος');
insert into X_PROFESSOR values (21, 'Ιωαννίδου Μελίνα');
insert into X_PROFESSOR values (22, 'Ιωσηφίδης Αθανάσιος');
insert into X_PROFESSOR values (23, 'Κεραμόπουλος Ευκλείδης');
insert into X_PROFESSOR values (24, 'Σπάσος Μιχαήλ');
insert into X_PROFESSOR values (25, 'Τζέκης Παναγιώτης');
insert into X_PROFESSOR values (26, 'Κωτσάκης Ρήγας');
insert into X_PROFESSOR values (27, 'Σαπουνίδης Θεοδόσιος');
insert into X_PROFESSOR values (28, 'Χατζόπουλος Αργύριος');
insert into X_PROFESSOR values (29, 'Γιακουμής Άγγελος');
insert into X_PROFESSOR values (30, 'Μανάβης Χρήστος');
insert into X_PROFESSOR values (31, 'Αμανατιάδης Δημήτριος');
insert into X_PROFESSOR values (32, 'Αμπατζής Ζαφείριος');
insert into X_PROFESSOR values (33, 'Ασδρέ Κατερίνα');
insert into X_PROFESSOR values (34, 'Καλλιδοπούλου Άννα-Ελένη');
insert into X_PROFESSOR values (35, 'Τσιακμάκης Κυριάκος');
insert into X_PROFESSOR values (36, 'Μανάβης Χρήστος');




/* ===============================================================
					Lessons
		
   =============================================================== */
create table X_LESSON
(
	 CID 			 int   	 		not null
	,SEMESTER_NUMBER tinyint 		not null 
	,NAME 			 nvarchar(128)
	,NAME_EN 		 nvarchar(128)
	,HAS_LAB   	 	 tinyint  		not null default 0
	
	,constraint PK_X_LESSON primary key (CID)
);

insert into X_LESSON values (1101,1,'Μαθηματικά Ι', 'Mathematics I',0);
insert into X_LESSON values (1102,1,'Δομημένος Προγραμματισμός', 'Structured Programming',1);
insert into X_LESSON values (1103,1,'Εισαγωγή στην Επιστήμη των Υπολογιστών', 'Introduction to computer science',0);
insert into X_LESSON values (1104,1,'Ηλεκτρονική Φυσική', 'Electronic Physics',0);
insert into X_LESSON values (1105,1,'Κυκλώματα Συνεχούς Ρεύματος', 'DC Circuits',0);
insert into X_LESSON values (1201,2,'Μαθηματικά ΙΙ', 'Mathematics II',0);
insert into X_LESSON values (1202,2,'Μετρήσεις και Κυκλώματα Εναλλασσόμενου Ρεύματος', 'Measurements and Alternating Current Circuits',1);
insert into X_LESSON values (1203,2,'Τεχνική Συγγραφή, Παρουσίαση και Ορολογία Ξένης Γλώσσας', 'Technical Writing, Presentation and Terminology of Foreign Language',0);
insert into X_LESSON values (1204,2,'Σχεδίαση Ψηφιακών Συστημάτων', 'Digital System Design',1);
insert into X_LESSON values (1205,2,'Αντικειμενοστρεφής Προγραμματισμός', 'Object Oriented Programming',1);
insert into X_LESSON values (1301,3,'Θεωρία Πιθανοτήτων και Στατιστική', 'Probability Theory and Statistics',0);
insert into X_LESSON values (1302,3,'Μαθηματικά ΙΙI', 'Mathematics ΙΙI',0);
insert into X_LESSON values (1303,3,'Επεξεργασία Σήματος', 'Signal Processing',0);
insert into X_LESSON values (1405,3,'Γλώσσες και Τεχνολογίες Ιστού', 'Web Languages and Technologies',1);
insert into X_LESSON values (1305,3,'Δομές Δεδομένων και Ανάλυση Αλγορίθμων', 'Data Structures and Analysis of Algorithms',0);
insert into X_LESSON values (1304,4,'Οργάνωση και Αρχιτεκτονική Υπολογιστικών Συστημάτων', 'Computer System Organization and Architecture',1);
insert into X_LESSON values (1401,4,'Συστήματα Διαχείρισης Βάσεων Δεδομένων', 'Database Management Systems',1);
insert into X_LESSON values (1402,4,'Τηλεπικοινωνιακά Συστήματα', 'Telecommunication Systems',0);
insert into X_LESSON values (1403,4,'Εισαγωγή στα Λειτουργικά Συστήματα', 'Introduction to Operating Systems',1);
insert into X_LESSON values (1404,4,'Ηλεκτρονικά Κυκλώματα', 'Electronic Circuits',0);
insert into X_LESSON values (1501,5, 'Ασύρματες Επικοινωνίες', 'Wireless Communications',1);
insert into X_LESSON values (1502,5, 'Μικροελεγκτές', 'Microcontrollers',0);
insert into X_LESSON values (1503,5, 'Σχεδίαση Λειτουργικών Συστημάτων', 'Operating Systems Design',0);
insert into X_LESSON values (1504,5, 'Ηλεκτρονικές Διατάξεις', 'Electronic Devices',1);
insert into X_LESSON values (1505,5, 'Αλληλεπίδραση Ανθρώπου-Μηχανής', 'Human Machine Interaction',0);
insert into X_LESSON values (1601,6, 'Τεχνητή Νοημοσύνη', 'Artificial Intelligence',0);
insert into X_LESSON values (1602,6, 'Ενσωματωμένα Συστήματα', 'Embedded Systems',1);
insert into X_LESSON values (1611,6, 'Σύνθεση Ηλεκτρονικών Κυκλωμάτων', 'Synthesis of electronic circuits',1);
insert into X_LESSON values (1612,6, 'Κβαντική Υπολογιστική', 'Quantum Computing',0);
insert into X_LESSON values (1613,6, 'Μεθοδολογίες Σχεδιασμού Μικροηλεκτρονικών Κυκλωμάτων', 'Microelectronic Circuit Design Methodologies',0);
insert into X_LESSON values (1671,6, 'Μικροκυματική Τεχνολογία και Τηλεπισκόπηση', 'Microwave Technology and Remote Sensing',0);
insert into X_LESSON values (1672,6, 'Οπτοηλεκτρονική και Οπτικές Επικοινωνίες', 'Optoelectronics and Optical Communications',1);
insert into X_LESSON values (1673,6, 'Συστήματα Μέσων Μαζικής Επικοινωνίας', 'Συστήματα Μέσων Μαζικής Επικοινωνίας',1);
insert into X_LESSON values (1641,6, 'Αριθμητικές Μέθοδοι', 'Numerical Methods',0);
insert into X_LESSON values (1642,6, 'Προηγμένα Θέματα Αλληλεπίδρασης (Προγραμματισμός Κινητών Συσκευών)', 'Advanced Topics of Human Computer Interaction (Mobile Programming)',0);
insert into X_LESSON values (1643,6, 'Διοίκηση Έργων', 'Project Management',0);
insert into X_LESSON values (1701,7, 'Δίκτυα Υπολογιστών', 'Computer Networks',1);
insert into X_LESSON values (1702,7, 'Ηλεκτρονικά Ισχύος', 'Power Electronics',0);
insert into X_LESSON values (1711,7, 'Συστήματα Αυτομάτου Ελέγχου', 'Συστήματα Αυτομάτου Ελέγχου',0);
insert into X_LESSON values (1712,7, 'Αισθητήρια και Επεξεργασία Μετρήσεων', 'Sensors Signal Contitioning',1);
insert into X_LESSON values (1713,7, 'Προγραμματιζόμενοι Λογικοί Ελεγκτές', 'Προγραμματιζόμενοι Λογικοί Ελεγκτές',1);
insert into X_LESSON values (1714,7, 'Σχεδίαση Επαναπροσδιοριζόμενων Ψηφιακών Συστημάτων (FPGA)', 'Design of Reconfigurable Digital Systems (FPGAs)',1);
insert into X_LESSON values (1771,7, 'Τεχνολογίες Ήχου και Εικόνας', 'Τεχνολογίες Ήχου και Εικόνας',1);
insert into X_LESSON values (1741,7, 'Εισαγωγή στην Αναλυτική των Δεδομένων', 'Introduction to Data Analytics',0);
insert into X_LESSON values (1742,7, 'Μηχανική Λογισμικού', 'Software Engineering',0);
insert into X_LESSON values (1743,7, 'Τεχνολογία Βάσεων Δεδομένων', 'Database Technology',0);
insert into X_LESSON values (1744,7, 'Προηγμένες Αρχιτεκτονικές Υπολογιστών και Προγραμματισμός Παράλληλων Συστημάτων', 'Advanced Computer Architecture and Parallel System Programming',0);
insert into X_LESSON values (1802,8, 'Αρχές και Μέθοδοι Μηχανικής Μάθησης', 'Machine Learning Principles and Methods',0);
insert into X_LESSON values (1803,8,'Διαδίκτυο των Πραγμάτων', 'Internet of Things',0);
insert into X_LESSON values (1811,8,'Εφαρμογές Συστημάτων Αυτομάτου Ελέγχου', 'Εφαρμογές Συστημάτων Αυτομάτου Ελέγχου',1);
insert into X_LESSON values (1812,8,'Μετατροπείς Ισχύος', 'Power Converters',1);
insert into X_LESSON values (1837,8,'Μικροηλεκτρονική', 'Microelectronics',1);
insert into X_LESSON values (1838,8,'Εφαρμογές Συστημάτων Ισχύος και ΑΠΕ', 'Application of power systems and RES',1);
insert into X_LESSON values (1839,8,'Ηλεκτροκίνηση και Ευφυή Δίκτυα', 'Motor drives and smart grid',1);
insert into X_LESSON values (1801,8,'Ασφάλεια Πληροφοριακών Συστημάτων', 'Information Security',0);
insert into X_LESSON values (1871,8,'Ασύρματα Δίκτυα', 'Ασύρματα Δίκτυα',0);
insert into X_LESSON values (1872,8,'Ειδικά Θέματα Δικτύων (CCNA) 1', 'Special Network Topics (CCNA) 1',1);
insert into X_LESSON values (1873,8,'Προηγμένα Θέματα Δικτύων', 'Προηγμένα Θέματα Δικτύων',0);
insert into X_LESSON values (1874,8,'Συστήματα Κινητών Επικοινωνιών', 'Mobile Communication Systems',0);
insert into X_LESSON values (1899,8,'Ραδιοτηλεοπτική Παραγωγή', 'Ραδιοτηλεοπτική Παραγωγή',1);
insert into X_LESSON values (1841,8,'Οργάνωση Δεδομένων και Εξόρυξη Πληροφορίας', 'Data Organization and Data Mining',0);
insert into X_LESSON values (1842,8,'Διαδικτυακές Υπηρεσίες Προστιθέμενης Αξίας', 'Added-Value Internet Services',0);
insert into X_LESSON values (1948,8,'Ανάπτυξη Ολοκληρωμένων Πληροφοριακών Συστημάτων', 'Development of Large Software Systems',0);
insert into X_LESSON values (1911,9,'Εφαρμογές Ενσωματωμένων Συστημάτων', 'Applications of Embedded Systems',1);
insert into X_LESSON values (1912,9,'Ρομποτική', 'Robotics',0);
insert into X_LESSON values (1913,9,'ΑΠΕ και Ευφυή Ηλεκτρικά Δίκτυα', 'Renewable energy sources and smart grid',0);
insert into X_LESSON values (1914,9,'Απτικές Διεπαφές', 'Tangible User Interfaces',0);
insert into X_LESSON values (1915,9,'Βιοϊατρική Τεχνολογία', 'Biomedical Technology',0);
insert into X_LESSON values (1916,9,'Συστήματα Μετρήσεων Υποβοηθούμενων από Η/Υ', 'Computer Assisted Measurement Systems',1);
insert into X_LESSON values (1971,9,'Ασφάλεια Δικτύων και Επικοινωνιών', 'Ασφάλεια Δικτύων και Επικοινωνιών',0);
insert into X_LESSON values (1972,9,'Δικτύωση Καθορισμένη από Λογισμικό', 'Software Defined Networking',0);
insert into X_LESSON values (1973,9,'Ειδικά Θέματα Δικτύων (CCNA) 2', 'Special Network Topics (CCNA) 2',1);
insert into X_LESSON values (1974,9,'Δορυφορικές Επικοινωνίες', 'Satellite Communications',0);
insert into X_LESSON values (1975,9,'Τεχνολογία Πολυμέσων', 'Multimedia Technology',0);
insert into X_LESSON values (1941,9,'Ανάπτυξη Διαδικτυακών Συστημάτων και Εφαρμογών', 'Development of Web Systems and Applications',0);
insert into X_LESSON values (1942,9,'Επιχειρησιακή Έρευνα', 'Operational Research',0);
insert into X_LESSON values (1943,9,'Ανάκτηση Πληροφοριών – Μηχανές Αναζήτησης', 'Information Retrieval – Search Engines',0);
insert into X_LESSON values (1944,9,'Διαχείριση Συστήματος και Υπηρεσιών DBMS', 'DBMS Systems and Services Administration',0);
insert into X_LESSON values (1945,9,'Ευφυή Συστήματα', 'Intelligent Systems',0);
insert into X_LESSON values (1946,9,'Προηγμένα Θέματα Τεχνητής Νοημοσύνης', 'Artificial Intelligence – Advanced Topics',0);
insert into X_LESSON values (1947,9,'Προηγμένη Μηχανική Μάθηση', 'Advanced Machine Learning',0);
insert into X_LESSON values (1949,9,'Κατανεμημένα Συστήματα', 'Distributed Systems',0);
insert into X_LESSON values (1950,9,'Σημασιολογικός Ιστός', 'Semantic Web',0);
insert into X_LESSON values (1969,9,'Γραφικά Υπολογιστών', 'Computer Graphics',0);








/* ===============================================================
					Lesson Classes
		
   =============================================================== */
create table X_LESSON_CLASS
(
	 CID 				int 			not null
	,ACADEMIC_SEMESTER_CID  int         not null
	,LESSON_CID			int				not null	 
	,NAME 				nvarchar(16) 	null
	,PROFESSOR_CID		int				null
	,TIME_FROM          tinyint         not null
	,TIME_UNTIL         tinyint         not null
	,DAY_OF_WEEK        datetime        not null
	,IS_PER_TWO_WEEKS   int             not null 
	,IS_LAB             tinyint         not null default 0
	,START_WEEK         int             not null
	,END_WEEK           int             not null
	,constraint PK_X_LESSON_CLASS 	 primary key (CID)
	,constraint FK_X_LESSON_CLASS_01 foreign key (LESSON_CID) references X_LESSON(CID)
	,constraint FK_X_LESSON_CLASS_02 foreign key (PROFESSOR_CID) references X_PROFESSOR(CID)
	,constraint FK_X_LESSON_CLASS_03 foreign key (ACADEMIC_SEMESTER_CID) references X_ACADEMIC_SEMESTER(CID)
);
/* ===============================================================
					Student Classes
		
   =============================================================== */
create table X_STUDENT_CLASS

(
     CID                int 	not null
	,IS_SPRING          tinyint not null default 1
	,IS_WINTER          tinyint not null default 0
	,STUDENT_CID 		int 	not null
	,LESSON_CLASS_CID	int		not null	 		
	,constraint PK_X_STUDENT_CLASS 	 primary key (CID)
	,constraint FK_X_STUDENT_CLASS_01 foreign key (STUDENT_CID) references X_STUDENT(CID)
	,constraint FK_X_STUDENT_CLASS_02 foreign key (LESSON_CLASS_CID) references X_LESSON_CLASS(CID)
);

/* ===============================================================
					Academic Semester 
		
   =============================================================== */
create table X_ACADEMIC_SEMESTER
(
    CID                      int              not null
    ACADEMIC_YEAR_FROM       int              not null
    ACADEMIC_YEAR_TO         int              not null
   ,constraint PK_X_ACADEMIC_SEMESTER primary key (CID)
 );



========================================================================================================================================





/* ===============================================================
                    Lesson Year 

   =============================================================== */

create table X_LESSON_YEAR
(
    CID                      int             not null
   ,LESSON_CID               int             not null
   ,ACADEMIC_YEAR_CID        int             not null
   ,ACADEMIC_SEMESTER        nvarchar(16)    not null
   ,LESSON_CLASS_START_WEEK  int             not null
   ,LESSON_CLASS_END_WEEK    int             not null
   ,constraint PK_X_LESSON_YEAR primary key (CID)
   ,constraint FK_X_LESSON_YEAR foreign key (LESSON_CID) references X_LESSON(CID)
);