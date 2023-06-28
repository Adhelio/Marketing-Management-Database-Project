-- ANGGOTA KELOMPOK 4

-- ADHELIO REYHANDRO (00000059870)
-- ARYA JAYAVARDHANA (00000060218)
-- AURA LINTANG PEMBAYUN PINASTI AJI (00000061031)
-- GABRIEL BUFFON HARAHAP (00000061688)
-- LEONARDO (00000060177)
-- SULTAN ADYATMA RANGGA SETIAWAN (00000061918)
-- VINKA BELLA (00000061043)

CREATE DATABASE Lif
GO

USE Lif
GO

CREATE TABLE [Employee] (
  [LifID] CHAR(8),
  [Name] VARCHAR(50),
  [Email] VARCHAR(50),
  [Birthdate] DATE,
  [Position] VARCHAR(50),
  [Department] VARCHAR(50),
  PRIMARY KEY ([LifID])
);

CREATE TABLE [Company] (
  [ComID] CHAR(8),
  [CompanyName] VARCHAR(50),
  [EmployeeAmount] INT,
  [Email] VARCHAR(30),
  [Phone] VARCHAR(20),
  PRIMARY KEY ([ComID])
);

CREATE TABLE [Project] (
  [ProjectID] CHAR(8),
  [ComID] CHAR(8),
  [LifID] CHAR(8),
  [ProjectName] VARCHAR(50),
  [Description] VARCHAR (MAX),
  [Status] VARCHAR (10),
  PRIMARY KEY ([ProjectID]),
  FOREIGN KEY ([ComID]) REFERENCES Company,
  FOREIGN KEY ([LifID]) REFERENCES Employee
);


CREATE TABLE [CompanyDetail] (
  [ComDetID] CHAR(8),
  [ComID] CHAR(8),
  [Address] TEXT,
  [City] VARCHAR(50),
  [PostCode] VARCHAR(50),
  [Description] TEXT,
  PRIMARY KEY ([ComDetID]),
  FOREIGN KEY ([ComID]) REFERENCES Company
);

CREATE TABLE [CompanyEmployee] (
  [ComEmpID] CHAR(8),
  [ComDetID] CHAR(8),
  [Name] VARCHAR(50),
  [Email] VARCHAR(50),
  [Phone] VARCHAR(20),
  [Birthdate] DATE,
  [Height] Decimal(18,1),
  [Weight] Decimal(18,1),
  PRIMARY KEY ([ComEmpID]),
  FOREIGN KEY ([ComDetID]) REFERENCES CompanyDetail
);

CREATE TABLE [Proposal] (
  [ProposalID] CHAR(8),
  [ProjectID] CHAR(8),
  [ProposalDate] DATETIME,
  [ProposalFile] VARBINARY(MAX),
  [Path] VarChar(50),
  [Alias] VarChar(20),
  [FileName] VarChar(100),
  [Extension] CHAR(7),
  [Description] VARCHAR (MAX),
  PRIMARY KEY ([ProposalID]),
  FOREIGN KEY ([ProjectID]) REFERENCES Project
);

CREATE TABLE [Meeting] (
  [MeetingID] CHAR(8),
  [ProjectID] CHAR(8),
  [MeetingDate] DATETIME,
  [Link] VARCHAR(MAX),
  [Description] VARCHAR (MAX),
  PRIMARY KEY ([MeetingID]),
  FOREIGN KEY ([ProjectID]) REFERENCES Project
);

CREATE TABLE [MoM] (
  [MomID] CHAR(8),
  [MeetingID] CHAR(8),
  [MomDate] DATETIME,
  [MomFile] VARBINARY(MAX),
  [Path] VarChar(50),
  [Alias] VarChar(20),
  [FileName] VarChar(100),
  [Extension] CHAR(7),
  [Description] VARCHAR(MAX),
  PRIMARY KEY ([MomID]),
  FOREIGN KEY ([MeetingID]) REFERENCES Meeting
);

