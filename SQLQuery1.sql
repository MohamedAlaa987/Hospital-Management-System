create database hosptial;
use hosptial;
CREATE TABLE employee
(
  EID INT  NOT NULL,
  mname VARCHAR(255) NOT NULL,
  lname VARCHAR(255) NOT NULL,
  fname VARCHAR(255) NOT NULL,
  type VARCHAR(255) NOT NULL,
  email VARCHAR(255) NOT NULL,
  gender VARCHAR(255) NOT NULL,
  birthdate VARCHAR(255) NOT NULL,
  salary INT NOT NULL,
  address VARCHAR(255) NOT NULL,
  phone VARCHAR(255) not null,
  DID INT NOT NULL,
  PRIMARY KEY (EID),
);
alter table employee add FOREIGN KEY (DID) REFERENCES department(DID)
CREATE TABLE department
(
  DID INT   NOT NULL,
  dname VARCHAR(255) NOT NULL,
  EID INT NOT NULL,
  PRIMARY KEY (DID),
);
alter table department add FOREIGN KEY (EID) REFERENCES employee(EID)

CREATE TABLE doctor
(
  qualification VARCHAR(255) NOT NULL,
  EID INT NOT NULL,
  PRIMARY KEY (EID),
  FOREIGN KEY (EID) REFERENCES employee(EID)
);

CREATE TABLE nurse
(
  numberofpatient INT NOT NULL,
  EID INT NOT NULL,
  PRIMARY KEY (EID),
  FOREIGN KEY (EID) REFERENCES employee(EID)
);


CREATE TABLE patient
(
  bloodtype VARCHAR(255) NOT NULL,
  pname VARCHAR(255) NOT NULL,
  birthdate VARCHAR(255) NOT NULL,
  phone VARCHAR(255) NOT NULL,
  gender VARCHAR(255) NOT NULL,
  PID INT  NOT NULL,
  email VARCHAR(255) NOT NULL,
  address VARCHAR(255) NOT NULL,
  disease varchar(255),
  DEID INT NOT NULL,
  SEID INT NOT NULL,
  PRIMARY KEY (PID),
  FOREIGN KEY (DEID) REFERENCES doctor(EID),
  FOREIGN KEY (SEID) REFERENCES nurse(EID)
);

CREATE TABLE bill
(
  billcost int NOT NULL,
  mtcost int NOT NULL,
  tcost int NOT NULL,
  BID INT NOT NULL,
  rcost int NOT NULL,
  billdate VARCHAR(255) NOT NULL,
  PID INT NOT NULL,
  PRIMARY KEY (BID,PID),
  FOREIGN KEY (PID) REFERENCES patient(PID)
);

CREATE TABLE treatment
(
  TID INT  NOT NULL,
  tname VARCHAR(255) NOT NULL,
  tcost int NOT NULL,
  PID INT NOT NULL,
  PRIMARY KEY (TID),
  FOREIGN KEY (PID) REFERENCES patient(PID)
);


CREATE TABLE room
(
  RID INT NOT NULL,
  rname VARCHAR(255) NOT NULL,
  rtype VARCHAR(255) NOT NULL,
  rcost int NOT NULL,
  PID INT NOT NULL,
  PRIMARY KEY (RID),
  FOREIGN KEY (PID) REFERENCES patient(PID)
);

CREATE TABLE Medicaltest
(
  mtname VARCHAR(255) NOT NULL,
  mtcost int NOT NULL,
  MTID INT NOT NULL,
  PID INT NOT NULL,
  PRIMARY KEY (MTID),
  FOREIGN KEY (PID) REFERENCES patient(PID)
);







