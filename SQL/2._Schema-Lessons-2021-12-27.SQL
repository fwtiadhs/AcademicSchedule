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
	 CID 		int not null
	,NAME 		nvarchar(128)
	,NAME_EN 	nvarchar(128)
	,HAS_LAB	tinyint not null default 0
	,constraint PK_X_LESSON primary key (CID)
);

insert into X_LESSON values (1101, 'Μαθηματικά Ι', 'Mathematics I');
insert into X_LESSON values (1102, 'Δομημένος Προγραμματισμός', 'Structured Programming');
insert into X_LESSON values (1103, 'Εισαγωγή στην Επιστήμη των Υπολογιστών', 'Introduction to computer science');
insert into X_LESSON values (1104, 'Ηλεκτρονική Φυσική', 'Electronic Physics');
insert into X_LESSON values (1105, 'Κυκλώματα Συνεχούς Ρεύματος', 'DC Circuits');
insert into X_LESSON values (1201, 'Μαθηματικά ΙΙ', 'Mathematics II');
insert into X_LESSON values (1202, 'Μετρήσεις και Κυκλώματα Εναλλασσόμενου Ρεύματος', 'Measurements and Alternating Current Circuits');
insert into X_LESSON values (1203, 'Τεχνική Συγγραφή, Παρουσίαση και Ορολογία Ξένης Γλώσσας', 'Technical Writing, Presentation and Terminology of Foreign Language');
insert into X_LESSON values (1204, 'Σχεδίαση Ψηφιακών Συστημάτων', 'Digital System Design');
insert into X_LESSON values (1205, 'Αντικειμενοστρεφής Προγραμματισμός', 'Object Oriented Programming');
insert into X_LESSON values (1301, 'Θεωρία Πιθανοτήτων και Στατιστική', 'Probability Theory and Statistics');
insert into X_LESSON values (1302, 'Μαθηματικά ΙΙI', 'Mathematics ΙΙI');
insert into X_LESSON values (1303, 'Επεξεργασία Σήματος', 'Signal Processing');
insert into X_LESSON values (1405, 'Γλώσσες και Τεχνολογίες Ιστού', 'Web Languages and Technologies');
insert into X_LESSON values (1305, 'Δομές Δεδομένων και Ανάλυση Αλγορίθμων', 'Data Structures and Analysis of Algorithms');
insert into X_LESSON values (1304, 'Οργάνωση και Αρχιτεκτονική Υπολογιστικών Συστημάτων', 'Computer System Organization and Architecture');
insert into X_LESSON values (1401, 'Συστήματα Διαχείρισης Βάσεων Δεδομένων', 'Database Management Systems');
insert into X_LESSON values (1402, 'Τηλεπικοινωνιακά Συστήματα', 'Telecommunication Systems');
insert into X_LESSON values (1403, 'Εισαγωγή στα Λειτουργικά Συστήματα', 'Introduction to Operating Systems');
insert into X_LESSON values (1404, 'Ηλεκτρονικά Κυκλώματα', 'Electronic Circuits');
insert into X_LESSON values (1501, 'Ασύρματες Επικοινωνίες', 'Wireless Communications');
insert into X_LESSON values (1502, 'Μικροελεγκτές', 'Microcontrollers');
insert into X_LESSON values (1503, 'Σχεδίαση Λειτουργικών Συστημάτων', 'Operating Systems Design');
insert into X_LESSON values (1504, 'Ηλεκτρονικές Διατάξεις', 'Electronic Devices');
insert into X_LESSON values (1505, 'Αλληλεπίδραση Ανθρώπου-Μηχανής', 'Human Machine Interaction');
insert into X_LESSON values (1601, 'Τεχνητή Νοημοσύνη', 'Artificial Intelligence');
insert into X_LESSON values (1602, 'Ενσωματωμένα Συστήματα', 'Embedded Systems');
insert into X_LESSON values (1611, 'Σύνθεση Ηλεκτρονικών Κυκλωμάτων', 'Synthesis of electronic circuits');
insert into X_LESSON values (1612, 'Κβαντική Υπολογιστική', 'Quantum Computing');
insert into X_LESSON values (1613, 'Μεθοδολογίες Σχεδιασμού Μικροηλεκτρονικών Κυκλωμάτων', 'Microelectronic Circuit Design Methodologies');
insert into X_LESSON values (1671, 'Μικροκυματική Τεχνολογία και Τηλεπισκόπηση', 'Microwave Technology and Remote Sensing');
insert into X_LESSON values (1672, 'Οπτοηλεκτρονική και Οπτικές Επικοινωνίες', 'Optoelectronics and Optical Communications');
insert into X_LESSON values (1673, 'Συστήματα Μέσων Μαζικής Επικοινωνίας', 'Συστήματα Μέσων Μαζικής Επικοινωνίας');
insert into X_LESSON values (1641, 'Αριθμητικές Μέθοδοι', 'Numerical Methods');
insert into X_LESSON values (1642, 'Προηγμένα Θέματα Αλληλεπίδρασης (Προγραμματισμός Κινητών Συσκευών)', 'Advanced Topics of Human Computer Interaction (Mobile Programming)');
insert into X_LESSON values (1643, 'Διοίκηση Έργων', 'Project Management');
insert into X_LESSON values (1701, 'Δίκτυα Υπολογιστών', 'Computer Networks');
insert into X_LESSON values (1702, 'Ηλεκτρονικά Ισχύος', 'Power Electronics');
insert into X_LESSON values (1711, 'Συστήματα Αυτομάτου Ελέγχου', 'Συστήματα Αυτομάτου Ελέγχου');
insert into X_LESSON values (1712, 'Αισθητήρια και Επεξεργασία Μετρήσεων', 'Sensors Signal Contitioning');
insert into X_LESSON values (1713, 'Προγραμματιζόμενοι Λογικοί Ελεγκτές', 'Προγραμματιζόμενοι Λογικοί Ελεγκτές');
insert into X_LESSON values (1714, 'Σχεδίαση Επαναπροσδιοριζόμενων Ψηφιακών Συστημάτων (FPGA)', 'Design of Reconfigurable Digital Systems (FPGAs)');
insert into X_LESSON values (1771, 'Τεχνολογίες Ήχου και Εικόνας', 'Τεχνολογίες Ήχου και Εικόνας');
insert into X_LESSON values (1741, 'Εισαγωγή στην Αναλυτική των Δεδομένων', 'Introduction to Data Analytics');
insert into X_LESSON values (1742, 'Μηχανική Λογισμικού', 'Software Engineering');
insert into X_LESSON values (1743, 'Τεχνολογία Βάσεων Δεδομένων', 'Database Technology');
insert into X_LESSON values (1744, 'Προηγμένες Αρχιτεκτονικές Υπολογιστών και Προγραμματισμός Παράλληλων Συστημάτων', 'Advanced Computer Architecture and Parallel System Programming');
insert into X_LESSON values (1802, 'Αρχές και Μέθοδοι Μηχανικής Μάθησης', 'Machine Learning Principles and Methods');
insert into X_LESSON values (1803, 'Διαδίκτυο των Πραγμάτων', 'Internet of Things');
insert into X_LESSON values (1811, 'Εφαρμογές Συστημάτων Αυτομάτου Ελέγχου', 'Εφαρμογές Συστημάτων Αυτομάτου Ελέγχου');
insert into X_LESSON values (1812, 'Μετατροπείς Ισχύος', 'Power Converters');
insert into X_LESSON values (1837, 'Μικροηλεκτρονική', 'Microelectronics');
insert into X_LESSON values (1838, 'Εφαρμογές Συστημάτων Ισχύος και ΑΠΕ', 'Application of power systems and RES');
insert into X_LESSON values (1839, 'Ηλεκτροκίνηση και Ευφυή Δίκτυα', 'Motor drives and smart grid');
insert into X_LESSON values (1801, 'Ασφάλεια Πληροφοριακών Συστημάτων', 'Information Security');
insert into X_LESSON values (1871, 'Ασύρματα Δίκτυα', 'Ασύρματα Δίκτυα');
insert into X_LESSON values (1872, 'Ειδικά Θέματα Δικτύων (CCNA) 1', 'Special Network Topics (CCNA) 1');
insert into X_LESSON values (1873, 'Προηγμένα Θέματα Δικτύων', 'Προηγμένα Θέματα Δικτύων');
insert into X_LESSON values (1874, 'Συστήματα Κινητών Επικοινωνιών', 'Mobile Communication Systems');
insert into X_LESSON values (1899, 'Ραδιοτηλεοπτική Παραγωγή', 'Ραδιοτηλεοπτική Παραγωγή');
insert into X_LESSON values (1841, 'Οργάνωση Δεδομένων και Εξόρυξη Πληροφορίας', 'Data Organization and Data Mining');
insert into X_LESSON values (1842, 'Διαδικτυακές Υπηρεσίες Προστιθέμενης Αξίας', 'Added-Value Internet Services');
insert into X_LESSON values (1948, 'Ανάπτυξη Ολοκληρωμένων Πληροφοριακών Συστημάτων', 'Development of Large Software Systems');
insert into X_LESSON values (1911, 'Εφαρμογές Ενσωματωμένων Συστημάτων', 'Applications of Embedded Systems');
insert into X_LESSON values (1912, 'Ρομποτική', 'Robotics');
insert into X_LESSON values (1913, 'ΑΠΕ και Ευφυή Ηλεκτρικά Δίκτυα', 'Renewable energy sources and smart grid');
insert into X_LESSON values (1914, 'Απτικές Διεπαφές', 'Tangible User Interfaces');
insert into X_LESSON values (1915, 'Βιοϊατρική Τεχνολογία', 'Biomedical Technology');
insert into X_LESSON values (1916, 'Συστήματα Μετρήσεων Υποβοηθούμενων από Η/Υ', 'Computer Assisted Measurement Systems');
insert into X_LESSON values (1971, 'Ασφάλεια Δικτύων και Επικοινωνιών', 'Ασφάλεια Δικτύων και Επικοινωνιών');
insert into X_LESSON values (1972, 'Δικτύωση Καθορισμένη από Λογισμικό', 'Software Defined Networking');
insert into X_LESSON values (1973, 'Ειδικά Θέματα Δικτύων (CCNA) 2', 'Special Network Topics (CCNA) 2');
insert into X_LESSON values (1974, 'Δορυφορικές Επικοινωνίες', 'Satellite Communications');
insert into X_LESSON values (1975, 'Τεχνολογία Πολυμέσων', 'Multimedia Technology');
insert into X_LESSON values (1941, 'Ανάπτυξη Διαδικτυακών Συστημάτων και Εφαρμογών', 'Development of Web Systems and Applications');
insert into X_LESSON values (1942, 'Επιχειρησιακή Έρευνα', 'Operational Research');
insert into X_LESSON values (1943, 'Ανάκτηση Πληροφοριών – Μηχανές Αναζήτησης', 'Information Retrieval – Search Engines');
insert into X_LESSON values (1944, 'Διαχείριση Συστήματος και Υπηρεσιών DBMS', 'DBMS Systems and Services Administration');
insert into X_LESSON values (1945, 'Ευφυή Συστήματα', 'Intelligent Systems');
insert into X_LESSON values (1946, 'Προηγμένα Θέματα Τεχνητής Νοημοσύνης', 'Artificial Intelligence – Advanced Topics');
insert into X_LESSON values (1947, 'Προηγμένη Μηχανική Μάθηση', 'Advanced Machine Learning');
insert into X_LESSON values (1949, 'Κατανεμημένα Συστήματα', 'Distributed Systems');
insert into X_LESSON values (1950, 'Σημασιολογικός Ιστός', 'Semantic Web');
insert into X_LESSON values (1969, 'Γραφικά Υπολογιστών', 'Computer Graphics');




