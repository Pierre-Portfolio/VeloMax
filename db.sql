/*CREATE SCHEMA `velomax` ;
SET FOREIGN_KEY_CHECKS=0;*/
DROP TABLE IF EXISTS assemblage;
CREATE TABLE assemblage(nom VARCHAR(255) NOT NULL,grandeur varchar(255) NOT NULL, cadre varchar(255), guidon varchar(255), freins varchar(255), selle varchar(255), derailleuravant varchar(255), derailleurarriere varchar(255), roueavant varchar(255), rouearriere varchar(255), reflecteur varchar(255), pedalleur varchar(255), ordinateur varchar(255), panier varchar(255));
DROP TABLE IF EXISTS bicyclette;
CREATE TABLE bicyclette (idbicy  INT NOT NULL, nom varchar(255), grandeur varchar(255), prixbicy float, ligneproduit varchar(255), dateintrobicy datetime, datediscontinuationbicy datetime); 
DROP TABLE IF EXISTS itemstock;
CREATE TABLE itemstock (iditemstock INT PRIMARY KEY NOT NULL AUTO_INCREMENT, idbicy int, numpiece VARCHAR(255));
DROP TABLE IF EXISTS piecedetache;
CREATE TABLE piecedetache (numpiece varchar(255)  NOT NULL, descpiece varchar(255), numprodcatalogue int, prixpiece float, dateintroprod datetime, datediscontprod datetime, delaiapprovprod int, siret varchar(255));
DROP TABLE IF EXISTS fournisseur;
CREATE TABLE fournisseur (siret varchar(255) NOT NULL, nomentreprise varchar(255), contact varchar(255), adrfour varchar(255), libellefourniseur text);
DROP TABLE IF EXISTS itemcmd;
CREATE TABLE itemcmd (iditemscmd INT PRIMARY KEY NOT NULL AUTO_INCREMENT, quantite int, iditemstock int, numcommande int);
DROP TABLE IF EXISTS commande;
CREATE TABLE commande (numcommande INT PRIMARY KEY NOT NULL AUTO_INCREMENT, datecommande datetime, adrlivraison varchar(255), datelivraison datetime, idclient int);
DROP TABLE IF EXISTS clientele;
CREATE TABLE clientele (idclient INT PRIMARY KEY NOT NULL AUTO_INCREMENT, rueclient varchar(255), codepostaleclient int, provinceclient varchar(255), villeclient varchar(255)); 
DROP TABLE IF EXISTS entreprise;
CREATE TABLE entreprise (identre  INT PRIMARY KEY NOT NULL AUTO_INCREMENT, nomentre varchar(255), remiseentre float, idclient int);
DROP TABLE IF EXISTS particulier;
CREATE TABLE particulier (idparticulier INT PRIMARY KEY NOT NULL AUTO_INCREMENT, nomclient varchar(255), prenomclient varchar(255), idclient int, idfidelio int);
DROP TABLE IF EXISTS fidelio;
CREATE TABLE fidelio (idfidelio INT PRIMARY KEY NOT NULL AUTO_INCREMENT , descfidelio varchar(255), cout int, duree int, rabais int); 

ALTER TABLE assemblage ADD CONSTRAINT PK_assemblage PRIMARY KEY (nom,grandeur );
ALTER TABLE bicyclette ADD CONSTRAINT PK_bicyclette PRIMARY KEY (idbicy);
ALTER TABLE piecedetache ADD CONSTRAINT PK_piecedetache PRIMARY KEY (numpiece);  
ALTER TABLE fournisseur ADD CONSTRAINT PK_fournisseur PRIMARY KEY (siret);  
ALTER TABLE bicyclette ADD CONSTRAINT FK_bicyclette_nomassemblage FOREIGN KEY (nom,grandeur) REFERENCES assemblage (nom,grandeur);  
ALTER TABLE itemstock ADD CONSTRAINT FK_itemstock_idbicy FOREIGN KEY (idbicy) REFERENCES bicyclette (idbicy) ON DELETE CASCADE;  
ALTER TABLE itemstock ADD CONSTRAINT FK_itemstock_numpiece FOREIGN KEY (numpiece) REFERENCES piecedetache (numpiece) ON DELETE CASCADE;  
ALTER TABLE piecedetache ADD CONSTRAINT FK_piecedetache_siret FOREIGN KEY (siret) REFERENCES fournisseur (siret) ON DELETE CASCADE;  
ALTER TABLE itemcmd ADD CONSTRAINT FK_itemcmd_iditemstock FOREIGN KEY (iditemstock) REFERENCES itemstock (iditemstock) ON DELETE CASCADE;  
ALTER TABLE itemcmd ADD CONSTRAINT FK_itemcmd_numcommande FOREIGN KEY (numcommande) REFERENCES commande (numcommande) ON DELETE CASCADE;  
ALTER TABLE commande ADD CONSTRAINT FK_commande_idclient FOREIGN KEY (idclient) REFERENCES clientele (idclient) ON DELETE CASCADE;  
ALTER TABLE entreprise ADD CONSTRAINT FK_entreprise_idclient FOREIGN KEY (idclient) REFERENCES clientele (idclient) ON DELETE CASCADE; 
ALTER TABLE particulier ADD CONSTRAINT FK_particulier_idclient FOREIGN KEY (idclient) REFERENCES clientele (idclient) ON DELETE CASCADE;  
ALTER TABLE particulier ADD CONSTRAINT FK_particulier_idfidelio FOREIGN KEY (idfidelio) REFERENCES fidelio (idfidelio) ON DELETE CASCADE;