insert into employee(EID,fname,mname,lname,gender,birthdate,type,salary,phone,email,address,DID) values(1,'Roxanne',' O ',' Rodriguez ','female','6/4/1986','doctor',4729,'434-420-9223','aileen.donnel@gmail.com','865 Queens Lane,Lynchburg, Virginia(VA)',1)
insert into employee(EID,fname,mname,lname,gender,birthdate,type,salary,phone,email,address,DID) values(2,'Rosa','F','Pippin','female','2/20/1992','doctor',1746,' 412-728-5901','van_gleichn@yahoo.com','628 Stuart Street,Brave, Pennsylvania(PA)',2)
insert into employee(EID,fname,mname,lname,gender,birthdate,type,salary,phone,email,address,DID) values(3,'Brandy',' R ','Turner','female','2/9/1991','doctor',3940,'617-803-8173','hanna.schaef@yahoo.com','2920 Cedar Lane, Cambridge, Massachusetts(MA)',3)
insert into employee(EID,fname,mname,lname,gender,birthdate,type,salary,phone,email,address,DID) values(4,'Jack',' E', 'Smalley','male','5/14/1988','doctor',4490,'339-298-2748','noah.emar9@hotmail.com',' 4312 Metz Lane,Woburn, Massachusetts(MA),',4)
insert into employee(EID,fname,mname,lname,gender,birthdate,type,salary,phone,email,address,DID) values(5,'Larry','E','Ruffin','male','8/18/1985','doctor',3409,'786-897-0418','gerardo2000@yahoo.com','1820 Poplar Lane,Miami, Florida(FL)',5)
insert into employee(EID,fname,mname,lname,gender,birthdate,type,salary,phone,email,address,DID) values(6,'Jeffery', 'F' ,'Snyder','male','7/17/1982','doctor',2486,'215-275-6145','berneice1984@gmail.com','4873 Horseshoe Lane,Philadelphia, Pennsylvania(PA)',6)
insert into employee(EID,fname,mname,lname,gender,birthdate,type,salary,phone,email,address,DID) values(7,'Waldo','S',' Crownover','male','1/29/1970','doctor',3712,' 908-385-4176','sonya.erdma5@hotmail.com ','3744 Finwood Road, Dunellen, New Jersey(NJ)',7)
insert into employee(EID,fname,mname,lname,gender,birthdate,type,salary,phone,email,address,DID) values(8,'Max','M','Blount','male','12/26/1962','doctor',5933,'919-243-5826','tony.blic6@gmail.com','4105 Dola Mine Road,Clayton, North Carolina(NC)',8)
insert into employee(EID,fname,mname,lname,gender,birthdate,type,salary,phone,email,address,DID) values(9,'Richard','J','Zinn','male','10/1/1986','doctor',6208,' 612-300-4331','ubaldo1986@yahoo.com','4771 Sardis Station,Minneapolis, Minnesota(MN)',9)
insert into employee(EID,fname,mname,lname,gender,birthdate,type,salary,phone,email,address,DID) values(10,'Carlos','B','Taft','male','1/2/1983','doctor',4496,'203-722-0969','laurine_kut@gmail.com','4833 Asylum Avenue, Norwalk, Connecticut(CT)',10)
insert into employee(EID,fname,mname,lname,gender,birthdate,type,salary,phone,email,address,DID) values(11,'Nicolas','P','Parkinson','male','9/25/1991','secretary',5116,'218-979-7172','maybelle_reing@gmail.com','1008 Orchard Street,Bloomington, Minnesota(MN)',12)
insert into employee(EID,fname,mname,lname,gender,birthdate,type,salary,phone,email,address,DID) values(12,'Richard','S','Taylor','male','11/7/1955','secretary',5829,'620-406-8694','kelly1985@gmail.com','1036 Preston Street,Meade, Kansas(KS)',12)
insert into employee(EID,fname,mname,lname,gender,birthdate,type,salary,phone,email,address,DID) values(13,'Joseph','B','Landry','male','12/19/1999','secretary',4709,'857-452-3422','winnifred.wintheis@hotmail.com','2386 Hinkle Lake Road,Charlestown, Massachusetts(MA)',12)
insert into employee(EID,fname,mname,lname,gender,birthdate,type,salary,phone,email,address,DID) values(14,'Pedro','L','Legros','male','3/31/1967','engineer',4648,'405-546-0159','larry.farre@yahoo.com','4723 Musgrave Street,Oklahoma City, Oklahoma(OK',13)
insert into employee(EID,fname,mname,lname,gender,birthdate,type,salary,phone,email,address,DID) values(15,'Hal','K','Franks','male','1/25/1972','engineer',4709,'520-609-2455','zola_hamil4@yahoo.com','87 Parkway Drive,Tucson, Arizona(AZ)',13)
insert into employee(EID,fname,mname,lname,gender,birthdate,type,salary,phone,email,address,DID) values(16,'Wilbert','D','Smith','male','3/12/1992','technician',4957,'414-391-0934','marisa2005@gmail.com','4885 Johnny Lane,Milwaukee, Wisconsin(WI)',14)
insert into employee(EID,fname,mname,lname,gender,birthdate,type,salary,phone,email,address,DID) values(17,'Paul','M','Skipper','male','6/26/1985','technician',3084,'305-314-2275','zella2009@yahoo.com','4415 Travis Street,Riviera Beach, Florida(FL)',14)
insert into employee(EID,fname,mname,lname,gender,birthdate,type,salary,phone,email,address,DID) values(18,'Ted','T','Brown','male','3/30/1971','nurse',2535,'217-710-1641','jana.ritchi3@hotmail.com','873 Hog Camp Road,Mokena, Illinois(IL)',11)
insert into employee(EID,fname,mname,lname,gender,birthdate,type,salary,phone,email,address,DID) values(19,'John','L','Wise','male','8/12/1997','nurse',3305,'415-220-3735','mikel1990@yahoo.com','898 Larry Street,San Francisco, California(CA)',11)
insert into employee(EID,fname,mname,lname,gender,birthdate,type,salary,phone,email,address,DID) values(20,'Jame','A','Enright','male','3/7/1974','nurse',5227,' 770-374-0865','eladio1994@yahoo.com','1355 Heavner Avenue,Marietta, Georgia(GA)',11)
insert into employee(EID,fname,mname,lname,gender,birthdate,type,salary,phone,email,address,DID) values(21,'Melvin','J','Foutz','male','11/2/1995','nurse',3409,'773-747-5297','emely.konopels@gmail.com','4713 Oakmound Drive, Chicago, Illinois(IL)',11)
insert into employee(EID,fname,mname,lname,gender,birthdate,type,salary,phone,email,address,DID) values(22,'James','D','Evans','male','12/24/1995','nurse',4232,'417-989-5873','arne.boga9@gmail.com','3739 Chandler Drive,Gainesville, Missouri(MO)',11)
insert into employee(EID,fname,mname,lname,gender,birthdate,type,salary,phone,email,address,DID) values(23,'Erik','C','Moore','male','8/16/1973','nurse',1510,'678-467-2542','vincenza_les@yahoo.com','4845 Adonais Way,Alpharetta, Georgia(GA)',11)
insert into employee(EID,fname,mname,lname,gender,birthdate,type,salary,phone,email,address,DID) values(24,'Ralph','E','Irizarry','male','7/31/1974','nurse',5574,'608-850-7824','patricia.fish@gmail.com','1970 Irish Lane,Waunakee, Wisconsin(WI)',11)
insert into employee(EID,fname,mname,lname,gender,birthdate,type,salary,phone,email,address,DID) values(25,'Kyle','T','Faller','male','11/4/1978','nurse',6608,'813-486-5459','alexandro_wa@hotmail.com',' 2481 Wilkinson Court,Cape Coral, Florida(FL)',11)
insert into employee(EID,fname,mname,lname,gender,birthdate,type,salary,phone,email,address,DID) values(26,'James','S','Neff','male','10/4/1983','nurse',6988,' 504-813-9573','jodie_durga6@yahoo.com','588 Paul Wayne Haggerty Road, Kenner, Louisiana(LA)',11)
insert into employee(EID,fname,mname,lname,gender,birthdate,type,salary,phone,email,address,DID) values(27,'Dave','J','Dewberry','male','7/27/1981','nurse',2536,'904-945-9648', 'glenda2006@gmail.com','4003 Cherry Tree Drive,Jacksonville, Florida(FL)',11)
insert into employee(EID,fname,mname,lname,gender,birthdate,type,salary,phone,email,address,DID) values(28,'John','G','Sanchez','male','12/17/1971','nurse',4253,'805-908-1840','larue2013@yahoo.com ','1177 Par Drive,Burbank, California(CA)',11)

