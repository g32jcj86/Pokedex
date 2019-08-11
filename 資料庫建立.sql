create database Pokedex
go

use Pokedex
go

create table pokeInfo
(
	id int identity(1,1) not null primary key,
	num varchar(5) not null unique,
	cName nvarchar(40) not null,
	jName nvarchar(40),
	eName varchar(40),
	typeA nvarchar(20),
	typeB nvarchar(20),
	pokeGroup nvarchar(40),
	abilityA nvarchar(40),
	abilityB nvarchar(40),
	hideAbility nvarchar(40),
	h varchar(10),
	w varchar(10),
	gender varchar(50),
	hp varchar(10),
	attack varchar(10),
	defens varchar(10),
	sAttack varchar(10),
	sDefencs varchar(10),
	speed varchar(10),
	describe nvarchar(400),
	creator nvarchar(50)
)


create table pokeInfo_log
(
	id int identity(1,1) not null primary key,
	num varchar(5),
	body nvarchar(500),
	time datetime,
	editor nvarchar(40)
)

create table userInfo
(
	uid int identity(1,1) not null primary key,
	cName nvarchar(40) not null,
	email varchar(40) not null,
	pwd varchar(30) not null
)


create table loginRecord
(
	id int identity(1,1) not null primary key,
	uid varchar(10),
	time datetime
)

create trigger tr_log_pokeInfo on pokeInfo
for insert,delete,update
as
	declare @numD varchar(5)
	declare @numI varchar(5)
	declare @cnameD nvarchar(40)
	declare @cnameI nvarchar(40)
	declare @editor nvarchar(40)
	declare @s nvarchar(400)
	--Update資料
	if exists (select * from inserted) and exists (select * from deleted)
	begin
		select @numD = num ,@cnameD = cname from deleted
		select @numI = num ,@cnameI = cname from inserted
		set @s = '修改編號: ' + @numI +',名字: '+ @cnameI + '的寶可夢資料'
		insert into pokeInfo_log(body,num,editor) values (@s,@numI,@editor)
	end
	--Insert資料
	else if exists (select * from inserted) and not exists (select * from deleted)
	begin
		select @numI = num ,@cnameI = cname,@editor=creator from inserted
		set @s = '新增編號: ' + @numI +',名字: '+ @cnameI + '的寶可夢資料'
		insert into pokeInfo_log(body,num,editor) values (@s,@numI,@editor)
	end
	--Delete資料
	else if not exists (select * from inserted) and exists (select * from deleted)
	begin
		select @numD = num ,@cnameD = cname,@editor=creator from deleted
		set @s = '刪除編號: ' + @numD +',名字: '+ @cnameD + '的寶可夢資料'
		insert into pokeInfo_log(body,num,editor) values (@s,@numD,@editor)
	end
	else
		insert into  pokeInfo_log(body) values ('無資料變更')
go


select * from pokeInfo
select * from pokeInfo_log
select * from userInfo
select * from loginRecord
