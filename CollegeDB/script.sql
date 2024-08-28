use college;

create table student(
    roll_no varchar(16) primary key,
    name varchar(32) not null,
    admission_date date not null,
    branch enum ('CS', 'ENTC', 'IT'),
    percentage double check ( percentage>=0 and percentage<=100 ),
    status enum ('PASS','DROP')
);

create table alumni(
   roll_no varchar(16) primary key,
   name varchar(32) not null,
   graduation_date date default (curdate())
);

insert into student(roll_no, name, admission_date, branch)
values
('2k180001','Dhiraj Om','2018-05-15','CS'),
('2k180002','Tanuja Chopra','2018-05-16','CS'),
('2k180003','Naina Johal','2018-05-20','ENTC'),
('2k180004','Samir Nath','2018-05-25','CS'),
('2k180005','Hari Nagar','2018-06-05','IT'),
('2k180006','Diya Kapur','2018-06-08','IT'),
('2k180007','Rupal Singh','2018-06-18','ENTC'),
('2k180008','Aruna Reddy','2018-06-23','ENTC'),
('2k180009','Binod Ram','2018-06-30','IT'),
('2k180010','Monica Gupta','2018-07-08','ENTC');