insert into department(DID,dname,EID) values(1,'ALLERGY',1);
insert into department(DID,dname,EID) values(2,'INTENSIVE CARE',2);
insert into department(DID,dname,EID) values(3,'ANESTHESIOLOGY',3);
insert into department(DID,dname,EID) values(4,'CARDIOLOGY',4);
insert into department(DID,dname,EID) values(5,'ENT',5);
insert into department(DID,dname,EID) values(6,'NEUROLOGY',6);
insert into department(DID,dname,EID) values(7,'ORTHOPEDICS',7);
insert into department(DID,dname,EID) values(8,'PATHOLOGY',8);
insert into department(DID,dname,EID) values(9,'RADIOLOGY',9);
insert into department(DID,dname,EID) values(10,'SURGERY',10);
insert into department(DID,dname,EID) values(11,'NURSE',18);
insert into department(DID,dname,EID) values(12,'secretary',11);
insert into department(DID,dname,EID) values(13,'engineer',14);
insert into department(DID,dname,EID) values(14,'technician',16);

insert into doctor (EID,qualification) values(8,'ALLERGY')
insert into doctor (EID,qualification) values(5,'NEUROLOGY')
insert into doctor (EID,qualification) values(2,'INTENSIVE CARE')
insert into doctor (EID,qualification) values(3,'PATHOLOGY')
insert into doctor (EID,qualification) values(4,'RADIOLOGY')
insert into doctor (EID,qualification) values(7,'ORTHOPEDICS')
insert into doctor (EID,qualification) values(1,'ANESTHESIOLOGY')
insert into doctor (EID,qualification) values(9,'CARDIOLOGY')
insert into doctor (EID,qualification) values(6,'PATHOLOGY')
insert into doctor (EID,qualification) values(10,'CARDIOLOGY')


