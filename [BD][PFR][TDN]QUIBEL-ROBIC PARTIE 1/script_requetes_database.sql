use agence_escapade;

##V Final ok 1

#####requetes#####

#1. Liste des clients (par numéro de client)
select * from client;
select idClient from client;

#2. Saisie d'un nouveau client
insert into client (nom, prenom, telephone, email) values ("Robic","Gaetan","0622541","");

#3. Liste des voitures, de leur position et de leur disponibilité
select * from voiture; #liste voitures
select * from voiture join stationnement where voiture.idVoiture = stationnement.idVoiture;#liste position
select * from voiture join location where voiture.idVoiture = location.idVoiture order by idLocation;#liste dispo

select * from stationnement;
#4. Sélection d'une voiture disponible dans un arrondissement
select * from voiture where voiture.idVoiture =
(select idVoiture from stationnement where
stationnement.idParking = (select parking.idParking from parking where parking.arrondissement_parking = 8)) limit 1;

#5. Requête de mise à jour de la place de parking d'un véhicule identifié par son immatriculation
update stationnement set stationnement.idParking = 8 where 
stationnement.idVoiture = (select idVoiture from voiture where voiture.idVoiture = 2);

update stationnement set stationnement.numPlace = 'A2' where 
stationnement.idVoiture = (select idVoiture from voiture where voiture.idVoiture = 2);

#6. Combien d'opérations de maintenance sur une voiture identifiée par son immatriculation
select count(*) from maintenance where maintenance.idVoiture = (select voiture.idVoiture from voiture where voiture.immat = '75AZ92');

#7. Enregistrement du retour d'une voiture
delete from location where location.idVoiture = (select voiture.idVoiture from voiture where voiture.immat = '75AZ92');
insert into stationnement (idParking, idVoiture, numPlace) values ( '8',(select voiture.idVoiture from voiture where voiture.immat = '90AA66'),'A9');

#8. Nombre de voitures contrôlées par chacun des contrôleurs
select idControlleur, count(idControlleur) from maintenance group by idControlleur;

#9. Liste des voitures indisponible et du motif correspondant
select * from voiture where voiture.idVoiture in (select location.idVoiture from location) or
 voiture.idVoiture in (select maintenance.idVoiture from maintenance);

#10. Enregistrement d'une opération de maintenance par un des contrôleurs sur une voiture identifiée par son immatriculation
INSERT INTO `maintenance` (idVoiture,`idControlleur`,`date`,`type_maintenance`) 
VALUES ((select voiture.idVoiture from voiture where voiture.immat = '11FG42'),
(select controlleur.idControlleur from controlleur where controlleur.idControlleur = 1),'2018-02-02','Revision');

select * from stationnement;