CREATE TABLE [EmployeeProfile] (
  [LifProfileID] CHAR(8),
  [LifID] CHAR(8),
  [Username] VARCHAR(15),
  [Password] VARCHAR(10),
  PRIMARY KEY ([LifProfileID]),
  FOREIGN KEY ([LifID]) REFERENCES Employee
);

CREATE TABLE [Transaction] (
  [TransactionID] CHAR(8),
  [ProjectID] CHAR(8),
  [StartDate] DATETIME,
  [DueDate] DATETIME,
  [AgreedPrice] MONEY,
  [Status] VARCHAR(20),
  PRIMARY KEY ([TransactionID]),
  FOREIGN KEY ([ProjectID]) REFERENCES Project
);

CREATE TABLE [Payment] (
  [PaymentID] CHAR(8),
  [TransactionID] CHAR(8),
  [PaymentMethod] VARCHAR(20),
  [AmountPaid] MONEY,
  [PaymentDate] DATETIME,
  [PaymentProof] VARBINARY(MAX),
  [Path] VarChar(50),
  [Alias] VarChar(20),
  [FileName] VarChar(100),
  [Extension] CHAR(7),
  PRIMARY KEY ([PaymentID]),
  FOREIGN KEY ([TransactionID]) REFERENCES [Transaction]
);

--INSERT DATA EMPLOYEE
INSERT INTO Employee VALUES ('LF001','Rendy Puja','rendy.puja@lif.id','23-July-1994','Marketing Director','Marketing');
INSERT INTO Employee VALUES ('LF002','Sumanto','sumanto@lif.id','03-March-1972','Project Manager','Marketing');
INSERT INTO Employee VALUES ('LF003','Griffin Reno','grifren@lif.id','17-November-1989','Account Manager','Marketing');
INSERT INTO Employee VALUES ('LF004','Yonathan Wibowo','yonathan.wibowo@lif.id','24-March-1989','Engagement Manager','Marketing');
INSERT INTO Employee VALUES ('LF005','Edellyn Cantika','edell.cantika@lif.id','20-June-1997','Engagement Manager','Marketing');
INSERT INTO Employee VALUES ('LF006','Aris Hermawan','aris.hrmwn@lif.id','01-October-1993','Project manager','Marketing');
INSERT INTO Employee VALUES ('LF007','Hasan Thamrin','Hasanthamrin@lif.id','23-July-1994','Marketing Director','Marketing');
INSERT INTO Employee VALUES ('LF008','Erfan Jaya','Erfanjaya@lif.id','03-March-1972','Engagement Manager','Marketing');
INSERT INTO Employee VALUES ('LF009','Yohana','Yohana@lif.id','17-November-1989','Project manager','Marketing');

-- INSERT DATA COMPANY
INSERT INTO Company VALUES('CO001', 'KlikDokter', '10', 'iklan@klikdokter.com', '02139507373');
INSERT INTO Company VALUES('CO002', 'PT Kalbe Farma', '15', 'Corp.Comm@kalbe.co.id', '0214287388889');
INSERT INTO Company VALUES('CO003', 'PT Tani Hub Indonesia', '13', 'help@tanihub.com', '0811877451');

--INSERT DATA PROJECT
INSERT INTO Project VALUES('PR001', 'CO001', 'LF001', 'CuanProject', 'Proyek pertama', 'Success');
INSERT INTO Project VALUES('PR002', 'CO002', 'LF006', 'GrindingProject', 'Proyek kedua', 'Success');
INSERT INTO Project VALUES('PR003', 'CO003', 'LF007', 'OleriProject', 'Proyek ketiga', 'Success');

--INSERT DATA COMPANY DETAIL--
INSERT INTO CompanyDetail VALUES('CD001', 'CO001', 'Jl. BSD Grand Boulevard, BSD City My Republic Plaza Green Office Park 6 3rd Floor, PT. Medika Komunika Teknologi, Klikdokter Wing B, Zone 7a, 7c & 8, Kec. Cisauk, Kabupaten Tangerang, Banten 15345', 'Tangerang', '15345', 'Company yang bergerak dibidang kesehatan');
INSERT INTO CompanyDetail VALUES('CD002', 'CO002', 'Jl. Let. Jend Suprapto Kav 4 Jakarta 10510 - Indonesia', 'Jakarta', '10510', 'Company yang bergerak dibidang farmasi');
INSERT INTO CompanyDetail VALUES('CD003', 'CO003', 'Jl. Prof. Dr. Satrio, No. 164, Karet Semanggi, Kec. Setiabudi. Jakarta Selatan', 'Jakarta Selatan', '12930', 'Company yang bergerak dibidang Agrikultur');