INSERT INTO patient(PID,pname,gender,bloodtype,birthdate,email,phone,address,disease,DEID,SEID)VALUES(1,'Donald K Henderson','male','O+','11/14/1973','bernadette_kilba@gmail.com','781-649-9493','4011 Single Street,Reading, Massachusetts(MA)','Diabetes',5,19)
INSERT INTO patient(PID,pname,gender,bloodtype,birthdate,email,phone,address,disease,DEID,SEID)VALUES(2,'Mildred D Rush','female','A-','7/29/1992','kendra2017@hotmail.com','810-499-2129','1251 Tennessee Avenue,Southfield, Michigan(MI)','Depression',6,18)
INSERT INTO patient(PID,pname,gender,bloodtype,birthdate,email,phone,address,disease,DEID,SEID)VALUES(3,'Stanley S Humphrey','male','O+','2/17/2001' ,'casimir2007@yahoo.com','806-703-1746','533 Smithfield Avenue,Amarillo, Texas(TX),','Anxiety',1,23)
INSERT INTO patient(PID,pname,gender,bloodtype,birthdate,email,phone,address,disease,DEID,SEID)VALUES(4,'Earl T McNeely','male','A+','11/15/1972','eugenia.kemm@hotmail.com','410-815-5792','2838 Pine Tree Lane,Beltsville, Maryland(MD)','Hemorrhoid',3,24)
INSERT INTO patient(PID,pname,gender,bloodtype,birthdate,email,phone,address,disease,DEID,SEID)VALUES(5,'Charles K Hair','male','O+','4/1/1967','brady1976@gmail.com','678-200-2081','2593 Flint Street,Atlanta, Georgia(GA)','Lupus',4,25)
INSERT INTO patient(PID,pname,gender,bloodtype,birthdate,email,phone,address,disease,DEID,SEID)VALUES(6,'Emilia F Root','female','A+','7/23/1978','damion2005@gmail.com','610-305-3724','2338 Saint James Drive,Mount Joy (Lancaster), Pennsylvania(PA))','Yeast infection',7,22)
INSERT INTO patient(PID,pname,gender,bloodtype,birthdate,email,phone,address,disease,DEID,SEID)VALUES(7,'Latoya D Parrish','female','A-','10/16/1969' ,'cordie1983@hotmail.com','701-610-1027','4911 Findley Avenue,Halliday, North Dakota(ND)','Lupus',8,27)
INSERT INTO patient(PID,pname,gender,bloodtype,birthdate,email,phone,address,disease,DEID,SEID)VALUES(8,'Howard A Cannon','male','AB-','2/13/1980','georgiana.croo@hotmail.com','781-649-9493','1358 Austin Avenue,Savannah, Georgia(GA)','Shingles',2,26)
INSERT INTO patient(PID,pname,gender,bloodtype,birthdate,email,phone,address,disease,DEID,SEID)VALUES(9,'Vernon K Stephens','male','b-','12/25/1986','brett.spink1@yahoo.com','801-514-9189','1202 Kemper Lane,Salt Lake City, Utah(UT)','Schizophrenia',9,20)
INSERT INTO patient(PID,pname,gender,bloodtype,birthdate,email,phone,address,disease,DEID,SEID)VALUES(10,'Antonio A Keen','male','b+','8/10/1996','ali1992@hotmail.com','704-957-6029','4587 Holly Street,Charlotte, North Carolina(NC)','Hemorrhoid',10,21)


