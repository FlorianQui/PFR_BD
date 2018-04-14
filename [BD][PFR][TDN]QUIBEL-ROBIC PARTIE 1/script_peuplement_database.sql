use agence_escapade;

#V Final ok 1

##client
INSERT INTO `client` (nom, prenom, telephone,email) VALUES ('Juniot', 'Gerard','0635164875','');
INSERT INTO `client` (nom, prenom, telephone,email) VALUES ('Dupond', 'Pierre','0675864253','');
INSERT INTO `client` (nom, prenom, telephone,email) VALUES ('Kowalski', 'Jacque','0621578965','');
INSERT INTO `client` (nom, prenom, telephone,email) VALUES ('Theo', 'Yves','0614679466','');
INSERT INTO `client` (nom, prenom, telephone,email) VALUES ('Calvez', 'Alexandre','0675210089','');

##voiture
INSERT INTO voiture (immat, marque, modele, type, nb_place) VALUES ('75AZ92','Renault', 'berline','Clio','4');
INSERT INTO voiture (immat, marque, modele, type, nb_place) VALUES ('56AA46','Renault', 'berline','Scenic','4');
INSERT INTO voiture (immat, marque, modele, type, nb_place) VALUES ('90AA46','Citroen', 'berline','C4','4');
INSERT INTO voiture (immat, marque, modele, type, nb_place) VALUES ('11FG62','Toyota', 'cabriolet','GT86','2');
INSERT INTO voiture (immat, marque, modele, type, nb_place) VALUES ('71PO37','Audi', 'cabriolet','A3','2');
INSERT INTO voiture (immat, marque, modele, type, nb_place) VALUES ('75AG92','Renault', 'berline','Clio','4');
INSERT INTO voiture (immat, marque, modele, type, nb_place) VALUES ('56DA46','Renault', 'berline','Scenic','4');
INSERT INTO voiture (immat, marque, modele, type, nb_place) VALUES ('90FA46','Citroen', 'berline','C4','4');
INSERT INTO voiture (immat, marque, modele, type, nb_place) VALUES ('11HG62','Toyota', 'cabriolet','GT86','2');
INSERT INTO voiture (immat, marque, modele, type, nb_place) VALUES ('71HO37','Audi', 'cabriolet','A3','2');
INSERT INTO voiture (immat, marque, modele, type, nb_place) VALUES ('75FH92','Renault', 'berline','Clio','4');
INSERT INTO voiture (immat, marque, modele, type, nb_place) VALUES ('56AA95','Renault', 'berline','Scenic','4');
INSERT INTO voiture (immat, marque, modele, type, nb_place) VALUES ('90AA96','Citroen', 'berline','C4','4');
INSERT INTO voiture (immat, marque, modele, type, nb_place) VALUES ('11FG92','Toyota', 'cabriolet','GT86','2');
INSERT INTO voiture (immat, marque, modele, type, nb_place) VALUES ('71PO97','Audi', 'cabriolet','A3','2');
INSERT INTO voiture (immat, marque, modele, type, nb_place) VALUES ('75AZ82','Renault', 'berline','Clio','4');
INSERT INTO voiture (immat, marque, modele, type, nb_place) VALUES ('56AA86','Renault', 'berline','Scenic','4');
INSERT INTO voiture (immat, marque, modele, type, nb_place) VALUES ('90AA86','Citroen', 'berline','C4','4');
INSERT INTO voiture (immat, marque, modele, type, nb_place) VALUES ('11FG82','Toyota', 'cabriolet','GT86','2');
INSERT INTO voiture (immat, marque, modele, type, nb_place) VALUES ('71PO87','Audi', 'cabriolet','A3','2');
INSERT INTO voiture (immat, marque, modele, type, nb_place) VALUES ('75AZ72','Renault', 'berline','Clio','4');
INSERT INTO voiture (immat, marque, modele, type, nb_place) VALUES ('56AA76','Renault', 'berline','Scenic','4');
INSERT INTO voiture (immat, marque, modele, type, nb_place) VALUES ('90KA76','Citroen', 'berline','C4','4');
INSERT INTO voiture (immat, marque, modele, type, nb_place) VALUES ('11FG72','Toyota', 'cabriolet','GT86','2');
INSERT INTO voiture (immat, marque, modele, type, nb_place) VALUES ('71PO77','Audi', 'cabriolet','A3','2');
INSERT INTO voiture (immat, marque, modele, type, nb_place) VALUES ('75AZ62','Renault', 'berline','Clio','4');
INSERT INTO voiture (immat, marque, modele, type, nb_place) VALUES ('56PA66','Renault', 'berline','Scenic','4');
INSERT INTO voiture (immat, marque, modele, type, nb_place) VALUES ('90AA66','Citroen', 'berline','C4','4');
INSERT INTO voiture (immat, marque, modele, type, nb_place) VALUES ('11GF62','Toyota', 'cabriolet','GT86','2');
INSERT INTO voiture (immat, marque, modele, type, nb_place) VALUES ('71PO67','Audi', 'cabriolet','A3','2');
INSERT INTO voiture (immat, marque, modele, type, nb_place) VALUES ('75AZ52','Renault', 'berline','Clio','4');
INSERT INTO voiture (immat, marque, modele, type, nb_place) VALUES ('56AA56','Renault', 'berline','Scenic','4');
INSERT INTO voiture (immat, marque, modele, type, nb_place) VALUES ('90AP56','Citroen', 'berline','C4','4');
INSERT INTO voiture (immat, marque, modele, type, nb_place) VALUES ('21FG52','Toyota', 'cabriolet','GT86','2');
INSERT INTO voiture (immat, marque, modele, type, nb_place) VALUES ('71PO57','Audi', 'cabriolet','A3','2');
INSERT INTO voiture (immat, marque, modele, type, nb_place) VALUES ('75AZ42','Renault', 'berline','Clio','4');
INSERT INTO voiture (immat, marque, modele, type, nb_place) VALUES ('66PA46','Renault', 'berline','Scenic','4');
INSERT INTO voiture (immat, marque, modele, type, nb_place) VALUES ('90CA46','Citroen', 'berline','C4','4');
INSERT INTO voiture (immat, marque, modele, type, nb_place) VALUES ('11FG42','Toyota', 'cabriolet','GT86','2');
INSERT INTO voiture (immat, marque, modele, type, nb_place) VALUES ('71PO47','Audi', 'cabriolet','A3','2');