X_ACADEMIC_SEMESTER


CID
202101  2020-2021   01 - Εαρινο
202102  2021-2022   02 - Χειμερινό
202201  2021-2022
202202  2022-2023

ACADEMIC_YEAR_FROM    2020
ACADEMIC_YEAR_TO	  2021


/* ===============================================================
					Lesson Classes
		
   =============================================================== */
create table X_LESSON_CLASS
(
	 CID 				int 			not null
	,ACADEMIC_SEMESTER_CID       int             not null
	,LESSON_CID			int				not null	 
	,NAME 				nvarchar(16) 	null
	,PROFESSOR_CID		int				null
	,TIME_FROM          tinyint         not null   
	,TIME_UNTIL         tinyint         not null
	,DAY_OF_WEEK        datetime        not null
	,IS_PER_TWO_WEEKS   int             not null  
	,START_WEEK         int             not null  
	,END_WEEK           int             not null
	,IS_LAB				tinyint			not null default 0
	,constraint PK_X_LESSON_CLASS 	 primary key (CID)
	,constraint FK_X_LESSON_CLASS_01 foreign key (LESSON_CID) references X_LESSON(CID)
	,constraint FK_X_LESSON_CLASS_02 foreign key (PROFESSOR_CID) references X_PROFESSOR(CID)
);
/* ===============================================================
					Student Classes
		
   =============================================================== */
create table X_STUDENT_CLASS
(
	 STUDENT_CID 		int not null
	,LESSON_CLASS_CID	int	not null	 		
	,constraint PK_X_STUDENT_CLASS 	 primary key (CID)
	,constraint FK_X_STUDENT_CLASS_01 foreign key (STUDENT_CID) references X_STUDENT(CID)
	,constraint FK_X_STUDENT_CLASS_02 foreign key (LESSON_CLASS_CID) references X_LESSON_CLASS(CID)
);