-- CompanyEmployee table
INSERT INTO CompanyEmployee Values ('CE001','CD001','Filemon Siregay', 'siregay4@gmail.com','087743678437','16-AUG-1990','173','60')
INSERT INTO CompanyEmployee Values ('CE002','CD001','Gay Crimson', 'crim02@gmail.com','081310210370','17-OCT-1970','167','60')
INSERT INTO CompanyEmployee Values ('CE003','CD001','Arya Tejawijaya', 'arya1946@gmail.com','088812218901','28-FEB-1989','174','70')
INSERT INTO CompanyEmployee Values ('CE004','CD001','Jonathan Hartono', 'jo.hartono@gmail.com','081576892044','10-MAR-1992','180','72')
INSERT INTO CompanyEmployee Values ('CE005','CD001','Kevin Nathanael', 'kevinatha@gmail.com','081384925540','28-OCT-1989','178','69')
INSERT INTO CompanyEmployee Values ('CE006','CD001','Edo Fernando', 'edoferdi@gmail.com','088514227467','16-SEP-1989','168','69')
INSERT INTO CompanyEmployee Values ('CE007','CD001','Desy Nathalia', 'descon@yahoo.com','089744387670','22-DEC-1995','162','50')
INSERT INTO CompanyEmployee Values ('CE008','CD001','Nielsen Anderson', 'nielsen19@gmail.com','082271979094','19-APR-1975','172','74')
INSERT INTO CompanyEmployee Values ('CE009','CD001','Bethany', 'bethyrembau@yahoo.com','081399230121','15-DEC-1993','162','52')
INSERT INTO CompanyEmployee Values ('CE010','CD001','Hazael Khoe', 'hazazel66@gmail.com','087264408947','08-JUL-1998','169','58')
INSERT INTO CompanyEmployee Values ('CE011','CD002','Jovan Nathan', 'jovan056@gmail.com','089752940079','16-OCT-1995','174','80')
INSERT INTO CompanyEmployee Values ('CE012','CD002','Justine Widjaja', 'widjaja31@gmail.com','088115582890','25-DEC-1980','165','70')
INSERT INTO CompanyEmployee Values ('CE013','CD002','Nathalia Kostan', 'nathal.57@gmail.com','087775907436','27-JAN-1991','174','60')
INSERT INTO CompanyEmployee Values ('CE014','CD002','Michelle Margareta', 'michellert@gmail.com','087741704596','21-JUL-1990','164','57')
INSERT INTO CompanyEmployee Values ('CE015','CD002','Indra Thamrin', 'indra83@gmail.com','087745516551','01-AUG-1995','170','68')
INSERT INTO CompanyEmployee Values ('CE016','CD002','Samuel', 'sam911@gmail.com','085291808374','24-MAR-1987','178','79')
INSERT INTO CompanyEmployee Values ('CE017','CD002','Angelica', 'angelica.21@gmail.com','088411189826','09-MAR-1992','162','56')
INSERT INTO CompanyEmployee Values ('CE018','CD002','Severin Lukita', 'lukitasev88@gmail.com','088795939544','17-NOV-1983','180','79')
INSERT INTO CompanyEmployee Values ('CE019','CD002','Richardo Hartoyo', 'richard632@gmail.com','081281848764','10-JUL-1992','176','80')
INSERT INTO CompanyEmployee Values ('CE020','CD002','Jean Claudia', 'jeanclaud2@gmail.com','082833337155','02-JUN-1997','160','51')
INSERT INTO CompanyEmployee Values ('CE021','CD002','Jetfen Lim', 'jetfens88@gmail.com','089212848966','16-OCT-1992','170','62')
INSERT INTO CompanyEmployee Values ('CE022','CD002','Josephine', 'jose3431@gmail.com','081640562845','07-SEP-1997','170','70')
INSERT INTO CompanyEmployee Values ('CE023','CD002','Yosafat Christian', 'yosafatchris3@gmail.com','083985731582','05-MAY-1994','171','68')
INSERT INTO CompanyEmployee Values ('CE024','CD002','Nicholas Bertand', 'nich213@gmail.com','081274473557','29-SEP-1989','172','70')
INSERT INTO CompanyEmployee Values ('CE025','CD002','Fransiska Febrianti', 'siska.feb@gmail.com','083514986931','02-FEB-1998','163','53')
INSERT INTO CompanyEmployee Values ('CE026','CD003','Aaron Christian', 'ascwy04@gmail.com','083095893142','24-AUG-1998','178','70')
INSERT INTO CompanyEmployee Values ('CE027','CD003','Rinda Dewi', 'rindadewi17@gmail.com','085456100343','26-OCT-1970','163','60')
INSERT INTO CompanyEmployee Values ('CE028','CD003','Serena', 'serena341@gmail.com','083862243850','30-JAN-1989','179','72')
INSERT INTO CompanyEmployee Values ('CE029','CD003','Stanley Joseph', 'stanjo88@gmail.com','082596240477','07-MAR-1992','181','72')
INSERT INTO CompanyEmployee Values ('CE030','CD003','Anthonius Prima', 'antonprim21@gmail.com','083947650253','08-OCT-1989','175','71')
INSERT INTO CompanyEmployee Values ('CE031','CD003','Muhammad Rizki', 'muhriz341@gmail.com','086083793237','18-OCT-1998','175','80')
INSERT INTO CompanyEmployee Values ('CE032','CD003','Fay Beatrice', 'beatrice984@gmail.com','088966970715','30-DEC-1995','171','70')
INSERT INTO CompanyEmployee Values ('CE033','CD003','Felix Gunawan', 'felix586@gmail.com','087790222751','02-APR-1975','182','76')
INSERT INTO CompanyEmployee Values ('CE034','CD003','Patrico Revanski', 'revanskuy@gmail.com','081695578603','30-DEC-1993','190','84')
INSERT INTO CompanyEmployee Values ('CE035','CD003','Yohen Joneri', 'yohen79@gmail.com','089126473322','26-JUL-1998','170','60')
INSERT INTO CompanyEmployee Values ('CE036','CD003','Jennifer', 'jennifer034@gmail.com','083825258191','12-NOV-1998','162','55')
INSERT INTO CompanyEmployee Values ('CE037','CD003','Marcellino wijaya', 'marcell592@gmail.com','083243895573','19-JAN-1999','184','77')
INSERT INTO CompanyEmployee Values ('CE038','CD003','Adrian Novalino', 'adrinov33@gmail.com','089318159366','10-SEP-1998','186','84')