insert into nurse(EID,numberofpatient) values(24,25)
insert into nurse(EID,numberofpatient) values(25,6) 
insert into nurse(EID,numberofpatient) values(15,1) 
insert into nurse(EID,numberofpatient) values(14,26)
insert into nurse(EID,numberofpatient) values(20,22)
insert into nurse(EID,numberofpatient) values(11,1)
insert into nurse(EID,numberofpatient) values(27,11)
insert into nurse(EID,numberofpatient) values(16,24)
insert into nurse(EID,numberofpatient) values(28,8)
insert into nurse(EID,numberofpatient) values(12,40)
insert into nurse(EID,numberofpatient) values(13,25)
insert into nurse(EID,numberofpatient) values(17,24)
insert into nurse(EID,numberofpatient) values(21,8)
insert into nurse(EID,numberofpatient) values(22,21)
insert into nurse(EID,numberofpatient) values(26,15)
insert into nurse(EID,numberofpatient) values(23,31)
insert into nurse(EID,numberofpatient) values(18,28)
insert into nurse(EID,numberofpatient) values(19,36)


INSERT INTO treatment VALUES(1,'CROCINE',10,4);
INSERT INTO treatment VALUES(2,'ASPIRIN',8,4);
INSERT INTO treatment VALUES(3,'NAMOSLATE',8,8);
INSERT INTO treatment VALUES(4,'GLUCOSE',200,3);
INSERT INTO treatment VALUES(5,'TARIVID',80,7);
INSERT INTO treatment VALUES(6,'CANESTEN',12,4);
INSERT INTO treatment VALUES(7,'DICLOFENAC',18,5);
INSERT INTO treatment VALUES(8,'ANTACIDS',8,9);
INSERT INTO treatment VALUES(9,'VERMOX',40,1);
INSERT INTO treatment VALUES(10,'OVEX',25,4);
INSERT INTO treatment VALUES(11,'OMEE',35,3);
INSERT INTO treatment VALUES(12,'AVIL',4,1);
INSERT INTO treatment VALUES(13,'HIDRASEC',50,5);
INSERT INTO treatment VALUES(14,'UTINOR',80,6);
INSERT INTO treatment VALUES(15,'PARIET',8,9);
INSERT INTO treatment VALUES(16,'CIPROXIN',6,7);
INSERT INTO treatment VALUES(17,'CYPROSTAT',12,8);
INSERT INTO treatment VALUES(18,'ANDROCUR',80,1);
INSERT INTO treatment VALUES(19,'DESTOLIT',82,7);
INSERT INTO treatment VALUES(20,'URSOFALK',15,3);
INSERT INTO treatment VALUES(21,'ORS',7,7);
INSERT INTO treatment VALUES(22,'URSOGAL',20,5);
INSERT INTO treatment VALUES(23,'OMNI GEL',30,7);
INSERT INTO treatment VALUES(24,'DETTOL',45,9);
INSERT INTO treatment VALUES(25,'BETADINE',8,2);
INSERT INTO treatment VALUES(26,'LIVER-52',100,1);
INSERT INTO treatment VALUES(27,'METHYLPHENIDATE',12,6);
INSERT INTO treatment VALUES(28,'BETA-BLOCKER',90,7);
INSERT INTO treatment VALUES(29,'BENZODIAZEPINES',120,2);
INSERT INTO treatment VALUES(30,'Z-DRUG',150,3);
INSERT INTO treatment VALUES(31,'ANTIPSYCHOTIC',200,7);
INSERT INTO treatment VALUES(32,'SSRI-ANTIDEPRESSANT',250,5);
INSERT INTO treatment VALUES(33,'MAOI-DRUG',140,4);
INSERT INTO treatment VALUES(34,'BICASUL',1,1);
INSERT INTO treatment VALUES(35,'NASAL DECONGESTANTS',20,1);
INSERT INTO treatment VALUES(36,'EXPECTORANTS',10,6);
INSERT INTO treatment VALUES(37,'COUGH SUPRESSANTS',60,4);
INSERT INTO treatment VALUES(38,'ANTI HISTAMINES',40,9);
INSERT INTO treatment VALUES(39,'ACETAMINOPHEN',60,7);
INSERT INTO treatment VALUES(40,'HPV VACCINE',140,1);
INSERT INTO treatment VALUES(41,'SYRINGE',3,1);
INSERT INTO treatment VALUES(42,'INJECTION',10,5);
INSERT INTO treatment VALUES(43,'MORFIN',5,7);
INSERT INTO treatment VALUES(44,'ORLISTAT',10,7);
INSERT INTO treatment VALUES(45,'ZALASTA',85,1);
INSERT INTO treatment VALUES(46,'ZANTAC',84,2);
INSERT INTO treatment VALUES(47,'ZEFFIX',82,3);
INSERT INTO treatment VALUES(48,'ZINNAT',100,2);
INSERT INTO treatment VALUES(49,'ZOFRAN',80,8);
INSERT INTO treatment VALUES(50,'ZOCOR',18,1);