##parking
insert into parking (nom, adresse,arrondissement_parking) values ("Parking Rivoli","2 Rue Boucher", '1');
insert into parking (nom, adresse,arrondissement_parking) values ("Parking Rivoli","2 Rue Boucher", '2');
insert into parking (nom, adresse,arrondissement_parking) values ("Parking Beaubourg","31 Rue Beaubourg", '3');
insert into parking (nom, adresse,arrondissement_parking) values ("Parking Lobau","4 rue Lobau", '4');
insert into parking (nom, adresse,arrondissement_parking) values ("Parling Soufflot","22 Rue Soufflot", '5');
insert into parking (nom, adresse,arrondissement_parking) values ("Parking Jardin des plantes","25 Rue Geoffroy-Saint-Hilaire", '6');
insert into parking (nom, adresse,arrondissement_parking) values ("Parking Maubourg","45 Quai d'Orsay ", '7');
insert into parking (nom, adresse,arrondissement_parking) values ("Parking Champs-Elysées","77 Avenue Marceau ", '8');
insert into parking (nom, adresse,arrondissement_parking) values ("Parking Pigalle","10 rue jean-baptiste Pigalle ", '9');
insert into parking (nom, adresse,arrondissement_parking) values ("Parking Lariboisière","1 bis Rue Ambroise Paré", '10');
insert into parking (nom, adresse,arrondissement_parking) values ("Parking Oberkampf","11 Rue Ternaux", '11');
insert into parking (nom, adresse,arrondissement_parking) values ("Parking Gare de Lyon","6 rue de Rambouillet ", '12');
insert into parking (nom, adresse,arrondissement_parking) values ("Parking Italie","25 rue Stephen Pichon ", '13');
insert into parking (nom, adresse,arrondissement_parking) values ("Parking Raspail","120 Boulevard du Montparnasse", '14');
insert into parking (nom, adresse,arrondissement_parking) values ("Parking Beaugrenelle ","5 quai Andre citroen", '15');
insert into parking (nom, adresse,arrondissement_parking) values ("Parking Victor Huho","74 Avenue Victor Hugo", '16');
insert into parking (nom, adresse,arrondissement_parking) values ("Parking Ternes","38 Avenue des Ternes", '17');
insert into parking (nom, adresse,arrondissement_parking) values ("Parking Stalingrad ","13 rue d'AUbervillier", '18');
insert into parking (nom, adresse,arrondissement_parking) values ("Parking Philharmonie","185 Boulevard Sérurier", '19');
insert into parking (nom, adresse,arrondissement_parking) values ("Parking Rosa Parks","157 boulevard Macdonald", '20');
insert into parking (nom, adresse,arrondissement_parking) values ("Parking Orly","Orly Airport", '94310');
insert into parking (nom, adresse,arrondissement_parking) values ("Parking Roissy","Roissy Airport", '95700');