--INSERT DATA PROPOSAL
INSERT INTO Proposal VALUES('PP001', 'PR001', '15-July-2020', (SELECT * FROM OPENROWSET(BULK N'C:\Proposal\Proposal01.PDF', SINGLE_BLOB) AS Proposal01),'C:\Proposal\Proposal01.PDF', 'Proposal01', 'Proposal01.PDF', '.PDF', 'Berisikan informasi kesepakatan dengan client berupa target employee, harga jasa, lama waktu pemakaian jasa, penetapan harga jasa, dan reward yang diberikan jika employee menuntaskan target');
INSERT INTO Proposal VALUES('PP002', 'PR002', '30-September-2020', (SELECT * FROM OPENROWSET(BULK N'C:\Proposal\Proposal02.PDF', SINGLE_BLOB) AS Proposal02),'C:\Proposal\Proposal02.PDF', 'Proposal02', 'Proposal02.PDF', '.PDF', 'Berisikan informasi kesepakatan dengan client berupa target employee, harga jasa, lama waktu pemakaian jasa, penetapan harga jasa, dan reward yang diberikan jika employee menuntaskan target');
INSERT INTO Proposal VALUES('PP003', 'PR003', '15-July-2020', (SELECT * FROM OPENROWSET(BULK N'C:\Proposal\Proposal03.PDF', SINGLE_BLOB) AS Proposal03),'C:\Proposal\Proposal03.PDF', 'Proposal03', 'Proposal03.PDF', '.PDF', 'Berisikan informasi kesepakatan dengan client berupa target employee, harga jasa, lama waktu pemakaian jasa, penetapan harga jasa, dan reward yang diberikan jika employee menuntaskan target');