INSERT INTO Medicaltest(MTID,mtname,mtcost,PID) VALUES(1,'X-RAY',100,1);
INSERT INTO Medicaltest(MTID,mtname,mtcost,PID) VALUES(2,'BLOOD TEST',300,3);
INSERT INTO Medicaltest(MTID,mtname,mtcost,PID) VALUES(3,'URINE TEST',100,7);
INSERT INTO Medicaltest(MTID,mtname,mtcost,PID) VALUES(4,'MRI SCAN',1200,8);
INSERT INTO Medicaltest(MTID,mtname,mtcost,PID) VALUES(5,'ENDOSCOPY',3000,9);
INSERT INTO Medicaltest(MTID,mtname,mtcost,PID) VALUES(6,'BIOPSY',3500,1);
INSERT INTO Medicaltest(MTID,mtname,mtcost,PID) VALUES(7,'ULTRASOUND',900,5);
INSERT INTO Medicaltest(MTID,mtname,mtcost,PID) VALUES(8,'CT-SCAN',1100,7);
INSERT INTO Medicaltest(MTID,mtname,mtcost,PID) VALUES(9,'CBC',350,8);
INSERT INTO Medicaltest(MTID,mtname,mtcost,PID) VALUES(10,'FLU TEST',1500,4);



INSERT INTO room(RID,rname,rtype,rcost,PID) VALUES(1,'1012','Normal',1240,1);
INSERT INTO room(RID,rname,rtype,rcost,PID) VALUES(2,'1013','Normal',1480,3);
INSERT INTO room(RID,rname,rtype,rcost,PID) VALUES(3,'1015','vip',1784,7);
INSERT INTO room(RID,rname,rtype,rcost,PID) VALUES(4,'1020','vip',1772,8);
INSERT INTO room(RID,rname,rtype,rcost,PID) VALUES(5,'1026','vip',682,9);
INSERT INTO room(RID,rname,rtype,rcost,PID) VALUES(6,'1023','Normal',1354,1);
INSERT INTO room(RID,rname,rtype,rcost,PID) VALUES(7,'1019','vip',1290,5);
INSERT INTO room(RID,rname,rtype,rcost,PID) VALUES(8,'1014','Normal',995,7);
INSERT INTO room(RID,rname,rtype,rcost,PID) VALUES(9,'1017','vip',602,8);
INSERT INTO room(RID,rname,rtype,rcost,PID) VALUES(10,'1030','Normal',1317,4);