INSERT INTO fournisseur (siret,nomentreprise,contact,adrfour,libellefourniseur)
 VALUES
(123456789124834,'Babel',"Babel@gmail.com",'12 rue du general','fournisseur de guidon'),
(837038217323928,'Sony',"Sony@gmail.com",'18 impasse du concombre','fournisseur de selle'),
(082136183927173,'Nintendo',"Nintendo@gmail.com",'78 rue du la bouteille','fournisseur de pedale'),
(523456789124834,'Real',"Real@gmail.com",'24 rue du lion','fournisseur de panier'),
(237038217323927,'Kroos',"Kroos@gmail.com",'18 impasse du concombre','fournisseur d ordinateur'),
(837038217323865,'Javel',"Javel@gmail.com",'17 impasse du concombre','fournisseur d ordinateur');

INSERT INTO piecedetache (numpiece,descpiece,numprodcatalogue,prixpiece,dateintroprod,datediscontprod,delaiapprovprod,siret)
 VALUES
('C32','Cadre','1',12,'2010-04-02 15:28:22','2010-04-02 15:28:22',3,123456789124834),
('C34','Cadre','2',11,'2010-04-02 15:28:22','2010-04-02 15:28:22',4,123456789124834),
('C76','Cadre','3',13,'2010-04-02 15:28:22','2010-04-02 15:28:22',2,123456789124834),
('C43','Cadre','4',12,'2010-04-02 15:28:22','2010-04-02 15:28:22',3,123456789124834),
('C43f','Cadre','4',12,'2010-04-02 15:28:22','2010-04-02 15:28:22',3,123456789124834),
('C44f','Cadre','5',11,'2010-04-02 15:28:22','2010-04-02 15:28:22',4,123456789124834),
('C01','Cadre','6',13,'2010-04-02 15:28:22','2010-04-02 15:28:22',2,123456789124834),
('C02','Cadre','7',12,'2010-04-02 15:28:22','2010-04-02 15:28:22',3,123456789124834),
('C15','Cadre','8',11,'2010-04-02 15:28:22','2010-04-02 15:28:22',4,123456789124834),
('C87','Cadre','9',13,'2010-04-02 15:28:22','2010-04-02 15:28:22',2,123456789124834),
('C87f','Cadre','10',12,'2010-04-02 15:28:22','2010-04-02 15:28:22',3,123456789124834),
('C25','Cadre','11',11,'2010-04-02 15:28:22','2010-04-02 15:28:22',4,123456789124834),
('C26','Cadre','12',13,'2010-04-02 15:28:22','2010-04-02 15:28:22',2,123456789124834),

('G7','Guidon','13',12,'2010-04-02 15:28:22','2010-04-02 15:28:22',3,123456789124834),
('G9','Guidon','14',11,'2010-04-02 15:28:22','2010-04-02 15:28:22',4,123456789124834),
('G12','Guidon','15',13,'2010-04-02 15:28:22','2010-04-02 15:28:22',2,123456789124834),