--INSERT DATA MEETING
INSERT INTO Meeting VALUES ('ME001','PR001','20-May-2020','https://zoom.us/j/97207547654?pwd=bzBKNjVtaENpVGc0S1FSUTVydFVwZz09','Membahas projek yang akan dilaksanakan');
INSERT INTO Meeting VALUES ('ME002','PR001','30-June-2020','https://zoom.us/j/97002080144?pwd=MWlyWVFRRUh0K1ZwYkd4QTdMV0JHUT09','Menetapkan projek');
INSERT INTO Meeting VALUES ('ME003','PR001','10-July-2020','https://zoom.us/j/99856477729?pwd=N1hXVDNNNnl5L3pDdWZVb0VGc0tVQT09','Membahas kesepakatan dengan client');
INSERT INTO Meeting VALUES ('ME004','PR002','10-August-2020','https://zoom.us/j/94140477493?pwd=TVV4T3VOSG90MzFCVEc5U0VZbnNFZz09','Membahas projek yang akan dilaksanakan');
INSERT INTO Meeting VALUES ('ME005','PR002','20-August-2020','https://zoom.us/j/96907636115?pwd=Ym5ndXdVcWxzaW9Bc2FtUzVqbjNTQT09','Menetapkan projek');
INSERT INTO Meeting VALUES ('ME006','PR002','15-September-2020','https://zoom.us/j/96313310243?pwd=QVg1MUtGRkVyQ2UrQjVGZFRvdmMyZz09','Membahas kesepakatan dengan client');
INSERT INTO Meeting VALUES ('ME007','PR003','01-November-2020','https://zoom.us/j/97207547654?pwd=bzBKNjVtaENpVGc0S1FSUTVydFVwZz09','Membahas projek yang akan dilaksanakan');
INSERT INTO Meeting VALUES ('ME008','PR003','21-November-2020','https://zoom.us/j/97002080144?pwd=MWlyWVFRRUh0K1ZwYkd4QTdMV0JHUT09','Menetapkan projek');
INSERT INTO Meeting VALUES ('ME009','PR003','04-December-2020','https://zoom.us/j/99856477729?pwd=N1hXVDNNNnl5L3pDdWZVb0VGc0tVQT09','Membahas kesepakatan dengan client');