##location
INSERT INTO location (idVoiture) VALUES (
(select voiture.idVoiture from voiture where voiture.immat = '71PO47'));
INSERT INTO location (idVoiture) VALUES ( 
(select voiture.idVoiture from voiture where voiture.immat = '11FG42'));
INSERT INTO location (idVoiture) VALUES ( 
(select voiture.idVoiture from voiture where voiture.immat = '90CA46'));
INSERT INTO location (idVoiture) VALUES ( 
(select voiture.idVoiture from voiture where voiture.immat = '66PA46'));
INSERT INTO location (idVoiture) VALUES ( 
(select voiture.idVoiture from voiture where voiture.immat = '11FG62'));
INSERT INTO location (idVoiture) VALUES ( 
(select voiture.idVoiture from voiture where voiture.immat = '56AA46'));
INSERT INTO location (idVoiture) VALUES ( 
(select voiture.idVoiture from voiture where voiture.immat = '71PO37'));
INSERT INTO location (idVoiture) VALUES ( 
(select voiture.idVoiture from voiture where voiture.immat = '75AG92'));
INSERT INTO location (idVoiture) VALUES ( 
(select voiture.idVoiture from voiture where voiture.immat = '56AA95'));
INSERT INTO location (idVoiture) VALUES ( 
(select voiture.idVoiture from voiture where voiture.immat = '90AA96'));
INSERT INTO location (idVoiture) VALUES ( 
(select voiture.idVoiture from voiture where voiture.immat = '11FG92'));
INSERT INTO location (idVoiture) VALUES ( 
(select voiture.idVoiture from voiture where voiture.immat = '90AA86'));

##stationnement
insert into stationnement (idParking, idVoiture, numPlace) values ( '1', '4', 'A0');
insert into stationnement (idParking, idVoiture, numPlace) values ( '12', '5','A0');
insert into stationnement (idParking, idVoiture, numPlace) values ( '19', '3','A0');
insert into stationnement (idParking, idVoiture, numPlace) values ( '4', '1','A0');
insert into stationnement (idParking, idVoiture, numPlace) values ( '8', '2','A0');

##controlleur
INSERT INTO `controlleur` (nom) VALUES ('DaSilva');
INSERT INTO `controlleur` (nom) VALUES ('Bourdon');
INSERT INTO `controlleur` (nom) VALUES ('Castela');

##sejour
INSERT INTO sejour (idClient,`idLocation`,`theme`,`date_debut`,`date_fin`,`arrondissement_sejour`,confirme) VALUES ((select client.idClient from client where client.idClient = 1),(select location.idLocation from location where location.idLocation = 3),' ','2018-02-02','2018-02-02','2',true);
INSERT INTO sejour (idClient,`idLocation`,`theme`,`date_debut`,`date_fin`,`arrondissement_sejour`,confirme) VALUES ((select client.idClient from client where client.idClient = 2),(select location.idLocation from location where location.idLocation = 1),' ','2018-03-17','2018-03-20','8',false);
INSERT INTO sejour (idClient,`idLocation`,`theme`,`date_debut`,`date_fin`,`arrondissement_sejour`,confirme) VALUES ((select client.idClient from client where client.idClient = 3),(select location.idLocation from location where location.idLocation = 2),' ','2018-04-12','2018-04-14','12',true);
INSERT INTO sejour (idClient,`idLocation`,`theme`,`date_debut`,`date_fin`,`arrondissement_sejour`,confirme) VALUES ((select client.idClient from client where client.idClient = 4),(select location.idLocation from location where location.idLocation = 5),' ','2018-04-02','2018-04-04','15',false);

##maintenance
INSERT INTO `maintenance` (idVoiture,`idControlleur`,`date`,`type_maintenance`) VALUES ((select voiture.idVoiture from voiture where voiture.idVoiture = 1),(select controlleur.idControlleur from controlleur where controlleur.idControlleur = 1),'2018-02-02','Revision');
INSERT INTO `maintenance` (idVoiture,`idControlleur`,`date`,`type_maintenance`) VALUES ((select voiture.idVoiture from voiture where voiture.idVoiture =4),(select controlleur.idControlleur from controlleur where controlleur.idControlleur = 2),'2018-02-02','Nettoyage');
INSERT INTO `maintenance` (idVoiture,`idControlleur`,`date`,`type_maintenance`) VALUES ((select voiture.idVoiture from voiture where voiture.idVoiture =2),(select controlleur.idControlleur from controlleur where controlleur.idControlleur = 2),'2018-02-02','Changement des pneus');
INSERT INTO `maintenance` (idVoiture,`idControlleur`,`date`,`type_maintenance`) VALUES ((select voiture.idVoiture from voiture where voiture.idVoiture =1),(select controlleur.idControlleur from controlleur where controlleur.idControlleur = 3),'2018-02-02','Revision');
INSERT INTO `maintenance` (idVoiture,`idControlleur`,`date`,`type_maintenance`) VALUES ((select voiture.idVoiture from voiture where voiture.idVoiture =1),(select controlleur.idControlleur from controlleur where controlleur.idControlleur = 3),'2018-02-02','Revision');


