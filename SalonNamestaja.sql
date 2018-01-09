Create table TipNamestaja (
	Id int primary key not null,
	Naziv varchar(15),
	Obrisan bit not null default 0
)

Create table Akcija (
	Id int primary key not null,
	OObrisan bit not null default 0,
	DatumPocetka DateTime,
	DatumZavrsetka DateTime,
	Popust float
)

Create table Korisnici(
	Id int primary key not null,
	Obrisan bit not null default 0,
	Ime varchar(15),
	Prezime varchar(15),
	KorisnickoIme varchar(15),
	Lozinka varchar(15),
	TipKorisnika varchar(15)
)

Create table Namestaj(
	Id int not null primary key,
	Naziv varchar(30),
	Sifra varchar(30),
	JedinicnaCena float,
	TipNamestaja int Foreign Key references TipNamestaja(Id),
	Obrisan bit not null default 0,
	KolicinaUMagacinu int,
	AkcijaId int Foreign Key references Akcija(Id),
	CenaSaAkcijom float
)

Create table DodatneUsluge(
	Id int primary key not null,
	Obrisan bit not null default 0,
	Naziv varchar(15),
	Cena float,
	PDV float,
	UkupanIznos float
)

create table Prodaja(
		ID int primary key not null,
		DatumProdaje DateTime,
		BrojRacuna varchar(20),
		Kupac varchar(25),
)

create table NamestajZaProdaju(
	Id int primary key not null,
	NamestajId int Foreign Key references Namestaj(Id),
	ProdajaId int Foreign Key references Prodaja(Id),
)

create table UslugeProdaje(
	Id int primary key not null,
	DodatneUslugaId int Foreign Key references DodatneUsluge(Id),
	ProdajaId int Foreign Key references Prodaja(Id)
)

insert into TipNamestaja values(1,'tip1',0)
insert into Akcija values(0,0,'1.1.2017','1.2.2017',0)
insert into namestaj values(1,'namestaj','n1',100,1,0,10,0,100)
insert into Korisnici values(1,0,'a','a','a','a','Administrator')
insert into Korisnici values(2,0,'a','a','m','m','Prodavac')
insert into DodatneUsluge values(1,0,'prevoz',100,10,110)
insert into Prodaja values(1,'4.1.2018','1234-1324','marko')
insert into NamestajZaProdaju values(1,1,1)
insert into UslugeProdaje values(1,1,1)

delete from Namestaj where id>1
delete from Akcija where id>1
delete from DodatneUsluge where id>1
delete from Korisnici where id>1
delete from NamestajZaProdaju where id>1
delete from Prodaja where id>1
delete from TipNamestaja where id>1
delete from UslugeProdaje where id>1