--INSERT DATA MOM
INSERT INTO MoM VALUES ('MO1001','ME001','20-May-2020',(SELECT * FROM OPENROWSET(BULK N'C:\Mom\MomKd01.txt', SINGLE_BLOB) AS MomKd01), 'C:\Mom\MomKd01.txt', 'MomKd01', 'MomKd01.txt', '.txt', 'Membahas projek yang akan dilaksanakan dengan atasan mengenai target employee, budget jasa, dan tanggal pelaksanaan');
INSERT INTO MoM VALUES ('MO1002','ME002','30-June-2020',(SELECT * FROM OPENROWSET(BULK N'C:\Mom\MomKd02.txt', SINGLE_BLOB) AS MomKd02), 'C:\Mom\MomKd02.txt', 'MomKd02', 'MomKd02.txt', '.txt', 'Menetapkan projek setelah mendapatkan feedback dari atasan dan mulai merancang pertemuan dengan client');
INSERT INTO MoM VALUES ('MO1003','ME003','10-July-2020',(SELECT * FROM OPENROWSET(BULK N'C:\Mom\MomKd03.txt', SINGLE_BLOB) AS MomKd03), 'C:\Mom\MomKd03.txt', 'MomKd03', 'MomKd03.txt', '.txt', 'Membahas dan menetapkan kesepakatan dengan client mengenai jasa yang akan diberikan');
INSERT INTO MoM VALUES ('MO1004','ME004','10-August-2020',(SELECT * FROM OPENROWSET(BULK N'C:\Mom\MomKb01.txt', SINGLE_BLOB) AS MomKb01), 'C:\Mom\MomKb01.txt', 'MomKb01', 'MomKb01.txt', '.txt', 'Membahas projek yang akan dilaksanakan dengan atasan mengenai target employee, budget jasa, dan tanggal pelaksanaan');
INSERT INTO MoM VALUES ('MO1005','ME005','20-August-2020',(SELECT * FROM OPENROWSET(BULK N'C:\Mom\MomKb02.txt', SINGLE_BLOB) AS MomKb02), 'C:\Mom\MomKb02.txt', 'MomKb02', 'MomKb02.txt', '.txt', 'Menetapkan projek setelah mendapatkan feedback dari atasan dan mulai merancang pertemuan dengan client');
INSERT INTO MoM VALUES ('MO1006','ME006','15-September-2020',(SELECT * FROM OPENROWSET(BULK N'C:\Mom\MomKb03.txt', SINGLE_BLOB) AS MomKb03), 'C:\Mom\MomKb03.txt', 'MomKb03', 'MomKb03.txt', '.txt', 'Membahas dan menetapkan kesepakatan dengan client mengenai jasa yang akan diberikan');
INSERT INTO MoM VALUES ('MO1007','ME007','01-November-2020',(SELECT * FROM OPENROWSET(BULK N'C:\Mom\MomTH01.txt', SINGLE_BLOB) AS MomTH01), 'C:\Mom\MomTH01.txt', 'MomTH01', 'MomTH01.txt', '.txt', 'Membahas projek yang akan dilaksanakan dengan atasan mengenai target employee, budget jasa, dan tanggal pelaksanaan');
INSERT INTO MoM VALUES ('MO1008','ME008','21-November-2020',(SELECT * FROM OPENROWSET(BULK N'C:\Mom\MomTH02.txt', SINGLE_BLOB) AS MomTH02), 'C:\Mom\MomTH02.txt', 'MomTH02', 'MomTH02.txt', '.txt', 'Menetapkan projek setelah mendapatkan feedback dari atasan dan mulai merancang pertemuan dengan client');
INSERT INTO MoM VALUES ('MO1009','ME009','04-December-2020',(SELECT * FROM OPENROWSET(BULK N'C:\Mom\MomTH03.txt', SINGLE_BLOB) AS MomTH03), 'C:\Mom\MomTH03.txt', 'MomTH03', 'MomTH03.txt', '.txt', 'Membahas dan menetapkan kesepakatan dengan client mengenai jasa yang akan diberikan');

--INSERT DATA EMPLOYEEPROFILE
INSERT INTO EmployeeProfile VALUES ('LP001','LF001','rendypuja','user001');
INSERT INTO EmployeeProfile VALUES ('LP002','LF002','Sumanto','user002');
INSERT INTO EmployeeProfile VALUES ('LP003','LF003','Griffin Reno','user003');
INSERT INTO EmployeeProfile VALUES ('LP004','LF004','Yonathan','user004');
INSERT INTO EmployeeProfile VALUES ('LP005','LF005','Edellyn','user005');
INSERT INTO EmployeeProfile VALUES ('LP006','LF006','Aris','user006');
INSERT INTO EmployeeProfile VALUES ('LP007','LF007','Hasan','user007');
INSERT INTO EmployeeProfile VALUES ('LP008','LF008','Erfan','user008');
INSERT INTO EmployeeProfile VALUES ('LP009','LF009','yohana','user009');

 --INSERT TRANSACTION
INSERT INTO [Transaction] VALUES('BY001', 'PR001', '01-JUN-2020', '01-AUG-2020', '25000000', 'Paid');
INSERT INTO [Transaction] VALUES('BY002', 'PR002', '21-AUG-2020', '15-OCT-2020', '37500000', 'Paid');
INSERT INTO [Transaction] VALUES('BY003', 'PR003', '6-DEC-2020', '03-JAN-2021', '32500000', 'Paid');