('S88','Selle','16',12,'2010-04-02 15:28:22','2010-04-02 15:28:22',3,123456789124834),
('S37','Selle','17',11,'2010-04-02 15:28:22','2010-04-02 15:28:22',4,123456789124834),
('S35','Selle','18',13,'2010-04-02 15:28:22','2010-04-02 15:28:22',2,123456789124834),
('S02','Selle','19',12,'2010-04-02 15:28:22','2010-04-02 15:28:22',3,123456789124834),
('S03','Selle','20',11,'2010-04-02 15:28:22','2010-04-02 15:28:22',4,123456789124834),
('S36','Selle','21',13,'2010-04-02 15:28:22','2010-04-02 15:28:22',2,123456789124834),
('S34','Selle','22',12,'2010-04-02 15:28:22','2010-04-02 15:28:22',3,123456789124834),
('S87','Selle','23',11,'2010-04-02 15:28:22','2010-04-02 15:28:22',4,123456789124834),

('F3','Frein','24',12,'2010-04-02 15:28:22','2010-04-02 15:28:22',3,123456789124834),
('F9','Frein','25',11,'2010-04-02 15:28:22','2010-04-02 15:28:22',4,123456789124834),

('DV133','Dérailleur avant','26',12,'2010-04-02 15:28:22','2010-04-02 15:28:22',3,123456789124834),
('DV17','Dérailleur avant','27',11,'2010-04-02 15:28:22','2010-04-02 15:28:22',4,123456789124834),
('DV87','Dérailleur avant','28',12,'2010-04-02 15:28:22','2010-04-02 15:28:22',3,123456789124834),
('DV57','Dérailleur avant','29',11,'2010-04-02 15:28:22','2010-04-02 15:28:22',4,123456789124834),
('DV15','Dérailleur avant','30',12,'2010-04-02 15:28:22','2010-04-02 15:28:22',3,123456789124834),
('DV41','Dérailleur avant','31',11,'2010-04-02 15:28:22','2010-04-02 15:28:22',4,123456789124834),
('DV132','Dérailleur avant','32',12,'2010-04-02 15:28:22','2010-04-02 15:28:22',3,123456789124834),

('DR56','Dérailleur arrière','33',12,'2010-04-02 15:28:22','2010-04-02 15:28:22',3,123456789124834),
('DR87','Dérailleur arrière','34',11,'2010-04-02 15:28:22','2010-04-02 15:28:22',4,123456789124834),
('DR86','Dérailleur arrière','35',12,'2010-04-02 15:28:22','2010-04-02 15:28:22',3,123456789124834),
('DR23','Dérailleur arrière','36',11,'2010-04-02 15:28:22','2010-04-02 15:28:22',4,123456789124834),
('DR76','Dérailleur arrière','37',12,'2010-04-02 15:28:22','2010-04-02 15:28:22',3,123456789124834),
('DR52','Dérailleur arrière','38',12,'2010-04-02 15:28:22','2010-04-02 15:28:22',3,123456789124834),

('R45','Roue avant','39',11,'2010-04-02 15:28:22','2010-04-02 15:28:22',4,123456789124834),
('R46','Roue arrière','40',12,'2010-04-02 15:28:22','2010-04-02 15:28:22',3,123456789124834),
('R47','Roue arrière','41',11,'2010-04-02 15:28:22','2010-04-02 15:28:22',4,123456789124834),
('R48','Roue avant','42',12,'2010-04-02 15:28:22','2010-04-02 15:28:22',3,123456789124834),
('R12','Roue','43',12,'2010-04-02 15:28:22','2010-04-02 15:28:22',3,123456789124834),
('R19','Roue avant','44',11,'2010-04-02 15:28:22','2010-04-02 15:28:22',4,123456789124834),
('R1','Roue avant','45',12,'2010-04-02 15:28:22','2010-04-02 15:28:22',3,123456789124834),
('R11','Roue avant','46',11,'2010-04-02 15:28:22','2010-04-02 15:28:22',4,123456789124834),
('R44','Roue avant','47',12,'2010-04-02 15:28:22','2010-04-02 15:28:22',3,123456789124834),
('R32','Roue arrière','48',12,'2010-04-02 15:28:22','2010-04-02 15:28:22',3,123456789124834),
('R18','Roue arrière','49',11,'2010-04-02 15:28:22','2010-04-02 15:28:22',4,123456789124834),
('R2','Roue arrière','50',12,'2010-04-02 15:28:22','2010-04-02 15:28:22',3,123456789124834),

('R02','Réflecteur','52',11,'2010-04-02 15:28:22','2010-04-02 15:28:22',4,123456789124834),
('R09','Réflecteur','53',12,'2010-04-02 15:28:22','2010-04-02 15:28:22',3,123456789124834),
('R10','Réflecteur','54',11,'2010-04-02 15:28:22','2010-04-02 15:28:22',4,123456789124834),

