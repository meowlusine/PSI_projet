DROP DATABASE IF EXISTS LivInParis;
CREATE DATABASE IF NOT EXISTS LivInParis;
USE LivInParis;


DROP TABLE IF EXISTS utilisateur;
CREATE TABLE utilisateur (
id_utilisateur INT PRIMARY KEY AUTO_INCREMENT,
nom VARCHAR(50),
prenom VARCHAR(50),
email VARCHAR(50) UNIQUE NOT NULL,
mot_de_passe VARCHAR(50) NOT NULL,
telephone VARCHAR(50),
numero_de_rue INT,
rue VARCHAR(50),
code_postal INT,
ville VARCHAR(50),
metro VARCHAR(50)
);


DROP TABLE IF EXISTS cuisinier;
CREATE TABLE cuisinier(
id_cuisinier INT PRIMARY KEY AUTO_INCREMENT,
id_utilisateur INT NOT NULL,
nb_etoile INT,
avis_cuisinier VARCHAR(255),
FOREIGN KEY (id_utilisateur) REFERENCES utilisateur(id_utilisateur) ON DELETE CASCADE
);

DROP TABLE IF EXISTS client;
CREATE TABLE client(
id_client INT PRIMARY KEY AUTO_INCREMENT,
id_utilisateur INT NOT NULL,
type_client ENUM('particulier', 'entreprise'),
FOREIGN KEY (id_utilisateur) REFERENCES utilisateur(id_utilisateur) ON DELETE CASCADE
);

DROP TABLE IF EXISTS entreprise;
CREATE TABLE entreprise (
id_entreprise INT PRIMARY KEY AUTO_INCREMENT,
nom_entreprise VARCHAR(100) NOT NULL,
nom_referent VARCHAR(50),
id_client INT,
FOREIGN KEY (id_client) REFERENCES client(id_client) ON DELETE CASCADE
);

DROP TABLE IF EXISTS recette;
CREATE TABLE recette (
id_recette INT PRIMARY KEY AUTO_INCREMENT,
nom_recette VARCHAR(50) NOT NULL,
description_recette TEXT,
date_creation DATETIME,
id_cuisinier INT NOT NULL,
id_recette_origine INT NULL,
FOREIGN KEY (id_cuisinier) REFERENCES cuisinier(id_cuisinier) ON DELETE CASCADE,
FOREIGN KEY (id_recette_origine) REFERENCES recette(id_recette)
);
 
 
DROP TABLE IF EXISTS plat;
CREATE TABLE plat(
id_plat INT PRIMARY KEY AUTO_INCREMENT,
nom_plat VARCHAR (50),
prix DOUBLE,
quantite INT ,
type_plat ENUM('entrée', 'plat', 'dessert'),
date_fabrication DATE,
date_peremption DATE,
regime VARCHAR(50),
origine VARCHAR (50),
description_recette TEXT,
id_cuisinier INT,
photo TINYBLOB,
id_recette INT,
FOREIGN KEY (id_recette) REFERENCES recette(id_recette) ON DELETE CASCADE,
FOREIGN KEY (id_cuisinier) REFERENCES cuisinier(id_cuisinier) ON DELETE CASCADE
);

DROP TABLE IF EXISTS transaction;
CREATE TABLE transaction (
id_transaction INT AUTO_INCREMENT PRIMARY KEY,
montant_total DECIMAL(10,2) NOT NULL,
date_paiement DATETIME,
moyen_paiement ENUM('carte bancaire', 'especes') NOT NULL
);

DROP TABLE IF EXISTS commande;
CREATE TABLE commande (
id_commande INT PRIMARY KEY AUTO_INCREMENT,
id_cuisinier INT ,
id_client INT ,
date_commande DATETIME,
id_plat INT,
FOREIGN KEY (id_plat) REFERENCES plat(id_plat) ON DELETE CASCADE,
FOREIGN KEY (id_cuisinier) REFERENCES cuisinier(id_cuisinier) ON DELETE CASCADE,
FOREIGN KEY (id_client) REFERENCES client(id_client) ON DELETE CASCADE
);

CREATE TABLE livraison (
    id_livraison INT PRIMARY KEY AUTO_INCREMENT,
    id_cuisinier INT NOT NULL,
    date_livraison DATE NOT NULL,
    zone_livraison VARCHAR(100) NOT NULL,
    FOREIGN KEY (id_cuisinier) REFERENCES cuisinier(id_cuisinier) ON DELETE CASCADE
);


DROP TABLE IF EXISTS transaction_commande;
CREATE TABLE transaction_commande (
id_transaction INT,
id_commande INT,
PRIMARY KEY (id_transaction, id_commande),
FOREIGN KEY (id_transaction) REFERENCES transaction(id_transaction) ON DELETE CASCADE,
FOREIGN KEY (id_commande) REFERENCES commande(id_commande) ON DELETE CASCADE
);


CREATE TABLE livraison_commande (
id_livraison INT,
id_commande INT,
PRIMARY KEY (id_livraison, id_commande),
FOREIGN KEY (id_livraison) REFERENCES livraison(id_livraison) ON DELETE CASCADE,
FOREIGN KEY (id_commande) REFERENCES commande(id_commande) ON DELETE CASCADE
);