--INSERT DATA PAYMENT--------------------
INSERT INTO Payment VALUES('PY001', 'BY001', 'Credit', '25000000', '12-JUL-2020', (SELECT * FROM OPENROWSET(BULK N'C:\bukti\bukti01.JPG', SINGLE_BLOB) AS bukti01), 'C:\bukti\bukti01.JPG', 'bukti01', 'bukti01.JPG', '.JPG');
INSERT INTO Payment VALUES('PY002', 'BY002', 'Credit', '37500000', '19-SEP-2020', (SELECT * FROM OPENROWSET(BULK N'C:\bukti\bukti02.JPG', SINGLE_BLOB) AS bukti02), 'C:\bukti\bukti02.JPG', 'bukti02', 'bukti02.JPG', '.JPG');
INSERT INTO Payment VALUES('PY003', 'BY003', 'Credit', '32500000', '09-DEC-2022', (SELECT * FROM OPENROWSET(BULK N'C:\bukti\bukti03.JPG', SINGLE_BLOB) AS bukti03), 'C:\bukti\bukti03.JPG', 'bukti03', 'bukti03.JPG', '.JPG');


SELECT a.ProjectID, a.ComID, a.LifID, a.ProjectName, b.MeetingID, a.Description, Status 
FROM Project a JOIN Meeting b
ON a.ProjectiD = b.ProjectID

SELECT a.ProjectID, a.ComID, a.LifID, a.ProjectName, COUNT(b.MeetingID) as TotalMeetings, a.Description, Status -- UDAH BENER
FROM Project a JOIN Meeting b
ON a.ProjectiD = b.ProjectID
GROUP BY  a.ProjectID, a.ComID, a.LifID, a.ProjectName, a.Description, Status 


SELECT a.ProjectID, a.ComID, a.LifID, a.ProjectName, COUNT(b.MeetingID) as TotalMeetings, COUNT(c.MomID) AS TotalMoMs, d.ProposalID, a.Description, Status -- no company
FROM Project a JOIN Meeting b
ON b.ProjectiD = a.ProjectID
JOIN MoM c ON b.MeetingID = c.MeetingID
JOIN Proposal d ON d.ProjectID =  a.ProjectID
GROUP BY  a.ProjectID, a.ComID, a.LifID, a.ProjectName, a.Description, Status, ProposalID

SELECT a.ProjectID, a.ComID, a.LifID, a.ProjectName, COUNT(b.MeetingID) as TotalMeetings, COUNT(c.MomID) AS TotalMoMs, d.ProposalID, a.Description, Status -- with company
FROM Project a JOIN Meeting b
ON b.ProjectiD = a.ProjectID
JOIN MoM c ON b.MeetingID = c.MeetingID
JOIN Proposal d ON d.ProjectID =  a.ProjectID
GROUP BY  a.ProjectID, a.ComID, a.LifID, a.ProjectName, a.Description, Status, ProposalID

SELECT a.ProjectID, a.ComID, a.LifID, a.ProjectName, COUNT(b.MeetingID) as TotalMeetings, COUNT(c.MomID) AS TotalMoMs, d.ProposalID, a.Description, Status 
FROM Project a JOIN Meeting b
ON b.ProjectiD = a.ProjectID
JOIN MoM c ON b.MeetingID = c.MeetingID
JOIN Proposal d ON d.ProjectID =  a.ProjectID
WHERE a.ProjectID = 'PR001'
GROUP BY  a.ProjectID, a.ComID, a.LifID, a.ProjectName, a.Description, Status, ProposalID

SELECT * FROM EmployeeProfile WHERE Username = 'rendypuja' AND Password = 'user001'
SELECT a.ComID, CompanyName, EmployeeAmount, Email, Phone FROM project a JOIN Company b ON a.ComID = b.ComID WHERE ProjectID = 'PR002'

SELECT * FROM Company
SELECT * FROM Project
SELECT * FROM Meeting
SELECT * FROM MoM
SELECT * FROM Proposal

DROP TABLE MoM;
DROP TABLE Proposal;
DROP TABLE [Project];
DROP TABLE MEETING;

USE MASTER
DROP DATABASE Lif
