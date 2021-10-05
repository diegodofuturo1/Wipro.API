DROP DATABASE IF EXISTS `wipro.database`;
CREATE DATABASE IF NOT EXISTS `wipro.database`;
USE `wipro.database`;

CREATE TABLE customer (
	id varchar(36),
    `name` varchar(50),
    email varchar(30),
    phone varchar(20),
    cpf varchar(14),
    `status` varchar(10) default 'activated',
    
    CONSTRAINT PRIMARY KEY(id),
    CONSTRAINT UNIQUE(email),
    CONSTRAINT UNIQUE(phone),
    CONSTRAINT UNIQUE(cpf)
);

CREATE TABLE `locator` (
	id varchar(36),
    `name` varchar(50),
    email varchar(30),
    phone varchar(20),
    cpf varchar(14),
    `status` varchar(10) default 'activated',
    
    CONSTRAINT PRIMARY KEY(id),
    CONSTRAINT UNIQUE(email),
    CONSTRAINT UNIQUE(phone),
    CONSTRAINT UNIQUE(cpf)
);

CREATE TABLE movie (
	id varchar(36),
    `name` varchar(50),
    gender varchar(20),
    releaseDate varchar(10),
    duration varchar(5),
    image varchar(255),
    `status` varchar(10) default 'activated',
    
    CONSTRAINT PRIMARY KEY(id),
    CONSTRAINT UNIQUE(`name`)
);

CREATE TABLE dvd (
	id varchar(36),
	price varchar(10),
	movieId varchar(36),
    `status` varchar(10) default 'activated',
    
    CONSTRAINT PRIMARY KEY(id),
    CONSTRAINT FOREIGN KEY(movieId) REFERENCES movie(id)
);

CREATE TABLE rent (
	id varchar(36),
	dvdId varchar(36),
	customerId varchar(36),
	locatorId varchar(36),
    rentDate varchar(10),
    returnDate varchar(10) DEFAULT '',
    `status` varchar(10) default 'activated',
    
    CONSTRAINT PRIMARY KEY(id),
    CONSTRAINT FOREIGN KEY(dvdId) REFERENCES dvd(id),
    CONSTRAINT FOREIGN KEY(customerId) REFERENCES customer(id),
    CONSTRAINT FOREIGN KEY(locatorId) REFERENCES `locator`(id)
);

INSERT INTO customer (id, `name`, email, phone, cpf) VALUES ("1", "Diego Heleno", "diego.heleno@email.com", "+55(11)99119-8744", "406.685.198-35");
INSERT INTO customer (id, `name`, email, phone, cpf) VALUES ("2", "Sarah Novais", "sarah.novais@email.com", "+55(11)98347-3940", "485.039.283-22");

INSERT INTO `locator` (id, `name`, email, phone, cpf) VALUES ("1", "Ana", "ana@email.com", "+55(11)93849-3499", "384.934.388-22");
INSERT INTO `locator` (id, `name`, email, phone, cpf) VALUES ("2", "Beto", "beto@email.com", "+55(11)95845-9999", "182.344.993-27");

INSERT INTO movie (id, `name`, gender, releaseDate, duration, image) VALUES ("1", "Harry Potter e a Pedra Filosofal", "Aventura Fantástica", "23/11/2001", "2h32", "https://static.wikia.nocookie.net/harrypotter/images/9/96/Capa_Harry_Potter_e_a_C%C3%A2mara_Secreta_%28filme%29.jpg/revision/latest?cb=20130101153346&path-prefix=pt-br");
INSERT INTO movie (id, `name`, gender, releaseDate, duration, image) VALUES ("2", "Harry Potter e a Camera Secreta", "Aventura Fantástica", "22/11/2002", "2h41", "https://br.web.img3.acsta.net/medias/nmedia/18/95/59/60/20417256.jpg");

INSERT INTO dvd (id, price, movieId) VALUES ("1", "30.00", "1");
INSERT INTO dvd (id, price, movieId) VALUES ("2", "30.00", "1");
INSERT INTO dvd (id, price, movieId) VALUES ("3", "30.00", "2");
INSERT INTO dvd (id, price, movieId) VALUES ("4", "30.00", "2");
INSERT INTO dvd (id, price, movieId) VALUES ("5", "30.00", "2");

INSERT INTO rent (id, dvdId, customerId, locatorId, rentDate, returnDate) VALUES ("1", "1", "1", "1", "29/09/2021", "01/10/2021");
INSERT INTO rent (id, dvdId, customerId, locatorId, rentDate) VALUES ("2", "2", "2", "2", "29/09/2021");
