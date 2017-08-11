CREATE TABLE Departments (
`name`			varchar(25),
`code` 			char(4),
`building` 		varchar(10),
`room`			varchar(6),
`phone`			int(10),
`college`		varchar(10),
`instructorWIN`	int(9),
PRIMARY KEY (`code`)
);

CREATE TABLE Courses (
`courseNum`		varchar(10),
`name`			varchar(20),
`desc`			varchar(100),
`credits`		int(1),
`deptCode`		char(4),
PRIMARY KEY (`courseNum`),
CONSTRAINT FK_courseDept FOREIGN KEY (`deptCode`) REFERENCES Departments(`code`)
);

CREATE TABLE Sections (
`instructorWIN`	int(9),
`semester`		int(1),
`year`			int(4),
`courseNum`		varchar(10),
`sectionNum`	int(5),
PRIMARY KEY (`sectionNum`),
CONSTRAINT FK_courseNum FOREIGN KEY (`courseNum`) REFERENCES Courses(`courseNum`)
);

CREATE TABLE Instructors (
`win`			int(9),
`fName`			varchar(15),
`lName`			varchar(15),
`sectionNum`	int(5),
PRIMARY KEY (`win`),
CONSTRAINT FK_winDept FOREIGN KEY (`win`) REFERENCES Departments(`instructorWIN`),
CONSTRAINT FK_sectionNum FOREIGN KEY (`sectionNum`) REFERENCES Sections(`instructorWIN`)
);

CREATE TABLE Students (
`win`			int(9),
`fName`			varchar(15),
`lname`			varchar(15),
`phone`			int(10),
`birthday`		date DEFAULT NULL,
`sex`			char(1),
`level`			varchar(10),
`major`			int(4),				# This corresponds to Department code
`homeDept`		int(4),				# Also corresponds to Department code
PRIMARY KEY (`win`),
CONSTRAINT FK_homeDept FOREIGN KEY (`homeDept`) REFERENCES Departments(`code`)
);

CREATE TABLE StudentAddress (
`win`			int(9),
`curCity`		varchar(10),
`curState`		char(2),			# 2char state abbrev.
`curZIP`		int(9),
`permCity`		varchar(10),
`permState`		char(2),
`permZIP`		int(9),
PRIMARY KEY (`win`),
CONSTRAINT FK_studentWIN FOREIGN KEY (`win`) REFERENCES Students(`win`)
);

CREATE TABLE Enrolled (
`win`			int(9),
`sectionNum`	int(5),
`grade`			varchar(2),
PRIMARY KEY (`win`),
CONSTRAINT FK_studentWIN FOREIGN KEY (`win`) REFERENCES Students(`win`)
);