('O2','Ordinateur','55',11,'2010-04-02 15:28:22','2010-04-02 15:28:22',4,123456789124834),
('O4','Ordinateur','56',12,'2010-04-02 15:28:22','2010-04-02 15:28:22',3,123456789124834),

('S01','Panier','57',11,'2010-04-02 15:28:22','2010-04-02 15:28:22',4,123456789124834),
('S05','Panier','58',12,'2010-04-02 15:28:22','2010-04-02 15:28:22',3,123456789124834),
('S74','Panier','59',11,'2010-04-02 15:28:22','2010-04-02 15:28:22',4,123456789124834),
('S73','Panier','60',11,'2010-04-02 15:28:22','2010-04-02 15:28:22',4,123456789124834),


('P12','Pédaleur','61',11,'2010-04-02 15:28:22','2010-04-02 15:28:22',4,123456789124834),
('P34','Pédaleur','62',12,'2010-04-02 15:28:22','2010-04-02 15:28:22',3,123456789124834),
('P1','Pédaleur','63',11,'2010-04-02 15:28:22','2010-04-02 15:28:22',4,123456789124834),
('P15','Pédaleur','64',12,'2010-04-02 15:28:22','2010-04-02 15:28:22',3,123456789124834);


INSERT INTO assemblage (nom, grandeur, cadre, guidon,freins,selle,derailleuravant,derailleurarriere,roueavant,rouearriere,reflecteur,pedalleur,ordinateur,panier)
 VALUES
 ('Kilimandjaro', 'Adultes', 'C32', 'G7','F3','S88','DV133','DR56','R45','R46','','P12','O2',''),
 ('NorthPole', 'Adultes', 'C34', 'G7','F3','S88','DV17','DR87','R48','R47','','P12','',''),
 ('MontBlanc', 'Jeunes', 'C76', 'G7','F3','S88','DV17','DR87','R48','R47','','P12','O2',''),
 ('Hooligan', 'Jeunes', 'C76', 'G7','F3','S88','DV87','DR86','R12','R32','','P12','',''),
 ('Orléans', 'Hommes', 'C43', 'G9','F9','S37','DV57','DR86','R19','R18','R02','P34','',''),
  ('Orléans', 'Dames', 'C44f', 'G9','F9','S35','DV57','DR86','R19','R18','R02','P34','',''),
 ('BlueJay', 'Hommes', 'C43', 'G9','F9','S37','DV57','DR87','R19','R18','R02','P34','O4',''),
 ('BlueJay', 'Dames', 'C43f', 'G9','F9','S35','DV57','DR87','R19','R18','R02','P34','O4',''),
 ('Trail Explorer', 'Filles', 'C01', 'G12','','S02','','','R1','R2','R09','P1','','S01'),
 ('Trail Explorer', 'Garçons', 'C02', 'G12','','S03','','','R1','R2','R09','P1','','S05'),
 ('Night Hawk', 'Jeunes', 'C15', 'G12','F9','S36','DV15','DR23','R11','R12','R10','P15','','S74'),
 ('Tierra Verde', 'Hommes', 'C87', 'G12','F9','S36','DV41','DR76','R11','R12','R10','P15','','S74'),
 ('Tierra Verde', 'Dames', 'C87f', 'G12','F9','S34','DV41','DR76','R11','R12','R10','P15','','S73'),
 ('Mud Zinger I', 'Jeunes', 'C25', 'G7','F3','S87','DV132','DR52','R44','R47','','P15','',''),
 ('Mud Zinger II', 'Adultes', 'C26', 'G7','F3','S87','DV133','DR52','R44','R47','','P12','','');


 INSERT INTO bicyclette (idbicy,nom ,grandeur ,prixbicy ,ligneproduit,dateintrobicy,datediscontinuationbicy)
 VALUES