INSERT INTO bill(BID,mtcost,rcost,tcost,billdate,billcost,PID) VALUES(1,1200,1480,200,'2021-01-05',1200+1400+200,3);
INSERT INTO bill(BID,mtcost,rcost,tcost,billdate,billcost,PID) VALUES(2,100,1784,80,'2021-02-20',100+1784+80,7);
INSERT INTO bill(BID,mtcost,rcost,tcost,billdate,billcost,PID) VALUES(3,1500,1354,45,'2021-07-07',1500+1354+45,8);
INSERT INTO bill(BID,mtcost,rcost,tcost,billdate,billcost,PID) VALUES(4,300,1772,6,'2021-03-15',300+1772+6,9);
INSERT INTO bill(BID,mtcost,rcost,tcost,billdate,billcost,PID) VALUES(5,3000,1317,3,'2021-12-10',3000+1317+3,1);
INSERT INTO bill(BID,mtcost,rcost,tcost,billdate,billcost,PID) VALUES(6,350,1290,4,'2021-01-11',350+1290+4,5);
INSERT INTO bill(BID,mtcost,rcost,tcost,billdate,billcost,PID) VALUES(7,300,602,7,'2021-9-17',300+600+7,7);
INSERT INTO bill(BID,mtcost,rcost,tcost,billdate,billcost,PID) VALUES(8,1500,995,1,'2021-09-30',1500+995+1,8);
INSERT INTO bill(BID,mtcost,rcost,tcost,billdate,billcost,PID) VALUES(9,900,1480,150,'2021-01-13',900+1480+150,4);
INSERT INTO bill(BID,mtcost,rcost,tcost,billdate,billcost,PID) VALUES(10,300,602,90,'2021-11-13',300+602+90,9);

 CREATE PROCEDURE all_data_for_all_table
AS
SELECT * FROM employee
SELECT * FROM department
SELECT * FROM patient
SELECT * FROM doctor
SELECT * FROM nurse
SELECT * FROM bill
SELECT * FROM medicaltest
SELECT * FROM treatment
SELECT * FROM room
GO;
exec all_data_for_all_table

/* show name of employee with specific department id*/
select fname,lname, type,DID from employee where DID in(5,11,3,24)


/* show name of employee end with specific pattern in name */
select fname,EID from employee where fname like '%y'

/*showing counting of employee in each department*/
select count(EID) as number_of_employees_in_department,DID from employee group by DID


/*showing counting of employee in department name='NEUROLOGY'*/
select e.fname,e.lname from employee e inner join department d on e.DID=d.DID 
where d.dname='NEUROLOGY'


/* select employee_id when birthdate=' 5/14/1988 ' and salary=4490*/
select EID,fname from employee where birthdate='5/14/1988' and Salary= 4490

/* showing sum of cost of all type room*/ 
select sum(rcost) as cost_type_value ,rtype from room r group by r.rtype


/* get billcost and data for who has booldtype ='o+'*/
select b.billcost,b.billdate from bill b inner join patient p  on p.PID=b.PID
where p.bloodtype='o+'

/*show  number of patient for each doctor */
select count(PID) as numberpatient from patient  group by(DEID)


/*showing doctor name for each patient*/
select (e.fname+e.mname+e.lname)as doctor_name ,p.pname as patient_name from employee e inner join patient p  on p.DEID=e.EID


/*showing nurse name for each patient*/
select (e.fname+e.mname+e.lname)as nusre_name ,p.pname as patient_name from employee e inner join patient p  on p.SEID=e.EID


 /* show all data for patient with  doctor even if doctor hasn’t patient*/
select PID,pname ,(e.fname+e.mname+e.lname)as doctor_name from patient p full outer join doctor d on d.EID=p.DEID
 inner join  employee e on d.EID=e.EID

 /* show  name of test for each patient*/
 select p.pname,m.mtname from patient p left  join Medicaltest m on m.PID=p.PID


 /* show  name treatment for each patient*/
 select p.pname,t.tname from patient p left join  treatment t on t.PID=p.pID


 /* showing all data  for patient order by name*/
 select * from patient order by pname

  /* showing  sum  of salaries in each type*/
 select sum(e.salary) as sum_of_salaries ,type from  employee e group by e.type


  /* showing max of salaries in each type*/
 select max(e.salary) as max_of_salaries ,e.type from  employee e group by e.type


 /* showing  max salary in doctors */
 select (e.fname+e.mname+e.lname)as doctor_name , e.salary from employee e where e.salary in (select  max(e.salary) as max_salaries_for_doctor from employee e group by e.type) and e.type='doctor'

  /* showing  max salary in nurse */
 select (e.fname+e.mname+e.lname)as nurse_name , e.salary from employee e where e.salary in (select  max(e.salary) as max_salaries_for_nurse from employee e group by e.type) and e.type='nurse'


 /*show billcost that above avager of bill cost*/

CREATE VIEW patient_costs AS
SELECT PID,billcost
FROM bill
WHERE billcost > (SELECT AVG(billcost) FROM bill );
 
 select * from patient_costs