(101, 'Kilimandjaro', 'Adultes', 569,'VTT','2010-04-02 15:28:22','2010-04-02 15:28:22'),
(102, 'NorthPole', 'Adultes', 329,'VTT','2010-04-02 15:28:22','2010-04-02 15:28:22'),
(103, 'MontBlanc', 'Jeunes', 399,'VTT','2010-04-02 15:28:22','2010-04-02 15:28:22'),
(104, 'Hooligan', 'Jeunes', 199,'VTT','2010-04-02 15:28:22','2010-04-02 15:28:22'),
(105, 'Orléans', 'Hommes', 229,'Vélo de course','2010-04-02 15:28:22','2010-04-02 15:28:22'),
(106, 'Orléans', 'Dames', 229,'Vélo de course','2010-04-02 15:28:22','2010-04-02 15:28:22'),
(107, 'BlueJay', 'Hommes', 349,'Vélo de course','2010-04-02 15:28:22','2010-04-02 15:28:22'),
(108, 'BlueJay', 'Dames', 349,'Vélo de course','2010-04-02 15:28:22','2010-04-02 15:28:22'),
(109, 'Trail Explorer', 'Filles', 129,'Classique','2010-04-02 15:28:22','2010-04-02 15:28:22'),
(110, 'Trail Explorer', 'Garçons', 129,'Classique','2010-04-02 15:28:22','2010-04-02 15:28:22'),
(111, 'Night Hawk', 'Jeunes', 189,'Classique','2010-04-02 15:28:22','2010-04-02 15:28:22'),
(112, 'Tierra Verde', 'Hommes', 199,'Classique','2010-04-02 15:28:22','2010-04-02 15:28:22'),
(113, 'Tierra Verde', 'Dames', 199,'Classique','2010-04-02 15:28:22','2010-04-02 15:28:22'),
(114, 'Mud Zinger I', 'Jeunes', 279,'BMX','2010-04-02 15:28:22','2010-04-02 15:28:22'),
(115, 'Mud Zinger II', 'Adultes', 359,'BMX','2010-04-02 15:28:22','2010-04-02 15:28:22');

 INSERT INTO fidelio (descfidelio ,cout ,duree ,rabais)
 VALUES
('Fidélio', 15, 1,5),
('Fidélio Or', 25, 1,8),
('Fidélio Platine', 60, 1,10),
('Fidélio Max', 100, 1,12);

 INSERT INTO clientele ( rueclient ,codepostaleclient ,provinceclient,villeclient)
 VALUES
('rue de la tour', 75000, 'IDF','Paris'),
('avenue Lafayette', 75000, 'IDF','Paris'),
('impasse des iles', 75000, 'IDF','Paris'),
('rue de la toile', 75000, 'IDF','Paris'),
('avenue rio', 78180, 'IDF','Voisin-le-Bx'),
('impasse de esilv', 75000, 'IDF','Paris'),
('rue de l aubrac', 75000, 'IDF','Paris'),
('avenue jeanne', 59000, 'Nord Pas de Calais','Lille'),
('impasse de esilv', 59000, 'Nord Pas de Calais','Lille'),
('rue de l aubrac', 59000, 'Nord Pas de Calais','Lille');

INSERT INTO particulier (nomclient,prenomclient,idclient,idfidelio)
 VALUES
('Martin', 'Louna', 1,1),
('Martin', 'Pierre', 2,2),
('Tribot', 'Thibault', 3,3),
('ROC', 'Yan', 4,4),
('Ramos', 'Sergio', 5,4);

INSERT INTO entreprise (nomentre,remiseentre,idclient)
 VALUES
('HG', 10,6),
('Riot Game', 2 ,7),
('Facebook',  30,8),
('Twitter',  15,9),
('Plato',  12,10);

INSERT INTO itemstock (idbicy,numpiece)
 VALUES
(null,'C32'),
(null,'C34'),
(null,'C76'),
(null,'P15'),
(null,'P1'),
(null,'S01'),
(null,'S74'),
(null,'DR52'),
(null,'R10'),
(null,'R02'),
(null,'DR52'),
(null,'DR23'),
(null,'F9'),
(null,'G7'),
(null,'G9'),
(null,'S87'),
(null,'S88'),

(101,null),
(102,null),
(103,null),
(104,null),
(105,null),
(106,null),
(107,null),
(108,null),
(109,null),
(110,null),
(111,null),
(112,null),
(113,null),
(114,null),
(115,null);

INSERT INTO commande (datecommande,adrlivraison,datelivraison,idclient)
 VALUES
('2010-04-01 15:28:22','76 rue du machin','2010-04-02 15:28:22',3),
('2010-04-01 15:29:22','73 rue du collab','2010-04-02 15:28:22',1),
('2010-04-01 15:30:22','6 rue du coca','2010-04-02 15:28:22',5),
('2010-04-01 15:31:22','14 rue du pepsi','2010-04-02 15:28:22',8),
('2010-04-01 15:32:22','26 rue du but','2010-04-02 15:28:22',7);


INSERT INTO itemcmd (quantite,iditemstock,numcommande)
 VALUES
(1,1,1),
(1,2,2),
(1,3,2),
(1,4,3);